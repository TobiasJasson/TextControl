namespace UI.FormsComun.Clientes
{
    partial class FormClientes
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
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Btn_Editar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Lbl_EmailCliente = new System.Windows.Forms.Label();
            this.Lbl_ContactoCliente = new System.Windows.Forms.Label();
            this.Lbl_NombreCliente = new System.Windows.Forms.Label();
            this.Txt_EmailCliente = new System.Windows.Forms.TextBox();
            this.Txt_ContactoCliente = new System.Windows.Forms.TextBox();
            this.Txt_NombreCliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(792, 345);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Location = new System.Drawing.Point(12, 12);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(86, 32);
            this.Btn_Agregar.TabIndex = 1;
            this.Btn_Agregar.Text = "Agregar";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.Location = new System.Drawing.Point(118, 12);
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(86, 32);
            this.Btn_Editar.TabIndex = 1;
            this.Btn_Editar.Text = "Editar";
            this.Btn_Editar.UseVisualStyleBackColor = true;
            this.Btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(233, 12);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(86, 32);
            this.Btn_Eliminar.TabIndex = 2;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Lbl_EmailCliente
            // 
            this.Lbl_EmailCliente.AutoSize = true;
            this.Lbl_EmailCliente.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_EmailCliente.Location = new System.Drawing.Point(409, 440);
            this.Lbl_EmailCliente.Name = "Lbl_EmailCliente";
            this.Lbl_EmailCliente.Size = new System.Drawing.Size(62, 23);
            this.Lbl_EmailCliente.TabIndex = 21;
            this.Lbl_EmailCliente.Text = "Email";
            this.Lbl_EmailCliente.Click += new System.EventHandler(this.Lbl_EmailCliente_Click);
            // 
            // Lbl_ContactoCliente
            // 
            this.Lbl_ContactoCliente.AutoSize = true;
            this.Lbl_ContactoCliente.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_ContactoCliente.Location = new System.Drawing.Point(223, 440);
            this.Lbl_ContactoCliente.Name = "Lbl_ContactoCliente";
            this.Lbl_ContactoCliente.Size = new System.Drawing.Size(105, 23);
            this.Lbl_ContactoCliente.TabIndex = 20;
            this.Lbl_ContactoCliente.Text = "Contacto";
            this.Lbl_ContactoCliente.Click += new System.EventHandler(this.Lbl_ContactoCliente_Click);
            // 
            // Lbl_NombreCliente
            // 
            this.Lbl_NombreCliente.AutoSize = true;
            this.Lbl_NombreCliente.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_NombreCliente.Location = new System.Drawing.Point(9, 440);
            this.Lbl_NombreCliente.Name = "Lbl_NombreCliente";
            this.Lbl_NombreCliente.Size = new System.Drawing.Size(90, 23);
            this.Lbl_NombreCliente.TabIndex = 19;
            this.Lbl_NombreCliente.Text = "Nombre";
            this.Lbl_NombreCliente.Click += new System.EventHandler(this.Lbl_NombreEmpleado_Click);
            // 
            // Txt_EmailCliente
            // 
            this.Txt_EmailCliente.Location = new System.Drawing.Point(413, 466);
            this.Txt_EmailCliente.Name = "Txt_EmailCliente";
            this.Txt_EmailCliente.Size = new System.Drawing.Size(150, 22);
            this.Txt_EmailCliente.TabIndex = 18;
            this.Txt_EmailCliente.TextChanged += new System.EventHandler(this.Txt_EmailCliente_TextChanged);
            // 
            // Txt_ContactoCliente
            // 
            this.Txt_ContactoCliente.Location = new System.Drawing.Point(218, 466);
            this.Txt_ContactoCliente.Name = "Txt_ContactoCliente";
            this.Txt_ContactoCliente.Size = new System.Drawing.Size(150, 22);
            this.Txt_ContactoCliente.TabIndex = 17;
            this.Txt_ContactoCliente.TextChanged += new System.EventHandler(this.Txt_ContactoCliente_TextChanged);
            // 
            // Txt_NombreCliente
            // 
            this.Txt_NombreCliente.Location = new System.Drawing.Point(13, 466);
            this.Txt_NombreCliente.Name = "Txt_NombreCliente";
            this.Txt_NombreCliente.Size = new System.Drawing.Size(150, 22);
            this.Txt_NombreCliente.TabIndex = 16;
            this.Txt_NombreCliente.TextChanged += new System.EventHandler(this.Txt_NombreCliente_TextChanged);
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 550);
            this.Controls.Add(this.Lbl_EmailCliente);
            this.Controls.Add(this.Lbl_ContactoCliente);
            this.Controls.Add(this.Lbl_NombreCliente);
            this.Controls.Add(this.Txt_EmailCliente);
            this.Controls.Add(this.Txt_ContactoCliente);
            this.Controls.Add(this.Txt_NombreCliente);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Editar);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormClientes";
            this.Text = "FormClientes";
            this.Load += new System.EventHandler(this.FormClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Button Btn_Editar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Label Lbl_EmailCliente;
        private System.Windows.Forms.Label Lbl_ContactoCliente;
        private System.Windows.Forms.Label Lbl_NombreCliente;
        private System.Windows.Forms.TextBox Txt_EmailCliente;
        private System.Windows.Forms.TextBox Txt_ContactoCliente;
        private System.Windows.Forms.TextBox Txt_NombreCliente;
    }
}