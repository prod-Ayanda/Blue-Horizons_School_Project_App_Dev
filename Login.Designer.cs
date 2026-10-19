namespace PROJECTT
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
                        this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.linkRegister2 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.chkLoginShow = new System.Windows.Forms.CheckBox();
            this.lblEmailAdresssViolation = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblLoginPasswordViolation = new System.Windows.Forms.Label();
            this.lblUserViolation = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxaLogo = new System.Windows.Forms.PictureBox();
            this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxaLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtEmailAddress.Location = new System.Drawing.Point(670, 285);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(540, 26);
            this.txtEmailAddress.TabIndex = 4;
            this.txtEmailAddress.TextChanged += new System.EventHandler(this.txtEmailAddress_TextChanged);
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(625, 246);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(124, 20);
            this.lblEmailAddress.TabIndex = 5;
            this.lblEmailAddress.Text = "Email Address";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(625, 384);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(86, 20);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            // 
            // linkForgotPassword
            // 
            this.linkForgotPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkForgotPassword.AutoSize = true;
            this.linkForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.linkForgotPassword.DisabledLinkColor = System.Drawing.Color.Blue;
            this.linkForgotPassword.ForeColor = System.Drawing.Color.Blue;
            this.linkForgotPassword.LinkColor = System.Drawing.Color.Blue;
            this.linkForgotPassword.Location = new System.Drawing.Point(855, 510);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(154, 20);
            this.linkForgotPassword.TabIndex = 8;
            this.linkForgotPassword.TabStop = true;
            this.linkForgotPassword.Text = "Forgot Password?";
            this.linkForgotPassword.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgotPassword_LinkClicked);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogIn.BackColor = System.Drawing.Color.Blue;
            this.btnLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(806, 572);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(248, 46);
            this.btnLogIn.TabIndex = 9;
            this.btnLogIn.Text = " Log In";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(52, 16);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(135, 15);
            this.lblAccount.TabIndex = 10;
            this.lblAccount.Text = "Don\'t have an account?";
            // 
            // linkRegister2
            // 
            this.linkRegister2.AutoSize = true;
            this.linkRegister2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkRegister2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkRegister2.LinkColor = System.Drawing.Color.Blue;
            this.linkRegister2.Location = new System.Drawing.Point(285, 12);
            this.linkRegister2.Name = "linkRegister2";
            this.linkRegister2.Size = new System.Drawing.Size(122, 19);
            this.linkRegister2.TabIndex = 11;
            this.linkRegister2.TabStop = true;
            this.linkRegister2.Text = "Register now! >";
            this.linkRegister2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister2_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblAccount);
            this.panel1.Controls.Add(this.linkRegister2);
            this.panel1.Location = new System.Drawing.Point(685, 668);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 46);
            this.panel1.TabIndex = 12;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLoginPassword.BackColor = System.Drawing.Color.White;
            this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtLoginPassword.Location = new System.Drawing.Point(670, 423);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.Size = new System.Drawing.Size(540, 26);
            this.txtLoginPassword.TabIndex = 4;
            this.txtLoginPassword.TextChanged += new System.EventHandler(this.txtLoginPassword_TextChanged);
            // 
            // chkLoginShow
            // 
            this.chkLoginShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkLoginShow.AutoSize = true;
            this.chkLoginShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLoginShow.Location = new System.Drawing.Point(1073, 393);
            this.chkLoginShow.Name = "chkLoginShow";
            this.chkLoginShow.Size = new System.Drawing.Size(125, 21);
            this.chkLoginShow.TabIndex = 32;
            this.chkLoginShow.Text = "Show password";
            this.chkLoginShow.UseVisualStyleBackColor = true;
            this.chkLoginShow.CheckedChanged += new System.EventHandler(this.chkLoginShow_CheckedChanged);
            // 
            // lblEmailAdresssViolation
            // 
            this.lblEmailAdresssViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmailAdresssViolation.AutoSize = true;
            this.lblEmailAdresssViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAdresssViolation.ForeColor = System.Drawing.Color.Red;
            this.lblEmailAdresssViolation.Location = new System.Drawing.Point(627, 329);
            this.lblEmailAdresssViolation.Name = "lblEmailAdresssViolation";
            this.lblEmailAdresssViolation.Size = new System.Drawing.Size(0, 13);
            this.lblEmailAdresssViolation.TabIndex = 33;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.White;
            this.linkLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(521, 20);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 19);
            this.linkLabel1.TabIndex = 35;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "< Back";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblLoginPasswordViolation
            // 
            this.lblLoginPasswordViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoginPasswordViolation.AutoSize = true;
            this.lblLoginPasswordViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginPasswordViolation.ForeColor = System.Drawing.Color.Red;
            this.lblLoginPasswordViolation.Location = new System.Drawing.Point(627, 467);
            this.lblLoginPasswordViolation.Name = "lblLoginPasswordViolation";
            this.lblLoginPasswordViolation.Size = new System.Drawing.Size(0, 13);
            this.lblLoginPasswordViolation.TabIndex = 37;
            // 
            // lblUserViolation
            // 
            this.lblUserViolation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUserViolation.AutoSize = true;
            this.lblUserViolation.BackColor = System.Drawing.Color.White;
            this.lblUserViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserViolation.ForeColor = System.Drawing.Color.Red;
            this.lblUserViolation.Location = new System.Drawing.Point(627, 572);
            this.lblUserViolation.Name = "lblUserViolation";
            this.lblUserViolation.Size = new System.Drawing.Size(0, 13);
            this.lblUserViolation.TabIndex = 42;
            // 
            // lblLength
            // 
            this.lblLength.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(1084, 456);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(0, 13);
            this.lblLength.TabIndex = 43;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.Location = new System.Drawing.Point(630, 423);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 30);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Location = new System.Drawing.Point(630, 285);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(14, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(501, 739);
            this.panel3.TabIndex = 41;
            // 
            // pictureBoxaLogo
            // 
            this.pictureBoxaLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxaLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxaLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxaLogo.Location = new System.Drawing.Point(764, 43);
            this.pictureBoxaLogo.Name = "pictureBoxaLogo";
            this.pictureBoxaLogo.Size = new System.Drawing.Size(302, 100);
            this.pictureBoxaLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxaLogo.TabIndex = 16;
            this.pictureBoxaLogo.TabStop = false;
            // 
            // object_ec93ebce_c74e_4598_a7d9_58d744e0d435
            // 
            this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435.Location = new System.Drawing.Point(-2, -3);
            this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435.Name = "object_ec93ebce_c74e_4598_a7d9_58d744e0d435";
            this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435.Size = new System.Drawing.Size(44, 29);
            this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435.TabIndex = 17;
            this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(813, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 43);
            this.label1.TabIndex = 44;
            this.label1.Text = "LOG IN ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(802, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 18);
            this.label2.TabIndex = 45;
            this.label2.Text = "Sign in to continue";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(1315, 736);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.lblUserViolation);
            this.Controls.Add(this.txtLoginPassword);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblLoginPasswordViolation);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblEmailAdresssViolation);
            this.Controls.Add(this.chkLoginShow);
            this.Controls.Add(this.pictureBoxaLogo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.linkForgotPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmailAddress);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Visitor Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxaLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.object_ec93ebce_c74e_4598_a7d9_58d744e0d435)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.LinkLabel linkRegister2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.PictureBox pictureBoxaLogo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox chkLoginShow;
        private System.Windows.Forms.Label lblEmailAdresssViolation;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblLoginPasswordViolation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox object_ec93ebce_c74e_4598_a7d9_58d744e0d435;
        private System.Windows.Forms.Label lblUserViolation;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
