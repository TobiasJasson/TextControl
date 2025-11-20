namespace UI.FormsComun.Stock
{
    partial class FormAgregarStock
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
            this.CBX_TipoInsumo = new System.Windows.Forms.ComboBox();
            this.Txt_StockActual = new System.Windows.Forms.TextBox();
            this.Txt_StockMinimo = new System.Windows.Forms.TextBox();
            this.Txt_CantidadUnidad = new System.Windows.Forms.TextBox();
            this.Txt_PrecioUnitario = new System.Windows.Forms.TextBox();
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.CBX_Color = new System.Windows.Forms.ComboBox();
            this.Lbl_titleTipoStock = new System.Windows.Forms.Label();
            this.Lbl_NombreInsumo = new System.Windows.Forms.Label();
            this.Lbl_ColorInsumo = new System.Windows.Forms.Label();
            this.Lbl_StockMinimo = new System.Windows.Forms.Label();
            this.Lbl_StockActual = new System.Windows.Forms.Label();
            this.Lbl_PrecioUnitario = new System.Windows.Forms.Label();
            this.Lbl_CantidadUnidad = new System.Windows.Forms.Label();
            this.Cbx_NombreInsumo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CBX_TipoInsumo
            // 
            this.CBX_TipoInsumo.FormattingEnabled = true;
            this.CBX_TipoInsumo.Location = new System.Drawing.Point(234, 82);
            this.CBX_TipoInsumo.Name = "CBX_TipoInsumo";
            this.CBX_TipoInsumo.Size = new System.Drawing.Size(246, 24);
            this.CBX_TipoInsumo.TabIndex = 0;
            this.CBX_TipoInsumo.SelectedIndexChanged += new System.EventHandler(this.CBX_TipoInsumo_SelectedIndexChanged);
            // 
            // Txt_StockActual
            // 
            this.Txt_StockActual.Location = new System.Drawing.Point(386, 242);
            this.Txt_StockActual.Name = "Txt_StockActual";
            this.Txt_StockActual.Size = new System.Drawing.Size(246, 22);
            this.Txt_StockActual.TabIndex = 2;
            this.Txt_StockActual.TextChanged += new System.EventHandler(this.Txt_StockActual_TextChanged);
            // 
            // Txt_StockMinimo
            // 
            this.Txt_StockMinimo.Location = new System.Drawing.Point(81, 242);
            this.Txt_StockMinimo.Name = "Txt_StockMinimo";
            this.Txt_StockMinimo.Size = new System.Drawing.Size(246, 22);
            this.Txt_StockMinimo.TabIndex = 3;
            this.Txt_StockMinimo.TextChanged += new System.EventHandler(this.Txt_StockMinimo_TextChanged);
            // 
            // Txt_CantidadUnidad
            // 
            this.Txt_CantidadUnidad.Location = new System.Drawing.Point(81, 326);
            this.Txt_CantidadUnidad.Name = "Txt_CantidadUnidad";
            this.Txt_CantidadUnidad.Size = new System.Drawing.Size(246, 22);
            this.Txt_CantidadUnidad.TabIndex = 4;
            this.Txt_CantidadUnidad.TextChanged += new System.EventHandler(this.Txt_CantidadUnidad_TextChanged);
            // 
            // Txt_PrecioUnitario
            // 
            this.Txt_PrecioUnitario.Location = new System.Drawing.Point(386, 326);
            this.Txt_PrecioUnitario.Name = "Txt_PrecioUnitario";
            this.Txt_PrecioUnitario.Size = new System.Drawing.Size(246, 22);
            this.Txt_PrecioUnitario.TabIndex = 5;
            this.Txt_PrecioUnitario.TextChanged += new System.EventHandler(this.Txt_PrecioUnitario_TextChanged);
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Location = new System.Drawing.Point(128, 371);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(145, 42);
            this.Btn_Agregar.TabIndex = 6;
            this.Btn_Agregar.Text = "Agregar";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(437, 371);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(145, 42);
            this.Btn_Cancelar.TabIndex = 7;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // CBX_Color
            // 
            this.CBX_Color.FormattingEnabled = true;
            this.CBX_Color.Location = new System.Drawing.Point(386, 162);
            this.CBX_Color.Name = "CBX_Color";
            this.CBX_Color.Size = new System.Drawing.Size(246, 24);
            this.CBX_Color.TabIndex = 8;
            this.CBX_Color.SelectedIndexChanged += new System.EventHandler(this.CBX_Color_SelectedIndexChanged);
            // 
            // Lbl_titleTipoStock
            // 
            this.Lbl_titleTipoStock.AutoSize = true;
            this.Lbl_titleTipoStock.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titleTipoStock.Location = new System.Drawing.Point(302, 40);
            this.Lbl_titleTipoStock.Name = "Lbl_titleTipoStock";
            this.Lbl_titleTipoStock.Size = new System.Drawing.Size(107, 23);
            this.Lbl_titleTipoStock.TabIndex = 9;
            this.Lbl_titleTipoStock.Text = "Tipo Stock";
            this.Lbl_titleTipoStock.Click += new System.EventHandler(this.Lbl_titleTipoStock_Click);
            // 
            // Lbl_NombreInsumo
            // 
            this.Lbl_NombreInsumo.AutoSize = true;
            this.Lbl_NombreInsumo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NombreInsumo.Location = new System.Drawing.Point(86, 127);
            this.Lbl_NombreInsumo.Name = "Lbl_NombreInsumo";
            this.Lbl_NombreInsumo.Size = new System.Drawing.Size(165, 23);
            this.Lbl_NombreInsumo.TabIndex = 10;
            this.Lbl_NombreInsumo.Text = "Nombre Insumo";
            this.Lbl_NombreInsumo.Click += new System.EventHandler(this.Lbl_NombreInsumo_Click);
            // 
            // Lbl_ColorInsumo
            // 
            this.Lbl_ColorInsumo.AutoSize = true;
            this.Lbl_ColorInsumo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ColorInsumo.Location = new System.Drawing.Point(382, 127);
            this.Lbl_ColorInsumo.Name = "Lbl_ColorInsumo";
            this.Lbl_ColorInsumo.Size = new System.Drawing.Size(138, 23);
            this.Lbl_ColorInsumo.TabIndex = 11;
            this.Lbl_ColorInsumo.Text = "Color Insumo";
            this.Lbl_ColorInsumo.Click += new System.EventHandler(this.Lbl_ColorInsumo_Click);
            // 
            // Lbl_StockMinimo
            // 
            this.Lbl_StockMinimo.AutoSize = true;
            this.Lbl_StockMinimo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_StockMinimo.Location = new System.Drawing.Point(77, 205);
            this.Lbl_StockMinimo.Name = "Lbl_StockMinimo";
            this.Lbl_StockMinimo.Size = new System.Drawing.Size(136, 23);
            this.Lbl_StockMinimo.TabIndex = 12;
            this.Lbl_StockMinimo.Text = "Minimo Stock";
            this.Lbl_StockMinimo.Click += new System.EventHandler(this.Lbl_StockMinimo_Click);
            // 
            // Lbl_StockActual
            // 
            this.Lbl_StockActual.AutoSize = true;
            this.Lbl_StockActual.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_StockActual.Location = new System.Drawing.Point(382, 205);
            this.Lbl_StockActual.Name = "Lbl_StockActual";
            this.Lbl_StockActual.Size = new System.Drawing.Size(135, 23);
            this.Lbl_StockActual.TabIndex = 13;
            this.Lbl_StockActual.Text = "Stock Actual";
            this.Lbl_StockActual.Click += new System.EventHandler(this.Lbl_StockActual_Click);
            // 
            // Lbl_PrecioUnitario
            // 
            this.Lbl_PrecioUnitario.AutoSize = true;
            this.Lbl_PrecioUnitario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PrecioUnitario.Location = new System.Drawing.Point(382, 291);
            this.Lbl_PrecioUnitario.Name = "Lbl_PrecioUnitario";
            this.Lbl_PrecioUnitario.Size = new System.Drawing.Size(147, 23);
            this.Lbl_PrecioUnitario.TabIndex = 14;
            this.Lbl_PrecioUnitario.Text = "Precio Unitario";
            this.Lbl_PrecioUnitario.Click += new System.EventHandler(this.Lbl_PrecioUnitario_Click);
            // 
            // Lbl_CantidadUnidad
            // 
            this.Lbl_CantidadUnidad.AutoSize = true;
            this.Lbl_CantidadUnidad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CantidadUnidad.Location = new System.Drawing.Point(77, 291);
            this.Lbl_CantidadUnidad.Name = "Lbl_CantidadUnidad";
            this.Lbl_CantidadUnidad.Size = new System.Drawing.Size(182, 23);
            this.Lbl_CantidadUnidad.TabIndex = 15;
            this.Lbl_CantidadUnidad.Text = "Cantidad Unitaria";
            this.Lbl_CantidadUnidad.Click += new System.EventHandler(this.Lbl_CantidadUnidad_Click);
            // 
            // Cbx_NombreInsumo
            // 
            this.Cbx_NombreInsumo.FormattingEnabled = true;
            this.Cbx_NombreInsumo.Location = new System.Drawing.Point(81, 162);
            this.Cbx_NombreInsumo.Name = "Cbx_NombreInsumo";
            this.Cbx_NombreInsumo.Size = new System.Drawing.Size(246, 24);
            this.Cbx_NombreInsumo.TabIndex = 16;
            this.Cbx_NombreInsumo.SelectedIndexChanged += new System.EventHandler(this.Cbx_NombreInsumo_SelectedIndexChanged);
            // 
            // FormAgregarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Cbx_NombreInsumo);
            this.Controls.Add(this.Lbl_CantidadUnidad);
            this.Controls.Add(this.Lbl_PrecioUnitario);
            this.Controls.Add(this.Lbl_StockActual);
            this.Controls.Add(this.Lbl_StockMinimo);
            this.Controls.Add(this.Lbl_ColorInsumo);
            this.Controls.Add(this.Lbl_NombreInsumo);
            this.Controls.Add(this.Lbl_titleTipoStock);
            this.Controls.Add(this.CBX_Color);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.Txt_PrecioUnitario);
            this.Controls.Add(this.Txt_CantidadUnidad);
            this.Controls.Add(this.Txt_StockMinimo);
            this.Controls.Add(this.Txt_StockActual);
            this.Controls.Add(this.CBX_TipoInsumo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAgregarStock";
            this.Load += new System.EventHandler(this.FormAgregarStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBX_TipoInsumo;
        private System.Windows.Forms.TextBox Txt_StockActual;
        private System.Windows.Forms.TextBox Txt_StockMinimo;
        private System.Windows.Forms.TextBox Txt_CantidadUnidad;
        private System.Windows.Forms.TextBox Txt_PrecioUnitario;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.ComboBox CBX_Color;
        private System.Windows.Forms.Label Lbl_titleTipoStock;
        private System.Windows.Forms.Label Lbl_NombreInsumo;
        private System.Windows.Forms.Label Lbl_ColorInsumo;
        private System.Windows.Forms.Label Lbl_StockMinimo;
        private System.Windows.Forms.Label Lbl_StockActual;
        private System.Windows.Forms.Label Lbl_PrecioUnitario;
        private System.Windows.Forms.Label Lbl_CantidadUnidad;
        private System.Windows.Forms.ComboBox Cbx_NombreInsumo;
    }
}