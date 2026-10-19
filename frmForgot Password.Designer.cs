namespace PROJECTT
{
    partial class frmForgot_Password
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
                        this.lblForgotPassword = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblForgotEmail = new System.Windows.Forms.Label();
            this.txtForgotEmail = new System.Windows.Forms.TextBox();
            this.linkBack = new System.Windows.Forms.LinkLabel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblForgotEmailViolation = new System.Windows.Forms.Label();
            this.lblOTP = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.lblOTPViolation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVerifyOTP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPassword.Location = new System.Drawing.Point(394, 51);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(496, 69);
            this.lblForgotPassword.TabIndex = 0;
            this.lblForgotPassword.Text = "Forgot Password";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.ForeColor = System.Drawing.Color.DimGray;
            this.lblNote.Location = new System.Drawing.Point(215, 154);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(908, 25);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Enter your registered email address below, and we will send you a secure link to " +
    "create a new password.";
            // 
            // lblForgotEmail
            // 
            this.lblForgotEmail.AutoSize = true;
            this.lblForgotEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotEmail.Location = new System.Drawing.Point(215, 239);
            this.lblForgotEmail.Name = "lblForgotEmail";
            this.lblForgotEmail.Size = new System.Drawing.Size(151, 25);
            this.lblForgotEmail.TabIndex = 2;
            this.lblForgotEmail.Text = "Email Address";
            // 
            // txtForgotEmail
            // 
            this.txtForgotEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtForgotEmail.Location = new System.Drawing.Point(220, 280);
            this.txtForgotEmail.Name = "txtForgotEmail";
            this.txtForgotEmail.Size = new System.Drawing.Size(759, 30);
            this.txtForgotEmail.TabIndex = 3;
            this.txtForgotEmail.TextChanged += new System.EventHandler(this.txtForgotEmail_TextChanged);
            // 
            // linkBack
            // 
            this.linkBack.AutoSize = true;
            this.linkBack.BackColor = System.Drawing.Color.Transparent;
            this.linkBack.LinkColor = System.Drawing.Color.Black;
            this.linkBack.Location = new System.Drawing.Point(13, 13);
            this.linkBack.Name = "linkBack";
            this.linkBack.Size = new System.Drawing.Size(56, 25);
            this.linkBack.TabIndex = 5;
            this.linkBack.TabStop = true;
            this.linkBack.Text = "Back";
            this.linkBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBack_LinkClicked);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmit.Location = new System.Drawing.Point(830, 373);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(144, 49);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Send OTP";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSendOTP_Click);
            // 
            // lblForgotEmailViolation
            // 
            this.lblForgotEmailViolation.AutoSize = true;
            this.lblForgotEmailViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotEmailViolation.ForeColor = System.Drawing.Color.Red;
            this.lblForgotEmailViolation.Location = new System.Drawing.Point(217, 313);
            this.lblForgotEmailViolation.Name = "lblForgotEmailViolation";
            this.lblForgotEmailViolation.Size = new System.Drawing.Size(0, 16);
            this.lblForgotEmailViolation.TabIndex = 7;
            // 
            // lblOTP
            // 
            this.lblOTP.AutoSize = true;
            this.lblOTP.BackColor = System.Drawing.Color.Transparent;
            this.lblOTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOTP.Location = new System.Drawing.Point(220, 439);
            this.lblOTP.Name = "lblOTP";
            this.lblOTP.Size = new System.Drawing.Size(57, 25);
            this.lblOTP.TabIndex = 8;
            this.lblOTP.Text = "OTP";
            // 
            // txtOTP
            // 
            this.txtOTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOTP.Location = new System.Drawing.Point(220, 482);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(754, 30);
            this.txtOTP.TabIndex = 9;
            this.txtOTP.TextChanged += new System.EventHandler(this.txtOTP_TextChanged);
            // 
            // lblOTPViolation
            // 
            this.lblOTPViolation.AutoSize = true;
            this.lblOTPViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOTPViolation.ForeColor = System.Drawing.Color.Red;
            this.lblOTPViolation.Location = new System.Drawing.Point(225, 519);
            this.lblOTPViolation.Name = "lblOTPViolation";
            this.lblOTPViolation.Size = new System.Drawing.Size(0, 16);
            this.lblOTPViolation.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(939, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "0/6";
            // 
            // btnVerifyOTP
            // 
            this.btnVerifyOTP.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnVerifyOTP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerifyOTP.Location = new System.Drawing.Point(835, 557);
            this.btnVerifyOTP.Name = "btnVerifyOTP";
            this.btnVerifyOTP.Size = new System.Drawing.Size(144, 49);
            this.btnVerifyOTP.TabIndex = 12;
            this.btnVerifyOTP.Text = "Verify OTP";
            this.btnVerifyOTP.UseVisualStyleBackColor = false;
            this.btnVerifyOTP.Click += new System.EventHandler(this.btnVerifyOTP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(341, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "__________________Then___________________";
            // 
            // frmForgot_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerifyOTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOTPViolation);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.lblOTP);
            this.Controls.Add(this.lblForgotEmailViolation);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.linkBack);
            this.Controls.Add(this.txtForgotEmail);
            this.Controls.Add(this.lblForgotEmail);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblForgotPassword);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmForgot_Password";
            this.Text = "Forgot_Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblForgotPassword;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblForgotEmail;
        private System.Windows.Forms.TextBox txtForgotEmail;
        private System.Windows.Forms.LinkLabel linkBack;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblForgotEmailViolation;
        private System.Windows.Forms.Label lblOTP;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Label lblOTPViolation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVerifyOTP;
        private System.Windows.Forms.Label label1;
    }
}
