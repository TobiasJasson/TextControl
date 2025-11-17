namespace UI.FormsComun.NuevoPedidos
{
    partial class FormNuevoPedido
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
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Cbx_Nombre = new System.Windows.Forms.ComboBox();
            this.Cbx_TipoProducto = new System.Windows.Forms.ComboBox();
            this.Lbl_TipoInsumo = new System.Windows.Forms.Label();
            this.Lbl_Cantidad = new System.Windows.Forms.Label();
            this.NuD_Cantidad = new System.Windows.Forms.NumericUpDown();
            this.Cbx_Talle = new System.Windows.Forms.ComboBox();
            this.Lbl_Talle = new System.Windows.Forms.Label();
            this.NumPrecioTotal = new System.Windows.Forms.NumericUpDown();
            this.Lbl_PrecioTotal = new System.Windows.Forms.Label();
            this.Num_Adelanto = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Adelanto = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Cbx_Cliente = new System.Windows.Forms.ComboBox();
            this.Lbl_Cliente = new System.Windows.Forms.Label();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Editar = new System.Windows.Forms.Button();
            this.Btn_Cargar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Cbx_Color = new System.Windows.Forms.ComboBox();
            this.Lbl_Color = new System.Windows.Forms.Label();
            this.Lbl_FaltaPagar = new System.Windows.Forms.Label();
            this.Lbl_FaltaPagarResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NuD_Cantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrecioTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Adelanto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Location = new System.Drawing.Point(12, 141);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(113, 16);
            this.Lbl_Nombre.TabIndex = 0;
            this.Lbl_Nombre.Text = "Nombre Producto";
            this.Lbl_Nombre.Click += new System.EventHandler(this.Lbl_Nombre_Click);
            // 
            // Cbx_Nombre
            // 
            this.Cbx_Nombre.FormattingEnabled = true;
            this.Cbx_Nombre.Location = new System.Drawing.Point(144, 133);
            this.Cbx_Nombre.Name = "Cbx_Nombre";
            this.Cbx_Nombre.Size = new System.Drawing.Size(200, 24);
            this.Cbx_Nombre.TabIndex = 1;
            this.Cbx_Nombre.SelectedIndexChanged += new System.EventHandler(this.Cbx_Nombre_SelectedIndexChanged);
            // 
            // Cbx_TipoProducto
            // 
            this.Cbx_TipoProducto.FormattingEnabled = true;
            this.Cbx_TipoProducto.Location = new System.Drawing.Point(144, 80);
            this.Cbx_TipoProducto.Name = "Cbx_TipoProducto";
            this.Cbx_TipoProducto.Size = new System.Drawing.Size(200, 24);
            this.Cbx_TipoProducto.TabIndex = 3;
            this.Cbx_TipoProducto.SelectedIndexChanged += new System.EventHandler(this.Cbx_TipoProducto_SelectedIndexChanged);
            // 
            // Lbl_TipoInsumo
            // 
            this.Lbl_TipoInsumo.AutoSize = true;
            this.Lbl_TipoInsumo.Location = new System.Drawing.Point(12, 88);
            this.Lbl_TipoInsumo.Name = "Lbl_TipoInsumo";
            this.Lbl_TipoInsumo.Size = new System.Drawing.Size(61, 16);
            this.Lbl_TipoInsumo.TabIndex = 2;
            this.Lbl_TipoInsumo.Text = "Producto";
            this.Lbl_TipoInsumo.Click += new System.EventHandler(this.Lbl_TipoInsumo_Click);
            // 
            // Lbl_Cantidad
            // 
            this.Lbl_Cantidad.AutoSize = true;
            this.Lbl_Cantidad.Location = new System.Drawing.Point(12, 226);
            this.Lbl_Cantidad.Name = "Lbl_Cantidad";
            this.Lbl_Cantidad.Size = new System.Drawing.Size(61, 16);
            this.Lbl_Cantidad.TabIndex = 4;
            this.Lbl_Cantidad.Text = "Cantidad";
            this.Lbl_Cantidad.Click += new System.EventHandler(this.Lbl_Cantidad_Click);
            // 
            // NuD_Cantidad
            // 
            this.NuD_Cantidad.Location = new System.Drawing.Point(144, 220);
            this.NuD_Cantidad.Name = "NuD_Cantidad";
            this.NuD_Cantidad.Size = new System.Drawing.Size(200, 22);
            this.NuD_Cantidad.TabIndex = 5;
            this.NuD_Cantidad.ValueChanged += new System.EventHandler(this.NuD_Cantidad_ValueChanged);
            // 
            // Cbx_Talle
            // 
            this.Cbx_Talle.FormattingEnabled = true;
            this.Cbx_Talle.Location = new System.Drawing.Point(500, 24);
            this.Cbx_Talle.Name = "Cbx_Talle";
            this.Cbx_Talle.Size = new System.Drawing.Size(200, 24);
            this.Cbx_Talle.TabIndex = 7;
            this.Cbx_Talle.SelectedIndexChanged += new System.EventHandler(this.Cbx_Talle_SelectedIndexChanged);
            // 
            // Lbl_Talle
            // 
            this.Lbl_Talle.AutoSize = true;
            this.Lbl_Talle.Location = new System.Drawing.Point(365, 24);
            this.Lbl_Talle.Name = "Lbl_Talle";
            this.Lbl_Talle.Size = new System.Drawing.Size(38, 16);
            this.Lbl_Talle.TabIndex = 6;
            this.Lbl_Talle.Text = "Talle";
            this.Lbl_Talle.Click += new System.EventHandler(this.Lbl_Talle_Click);
            // 
            // NumPrecioTotal
            // 
            this.NumPrecioTotal.Location = new System.Drawing.Point(500, 133);
            this.NumPrecioTotal.Name = "NumPrecioTotal";
            this.NumPrecioTotal.Size = new System.Drawing.Size(200, 22);
            this.NumPrecioTotal.TabIndex = 9;
            this.NumPrecioTotal.ValueChanged += new System.EventHandler(this.NumPrecioTotal_ValueChanged);
            // 
            // Lbl_PrecioTotal
            // 
            this.Lbl_PrecioTotal.AutoSize = true;
            this.Lbl_PrecioTotal.Location = new System.Drawing.Point(369, 135);
            this.Lbl_PrecioTotal.Name = "Lbl_PrecioTotal";
            this.Lbl_PrecioTotal.Size = new System.Drawing.Size(80, 16);
            this.Lbl_PrecioTotal.TabIndex = 8;
            this.Lbl_PrecioTotal.Text = "Precio Total";
            this.Lbl_PrecioTotal.Click += new System.EventHandler(this.Lbl_PrecioTotal_Click);
            // 
            // Num_Adelanto
            // 
            this.Num_Adelanto.Location = new System.Drawing.Point(500, 81);
            this.Num_Adelanto.Name = "Num_Adelanto";
            this.Num_Adelanto.Size = new System.Drawing.Size(200, 22);
            this.Num_Adelanto.TabIndex = 11;
            this.Num_Adelanto.ValueChanged += new System.EventHandler(this.Num_Adelanto_ValueChanged);
            // 
            // Lbl_Adelanto
            // 
            this.Lbl_Adelanto.AutoSize = true;
            this.Lbl_Adelanto.Location = new System.Drawing.Point(369, 83);
            this.Lbl_Adelanto.Name = "Lbl_Adelanto";
            this.Lbl_Adelanto.Size = new System.Drawing.Size(61, 16);
            this.Lbl_Adelanto.TabIndex = 10;
            this.Lbl_Adelanto.Text = "Adelanto";
            this.Lbl_Adelanto.Click += new System.EventHandler(this.Lbl_Adelanto_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 266);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(685, 182);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Location = new System.Drawing.Point(351, 210);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(115, 37);
            this.Btn_Agregar.TabIndex = 13;
            this.Btn_Agregar.Text = "Agregar";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Cbx_Cliente
            // 
            this.Cbx_Cliente.FormattingEnabled = true;
            this.Cbx_Cliente.Location = new System.Drawing.Point(144, 24);
            this.Cbx_Cliente.Name = "Cbx_Cliente";
            this.Cbx_Cliente.Size = new System.Drawing.Size(200, 24);
            this.Cbx_Cliente.TabIndex = 15;
            this.Cbx_Cliente.SelectedIndexChanged += new System.EventHandler(this.Cbx_Cliente_SelectedIndexChanged);
            // 
            // Lbl_Cliente
            // 
            this.Lbl_Cliente.AutoSize = true;
            this.Lbl_Cliente.Location = new System.Drawing.Point(12, 32);
            this.Lbl_Cliente.Name = "Lbl_Cliente";
            this.Lbl_Cliente.Size = new System.Drawing.Size(48, 16);
            this.Lbl_Cliente.TabIndex = 14;
            this.Lbl_Cliente.Text = "Cliente";
            this.Lbl_Cliente.Click += new System.EventHandler(this.Lbl_Cliente_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(472, 210);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(111, 37);
            this.Btn_Eliminar.TabIndex = 16;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.Location = new System.Drawing.Point(589, 210);
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(111, 37);
            this.Btn_Editar.TabIndex = 17;
            this.Btn_Editar.Text = "Editar";
            this.Btn_Editar.UseVisualStyleBackColor = true;
            this.Btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // Btn_Cargar
            // 
            this.Btn_Cargar.Location = new System.Drawing.Point(415, 468);
            this.Btn_Cargar.Name = "Btn_Cargar";
            this.Btn_Cargar.Size = new System.Drawing.Size(95, 37);
            this.Btn_Cargar.TabIndex = 18;
            this.Btn_Cargar.Text = "Cargar";
            this.Btn_Cargar.UseVisualStyleBackColor = true;
            this.Btn_Cargar.Click += new System.EventHandler(this.Btn_Cargar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(589, 468);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(95, 37);
            this.Btn_Cancelar.TabIndex = 19;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Cbx_Color
            // 
            this.Cbx_Color.FormattingEnabled = true;
            this.Cbx_Color.Location = new System.Drawing.Point(144, 177);
            this.Cbx_Color.Name = "Cbx_Color";
            this.Cbx_Color.Size = new System.Drawing.Size(200, 24);
            this.Cbx_Color.TabIndex = 21;
            this.Cbx_Color.SelectedIndexChanged += new System.EventHandler(this.Cbx_Color_SelectedIndexChanged);
            // 
            // Lbl_Color
            // 
            this.Lbl_Color.AutoSize = true;
            this.Lbl_Color.Location = new System.Drawing.Point(12, 185);
            this.Lbl_Color.Name = "Lbl_Color";
            this.Lbl_Color.Size = new System.Drawing.Size(39, 16);
            this.Lbl_Color.TabIndex = 20;
            this.Lbl_Color.Text = "Color";
            this.Lbl_Color.Click += new System.EventHandler(this.Lbl_Color_Click);
            // 
            // Lbl_FaltaPagar
            // 
            this.Lbl_FaltaPagar.AutoSize = true;
            this.Lbl_FaltaPagar.Location = new System.Drawing.Point(369, 180);
            this.Lbl_FaltaPagar.Name = "Lbl_FaltaPagar";
            this.Lbl_FaltaPagar.Size = new System.Drawing.Size(77, 16);
            this.Lbl_FaltaPagar.TabIndex = 22;
            this.Lbl_FaltaPagar.Text = "Falta Pagar";
            this.Lbl_FaltaPagar.Click += new System.EventHandler(this.Lbl_FaltaPagar_Click);
            // 
            // Lbl_FaltaPagarResult
            // 
            this.Lbl_FaltaPagarResult.AutoSize = true;
            this.Lbl_FaltaPagarResult.Location = new System.Drawing.Point(506, 185);
            this.Lbl_FaltaPagarResult.Name = "Lbl_FaltaPagarResult";
            this.Lbl_FaltaPagarResult.Size = new System.Drawing.Size(77, 16);
            this.Lbl_FaltaPagarResult.TabIndex = 23;
            this.Lbl_FaltaPagarResult.Text = "Falta Pagar";
            this.Lbl_FaltaPagarResult.Click += new System.EventHandler(this.Lbl_FaltaPagarResult_Click);
            // 
            // FormNuevoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 517);
            this.Controls.Add(this.Lbl_FaltaPagarResult);
            this.Controls.Add(this.Lbl_FaltaPagar);
            this.Controls.Add(this.Cbx_Color);
            this.Controls.Add(this.Lbl_Color);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Cargar);
            this.Controls.Add(this.Btn_Editar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Cbx_Cliente);
            this.Controls.Add(this.Lbl_Cliente);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Num_Adelanto);
            this.Controls.Add(this.Lbl_Adelanto);
            this.Controls.Add(this.NumPrecioTotal);
            this.Controls.Add(this.Lbl_PrecioTotal);
            this.Controls.Add(this.Cbx_Talle);
            this.Controls.Add(this.Lbl_Talle);
            this.Controls.Add(this.NuD_Cantidad);
            this.Controls.Add(this.Lbl_Cantidad);
            this.Controls.Add(this.Cbx_TipoProducto);
            this.Controls.Add(this.Lbl_TipoInsumo);
            this.Controls.Add(this.Cbx_Nombre);
            this.Controls.Add(this.Lbl_Nombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNuevoPedido";
            this.Text = "FormNuevoPedido";
            this.Load += new System.EventHandler(this.FormNuevoPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NuD_Cantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrecioTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Adelanto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.ComboBox Cbx_Nombre;
        private System.Windows.Forms.ComboBox Cbx_TipoProducto;
        private System.Windows.Forms.Label Lbl_TipoInsumo;
        private System.Windows.Forms.Label Lbl_Cantidad;
        private System.Windows.Forms.NumericUpDown NuD_Cantidad;
        private System.Windows.Forms.ComboBox Cbx_Talle;
        private System.Windows.Forms.Label Lbl_Talle;
        private System.Windows.Forms.NumericUpDown NumPrecioTotal;
        private System.Windows.Forms.Label Lbl_PrecioTotal;
        private System.Windows.Forms.NumericUpDown Num_Adelanto;
        private System.Windows.Forms.Label Lbl_Adelanto;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.ComboBox Cbx_Cliente;
        private System.Windows.Forms.Label Lbl_Cliente;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Editar;
        private System.Windows.Forms.Button Btn_Cargar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.ComboBox Cbx_Color;
        private System.Windows.Forms.Label Lbl_Color;
        private System.Windows.Forms.Label Lbl_FaltaPagar;
        private System.Windows.Forms.Label Lbl_FaltaPagarResult;
    }
}