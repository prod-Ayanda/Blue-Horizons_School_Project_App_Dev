namespace PROJECTT
{
    partial class frmResetPassword
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
                        this.lblResetPassword = new System.Windows.Forms.Label();
            this.txtCreatePassword = new System.Windows.Forms.TextBox();
            this.lblCreatePassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmForgotPassword = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.lblCreatePasswordViolation = new System.Windows.Forms.Label();
            this.lblConfirmForgotPasswordViolation = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResetPassword
            // 
            this.lblResetPassword.AutoSize = true;
            this.lblResetPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblResetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetPassword.Location = new System.Drawing.Point(437, 66);
            this.lblResetPassword.Name = "lblResetPassword";
            this.lblResetPassword.Size = new System.Drawing.Size(389, 55);
            this.lblResetPassword.TabIndex = 0;
            this.lblResetPassword.Text = "Reset Password";
            // 
            // txtCreatePassword
            // 
            this.txtCreatePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreatePassword.Location = new System.Drawing.Point(449, 317);
            this.txtCreatePassword.Name = "txtCreatePassword";
            this.txtCreatePassword.PasswordChar = '*';
            this.txtCreatePassword.Size = new System.Drawing.Size(393, 26);
            this.txtCreatePassword.TabIndex = 1;
            this.txtCreatePassword.TextChanged += new System.EventHandler(this.txtCreatePassword_TextChanged);
            // 
            // lblCreatePassword
            // 
            this.lblCreatePassword.AutoSize = true;
            this.lblCreatePassword.Location = new System.Drawing.Point(444, 247);
            this.lblCreatePassword.Name = "lblCreatePassword";
            this.lblCreatePassword.Size = new System.Drawing.Size(196, 20);
            this.lblCreatePassword.TabIndex = 2;
            this.lblCreatePassword.Text = "Create a new password";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(444, 396);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(153, 20);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmForgotPassword
            // 
            this.txtConfirmForgotPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmForgotPassword.Location = new System.Drawing.Point(449, 467);
            this.txtConfirmForgotPassword.Name = "txtConfirmForgotPassword";
            this.txtConfirmForgotPassword.PasswordChar = '*';
            this.txtConfirmForgotPassword.Size = new System.Drawing.Size(393, 26);
            this.txtConfirmForgotPassword.TabIndex = 4;
            this.txtConfirmForgotPassword.TextChanged += new System.EventHandler(this.txtConfirmForgotPassword_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnCreate.Location = new System.Drawing.Point(1051, 602);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(171, 51);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // chkShow
            // 
            this.chkShow.AutoSize = true;
            this.chkShow.Location = new System.Drawing.Point(654, 523);
            this.chkShow.Name = "chkShow";
            this.chkShow.Size = new System.Drawing.Size(154, 24);
            this.chkShow.TabIndex = 6;
            this.chkShow.Text = "Show Password";
            this.chkShow.UseVisualStyleBackColor = true;
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // lblCreatePasswordViolation
            // 
            this.lblCreatePasswordViolation.AutoSize = true;
            this.lblCreatePasswordViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatePasswordViolation.ForeColor = System.Drawing.Color.Red;
            this.lblCreatePasswordViolation.Location = new System.Drawing.Point(446, 350);
            this.lblCreatePasswordViolation.Name = "lblCreatePasswordViolation";
            this.lblCreatePasswordViolation.Size = new System.Drawing.Size(0, 13);
            this.lblCreatePasswordViolation.TabIndex = 7;
            // 
            // lblConfirmForgotPasswordViolation
            // 
            this.lblConfirmForgotPasswordViolation.AutoSize = true;
            this.lblConfirmForgotPasswordViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmForgotPasswordViolation.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmForgotPasswordViolation.Location = new System.Drawing.Point(446, 500);
            this.lblConfirmForgotPasswordViolation.Name = "lblConfirmForgotPasswordViolation";
            this.lblConfirmForgotPasswordViolation.Size = new System.Drawing.Size(0, 13);
            this.lblConfirmForgotPasswordViolation.TabIndex = 8;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(700, 405);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(0, 13);
            this.lblLength.TabIndex = 9;
            // 
            // frmResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1300, 703);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.lblConfirmForgotPasswordViolation);
            this.Controls.Add(this.lblCreatePasswordViolation);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtConfirmForgotPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblCreatePassword);
            this.Controls.Add(this.txtCreatePassword);
            this.Controls.Add(this.lblResetPassword);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmResetPassword";
            this.Text = "ResetPassword";
            this.Load += new System.EventHandler(this.frmResetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResetPassword;
        private System.Windows.Forms.TextBox txtCreatePassword;
        private System.Windows.Forms.Label lblCreatePassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmForgotPassword;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Label lblCreatePasswordViolation;
        private System.Windows.Forms.Label lblConfirmForgotPasswordViolation;
        private System.Windows.Forms.Label lblLength;
    }
}
