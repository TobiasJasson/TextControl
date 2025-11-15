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
                    var headerCell = ws.Cells[startRow, startCol + c];
                    headerCell.Value = encabezados[c];
                    headerCell.Style.Font.Bold = true;
                    headerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    headerCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    headerCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    headerCell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(220, 220, 220));
                    headerCell.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                }
    
                int currentRow = startRow + 1;
                int colPrecio = encabezados.Length - 1;
    
                for (int r = 0; r < grid.Rows.Count; r++)
                    {
                        int stockActual = Convert.ToInt32(grid.Rows[r].Cells["StockActual"].Value);
                        int stockMinimo = Convert.ToInt32(grid.Rows[r].Cells["StockMinimo"].Value);
    
                        Color? rowColor = null;
                        if (stockActual <= stockMinimo)
                            rowColor = Color.LightCoral;
                        else if (stockActual - stockMinimo <= 20)
                            rowColor = Color.Khaki;
    
                        for (int c = 0; c < encabezados.Length; c++)
                        {
                            var cell = ws.Cells[currentRow, startCol + c];
                            cell.Value = grid.Rows[r].Cells[c].Value;
    
                            if (encabezados[c] == "PrecioUnitario")
                            {
                                cell.Style.Numberformat.Format = "\"$\" #,##0.00";
                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
    
                            if (rowColor != null)
                            {
                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell.Style.Fill.BackgroundColor.SetColor((Color)rowColor);
                            }
    
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }    
                    currentRow++;
                }
    
                var dataRange = ws.Cells[startRow, startCol, currentRow - 1, startCol + encabezados.Length - 1];
    
                ws.Cells[startRow, startCol, currentRow - 1, startCol + encabezados.Length - 1].AutoFilter = true;
    
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
    
                using (SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook|*.xlsx",
                    Title = "Guardar como Excel",
                    FileName = "Listado Stock.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(sfd.FileName));
                        MessageBox.Show(LanguageManager.Traducir("ExporCorrectamente")," ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}