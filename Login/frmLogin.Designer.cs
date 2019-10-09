namespace PalcoNet.Login
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            this.lblCreateUser = new System.Windows.Forms.LinkLabel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.Location = new System.Drawing.Point(85, 179);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(69, 13);
            this.lblCreateUser.TabIndex = 13;
            this.lblCreateUser.TabStop = true;
            this.lblCreateUser.Text = "Crear usuario";
            this.lblCreateUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCreateUser_LinkClicked);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(19, 110);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(19, 53);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 11;
            this.lblUsuario.Text = "Usuario:";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(31, 226);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 10;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(162, 226);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(81, 103);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(81, 46);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 0;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 305);
            this.Controls.Add(this.lblCreateUser);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Name = "frmLogin";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblCreateUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}