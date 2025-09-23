namespace Gestor_Gimnasio
{
    partial class Login
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
            this.LabelUsuario = new System.Windows.Forms.Label();
            this.Button_Ingresar = new System.Windows.Forms.Button();
            this.label_usuario = new System.Windows.Forms.Label();
            this.label_contraseña = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_contrasena = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelUsuario
            // 
            this.LabelUsuario.AutoSize = true;
            this.LabelUsuario.BackColor = System.Drawing.Color.YellowGreen;
            this.LabelUsuario.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUsuario.Location = new System.Drawing.Point(203, 153);
            this.LabelUsuario.Name = "LabelUsuario";
            this.LabelUsuario.Size = new System.Drawing.Size(0, 23);
            this.LabelUsuario.TabIndex = 0;
            this.LabelUsuario.Click += new System.EventHandler(this.label1_Click);
            // 
            // Button_Ingresar
            // 
            this.Button_Ingresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Button_Ingresar.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Ingresar.ForeColor = System.Drawing.Color.White;
            this.Button_Ingresar.Location = new System.Drawing.Point(94, 363);
            this.Button_Ingresar.Name = "Button_Ingresar";
            this.Button_Ingresar.Size = new System.Drawing.Size(150, 47);
            this.Button_Ingresar.TabIndex = 4;
            this.Button_Ingresar.Text = "Ingresar";
            this.Button_Ingresar.UseVisualStyleBackColor = false;
            this.Button_Ingresar.Click += new System.EventHandler(this.Button_Ingresar_Click);
            // 
            // label_usuario
            // 
            this.label_usuario.AutoSize = true;
            this.label_usuario.BackColor = System.Drawing.Color.White;
            this.label_usuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label_usuario.Location = new System.Drawing.Point(45, 148);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(99, 28);
            this.label_usuario.TabIndex = 5;
            this.label_usuario.Text = "USUARIO";
            // 
            // label_contraseña
            // 
            this.label_contraseña.AutoSize = true;
            this.label_contraseña.BackColor = System.Drawing.Color.White;
            this.label_contraseña.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_contraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label_contraseña.Location = new System.Drawing.Point(45, 245);
            this.label_contraseña.Name = "label_contraseña";
            this.label_contraseña.Size = new System.Drawing.Size(146, 28);
            this.label_contraseña.TabIndex = 6;
            this.label_contraseña.Text = "CONTRASEÑA";
            // 
            // txt_user
            // 
            this.txt_user.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.Location = new System.Drawing.Point(49, 174);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(244, 30);
            this.txt_user.TabIndex = 7;
            this.txt_user.TextChanged += new System.EventHandler(this.txt_user_TextChanged);
            this.txt_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_user_KeyPress);
            // 
            // txt_contrasena
            // 
            this.txt_contrasena.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_contrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_contrasena.Location = new System.Drawing.Point(49, 271);
            this.txt_contrasena.Name = "txt_contrasena";
            this.txt_contrasena.PasswordChar = '*';
            this.txt_contrasena.Size = new System.Drawing.Size(244, 30);
            this.txt_contrasena.TabIndex = 8;
            this.txt_contrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_contrasena_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Gestor_Gimnasio.Properties.Resources.gym_image;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(-5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 457);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.BCerrar);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.txt_contrasena);
            this.panel2.Controls.Add(this.txt_user);
            this.panel2.Controls.Add(this.label_usuario);
            this.panel2.Controls.Add(this.label_contraseña);
            this.panel2.Controls.Add(this.Button_Ingresar);
            this.panel2.Location = new System.Drawing.Point(384, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 457);
            this.panel2.TabIndex = 10;
            // 
            // BCerrar
            // 
            this.BCerrar.BackColor = System.Drawing.Color.White;
            this.BCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCerrar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrar.ForeColor = System.Drawing.Color.Red;
            this.BCerrar.Location = new System.Drawing.Point(293, 12);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(28, 26);
            this.BCerrar.TabIndex = 9;
            this.BCerrar.Text = "X";
            this.BCerrar.UseVisualStyleBackColor = false;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(71, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(717, 456);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LabelUsuario);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelUsuario;
        private System.Windows.Forms.Button Button_Ingresar;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.Label label_contraseña;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_contrasena;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BCerrar;
    }
}