using Services.MultiIdioma;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.LocalWidget
{
    public static class CustomMessageBox
    {
        public static DialogResult Show(string message, string title)
        {
            var form = new Form()
            {
                Width = 360,
                Height = 160,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false,
                ShowIcon = false,
                BackColor = Color.White
            };

            var icon = new PictureBox()
            {
                Image = SystemIcons.Question.ToBitmap(),
                SizeMode = PictureBoxSizeMode.CenterImage,
                Dock = DockStyle.Fill,
                Width = 48,
                Height = 48,
                Margin = new Padding(10, 5, 10, 5)
            };

            var label = new Label()
            {
                Text = message,
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Padding = new Padding(5),
            };

            var tableLayout = new TableLayoutPanel()
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                RowCount = 1,
                AutoSize = true
            };

            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayout.Controls.Add(icon, 0, 0);
            tableLayout.Controls.Add(label, 1, 0);
            var btnCerrarSesion = new Button()
            {
                Text = LanguageManager.Traducir("Btn_CerrarSesion"),
                DialogResult = DialogResult.Yes,
                Width = 100
            };

            var btnSalir = new Button()
            {
                Text = LanguageManager.Traducir("Btn_Salir"),
                DialogResult = DialogResult.No,
                Width = 100
            };

            var btnCancel = new Button()
            {
                Text = LanguageManager.Traducir("Btn_Cancel"),
                DialogResult = DialogResult.Cancel,
                Width = 100
            };

            var panelButtons = new FlowLayoutPanel()
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.LeftToRight,
                Height = 50,
                Padding = new Padding(10, 5, 10, 10),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            panelButtons.Controls.Add(btnCerrarSesion);
            panelButtons.Controls.Add(btnSalir);
            panelButtons.Controls.Add(btnCancel);

            form.Controls.Add(tableLayout);
            form.Controls.Add(panelButtons);

            form.AcceptButton = btnCerrarSesion;
            form.CancelButton = btnCancel;

            return form.ShowDialog();
        }
    

        public static DialogResult error(string message, string title)
            {
                var form = new Form()
                {
                    Width = 360,
                    Height = 160,
                    Text = title,
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MinimizeBox = false,
                    MaximizeBox = false,
                    ShowIcon = false,
                    BackColor = Color.White
                };

                var icon = new PictureBox()
                {
                    Image = SystemIcons.Error.ToBitmap(),
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Dock = DockStyle.Fill,
                    Width = 48,
                    Height = 48,
                    Margin = new Padding(10, 5, 10, 5)
                };

                var label = new Label()
                {
                    Text = message,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(5),
                };

                var tableLayout = new TableLayoutPanel()
                {
                    Dock = DockStyle.Top,
                    ColumnCount = 2,
                    RowCount = 1,
                    AutoSize = true
                };

                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tableLayout.Controls.Add(icon, 0, 0);
                tableLayout.Controls.Add(label, 1, 0);
                var btnOk = new Button()
                {
                    Text = LanguageManager.Traducir("Btn_Ok"),
                    DialogResult = DialogResult.Yes,
                    Width = 100
                };

                var panelButtons = new FlowLayoutPanel()
                {
                    Dock = DockStyle.Bottom,
                    FlowDirection = FlowDirection.LeftToRight,
                    Height = 50,
                    Padding = new Padding(10, 5, 10, 10),
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };

                panelButtons.Controls.Add(btnOk);

                form.Controls.Add(tableLayout);
                form.Controls.Add(panelButtons);

                form.CancelButton = btnOk;

                return form.ShowDialog();
            }
        }
}