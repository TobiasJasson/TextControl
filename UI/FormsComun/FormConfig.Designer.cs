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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNuevaClave = new System.Windows.Forms.TextBox();
            this.TxtConfirmarClave = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_NuevoMail = new System.Windows.Forms.Button();
            this.Txt_NuevoMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modo Oscuro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cambiar Clave";
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(42, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cambiar Clave";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.Txt_NuevoMail.Text = "Email";
            this.Txt_NuevoMail.TextChanged += new System.EventHandler(this.Txt_NuevoMail_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cambiar Mail";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 481);
            this.Controls.Add(this.Btn_NuevoMail);
            this.Controls.Add(this.Txt_NuevoMail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtConfirmarClave);
            this.Controls.Add(this.TxtNuevaClave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNuevaClave;
        private System.Windows.Forms.TextBox TxtConfirmarClave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_NuevoMail;
        private System.Windows.Forms.TextBox Txt_NuevoMail;
        private System.Windows.Forms.Label label3;
    }
}