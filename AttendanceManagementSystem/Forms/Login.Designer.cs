namespace AttendanceManagementSystem
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.link_reg = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.link_login = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chk_show = new System.Windows.Forms.CheckBox();
            this.lbl_login = new System.Windows.Forms.Label();
            this.link_forgetpassword = new System.Windows.Forms.LinkLabel();
            this.txt_newpassword = new System.Windows.Forms.TextBox();
            this.lbl_confirmpassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(70, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            // 
            // lbl_password
            // 
            this.lbl_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_password.Location = new System.Drawing.Point(70, 192);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(0, 17);
            this.lbl_password.TabIndex = 0;
            // 
            // txt_username
            // 
            this.txt_username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Location = new System.Drawing.Point(73, 144);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(219, 26);
            this.txt_username.TabIndex = 1;
            this.txt_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_password
            // 
            this.txt_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(73, 212);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(219, 26);
            this.txt_password.TabIndex = 2;
            this.txt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_password.UseSystemPasswordChar = true;
            this.txt_password.UseWaitCursor = true;
            // 
            // btn_login
            // 
            this.btn_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_login.BackColor = System.Drawing.Color.Snow;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Location = new System.Drawing.Point(104, 331);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(167, 33);
            this.btn_login.TabIndex = 3;
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // link_reg
            // 
            this.link_reg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.link_reg.AutoSize = true;
            this.link_reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_reg.ForeColor = System.Drawing.Color.White;
            this.link_reg.LinkColor = System.Drawing.Color.White;
            this.link_reg.Location = new System.Drawing.Point(70, 364);
            this.link_reg.Name = "link_reg";
            this.link_reg.Size = new System.Drawing.Size(61, 17);
            this.link_reg.TabIndex = 4;
            this.link_reg.TabStop = true;
            this.link_reg.Text = "Register";
            this.link_reg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_reg_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AttendanceManagementSystem.Properties.Resources.download;
            this.pictureBox2.Location = new System.Drawing.Point(25, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(170, 138);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.link_login);
            this.panel2.Controls.Add(this.link_reg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 552);
            this.panel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(227)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 338);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 84);
            this.label3.TabIndex = 8;
            this.label3.Text = "Technological\r\n    University\r\n    (Kyaukse)\r\n";
            // 
            // link_login
            // 
            this.link_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.link_login.AutoSize = true;
            this.link_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_login.ForeColor = System.Drawing.Color.White;
            this.link_login.LinkColor = System.Drawing.Color.White;
            this.link_login.Location = new System.Drawing.Point(70, 398);
            this.link_login.Name = "link_login";
            this.link_login.Size = new System.Drawing.Size(43, 17);
            this.link_login.TabIndex = 4;
            this.link_login.TabStop = true;
            this.link_login.Text = "Login";
            this.link_login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_login_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.chk_show);
            this.panel3.Controls.Add(this.lbl_login);
            this.panel3.Controls.Add(this.link_forgetpassword);
            this.panel3.Controls.Add(this.txt_newpassword);
            this.panel3.Controls.Add(this.txt_password);
            this.panel3.Controls.Add(this.txt_username);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lbl_confirmpassword);
            this.panel3.Controls.Add(this.btn_login);
            this.panel3.Controls.Add(this.lbl_password);
            this.panel3.Location = new System.Drawing.Point(532, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 475);
            this.panel3.TabIndex = 7;
            // 
            // chk_show
            // 
            this.chk_show.AutoSize = true;
            this.chk_show.Location = new System.Drawing.Point(307, 219);
            this.chk_show.Name = "chk_show";
            this.chk_show.Size = new System.Drawing.Size(51, 17);
            this.chk_show.TabIndex = 5;
            this.chk_show.Text = "show";
            this.chk_show.UseVisualStyleBackColor = true;
            this.chk_show.Click += new System.EventHandler(this.chk_show_Click);
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.ForeColor = System.Drawing.Color.Red;
            this.lbl_login.Location = new System.Drawing.Point(67, 63);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(0, 25);
            this.lbl_login.TabIndex = 4;
            // 
            // link_forgetpassword
            // 
            this.link_forgetpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.link_forgetpassword.AutoSize = true;
            this.link_forgetpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_forgetpassword.ForeColor = System.Drawing.Color.DarkRed;
            this.link_forgetpassword.LinkColor = System.Drawing.Color.Maroon;
            this.link_forgetpassword.Location = new System.Drawing.Point(100, 380);
            this.link_forgetpassword.Name = "link_forgetpassword";
            this.link_forgetpassword.Size = new System.Drawing.Size(171, 20);
            this.link_forgetpassword.TabIndex = 4;
            this.link_forgetpassword.TabStop = true;
            this.link_forgetpassword.Text = "Forgot your password?";
            this.link_forgetpassword.Visible = false;
            this.link_forgetpassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_reg_LinkClicked);
            // 
            // txt_newpassword
            // 
            this.txt_newpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_newpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_newpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newpassword.Location = new System.Drawing.Point(73, 282);
            this.txt_newpassword.Name = "txt_newpassword";
            this.txt_newpassword.Size = new System.Drawing.Size(219, 26);
            this.txt_newpassword.TabIndex = 2;
            this.txt_newpassword.UseSystemPasswordChar = true;
            // 
            // lbl_confirmpassword
            // 
            this.lbl_confirmpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_confirmpassword.AutoSize = true;
            this.lbl_confirmpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_confirmpassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_confirmpassword.Location = new System.Drawing.Point(70, 262);
            this.lbl_confirmpassword.Name = "lbl_confirmpassword";
            this.lbl_confirmpassword.Size = new System.Drawing.Size(0, 17);
            this.lbl_confirmpassword.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1349, 552);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.LinkLabel link_reg;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.LinkLabel link_forgetpassword;
        private System.Windows.Forms.TextBox txt_newpassword;
        private System.Windows.Forms.Label lbl_confirmpassword;
        private System.Windows.Forms.LinkLabel link_login;
        private System.Windows.Forms.CheckBox chk_show;
    }
}

