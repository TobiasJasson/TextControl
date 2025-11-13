using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.LocalWidget
{
    public class ExcelExporter
    {
        public void ExportarDataGridConColores(DataGridView grid)
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Stock");

                for (int c = 0; c < grid.Columns.Count; c++)
                    ws.Cells[1, c + 1].Value = grid.Columns[c].HeaderText;

                for (int r = 0; r < grid.Rows.Count; r++)
                {
                    for (int c = 0; c < grid.Columns.Count; c++)
                    {
                        var cell = ws.Cells[r + 2, c + 1];
                        cell.Value = grid.Rows[r].Cells[c].Value;
                        var color = grid.Rows[r].DefaultCellStyle.BackColor;
                        if (color != Color.Empty)
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(color);
                    }
                }

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook|*.xlsx",
                    Title = "Guardar como Excel"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                    package.SaveAs(new System.IO.FileInfo(sfd.FileName));
            }
        }
    }
}