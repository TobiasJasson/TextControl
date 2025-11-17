namespace UI.FormsComun.OrdenesPedidos
{
    partial class FormDetallesPedidos
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
            this.Lbl_Pedido = new System.Windows.Forms.Label();
            this.Lbl_PedidoResultado = new System.Windows.Forms.Label();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Lbl_FechaResult = new System.Windows.Forms.Label();
            this.Lbl_Cliente = new System.Windows.Forms.Label();
            this.Lbl_Estado = new System.Windows.Forms.Label();
            this.Lbl_EstadoResult = new System.Windows.Forms.Label();
            this.Lbl_ClienteResult = new System.Windows.Forms.Label();
            this.Lbl_Total = new System.Windows.Forms.Label();
            this.Dgv_DetallePedido = new System.Windows.Forms.DataGridView();
            this.Btn_Volver = new System.Windows.Forms.Button();
            this.Lbl_TotalResult = new System.Windows.Forms.Label();
            this.Lbl_AdelantoResult = new System.Windows.Forms.Label();
            this.Lbl_Adelanto = new System.Windows.Forms.Label();
            this.Lbl_FaltaPagarResult = new System.Windows.Forms.Label();
            this.Lbl_FaltaPagar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DetallePedido)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Pedido
            // 
            this.Lbl_Pedido.AutoSize = true;
            this.Lbl_Pedido.Location = new System.Drawing.Point(5, 31);
            this.Lbl_Pedido.Name = "Lbl_Pedido";
            this.Lbl_Pedido.Size = new System.Drawing.Size(54, 16);
            this.Lbl_Pedido.TabIndex = 0;
            this.Lbl_Pedido.Text = "Pedido ";
            // 
            // Lbl_PedidoResultado
            // 
            this.Lbl_PedidoResultado.AutoSize = true;
            this.Lbl_PedidoResultado.Location = new System.Drawing.Point(83, 31);
            this.Lbl_PedidoResultado.Name = "Lbl_PedidoResultado";
            this.Lbl_PedidoResultado.Size = new System.Drawing.Size(54, 16);
            this.Lbl_PedidoResultado.TabIndex = 1;
            this.Lbl_PedidoResultado.Text = "Pedido ";
            this.Lbl_PedidoResultado.Click += new System.EventHandler(this.Lbl_PedidoResultado_Click);
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Location = new System.Drawing.Point(5, 76);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(48, 16);
            this.Lbl_Fecha.TabIndex = 2;
            this.Lbl_Fecha.Text = "Fecha:";
            this.Lbl_Fecha.Click += new System.EventHandler(this.Lbl_Fecha_Click);
            // 
            // Lbl_FechaResult
            // 
            this.Lbl_FechaResult.AutoSize = true;
            this.Lbl_FechaResult.Location = new System.Drawing.Point(83, 76);
            this.Lbl_FechaResult.Name = "Lbl_FechaResult";
            this.Lbl_FechaResult.Size = new System.Drawing.Size(54, 16);
            this.Lbl_FechaResult.TabIndex = 3;
            this.Lbl_FechaResult.Text = "Pedido ";
            this.Lbl_FechaResult.Click += new System.EventHandler(this.Lbl_FechaResult_Click);
            // 
            // Lbl_Cliente
            // 
            this.Lbl_Cliente.AutoSize = true;
            this.Lbl_Cliente.Location = new System.Drawing.Point(191, 31);
            this.Lbl_Cliente.Name = "Lbl_Cliente";
            this.Lbl_Cliente.Size = new System.Drawing.Size(48, 16);
            this.Lbl_Cliente.TabIndex = 4;
            this.Lbl_Cliente.Text = "Cliente";
            this.Lbl_Cliente.Click += new System.EventHandler(this.Lbl_Cliente_Click);
            // 
            // Lbl_Estado
            // 
            this.Lbl_Estado.AutoSize = true;
            this.Lbl_Estado.Location = new System.Drawing.Point(191, 76);
            this.Lbl_Estado.Name = "Lbl_Estado";
            this.Lbl_Estado.Size = new System.Drawing.Size(53, 16);
            this.Lbl_Estado.TabIndex = 5;
            this.Lbl_Estado.Text = "Estado:";
            this.Lbl_Estado.Click += new System.EventHandler(this.Lbl_Estado_Click);
            // 
            // Lbl_EstadoResult
            // 
            this.Lbl_EstadoResult.AutoSize = true;
            this.Lbl_EstadoResult.Location = new System.Drawing.Point(313, 76);
            this.Lbl_EstadoResult.Name = "Lbl_EstadoResult";
            this.Lbl_EstadoResult.Size = new System.Drawing.Size(54, 16);
            this.Lbl_EstadoResult.TabIndex = 6;
            this.Lbl_EstadoResult.Text = "Pedido ";
            this.Lbl_EstadoResult.Click += new System.EventHandler(this.Lbl_EstadoResult_Click);
            // 
            // Lbl_ClienteResult
            // 
            this.Lbl_ClienteResult.AutoSize = true;
            this.Lbl_ClienteResult.Location = new System.Drawing.Point(313, 31);
            this.Lbl_ClienteResult.Name = "Lbl_ClienteResult";
            this.Lbl_ClienteResult.Size = new System.Drawing.Size(54, 16);
            this.Lbl_ClienteResult.TabIndex = 7;
            this.Lbl_ClienteResult.Text = "Pedido ";
            this.Lbl_ClienteResult.Click += new System.EventHandler(this.Lbl_ClienteResult_Click);
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.AutoSize = true;
            this.Lbl_Total.Location = new System.Drawing.Point(430, 10);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(38, 16);
            this.Lbl_Total.TabIndex = 8;
            this.Lbl_Total.Text = "Total";
            this.Lbl_Total.Click += new System.EventHandler(this.Lbl_Total_Click);
            // 
            // Dgv_DetallePedido
            // 
            this.Dgv_DetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_DetallePedido.Location = new System.Drawing.Point(8, 121);
            this.Dgv_DetallePedido.Name = "Dgv_DetallePedido";
            this.Dgv_DetallePedido.RowHeadersWidth = 51;
            this.Dgv_DetallePedido.RowTemplate.Height = 24;
            this.Dgv_DetallePedido.Size = new System.Drawing.Size(790, 317);
            this.Dgv_DetallePedido.TabIndex = 9;
            this.Dgv_DetallePedido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_DetallePedido_CellContentClick);
            // 
            // Btn_Volver
            // 
            this.Btn_Volver.Location = new System.Drawing.Point(709, 41);
            this.Btn_Volver.Name = "Btn_Volver";
            this.Btn_Volver.Size = new System.Drawing.Size(89, 36);
            this.Btn_Volver.TabIndex = 10;
            this.Btn_Volver.Text = "Volver";
            this.Btn_Volver.UseVisualStyleBackColor = true;
            this.Btn_Volver.Click += new System.EventHandler(this.Btn_Volver_Click);
            // 
            // Lbl_TotalResult
            // 
            this.Lbl_TotalResult.AutoSize = true;
            this.Lbl_TotalResult.Location = new System.Drawing.Point(581, 10);
            this.Lbl_TotalResult.Name = "Lbl_TotalResult";
            this.Lbl_TotalResult.Size = new System.Drawing.Size(54, 16);
            this.Lbl_TotalResult.TabIndex = 11;
            this.Lbl_TotalResult.Text = "Pedido ";
            this.Lbl_TotalResult.Click += new System.EventHandler(this.Lbl_TotalResult_Click);
            // 
            // Lbl_AdelantoResult
            // 
            this.Lbl_AdelantoResult.AutoSize = true;
            this.Lbl_AdelantoResult.Location = new System.Drawing.Point(581, 51);
            this.Lbl_AdelantoResult.Name = "Lbl_AdelantoResult";
            this.Lbl_AdelantoResult.Size = new System.Drawing.Size(54, 16);
            this.Lbl_AdelantoResult.TabIndex = 13;
            this.Lbl_AdelantoResult.Text = "Pedido ";
            this.Lbl_AdelantoResult.Click += new System.EventHandler(this.Lbl_AdelantoResult_Click);
            // 
            // Lbl_Adelanto
            // 
            this.Lbl_Adelanto.AutoSize = true;
            this.Lbl_Adelanto.Location = new System.Drawing.Point(430, 51);
            this.Lbl_Adelanto.Name = "Lbl_Adelanto";
            this.Lbl_Adelanto.Size = new System.Drawing.Size(38, 16);
            this.Lbl_Adelanto.TabIndex = 12;
            this.Lbl_Adelanto.Text = "Total";
            // 
            // Lbl_FaltaPagarResult
            // 
            this.Lbl_FaltaPagarResult.AutoSize = true;
            this.Lbl_FaltaPagarResult.Location = new System.Drawing.Point(581, 93);
            this.Lbl_FaltaPagarResult.Name = "Lbl_FaltaPagarResult";
            this.Lbl_FaltaPagarResult.Size = new System.Drawing.Size(54, 16);
            this.Lbl_FaltaPagarResult.TabIndex = 15;
            this.Lbl_FaltaPagarResult.Text = "Pedido ";
            this.Lbl_FaltaPagarResult.Click += new System.EventHandler(this.Lbl_FaltaPagarResult_Click);
            // 
            // Lbl_FaltaPagar
            // 
            this.Lbl_FaltaPagar.AutoSize = true;
            this.Lbl_FaltaPagar.Location = new System.Drawing.Point(430, 93);
            this.Lbl_FaltaPagar.Name = "Lbl_FaltaPagar";
            this.Lbl_FaltaPagar.Size = new System.Drawing.Size(38, 16);
            this.Lbl_FaltaPagar.TabIndex = 14;
            this.Lbl_FaltaPagar.Text = "Total";
            // 
            // FormDetallesPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Lbl_FaltaPagarResult);
            this.Controls.Add(this.Lbl_FaltaPagar);
            this.Controls.Add(this.Lbl_AdelantoResult);
            this.Controls.Add(this.Lbl_Adelanto);
            this.Controls.Add(this.Lbl_TotalResult);
            this.Controls.Add(this.Btn_Volver);
            this.Controls.Add(this.Dgv_DetallePedido);
            this.Controls.Add(this.Lbl_Total);
            this.Controls.Add(this.Lbl_ClienteResult);
            this.Controls.Add(this.Lbl_EstadoResult);
            this.Controls.Add(this.Lbl_Estado);
            this.Controls.Add(this.Lbl_Cliente);
            this.Controls.Add(this.Lbl_FechaResult);
            this.Controls.Add(this.Lbl_Fecha);
            this.Controls.Add(this.Lbl_PedidoResultado);
            this.Controls.Add(this.Lbl_Pedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDetallesPedidos";
            this.Text = "FormDetallesPedidos";
            this.Load += new System.EventHandler(this.FormDetallesPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DetallePedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Pedido;
        private System.Windows.Forms.Label Lbl_PedidoResultado;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.Label Lbl_FechaResult;
        private System.Windows.Forms.Label Lbl_Cliente;
        private System.Windows.Forms.Label Lbl_Estado;
        private System.Windows.Forms.Label Lbl_EstadoResult;
        private System.Windows.Forms.Label Lbl_ClienteResult;
        private System.Windows.Forms.Label Lbl_Total;
        private System.Windows.Forms.DataGridView Dgv_DetallePedido;
        private System.Windows.Forms.Button Btn_Volver;
        private System.Windows.Forms.Label Lbl_TotalResult;
        private System.Windows.Forms.Label Lbl_AdelantoResult;
        private System.Windows.Forms.Label Lbl_Adelanto;
        private System.Windows.Forms.Label Lbl_FaltaPagarResult;
        private System.Windows.Forms.Label Lbl_FaltaPagar;
    }
}