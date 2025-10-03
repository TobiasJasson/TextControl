namespace UI
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.TxtNameUser = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.Btn_Ingresar = new System.Windows.Forms.Button();
            this.LiL_RecuperarPass = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.Btn_Cerrar = new System.Windows.Forms.Button();
            this.Btn_Minimize = new System.Windows.Forms.Button();
            this.ChBox_MostrarContraseña = new System.Windows.Forms.CheckBox();
            this.BtnCambiarIdioma = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNameUser
            // 
            this.TxtNameUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.TxtNameUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNameUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNameUser.ForeColor = System.Drawing.Color.Silver;
            this.TxtNameUser.Location = new System.Drawing.Point(326, 75);
            this.TxtNameUser.Name = "TxtNameUser";
            this.TxtNameUser.Size = new System.Drawing.Size(307, 25);
            this.TxtNameUser.TabIndex = 1;
            this.TxtNameUser.Text = "Usuario";
            this.TxtNameUser.TextChanged += new System.EventHandler(this.TxtNameUser_TextChanged);
            this.TxtNameUser.Enter += new System.EventHandler(this.TxtNameUser_Enter);
            this.TxtNameUser.Leave += new System.EventHandler(this.TxtNameUser_Leave);
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.ForeColor = System.Drawing.Color.Silver;
            this.TxtPassword.Location = new System.Drawing.Point(326, 154);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(307, 25);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.Text = "Contraseña";
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            this.TxtPassword.Enter += new System.EventHandler(this.TxtPassword_Enter);
            this.TxtPassword.Leave += new System.EventHandler(this.TxtPassword_Leave);
            // 
            // Btn_Ingresar
            // 
            this.Btn_Ingresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.Btn_Ingresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.Btn_Ingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Btn_Ingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.Btn_Ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ingresar.ForeColor = System.Drawing.Color.LightGray;
            this.Btn_Ingresar.Location = new System.Drawing.Point(301, 236);
            this.Btn_Ingresar.Name = "Btn_Ingresar";
            this.Btn_Ingresar.Size = new System.Drawing.Size(356, 40);
            this.Btn_Ingresar.TabIndex = 4;
            this.Btn_Ingresar.Text = "INGRESAR";
            this.Btn_Ingresar.UseVisualStyleBackColor = false;
            this.Btn_Ingresar.Click += new System.EventHandler(this.Btn_Ingresar_Click);
            // 
            // LiL_RecuperarPass
            // 
            this.LiL_RecuperarPass.AutoSize = true;
            this.LiL_RecuperarPass.LinkColor = System.Drawing.Color.Silver;
            this.LiL_RecuperarPass.Location = new System.Drawing.Point(339, 295);
            this.LiL_RecuperarPass.Name = "LiL_RecuperarPass";
            this.LiL_RecuperarPass.Size = new System.Drawing.Size(148, 16);
            this.LiL_RecuperarPass.TabIndex = 0;
            this.LiL_RecuperarPass.TabStop = true;
            this.LiL_RecuperarPass.Text = "¿Ha olvidado su clave?";
            this.LiL_RecuperarPass.VisitedLinkColor = System.Drawing.Color.Silver;
            this.LiL_RecuperarPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LiL_RecuperarPass_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 331);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(326, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(306, 1);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(327, 182);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(306, 1);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Silver;
            this.lblTitulo.Location = new System.Drawing.Point(445, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(103, 34);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "LOGIN";
            // 
            // Btn_Cerrar
            // 
            this.Btn_Cerrar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Btn_Cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cerrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cerrar.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Cerrar.Location = new System.Drawing.Point(745, 0);
            this.Btn_Cerrar.Name = "Btn_Cerrar";
            this.Btn_Cerrar.Size = new System.Drawing.Size(37, 43);
            this.Btn_Cerrar.TabIndex = 8;
            this.Btn_Cerrar.Text = "X";
            this.Btn_Cerrar.UseVisualStyleBackColor = true;
            this.Btn_Cerrar.Click += new System.EventHandler(this.Btn_Cerrar_Click);
            // 
            // Btn_Minimize
            // 
            this.Btn_Minimize.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Btn_Minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Btn_Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.Btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Minimize.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Minimize.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Minimize.Location = new System.Drawing.Point(702, 0);
            this.Btn_Minimize.Name = "Btn_Minimize";
            this.Btn_Minimize.Size = new System.Drawing.Size(37, 43);
            this.Btn_Minimize.TabIndex = 9;
            this.Btn_Minimize.Text = "-";
            this.Btn_Minimize.UseVisualStyleBackColor = true;
            this.Btn_Minimize.Click += new System.EventHandler(this.Btn_Minimize_Click);
            // 
            // ChBox_MostrarContraseña
            // 
            this.ChBox_MostrarContraseña.AutoSize = true;
            this.ChBox_MostrarContraseña.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChBox_MostrarContraseña.ForeColor = System.Drawing.Color.Silver;
            this.ChBox_MostrarContraseña.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChBox_MostrarContraseña.Location = new System.Drawing.Point(327, 205);
            this.ChBox_MostrarContraseña.Name = "ChBox_MostrarContraseña";
            this.ChBox_MostrarContraseña.Size = new System.Drawing.Size(197, 25);
            this.ChBox_MostrarContraseña.TabIndex = 3;
            this.ChBox_MostrarContraseña.Text = "Mostrar contraseña";
            this.ChBox_MostrarContraseña.UseVisualStyleBackColor = true;
            this.ChBox_MostrarContraseña.CheckedChanged += new System.EventHandler(this.ChBox_MostrarContraseña_CheckedChanged);
            // 
            // BtnCambiarIdioma
            // 
            this.BtnCambiarIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.BtnCambiarIdioma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.BtnCambiarIdioma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BtnCambiarIdioma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.BtnCambiarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambiarIdioma.ForeColor = System.Drawing.Color.LightGray;
            this.BtnCambiarIdioma.Location = new System.Drawing.Point(692, 283);
            this.BtnCambiarIdioma.Name = "BtnCambiarIdioma";
            this.BtnCambiarIdioma.Size = new System.Drawing.Size(76, 40);
            this.BtnCambiarIdioma.TabIndex = 10;
            this.BtnCambiarIdioma.Text = "ES-AR";
            this.BtnCambiarIdioma.UseVisualStyleBackColor = false;
            this.BtnCambiarIdioma.Click += new System.EventHandler(this.BtnCambiarIdioma_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(780, 330);
            this.Controls.Add(this.BtnCambiarIdioma);
            this.Controls.Add(this.ChBox_MostrarContraseña);
            this.Controls.Add(this.Btn_Minimize);
            this.Controls.Add(this.Btn_Cerrar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LiL_RecuperarPass);
            this.Controls.Add(this.Btn_Ingresar);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtNameUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextControl";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNameUser;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button Btn_Ingresar;
        private System.Windows.Forms.LinkLabel LiL_RecuperarPass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button Btn_Cerrar;
        private System.Windows.Forms.Button Btn_Minimize;
        private System.Windows.Forms.CheckBox ChBox_MostrarContraseña;
        private System.Windows.Forms.Button BtnCambiarIdioma;
    }
}

