namespace UI
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.Panel_Title = new System.Windows.Forms.Panel();
            this.Btn_MenuDesplegable = new System.Windows.Forms.Button();
            this.BtnMaximize = new System.Windows.Forms.Button();
            this.Btn_Minimize = new System.Windows.Forms.Button();
            this.Btn_Cerrar = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.Btn_Venta = new System.Windows.Forms.Button();
            this.Btn_Usuarios = new System.Windows.Forms.Button();
            this.BtnReporte = new System.Windows.Forms.Button();
            this.BtnStock = new System.Windows.Forms.Button();
            this.BtnConfig = new System.Windows.Forms.Button();
            this.Btn_LogOut = new System.Windows.Forms.Button();
            this.BtnCambiarIdioma = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.Panel_Title.SuspendLayout();
            this.panel_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Title
            // 
            this.Panel_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.Panel_Title.Controls.Add(this.Btn_MenuDesplegable);
            this.Panel_Title.Controls.Add(this.BtnMaximize);
            this.Panel_Title.Controls.Add(this.Btn_Minimize);
            this.Panel_Title.Controls.Add(this.Btn_Cerrar);
            this.Panel_Title.Controls.Add(this.lblTitle);
            this.Panel_Title.Location = new System.Drawing.Point(1, 1);
            this.Panel_Title.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Panel_Title.Name = "Panel_Title";
            this.Panel_Title.Size = new System.Drawing.Size(1315, 64);
            this.Panel_Title.TabIndex = 2;
            this.Panel_Title.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Title_Paint);
            this.Panel_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // Btn_MenuDesplegable
            // 
            this.Btn_MenuDesplegable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_MenuDesplegable.BackgroundImage")));
            this.Btn_MenuDesplegable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_MenuDesplegable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(90)))));
            this.Btn_MenuDesplegable.FlatAppearance.BorderSize = 0;
            this.Btn_MenuDesplegable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_MenuDesplegable.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_MenuDesplegable.ForeColor = System.Drawing.Color.Silver;
            this.Btn_MenuDesplegable.Location = new System.Drawing.Point(11, 7);
            this.Btn_MenuDesplegable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_MenuDesplegable.Name = "Btn_MenuDesplegable";
            this.Btn_MenuDesplegable.Size = new System.Drawing.Size(59, 50);
            this.Btn_MenuDesplegable.TabIndex = 17;
            this.Btn_MenuDesplegable.UseVisualStyleBackColor = true;
            this.Btn_MenuDesplegable.Click += new System.EventHandler(this.Btn_MenuDesplegable_Click);
            // 
            // BtnMaximize
            // 
            this.BtnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMaximize.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BtnMaximize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.BtnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.BtnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMaximize.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMaximize.ForeColor = System.Drawing.Color.Silver;
            this.BtnMaximize.Location = new System.Drawing.Point(1219, 7);
            this.BtnMaximize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnMaximize.Name = "BtnMaximize";
            this.BtnMaximize.Size = new System.Drawing.Size(37, 43);
            this.BtnMaximize.TabIndex = 12;
            this.BtnMaximize.Text = "⬜ ";
            this.BtnMaximize.UseVisualStyleBackColor = true;
            this.BtnMaximize.Click += new System.EventHandler(this.BtnMaximize_Click_1);
            // 
            // Btn_Minimize
            // 
            this.Btn_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Minimize.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Btn_Minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Btn_Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.Btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Minimize.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Minimize.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Minimize.Location = new System.Drawing.Point(1176, 7);
            this.Btn_Minimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Minimize.Name = "Btn_Minimize";
            this.Btn_Minimize.Size = new System.Drawing.Size(37, 43);
            this.Btn_Minimize.TabIndex = 11;
            this.Btn_Minimize.Text = "-";
            this.Btn_Minimize.UseVisualStyleBackColor = true;
            this.Btn_Minimize.Click += new System.EventHandler(this.Btn_Minimize_Click);
            // 
            // Btn_Cerrar
            // 
            this.Btn_Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Cerrar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Btn_Cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cerrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cerrar.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Cerrar.Location = new System.Drawing.Point(1267, 7);
            this.Btn_Cerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Cerrar.Name = "Btn_Cerrar";
            this.Btn_Cerrar.Size = new System.Drawing.Size(37, 43);
            this.Btn_Cerrar.TabIndex = 10;
            this.Btn_Cerrar.Text = "X";
            this.Btn_Cerrar.UseVisualStyleBackColor = true;
            this.Btn_Cerrar.Click += new System.EventHandler(this.Btn_Cerrar_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblTitle.Location = new System.Drawing.Point(139, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Menu Principal";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(90)))));
            this.panel_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_Menu.Controls.Add(this.Btn_Venta);
            this.panel_Menu.Controls.Add(this.Btn_Usuarios);
            this.panel_Menu.Controls.Add(this.BtnReporte);
            this.panel_Menu.Controls.Add(this.BtnStock);
            this.panel_Menu.Controls.Add(this.BtnConfig);
            this.panel_Menu.Controls.Add(this.Btn_LogOut);
            this.panel_Menu.Controls.Add(this.BtnCambiarIdioma);
            this.panel_Menu.Location = new System.Drawing.Point(1, 63);
            this.panel_Menu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(281, 674);
            this.panel_Menu.TabIndex = 5;
            this.panel_Menu.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Menu_Paint);
            // 
            // Btn_Venta
            // 
            this.Btn_Venta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(90)))));
            this.Btn_Venta.FlatAppearance.BorderSize = 0;
            this.Btn_Venta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Venta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Venta.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Venta.Location = new System.Drawing.Point(11, 18);
            this.Btn_Venta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Venta.Name = "Btn_Venta";
            this.Btn_Venta.Size = new System.Drawing.Size(265, 59);
            this.Btn_Venta.TabIndex = 17;
            this.Btn_Venta.Text = "Nuevo Pedido";
            this.Btn_Venta.UseVisualStyleBackColor = true;
            this.Btn_Venta.Click += new System.EventHandler(this.Btn_Venta_Click);
            // 
            // Btn_Usuarios
            // 
            this.Btn_Usuarios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(90)))));
            this.Btn_Usuarios.FlatAppearance.BorderSize = 0;
            this.Btn_Usuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Usuarios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Usuarios.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Usuarios.Location = new System.Drawing.Point(11, 84);
            this.Btn_Usuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Usuarios.Name = "Btn_Usuarios";
            this.Btn_Usuarios.Size = new System.Drawing.Size(265, 59);
            this.Btn_Usuarios.TabIndex = 12;
            this.Btn_Usuarios.Text = "Usuario";
            this.Btn_Usuarios.UseVisualStyleBackColor = true;
            this.Btn_Usuarios.Click += new System.EventHandler(this.Btn_Usuarios_Click);
            // 
            // BtnReporte
            // 
            this.BtnReporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(90)))));
            this.BtnReporte.FlatAppearance.BorderSize = 0;
            this.BtnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnReporte.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReporte.ForeColor = System.Drawing.Color.Silver;
            this.BtnReporte.Location = new System.Drawing.Point(11, 155);
            this.BtnReporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReporte.Name = "BtnReporte";
            this.BtnReporte.Size = new System.Drawing.Size(265, 64);
            this.BtnReporte.TabIndex = 13;
            this.BtnReporte.Text = "Reporte";
            this.BtnReporte.UseVisualStyleBackColor = true;
            this.BtnReporte.Click += new System.EventHandler(this.BtnReporte_Click);
            // 
            // BtnStock
            // 
            this.BtnStock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(90)))));
            this.BtnStock.FlatAppearance.BorderSize = 0;
            this.BtnStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnStock.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStock.ForeColor = System.Drawing.Color.Silver;
            this.BtnStock.Location = new System.Drawing.Point(11, 230);
            this.BtnStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnStock.Name = "BtnStock";
            this.BtnStock.Size = new System.Drawing.Size(265, 59);
            this.BtnStock.TabIndex = 14;
            this.BtnStock.Text = "Stock";
            this.BtnStock.UseVisualStyleBackColor = true;
            this.BtnStock.Click += new System.EventHandler(this.BtnStock_Click);
            // 
            // BtnConfig
            // 
            this.BtnConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(90)))));
            this.BtnConfig.FlatAppearance.BorderSize = 0;
            this.BtnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnConfig.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfig.ForeColor = System.Drawing.Color.Silver;
            this.BtnConfig.Location = new System.Drawing.Point(11, 309);
            this.BtnConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnConfig.Name = "BtnConfig";
            this.BtnConfig.Size = new System.Drawing.Size(265, 69);
            this.BtnConfig.TabIndex = 15;
            this.BtnConfig.Text = "Configuraciones";
            this.BtnConfig.UseVisualStyleBackColor = true;
            this.BtnConfig.Click += new System.EventHandler(this.BtnConfig_Click);
            // 
            // Btn_LogOut
            // 
            this.Btn_LogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_LogOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(90)))));
            this.Btn_LogOut.FlatAppearance.BorderSize = 0;
            this.Btn_LogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_LogOut.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_LogOut.ForeColor = System.Drawing.Color.Silver;
            this.Btn_LogOut.Location = new System.Drawing.Point(11, 582);
            this.Btn_LogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_LogOut.Name = "Btn_LogOut";
            this.Btn_LogOut.Size = new System.Drawing.Size(136, 41);
            this.Btn_LogOut.TabIndex = 16;
            this.Btn_LogOut.Text = "Salir";
            this.Btn_LogOut.UseVisualStyleBackColor = true;
            this.Btn_LogOut.Click += new System.EventHandler(this.Btn_LogOut_Click);
            // 
            // BtnCambiarIdioma
            // 
            this.BtnCambiarIdioma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCambiarIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.BtnCambiarIdioma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.BtnCambiarIdioma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BtnCambiarIdioma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.BtnCambiarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambiarIdioma.ForeColor = System.Drawing.Color.LightGray;
            this.BtnCambiarIdioma.Location = new System.Drawing.Point(189, 582);
            this.BtnCambiarIdioma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCambiarIdioma.Name = "BtnCambiarIdioma";
            this.BtnCambiarIdioma.Size = new System.Drawing.Size(76, 39);
            this.BtnCambiarIdioma.TabIndex = 11;
            this.BtnCambiarIdioma.Text = "ES-AR";
            this.BtnCambiarIdioma.UseVisualStyleBackColor = false;
            this.BtnCambiarIdioma.Click += new System.EventHandler(this.BtnCambiarIdioma_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // panelContenido
            // 
            this.panelContenido.Location = new System.Drawing.Point(283, 65);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1032, 672);
            this.panelContenido.TabIndex = 6;
            this.panelContenido.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenido_Paint);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1315, 738);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.Panel_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.Panel_Title.ResumeLayout(false);
            this.Panel_Title.PerformLayout();
            this.panel_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Title;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Button Btn_Minimize;
        private System.Windows.Forms.Button Btn_Cerrar;
        private System.Windows.Forms.Button BtnMaximize;
        private System.Windows.Forms.Button Btn_MenuDesplegable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelContenido;
        public System.Windows.Forms.Button Btn_Usuarios;
        public System.Windows.Forms.Button BtnCambiarIdioma;
        public System.Windows.Forms.Button BtnReporte;
        public System.Windows.Forms.Button Btn_LogOut;
        public System.Windows.Forms.Button BtnConfig;
        public System.Windows.Forms.Button BtnStock;
        public System.Windows.Forms.Button Btn_Venta;
    }
}