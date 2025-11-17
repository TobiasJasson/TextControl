using BLL.Servicios;
using DAL.Repository;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Services.MultiIdioma;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UI.LocalWidget
{
    public class ExcelExporter
    {


        private readonly PedidoService _PedidoService;
        private readonly ColorService _ColorService;
        private readonly InsumoRepository _insumoRepo;

        public ExcelExporter()
        {
            _PedidoService = new PedidoService();
            _ColorService = new ColorService();
            _insumoRepo = new InsumoRepository();
        }
        public void ExportarStock(DataGridView grid)
        {
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            var colores = _ColorService.ObtenerTodosLosColores();

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Listado Stock");

                int startRow = 2;
                int startCol = 2;

                string[] encabezados = new[]
                {
                    "TipoInsumo", "Nombre", "Color",
                    "StockActual", "StockMinimo",
                    "UltimaSalida", "PrecioUnitario"
                };

                for (int c = 0; c < encabezados.Length; c++)
                {
                    var cell = ws.Cells[startRow, startCol + c];
                    cell.Value = LanguageManager.Traducir(encabezados[c]);
                    cell.Style.Font.Bold = true;
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 230, 230));
                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                }

                int currentRow = startRow + 1;

                foreach (DataGridViewRow dgvRow in grid.Rows)
                {
                    if (dgvRow.IsNewRow) continue;

                    int? stockActual = TryInt(dgvRow.Cells["StockActual"]?.Value);
                    int? stockMinimo = TryInt(dgvRow.Cells["StockMinimo"]?.Value);
                    Color rowColor = ObtenerColorFila(stockActual, stockMinimo);

                    for (int c = 0; c < encabezados.Length; c++)
                    {
                        string colName = encabezados[c];
                        var cell = ws.Cells[currentRow, startCol + c];

                        object valor = dgvRow.Cells[colName]?.Value;

                        if (colName == "Color" && valor != null)
                        {
                            int idColor = Convert.ToInt32(valor);
                            var colorModel = colores.Find(x => x.ID_Color == idColor);
                            valor = colorModel?.Descripcion ?? "";
                        }

                        if (colName == "PrecioUnitario" && valor != null)
                        {
                            if (double.TryParse(valor.ToString(), out double precio))
                                valor = precio;
                        }

                        if (colName == "UltimaSalida" && valor != null && DateTime.TryParse(valor.ToString(), out DateTime fecha))
                        {
                            valor = fecha.ToString("dd/MM/yyyy");
                        }

                        cell.Value = valor;

                        if (colName == "PrecioUnitario")
                        {
                            cell.Style.Numberformat.Format = "\"$\" #,##0.00";
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }

                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(rowColor);

                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    currentRow++;
                }

                ws.Cells[startRow, startCol, currentRow - 1, startCol + encabezados.Length - 1].AutoFilter = true;
                ws.Cells[ws.Dimension.Address].AutoFitColumns(0);

                using (var sfd = new SaveFileDialog()
                {
                    Filter = "Excel Workbook|*.xlsx",
                    Title = "Guardar como Excel",
                    FileName = "Listado Stock.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(sfd.FileName));

                        MessageBox.Show(
                            LanguageManager.Traducir("ExporCorrectamente"),
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
        }
        public void ExportarOrdenPedido(DataGridView grid)
        {
            try
            {
                if (grid.Rows.Count == 0)
                {
                    MessageBox.Show(LanguageManager.Traducir("NoHayDatosExportar") ?? "No hay datos para exportar.",
                        LanguageManager.Traducir("Mensaje_Atencion") ?? "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var pedidos = _PedidoService.ObtenerTodos()
                    .GroupBy(p => p.ID_pedido)
                    .Select(g => g.First())
                    .OrderBy(x => x.ID_pedido)
                    .ToList();

                using (var package = new ExcelPackage())
                {
                    foreach (var pedido in pedidos)
                    {
                        int idPedido = pedido.ID_pedido;

                        string hojaNombre = $"Pedido_{idPedido}";
                        if (hojaNombre.Length > 31) hojaNombre = hojaNombre.Substring(0, 31);

                        var ws = package.Workbook.Worksheets.Add(hojaNombre);

                        int startRow = 2;
                        int startCol = 2; 

                        var detalles = _PedidoService.ObtenerDetallesPorPedido(idPedido);

                        var columnasPrincipales = new Dictionary<string, object>
                        {
                            { "ID pedido", idPedido },
                            { "Fecha Pedido", pedido.FechaPedido.ToString("dd/MM/yyyy") },
                            { "Fecha Entrega", pedido.FechaEntrega_pedido?.ToString("dd/MM/yyyy") ?? "-" },
                            { "Precio Total", pedido.PrecioTotal_pedido },
                            { "Saldo Pendiente", pedido.SaldoPendiente_pedido },
                            { "Pago Adelanto", pedido.pagoAdelanto_pedido ? pedido.TotalPagosAdelantados : 0 },
                            { "Cliente", pedido.Nombre_Cliente },
                            { "Contacto Cliente", pedido.Contacto_Cliente },
                            { "Email Cliente", pedido.Email_Cliente },
                            { "Empleado", $"{pedido.Nombre_Empleado} {pedido.Apellido_Empleado}" },
                            { "Contacto Empleado", pedido.Contacto_Empleado },
                            { "Prioridad", pedido.Prioridad },
                            { "Color", pedido.Color_Detalle },
                            { "Talle", pedido.Detalles_Talles },
                            { "Cantidad", pedido.Cantidad_Detalle },
                            { "Precio Unitario", pedido.Precio_Detalle },
                            { "Tela", _insumoRepo.ObtenerNombrePorIdSiEsTela(pedido.ID_Tela) ?? pedido.ID_Tela.ToString() },
                            { "Estado Pedido", pedido.EstadoPedido },
                        };

                        var columnasDetalle = new Dictionary<string, Func<dynamic, object>>
                        {
                            { "Tipo Personalización", d => d.Personalizacion_Tipo },
                            { "Diseño", d => d.Personalizacion_Diseno },
                            { "Tamaño", d => d.Personalizacion_Tamano },
                            { "Posición", d => d.Personalizacion_Posicion }
                        };

                        var columnasDetalleUsadas = columnasDetalle
                            .Where(colum => detalles.Any(d =>
                            {
                                var val = colum.Value(d);
                                return val != null && val.ToString().Trim() != "";
                            }))
                            .ToList();
                        ws.Cells[1, startCol].Value = $"Pedido Nº {idPedido}";
                        ws.Cells[1, startCol].Style.Font.Bold = true;
                        ws.Cells[1, startCol].Style.Font.Size = 14;

                        ws.Cells[1, startCol + 2].Value = $"Cliente: {pedido.Nombre_Cliente}";
                        ws.Cells[1, startCol + 4].Value = $"Fecha: {pedido.FechaPedido:dd/MM/yyyy}";

                        int col = startCol;

                        foreach (var key in columnasPrincipales.Keys)
                        {
                            var cell = ws.Cells[startRow, col++];
                            cell.Value = key;
                            cell.Style.Font.Bold = true;
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 230, 230));
                            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }

                        foreach (var colDet in columnasDetalleUsadas)
                        {
                            var cell = ws.Cells[startRow, col++];
                            cell.Value = colDet.Key;
                            cell.Style.Font.Bold = true;
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 230, 230));
                            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }

                        int cantidadColumnas = col - startCol;
                        ws.Cells[startRow, startCol, startRow, startCol + cantidadColumnas - 1].AutoFilter = true;

                        int currentRow = startRow + 1;

                        foreach (var det in detalles)
                        {
                            col = startCol;

                            foreach (var kv in columnasPrincipales)
                            {
                                var cell = ws.Cells[currentRow, col];

                                if (kv.Key == "Precio Total" ||
                                    kv.Key == "Saldo Pendiente" ||
                                    kv.Key == "Pago Adelanto")
                                {
                                    cell.Value = Convert.ToDouble(kv.Value);
                                    cell.Style.Numberformat.Format = "\"$\" #,##0.00";
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                }
                                else
                                {
                                    cell.Value = kv.Value;
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                }

                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                col++;
                            }

                            foreach (var colDet in columnasDetalleUsadas)
                            {
                                var val = colDet.Value(det);
                                var cell = ws.Cells[currentRow, col++];

                                if (colDet.Key == "Precio Unitario")
                                    cell.Style.Numberformat.Format = "\"$\" #,##0.00";

                                cell.Value = val;
                                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            currentRow++;
                        }

                        int totalRow = currentRow + 1;

                        ws.Cells[totalRow, startCol].Value = "Total A Pagar:";
                        ws.Cells[totalRow, startCol].Style.Font.Bold = true;

                        double totalAPagar =
                            pedido.PrecioTotal_pedido -
                            (pedido.pagoAdelanto_pedido ? pedido.TotalPagosAdelantados : 0);

                        var totalCell = ws.Cells[totalRow, startCol + 1];
                        totalCell.Value = totalAPagar;
                        totalCell.Style.Numberformat.Format = "\"$\" #,##0.00";
                        totalCell.Style.Font.Bold = true;

                        ws.Cells[ws.Dimension.Address].AutoFitColumns();
                    }

                    using (var sfd = new SaveFileDialog()
                    {
                        Filter = "Excel Workbook|*.xlsx",
                        FileName = "Pedidos.xlsx"
                    })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            package.SaveAs(new FileInfo(sfd.FileName));
                            MessageBox.Show(LanguageManager.Traducir("ExporCorrectamente"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }




        private object GetPropValue(object obj, params string[] names)
        {
            if (obj == null) return null;
            var t = obj.GetType();

            if (obj is System.Collections.IDictionary dict)
            {
                foreach (var name in names)
                {
                    if (dict.Contains(name)) return dict[name];
                }
            }

            foreach (var name in names)
            {
                var prop = t.GetProperty(name);
                if (prop != null) return prop.GetValue(obj);
                var altName = name.Replace("_", "");
                prop = t.GetProperty(altName);
                if (prop != null) return prop.GetValue(obj);
            }

            foreach (var name in names)
            {
                var field = t.GetField(name);
                if (field != null) return field.GetValue(obj);
            }

            return null;
        }

        private string FormatDateValue(object val)
        {
            if (val == null) return "-";
            if (val is DateTime dt) return dt.ToString("dd/MM/yyyy");
            if (val is DateTime?) { var ndt = (DateTime?)val; return ndt.HasValue ? ndt.Value.ToString("dd/MM/yyyy") : "-"; }
            if (DateTime.TryParse(val.ToString(), out DateTime parsed)) return parsed.ToString("dd/MM/yyyy");
            return val.ToString();
        }

        private double ToDoubleSafe(object val)
        {
            if (val == null) return 0;
            if (val is double d) return d;
            if (val is decimal dec) return (double)dec;
            if (val is float f) return (double)f;
            if (double.TryParse(val.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double r)) return r;
            var s = val.ToString().Replace("$", "").Replace(" ", "").Replace(".", "").Replace(",", ".");
            if (double.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double r2)) return r2;
            return 0;
        }

        private static int? TryInt(object val)
        {
            if (val == null) return null;
            if (int.TryParse(val.ToString(), out int n)) return n;
            return null;
        }

        private Color ObtenerColorFila(int? stockActual, int? stockMinimo)
        {
            if (stockActual == null || stockMinimo == null)
                return Color.White;

            int diferencia = stockActual.Value - stockMinimo.Value;

            if (diferencia <= 20)
                return Color.LightCoral;
            else if (diferencia <= 50)
                return Color.Khaki;
            else
                return Color.White;
        }
    }
}