namespace UI.FormsComun.OrdenesPedidos
{
    partial class FormOrdenesPedidos
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Dtp_FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.Dtp_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.Cbx_EstadoPedido = new System.Windows.Forms.ComboBox();
            this.Btn_Detalle = new System.Windows.Forms.Button();
            this.Btn_Exportar = new System.Windows.Forms.Button();
            this.Lbl_FechaDede = new System.Windows.Forms.Label();
            this.Lbl_FechaHasta = new System.Windows.Forms.Label();
            this.Lbl_EstadoPedido = new System.Windows.Forms.Label();
            this.Btn_LimpiarFiltros = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 310);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Dtp_FechaDesde
            // 
            this.Dtp_FechaDesde.Location = new System.Drawing.Point(25, 41);
            this.Dtp_FechaDesde.Name = "Dtp_FechaDesde";
            this.Dtp_FechaDesde.Size = new System.Drawing.Size(200, 22);
            this.Dtp_FechaDesde.TabIndex = 1;
            this.Dtp_FechaDesde.ValueChanged += new System.EventHandler(this.Dtp_FechaDesde_ValueChanged);
            // 
            // Dtp_FechaHasta
            // 
            this.Dtp_FechaHasta.Location = new System.Drawing.Point(25, 100);
            this.Dtp_FechaHasta.Name = "Dtp_FechaHasta";
            this.Dtp_FechaHasta.Size = new System.Drawing.Size(200, 22);
            this.Dtp_FechaHasta.TabIndex = 2;
            this.Dtp_FechaHasta.ValueChanged += new System.EventHandler(this.Dtp_FechaHasta_ValueChanged);
            // 
            // Cbx_EstadoPedido
            // 
            this.Cbx_EstadoPedido.FormattingEnabled = true;
            this.Cbx_EstadoPedido.Location = new System.Drawing.Point(258, 41);
            this.Cbx_EstadoPedido.Name = "Cbx_EstadoPedido";
            this.Cbx_EstadoPedido.Size = new System.Drawing.Size(186, 24);
            this.Cbx_EstadoPedido.TabIndex = 3;
            this.Cbx_EstadoPedido.SelectedIndexChanged += new System.EventHandler(this.Cbx_EstadoPedido_SelectedIndexChanged);
            // 
            // Btn_Detalle
            // 
            this.Btn_Detalle.Location = new System.Drawing.Point(517, 26);
            this.Btn_Detalle.Name = "Btn_Detalle";
            this.Btn_Detalle.Size = new System.Drawing.Size(186, 39);
            this.Btn_Detalle.TabIndex = 4;
            this.Btn_Detalle.Text = "Detalles";
            this.Btn_Detalle.UseVisualStyleBackColor = true;
            this.Btn_Detalle.Click += new System.EventHandler(this.Btn_Detalle_Click);
            // 
            // Btn_Exportar
            // 
            this.Btn_Exportar.Location = new System.Drawing.Point(517, 83);
            this.Btn_Exportar.Name = "Btn_Exportar";
            this.Btn_Exportar.Size = new System.Drawing.Size(186, 39);
            this.Btn_Exportar.TabIndex = 5;
            this.Btn_Exportar.Text = "Exportar";
            this.Btn_Exportar.UseVisualStyleBackColor = true;
            this.Btn_Exportar.Click += new System.EventHandler(this.Btn_Exportar_Click);
            // 
            // Lbl_FechaDede
            // 
            this.Lbl_FechaDede.AutoSize = true;
            this.Lbl_FechaDede.Location = new System.Drawing.Point(22, 12);
            this.Lbl_FechaDede.Name = "Lbl_FechaDede";
            this.Lbl_FechaDede.Size = new System.Drawing.Size(89, 16);
            this.Lbl_FechaDede.TabIndex = 6;
            this.Lbl_FechaDede.Text = "Fecha Desde";
            this.Lbl_FechaDede.Click += new System.EventHandler(this.Lbl_FechaDede_Click);
            // 
            // Lbl_FechaHasta
            // 
            this.Lbl_FechaHasta.AutoSize = true;
            this.Lbl_FechaHasta.Location = new System.Drawing.Point(22, 79);
            this.Lbl_FechaHasta.Name = "Lbl_FechaHasta";
            this.Lbl_FechaHasta.Size = new System.Drawing.Size(84, 16);
            this.Lbl_FechaHasta.TabIndex = 7;
            this.Lbl_FechaHasta.Text = "Fecha Hasta";
            this.Lbl_FechaHasta.Click += new System.EventHandler(this.Lbl_FechaHasta_Click);
            // 
            // Lbl_EstadoPedido
            // 
            this.Lbl_EstadoPedido.AutoSize = true;
            this.Lbl_EstadoPedido.Location = new System.Drawing.Point(255, 12);
            this.Lbl_EstadoPedido.Name = "Lbl_EstadoPedido";
            this.Lbl_EstadoPedido.Size = new System.Drawing.Size(129, 16);
            this.Lbl_EstadoPedido.TabIndex = 8;
            this.Lbl_EstadoPedido.Text = "Filtro Estado Pedido";
            this.Lbl_EstadoPedido.Click += new System.EventHandler(this.Lbl_EstadoPedido_Click);
            // 
            // Btn_LimpiarFiltros
            // 
            this.Btn_LimpiarFiltros.Location = new System.Drawing.Point(258, 83);
            this.Btn_LimpiarFiltros.Name = "Btn_LimpiarFiltros";
            this.Btn_LimpiarFiltros.Size = new System.Drawing.Size(186, 39);
            this.Btn_LimpiarFiltros.TabIndex = 9;
            this.Btn_LimpiarFiltros.Text = "Filtrar";
            this.Btn_LimpiarFiltros.UseVisualStyleBackColor = true;
            this.Btn_LimpiarFiltros.Click += new System.EventHandler(this.Btn_LimpiarFiltros_Click);
            // 
            // FormOrdenesPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_LimpiarFiltros);
            this.Controls.Add(this.Lbl_EstadoPedido);
            this.Controls.Add(this.Lbl_FechaHasta);
            this.Controls.Add(this.Lbl_FechaDede);
            this.Controls.Add(this.Btn_Exportar);
            this.Controls.Add(this.Btn_Detalle);
            this.Controls.Add(this.Cbx_EstadoPedido);
            this.Controls.Add(this.Dtp_FechaHasta);
            this.Controls.Add(this.Dtp_FechaDesde);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOrdenesPedidos";
            this.Text = "FormOrdenesPedidos";
            this.Load += new System.EventHandler(this.FormOrdenesPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker Dtp_FechaDesde;
        private System.Windows.Forms.DateTimePicker Dtp_FechaHasta;
        private System.Windows.Forms.ComboBox Cbx_EstadoPedido;
        private System.Windows.Forms.Button Btn_Detalle;
        private System.Windows.Forms.Button Btn_Exportar;
        private System.Windows.Forms.Label Lbl_FechaDede;
        private System.Windows.Forms.Label Lbl_FechaHasta;
        private System.Windows.Forms.Label Lbl_EstadoPedido;
        private System.Windows.Forms.Button Btn_LimpiarFiltros;
    }
}