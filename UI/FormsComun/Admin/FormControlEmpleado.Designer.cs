namespace UI.FormsComun.Admin
{
    partial class FormControlEmpleado
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
            this.Txt_NombreEmpleado = new System.Windows.Forms.TextBox();
            this.Txt_ApellidoEmpleado = new System.Windows.Forms.TextBox();
            this.Txt_DniEmpleado = new System.Windows.Forms.TextBox();
            this.Txt_EmailEmpleado = new System.Windows.Forms.TextBox();
            this.Txt_NumeroEmpleado = new System.Windows.Forms.TextBox();
            this.Cbx_RolEmpleado = new System.Windows.Forms.ComboBox();
            this.Switch_Activo = new RJCodeAdvance.RJControls.RJToggleButton();
            this.Lbl_Activo = new System.Windows.Forms.Label();
            this.Btn_GuardarEmpleado = new System.Windows.Forms.Button();
            this.Lbl_NombreEmpleado = new System.Windows.Forms.Label();
            this.Lbl_ApellidoEmpleado = new System.Windows.Forms.Label();
            this.Lbl_DniEmpleado = new System.Windows.Forms.Label();
            this.Lbl_Email = new System.Windows.Forms.Label();
            this.Lbl_NumeroEmpleado = new System.Windows.Forms.Label();
            this.Lbl_RolEmpleado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 229);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Location = new System.Drawing.Point(24, 21);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(96, 33);
            this.Btn_Agregar.TabIndex = 1;
            this.Btn_Agregar.Text = "Agregar ➕";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.Location = new System.Drawing.Point(159, 21);
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(96, 33);
            this.Btn_Editar.TabIndex = 2;
            this.Btn_Editar.Text = "Editar ✏";
            this.Btn_Editar.UseVisualStyleBackColor = true;
            this.Btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(301, 21);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(96, 33);
            this.Btn_Eliminar.TabIndex = 3;
            this.Btn_Eliminar.Text = "Eliminar 🗑";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Txt_NombreEmpleado
            // 
            this.Txt_NombreEmpleado.Location = new System.Drawing.Point(12, 352);
            this.Txt_NombreEmpleado.Name = "Txt_NombreEmpleado";
            this.Txt_NombreEmpleado.Size = new System.Drawing.Size(150, 22);
            this.Txt_NombreEmpleado.TabIndex = 4;
            this.Txt_NombreEmpleado.TextChanged += new System.EventHandler(this.Txt_NombreEmpleado_TextChanged);
            // 
            // Txt_ApellidoEmpleado
            // 
            this.Txt_ApellidoEmpleado.Location = new System.Drawing.Point(217, 352);
            this.Txt_ApellidoEmpleado.Name = "Txt_ApellidoEmpleado";
            this.Txt_ApellidoEmpleado.Size = new System.Drawing.Size(150, 22);
            this.Txt_ApellidoEmpleado.TabIndex = 5;
            this.Txt_ApellidoEmpleado.TextChanged += new System.EventHandler(this.Txt_ApellidoEmpleado_TextChanged);
            // 
            // Txt_DniEmpleado
            // 
            this.Txt_DniEmpleado.Location = new System.Drawing.Point(412, 352);
            this.Txt_DniEmpleado.Name = "Txt_DniEmpleado";
            this.Txt_DniEmpleado.Size = new System.Drawing.Size(150, 22);
            this.Txt_DniEmpleado.TabIndex = 6;
            this.Txt_DniEmpleado.TextChanged += new System.EventHandler(this.Txt_DniEmpleado_TextChanged);
            // 
            // Txt_EmailEmpleado
            // 
            this.Txt_EmailEmpleado.Location = new System.Drawing.Point(638, 352);
            this.Txt_EmailEmpleado.Name = "Txt_EmailEmpleado";
            this.Txt_EmailEmpleado.Size = new System.Drawing.Size(150, 22);
            this.Txt_EmailEmpleado.TabIndex = 7;
            this.Txt_EmailEmpleado.TextChanged += new System.EventHandler(this.Txt_EmailEmpleado_TextChanged);
            // 
            // Txt_NumeroEmpleado
            // 
            this.Txt_NumeroEmpleado.Location = new System.Drawing.Point(12, 416);
            this.Txt_NumeroEmpleado.Name = "Txt_NumeroEmpleado";
            this.Txt_NumeroEmpleado.Size = new System.Drawing.Size(150, 22);
            this.Txt_NumeroEmpleado.TabIndex = 8;
            this.Txt_NumeroEmpleado.TextChanged += new System.EventHandler(this.Txt_NumeroEmpleado_TextChanged);
            // 
            // Cbx_RolEmpleado
            // 
            this.Cbx_RolEmpleado.FormattingEnabled = true;
            this.Cbx_RolEmpleado.Location = new System.Drawing.Point(217, 414);
            this.Cbx_RolEmpleado.Name = "Cbx_RolEmpleado";
            this.Cbx_RolEmpleado.Size = new System.Drawing.Size(150, 24);
            this.Cbx_RolEmpleado.TabIndex = 9;
            this.Cbx_RolEmpleado.SelectedIndexChanged += new System.EventHandler(this.Cbx_RolEmpleado_SelectedIndexChanged);
            // 
            // Switch_Activo
            // 
            this.Switch_Activo.AutoSize = true;
            this.Switch_Activo.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Switch_Activo.Location = new System.Drawing.Point(517, 414);
            this.Switch_Activo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Switch_Activo.MinimumSize = new System.Drawing.Size(45, 22);
            this.Switch_Activo.Name = "Switch_Activo";
            this.Switch_Activo.OffBackColor = System.Drawing.Color.Gray;
            this.Switch_Activo.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.Switch_Activo.OnBackColor = System.Drawing.Color.MidnightBlue;
            this.Switch_Activo.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.Switch_Activo.Size = new System.Drawing.Size(45, 22);
            this.Switch_Activo.TabIndex = 10;
            this.Switch_Activo.UseVisualStyleBackColor = true;
            this.Switch_Activo.CheckedChanged += new System.EventHandler(this.Switch_Activo_CheckedChanged);
            // 
            // Lbl_Activo
            // 
            this.Lbl_Activo.AutoSize = true;
            this.Lbl_Activo.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_Activo.Location = new System.Drawing.Point(408, 411);
            this.Lbl_Activo.Name = "Lbl_Activo";
            this.Lbl_Activo.Size = new System.Drawing.Size(74, 23);
            this.Lbl_Activo.TabIndex = 11;
            this.Lbl_Activo.Text = "Activo";
            this.Lbl_Activo.Click += new System.EventHandler(this.Lbl_Activo_Click);
            // 
            // Btn_GuardarEmpleado
            // 
            this.Btn_GuardarEmpleado.Location = new System.Drawing.Point(671, 405);
            this.Btn_GuardarEmpleado.Name = "Btn_GuardarEmpleado";
            this.Btn_GuardarEmpleado.Size = new System.Drawing.Size(96, 33);
            this.Btn_GuardarEmpleado.TabIndex = 12;
            this.Btn_GuardarEmpleado.Text = "Guardar";
            this.Btn_GuardarEmpleado.UseVisualStyleBackColor = true;
            this.Btn_GuardarEmpleado.Click += new System.EventHandler(this.Btn_GuardarEmpleado_Click);
            // 
            // Lbl_NombreEmpleado
            // 
            this.Lbl_NombreEmpleado.AutoSize = true;
            this.Lbl_NombreEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_NombreEmpleado.Location = new System.Drawing.Point(8, 326);
            this.Lbl_NombreEmpleado.Name = "Lbl_NombreEmpleado";
            this.Lbl_NombreEmpleado.Size = new System.Drawing.Size(90, 23);
            this.Lbl_NombreEmpleado.TabIndex = 13;
            this.Lbl_NombreEmpleado.Text = "Nombre";
            this.Lbl_NombreEmpleado.Click += new System.EventHandler(this.Lbl_NombreEmpleado_Click);
            // 
            // Lbl_ApellidoEmpleado
            // 
            this.Lbl_ApellidoEmpleado.AutoSize = true;
            this.Lbl_ApellidoEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_ApellidoEmpleado.Location = new System.Drawing.Point(222, 326);
            this.Lbl_ApellidoEmpleado.Name = "Lbl_ApellidoEmpleado";
            this.Lbl_ApellidoEmpleado.Size = new System.Drawing.Size(92, 23);
            this.Lbl_ApellidoEmpleado.TabIndex = 14;
            this.Lbl_ApellidoEmpleado.Text = "Apellido";
            this.Lbl_ApellidoEmpleado.Click += new System.EventHandler(this.Lbl_ApellidoEmpleado_Click);
            // 
            // Lbl_DniEmpleado
            // 
            this.Lbl_DniEmpleado.AutoSize = true;
            this.Lbl_DniEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_DniEmpleado.Location = new System.Drawing.Point(408, 326);
            this.Lbl_DniEmpleado.Name = "Lbl_DniEmpleado";
            this.Lbl_DniEmpleado.Size = new System.Drawing.Size(45, 23);
            this.Lbl_DniEmpleado.TabIndex = 15;
            this.Lbl_DniEmpleado.Text = "DNI";
            this.Lbl_DniEmpleado.Click += new System.EventHandler(this.Lbl_DniEmpleado_Click);
            // 
            // Lbl_Email
            // 
            this.Lbl_Email.AutoSize = true;
            this.Lbl_Email.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_Email.Location = new System.Drawing.Point(634, 326);
            this.Lbl_Email.Name = "Lbl_Email";
            this.Lbl_Email.Size = new System.Drawing.Size(62, 23);
            this.Lbl_Email.TabIndex = 16;
            this.Lbl_Email.Text = "Email";
            this.Lbl_Email.Click += new System.EventHandler(this.Lbl_Email_Click);
            // 
            // Lbl_NumeroEmpleado
            // 
            this.Lbl_NumeroEmpleado.AutoSize = true;
            this.Lbl_NumeroEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_NumeroEmpleado.Location = new System.Drawing.Point(8, 390);
            this.Lbl_NumeroEmpleado.Name = "Lbl_NumeroEmpleado";
            this.Lbl_NumeroEmpleado.Size = new System.Drawing.Size(88, 23);
            this.Lbl_NumeroEmpleado.TabIndex = 17;
            this.Lbl_NumeroEmpleado.Text = "Numero";
            this.Lbl_NumeroEmpleado.Click += new System.EventHandler(this.Lbl_NumeroEmpleado_Click);
            // 
            // Lbl_RolEmpleado
            // 
            this.Lbl_RolEmpleado.AutoSize = true;
            this.Lbl_RolEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Lbl_RolEmpleado.Location = new System.Drawing.Point(216, 388);
            this.Lbl_RolEmpleado.Name = "Lbl_RolEmpleado";
            this.Lbl_RolEmpleado.Size = new System.Drawing.Size(40, 23);
            this.Lbl_RolEmpleado.TabIndex = 18;
            this.Lbl_RolEmpleado.Text = "Rol";
            this.Lbl_RolEmpleado.Click += new System.EventHandler(this.Lbl_RolEmpleado_Click);
            // 
            // FormControlEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Lbl_RolEmpleado);
            this.Controls.Add(this.Lbl_NumeroEmpleado);
            this.Controls.Add(this.Lbl_Email);
            this.Controls.Add(this.Lbl_DniEmpleado);
            this.Controls.Add(this.Lbl_ApellidoEmpleado);
            this.Controls.Add(this.Lbl_NombreEmpleado);
            this.Controls.Add(this.Btn_GuardarEmpleado);
            this.Controls.Add(this.Lbl_Activo);
            this.Controls.Add(this.Switch_Activo);
            this.Controls.Add(this.Cbx_RolEmpleado);
            this.Controls.Add(this.Txt_NumeroEmpleado);
            this.Controls.Add(this.Txt_EmailEmpleado);
            this.Controls.Add(this.Txt_DniEmpleado);
            this.Controls.Add(this.Txt_ApellidoEmpleado);
            this.Controls.Add(this.Txt_NombreEmpleado);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Editar);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormControlEmpleado";
            this.Text = "FormControlEmpleado";
            this.Load += new System.EventHandler(this.FormControlEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Button Btn_Editar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.TextBox Txt_NombreEmpleado;
        private System.Windows.Forms.TextBox Txt_ApellidoEmpleado;
        private System.Windows.Forms.TextBox Txt_DniEmpleado;
        private System.Windows.Forms.TextBox Txt_EmailEmpleado;
        private System.Windows.Forms.TextBox Txt_NumeroEmpleado;
        private System.Windows.Forms.ComboBox Cbx_RolEmpleado;
        private RJCodeAdvance.RJControls.RJToggleButton Switch_Activo;
        private System.Windows.Forms.Label Lbl_Activo;
        private System.Windows.Forms.Button Btn_GuardarEmpleado;
        private System.Windows.Forms.Label Lbl_NombreEmpleado;
        private System.Windows.Forms.Label Lbl_ApellidoEmpleado;
        private System.Windows.Forms.Label Lbl_DniEmpleado;
        private System.Windows.Forms.Label Lbl_Email;
        private System.Windows.Forms.Label Lbl_NumeroEmpleado;
        private System.Windows.Forms.Label Lbl_RolEmpleado;
    }
}