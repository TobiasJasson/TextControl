namespace UI.FormsComun
{
    partial class FormStock
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
            this.DataGrid_Stock = new System.Windows.Forms.DataGridView();
            this.Btn_Exportar = new System.Windows.Forms.Button();
            this.Btn_Editar = new System.Windows.Forms.Button();
            this.Txt_Buscador = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Stock)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid_Stock
            // 
            this.DataGrid_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Stock.Location = new System.Drawing.Point(12, 101);
            this.DataGrid_Stock.Name = "DataGrid_Stock";
            this.DataGrid_Stock.RowHeadersWidth = 51;
            this.DataGrid_Stock.RowTemplate.Height = 24;
            this.DataGrid_Stock.Size = new System.Drawing.Size(758, 325);
            this.DataGrid_Stock.TabIndex = 0;
            this.DataGrid_Stock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_Stock_CellContentClick);
            // 
            // Btn_Exportar
            // 
            this.Btn_Exportar.Location = new System.Drawing.Point(644, 45);
            this.Btn_Exportar.Name = "Btn_Exportar";
            this.Btn_Exportar.Size = new System.Drawing.Size(126, 30);
            this.Btn_Exportar.TabIndex = 1;
            this.Btn_Exportar.Text = "Exportar";
            this.Btn_Exportar.UseVisualStyleBackColor = true;
            this.Btn_Exportar.Click += new System.EventHandler(this.Btn_Exportar_Click);
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.Location = new System.Drawing.Point(440, 45);
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(126, 30);
            this.Btn_Editar.TabIndex = 2;
            this.Btn_Editar.Text = "Editar";
            this.Btn_Editar.UseVisualStyleBackColor = true;
            this.Btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // Txt_Buscador
            // 
            this.Txt_Buscador.Location = new System.Drawing.Point(29, 53);
            this.Txt_Buscador.Name = "Txt_Buscador";
            this.Txt_Buscador.Size = new System.Drawing.Size(242, 22);
            this.Txt_Buscador.TabIndex = 3;
            this.Txt_Buscador.TextChanged += new System.EventHandler(this.Txt_Buscador_TextChanged);
            // 
            // FormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Txt_Buscador);
            this.Controls.Add(this.Btn_Editar);
            this.Controls.Add(this.Btn_Exportar);
            this.Controls.Add(this.DataGrid_Stock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStock";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormStock_Load);
            this.Resize += new System.EventHandler(this.FormStock_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Stock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid_Stock;
        private System.Windows.Forms.Button Btn_Exportar;
        private System.Windows.Forms.Button Btn_Editar;
        private System.Windows.Forms.TextBox Txt_Buscador;
    }
}