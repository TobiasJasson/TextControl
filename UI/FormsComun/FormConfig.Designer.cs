namespace UI.FormsComun
{
    partial class FormConfig
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
            this.Switch_modoOscuro = new RJCodeAdvance.RJControls.RJToggleButton();
            this.Lbl_ModoOscuro = new System.Windows.Forms.Label();
            this.Lbl_titleCambiarClave = new System.Windows.Forms.Label();
            this.TxtNuevaClave = new System.Windows.Forms.TextBox();
            this.TxtConfirmarClave = new System.Windows.Forms.TextBox();
            this.BtnCambiarClave = new System.Windows.Forms.Button();
            this.Btn_NuevoMail = new System.Windows.Forms.Button();
            this.Txt_NuevoMail = new System.Windows.Forms.TextBox();
            this.Lbl_titleCambioMail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Switch_modoOscuro
            // 
            this.Switch_modoOscuro.AutoSize = true;
            this.Switch_modoOscuro.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Switch_modoOscuro.Location = new System.Drawing.Point(199, 26);
            this.Switch_modoOscuro.MinimumSize = new System.Drawing.Size(45, 22);
            this.Switch_modoOscuro.Name = "Switch_modoOscuro";
            this.Switch_modoOscuro.OffBackColor = System.Drawing.Color.Gray;
            this.Switch_modoOscuro.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.Switch_modoOscuro.OnBackColor = System.Drawing.Color.MidnightBlue;
            this.Switch_modoOscuro.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.Switch_modoOscuro.Size = new System.Drawing.Size(45, 22);
            this.Switch_modoOscuro.TabIndex = 0;
            this.Switch_modoOscuro.UseVisualStyleBackColor = true;
            this.Switch_modoOscuro.CheckedChanged += new System.EventHandler(this.Switch_modoOscuro_CheckedChanged);
            // 
            // Lbl_ModoOscuro
            // 
            this.Lbl_ModoOscuro.AutoSize = true;
            this.Lbl_ModoOscuro.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ModoOscuro.Location = new System.Drawing.Point(30, 24);
            this.Lbl_ModoOscuro.Name = "Lbl_ModoOscuro";
            this.Lbl_ModoOscuro.Size = new System.Drawing.Size(142, 23);
            this.Lbl_ModoOscuro.TabIndex = 1;
            this.Lbl_ModoOscuro.Text = "Modo Oscuro";
            // 
            // Lbl_titleCambiarClave
            // 
            this.Lbl_titleCambiarClave.AutoSize = true;
            this.Lbl_titleCambiarClave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titleCambiarClave.Location = new System.Drawing.Point(30, 81);
            this.Lbl_titleCambiarClave.Name = "Lbl_titleCambiarClave";
            this.Lbl_titleCambiarClave.Size = new System.Drawing.Size(163, 23);
            this.Lbl_titleCambiarClave.TabIndex = 2;
            this.Lbl_titleCambiarClave.Text = "Cambiar Clave";
            // 
            // TxtNuevaClave
            // 
            this.TxtNuevaClave.BackColor = System.Drawing.Color.White;
            this.TxtNuevaClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNuevaClave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNuevaClave.ForeColor = System.Drawing.Color.Black;
            this.TxtNuevaClave.Location = new System.Drawing.Point(34, 132);
            this.TxtNuevaClave.Name = "TxtNuevaClave";
            this.TxtNuevaClave.Size = new System.Drawing.Size(307, 25);
            this.TxtNuevaClave.TabIndex = 3;
            this.TxtNuevaClave.Text = "Contraseña Nueva";
            this.TxtNuevaClave.TextChanged += new System.EventHandler(this.TxtNuevaClave_TextChanged);
            // 
            // TxtConfirmarClave
            // 
            this.TxtConfirmarClave.BackColor = System.Drawing.Color.White;
            this.TxtConfirmarClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtConfirmarClave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConfirmarClave.ForeColor = System.Drawing.Color.Black;
            this.TxtConfirmarClave.Location = new System.Drawing.Point(34, 181);
            this.TxtConfirmarClave.Name = "TxtConfirmarClave";
            this.TxtConfirmarClave.Size = new System.Drawing.Size(307, 25);
            this.TxtConfirmarClave.TabIndex = 4;
            this.TxtConfirmarClave.Text = "Confirmar Contraseña";
            this.TxtConfirmarClave.TextChanged += new System.EventHandler(this.TxtConfirmarClave_TextChanged);
            // 
            // BtnCambiarClave
            // 
            this.BtnCambiarClave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarClave.Location = new System.Drawing.Point(42, 223);
            this.BtnCambiarClave.Name = "BtnCambiarClave";
            this.BtnCambiarClave.Size = new System.Drawing.Size(202, 43);
            this.BtnCambiarClave.TabIndex = 5;
            this.BtnCambiarClave.Text = "Cambiar Clave";
            this.BtnCambiarClave.UseVisualStyleBackColor = true;
            this.BtnCambiarClave.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_NuevoMail
            // 
            this.Btn_NuevoMail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_NuevoMail.Location = new System.Drawing.Point(42, 404);
            this.Btn_NuevoMail.Name = "Btn_NuevoMail";
            this.Btn_NuevoMail.Size = new System.Drawing.Size(202, 43);
            this.Btn_NuevoMail.TabIndex = 8;
            this.Btn_NuevoMail.Text = "Cambiar Email";
            this.Btn_NuevoMail.UseVisualStyleBackColor = true;
            this.Btn_NuevoMail.Click += new System.EventHandler(this.Btn_NuevoMail_Click);
            // 
            // Txt_NuevoMail
            // 
            this.Txt_NuevoMail.BackColor = System.Drawing.Color.White;
            this.Txt_NuevoMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_NuevoMail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_NuevoMail.ForeColor = System.Drawing.Color.Black;
            this.Txt_NuevoMail.Location = new System.Drawing.Point(42, 362);
            this.Txt_NuevoMail.Name = "Txt_NuevoMail";
            this.Txt_NuevoMail.Size = new System.Drawing.Size(307, 25);
            this.Txt_NuevoMail.TabIndex = 7;
            this.Txt_NuevoMail.Text = "Nuevo Email";
            this.Txt_NuevoMail.TextChanged += new System.EventHandler(this.Txt_NuevoMail_TextChanged);
            // 
            // Lbl_titleCambioMail
            // 
            this.Lbl_titleCambioMail.AutoSize = true;
            this.Lbl_titleCambioMail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titleCambioMail.Location = new System.Drawing.Point(38, 311);
            this.Lbl_titleCambioMail.Name = "Lbl_titleCambioMail";
            this.Lbl_titleCambioMail.Size = new System.Drawing.Size(141, 23);
            this.Lbl_titleCambioMail.TabIndex = 6;
            this.Lbl_titleCambioMail.Text = "Cambiar Mail";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 481);
            this.Controls.Add(this.Btn_NuevoMail);
            this.Controls.Add(this.Txt_NuevoMail);
            this.Controls.Add(this.Lbl_titleCambioMail);
            this.Controls.Add(this.BtnCambiarClave);
            this.Controls.Add(this.TxtConfirmarClave);
            this.Controls.Add(this.TxtNuevaClave);
            this.Controls.Add(this.Lbl_titleCambiarClave);
            this.Controls.Add(this.Lbl_ModoOscuro);
            this.Controls.Add(this.Switch_modoOscuro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfig";
            this.Text = "FormConfig";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJCodeAdvance.RJControls.RJToggleButton Switch_modoOscuro;
        private System.Windows.Forms.Label Lbl_ModoOscuro;
        private System.Windows.Forms.Label Lbl_titleCambiarClave;
        private System.Windows.Forms.TextBox TxtNuevaClave;
        private System.Windows.Forms.TextBox TxtConfirmarClave;
        private System.Windows.Forms.Button BtnCambiarClave;
        private System.Windows.Forms.Button Btn_NuevoMail;
        private System.Windows.Forms.TextBox Txt_NuevoMail;
        private System.Windows.Forms.Label Lbl_titleCambioMail;
    }
}