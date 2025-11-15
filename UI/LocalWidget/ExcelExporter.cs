using OfficeOpenXml;
using OfficeOpenXml.Style;
using Services.MultiIdioma;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI.LocalWidget
{
    public class ExcelExporter
    {
        public void ExportarDataGridConColores(DataGridView grid)
        {
            //if (grid.Rows.Count == 0)
            //{
            //    MessageBox.Show("No hay datos para exportar.");
            //    return;
            //}

            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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
                    cell.Value = LanguageManager.Traducir("Stock_" + encabezados[c]);
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

                    Color? rowColor = ObtenerColorFila(stockActual, stockMinimo);

                    for (int c = 0; c < encabezados.Length; c++)
                    {
                        string colName = encabezados[c];
                        var cell = ws.Cells[currentRow, startCol + c];

                        object valor = dgvRow.Cells[colName]?.Value;

                        if (colName == "PrecioUnitario" && valor != null)
                        {
                            if (double.TryParse(valor.ToString(), out double precio))
                                valor = precio;
                        }

                        cell.Value = valor;

                        if (colName == "PrecioUnitario")
                        {
                            cell.Style.Numberformat.Format = "\"$\" #,##0.00";
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }

                        if (rowColor != null)
                        {
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(rowColor.Value);
                        }

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
        private static int? TryInt(object val)
        {
            if (val == null) return null;
            if (int.TryParse(val.ToString(), out int n)) return n;
            return null;
        }

        private Color? ObtenerColorFila(int? stockActual, int? stockMinimo)
        {
            if (stockActual == null || stockMinimo == null) return null;

            if (stockActual <= stockMinimo)
                return Color.LightCoral;

            if (stockActual - stockMinimo <= 20)
                return Color.Khaki;

            return null;
        }
    }
}