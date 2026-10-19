namespace PROJECTT
{
    partial class frmAdminLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
                        this.panelCard = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblSubHeading = new System.Windows.Forms.Label();
            this.lblAdminEmail = new System.Windows.Forms.Label();
            this.txtAdminEmail = new System.Windows.Forms.TextBox();
            this.lblAdminEmailViolation = new System.Windows.Forms.Label();
            this.lblAdminPassword = new System.Windows.Forms.Label();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.lblAdminPasswordViolation = new System.Windows.Forms.Label();
            this.chkAdminShow = new System.Windows.Forms.CheckBox();
            this.btnAdminLogIn = new System.Windows.Forms.Button();
            this.linkAdminBack = new System.Windows.Forms.LinkLabel();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.lblHeading);
            this.panelCard.Controls.Add(this.lblSubHeading);
            this.panelCard.Controls.Add(this.lblAdminEmail);
            this.panelCard.Controls.Add(this.txtAdminEmail);
            this.panelCard.Controls.Add(this.lblAdminEmailViolation);
            this.panelCard.Controls.Add(this.lblAdminPassword);
            this.panelCard.Controls.Add(this.txtAdminPassword);
            this.panelCard.Controls.Add(this.lblAdminPasswordViolation);
            this.panelCard.Controls.Add(this.chkAdminShow);
            this.panelCard.Controls.Add(this.btnAdminLogIn);
            this.panelCard.Location = new System.Drawing.Point(204, 60);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(560, 480);
            this.panelCard.TabIndex = 0;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lblHeading.Location = new System.Drawing.Point(30, 28);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(264, 39);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "ADMIN LOG IN";
            // 
            // lblSubHeading
            // 
            this.lblSubHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubHeading.ForeColor = System.Drawing.Color.Firebrick;
            this.lblSubHeading.Location = new System.Drawing.Point(33, 76);
            this.lblSubHeading.Name = "lblSubHeading";
            this.lblSubHeading.Size = new System.Drawing.Size(490, 30);
            this.lblSubHeading.TabIndex = 1;
            this.lblSubHeading.Text = "Passkey accepted. Please sign in with the admin account.";
            // 
            // lblAdminEmail
            // 
            this.lblAdminEmail.AutoSize = true;
            this.lblAdminEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminEmail.Location = new System.Drawing.Point(33, 124);
            this.lblAdminEmail.Name = "lblAdminEmail";
            this.lblAdminEmail.Size = new System.Drawing.Size(138, 25);
            this.lblAdminEmail.TabIndex = 2;
            this.lblAdminEmail.Text = "Email Address";
            // 
            // txtAdminEmail
            // 
            this.txtAdminEmail.Location = new System.Drawing.Point(38, 154);
            this.txtAdminEmail.Name = "txtAdminEmail";
            this.txtAdminEmail.Size = new System.Drawing.Size(485, 30);
            this.txtAdminEmail.TabIndex = 3;
            this.txtAdminEmail.TextChanged += new System.EventHandler(this.txtAdminEmail_TextChanged);
            // 
            // lblAdminEmailViolation
            // 
            this.lblAdminEmailViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminEmailViolation.ForeColor = System.Drawing.Color.Red;
            this.lblAdminEmailViolation.Location = new System.Drawing.Point(35, 188);
            this.lblAdminEmailViolation.Name = "lblAdminEmailViolation";
            this.lblAdminEmailViolation.Size = new System.Drawing.Size(488, 24);
            this.lblAdminEmailViolation.TabIndex = 4;
            this.lblAdminEmailViolation.Visible = false;
            // 
            // lblAdminPassword
            // 
            this.lblAdminPassword.AutoSize = true;
            this.lblAdminPassword.Location = new System.Drawing.Point(33, 222);
            this.lblAdminPassword.Name = "lblAdminPassword";
            this.lblAdminPassword.Size = new System.Drawing.Size(98, 25);
            this.lblAdminPassword.TabIndex = 5;
            this.lblAdminPassword.Text = "Password";
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.Location = new System.Drawing.Point(38, 252);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.PasswordChar = '*';
            this.txtAdminPassword.Size = new System.Drawing.Size(485, 30);
            this.txtAdminPassword.TabIndex = 6;
            this.txtAdminPassword.TextChanged += new System.EventHandler(this.txtAdminPassword_TextChanged);
            // 
            // lblAdminPasswordViolation
            // 
            this.lblAdminPasswordViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPasswordViolation.ForeColor = System.Drawing.Color.Red;
            this.lblAdminPasswordViolation.Location = new System.Drawing.Point(35, 286);
            this.lblAdminPasswordViolation.Name = "lblAdminPasswordViolation";
            this.lblAdminPasswordViolation.Size = new System.Drawing.Size(488, 60);
            this.lblAdminPasswordViolation.TabIndex = 7;
            this.lblAdminPasswordViolation.Visible = false;
            // 
            // chkAdminShow
            // 
            this.chkAdminShow.AutoSize = true;
            this.chkAdminShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdminShow.Location = new System.Drawing.Point(39, 322);
            this.chkAdminShow.Name = "chkAdminShow";
            this.chkAdminShow.Size = new System.Drawing.Size(149, 24);
            this.chkAdminShow.TabIndex = 8;
            this.chkAdminShow.Text = "Show password";
            this.chkAdminShow.UseVisualStyleBackColor = true;
            this.chkAdminShow.CheckedChanged += new System.EventHandler(this.chkAdminShow_CheckedChanged);
            // 
            // btnAdminLogIn
            // 
            this.btnAdminLogIn.BackColor = System.Drawing.Color.Blue;
            this.btnAdminLogIn.ForeColor = System.Drawing.Color.White;
            this.btnAdminLogIn.Location = new System.Drawing.Point(37, 352);
            this.btnAdminLogIn.Name = "btnAdminLogIn";
            this.btnAdminLogIn.Size = new System.Drawing.Size(485, 46);
            this.btnAdminLogIn.TabIndex = 9;
            this.btnAdminLogIn.Text = "Log In";
            this.btnAdminLogIn.UseVisualStyleBackColor = false;
            this.btnAdminLogIn.Click += new System.EventHandler(this.btnAdminLogIn_Click);
            // 
            // linkAdminBack
            // 
            this.linkAdminBack.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkAdminBack.AutoSize = true;
            this.linkAdminBack.BackColor = System.Drawing.Color.White;
            this.linkAdminBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkAdminBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAdminBack.LinkColor = System.Drawing.Color.Black;
            this.linkAdminBack.Location = new System.Drawing.Point(18, 16);
            this.linkAdminBack.Name = "linkAdminBack";
            this.linkAdminBack.Size = new System.Drawing.Size(70, 22);
            this.linkAdminBack.TabIndex = 1;
            this.linkAdminBack.TabStop = true;
            this.linkAdminBack.Text = "< Back";
            this.linkAdminBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAdminBack_LinkClicked);
            // 
            // frmAdminLogin
            // 
            this.AcceptButton = this.btnAdminLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.BackgroundImage = global::PROJECTT.Properties.Resources.i_safarii;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(968, 600);
            this.Controls.Add(this.linkAdminBack);
            this.Controls.Add(this.panelCard);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdminLogin_FormClosed);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblSubHeading;
        private System.Windows.Forms.Label lblAdminEmail;
        private System.Windows.Forms.TextBox txtAdminEmail;
        private System.Windows.Forms.Label lblAdminEmailViolation;
        private System.Windows.Forms.Label lblAdminPassword;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Label lblAdminPasswordViolation;
        private System.Windows.Forms.CheckBox chkAdminShow;
        private System.Windows.Forms.Button btnAdminLogIn;
        private System.Windows.Forms.LinkLabel linkAdminBack;
    }
}
