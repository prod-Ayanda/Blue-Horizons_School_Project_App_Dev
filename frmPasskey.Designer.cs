namespace PROJECTT
{
    partial class frmPasskey
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtPasskey = new System.Windows.Forms.TextBox();
            this.chkShowPasskey = new System.Windows.Forms.CheckBox();
            this.lblPasskeyViolation = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(22, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(218, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Admin Passkey";
            // 
            // lblPrompt
            // 
            this.lblPrompt.Location = new System.Drawing.Point(26, 62);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(460, 30);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "Enter the admin passkey to continue:";
            // 
            // txtPasskey
            // 
            this.txtPasskey.Location = new System.Drawing.Point(27, 98);
            this.txtPasskey.MaxLength = 6;
            this.txtPasskey.Name = "txtPasskey";
            this.txtPasskey.PasswordChar = '*';
            this.txtPasskey.Size = new System.Drawing.Size(459, 30);
            this.txtPasskey.TabIndex = 2;
            this.txtPasskey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPasskey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPasskey_KeyPress);
            this.txtPasskey.TextChanged += new System.EventHandler(this.txtPasskey_TextChanged);
            // 
            // chkShowPasskey
            // 
            this.chkShowPasskey.AutoSize = true;
            this.chkShowPasskey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowPasskey.Location = new System.Drawing.Point(27, 136);
            this.chkShowPasskey.Name = "chkShowPasskey";
            this.chkShowPasskey.Size = new System.Drawing.Size(122, 21);
            this.chkShowPasskey.TabIndex = 3;
            this.chkShowPasskey.Text = "Show passkey";
            this.chkShowPasskey.UseVisualStyleBackColor = true;
            this.chkShowPasskey.CheckedChanged += new System.EventHandler(this.chkShowPasskey_CheckedChanged);
            // 
            // lblPasskeyViolation
            // 
            this.lblPasskeyViolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasskeyViolation.ForeColor = System.Drawing.Color.Red;
            this.lblPasskeyViolation.Location = new System.Drawing.Point(24, 162);
            this.lblPasskeyViolation.Name = "lblPasskeyViolation";
            this.lblPasskeyViolation.Size = new System.Drawing.Size(462, 40);
            this.lblPasskeyViolation.TabIndex = 4;
            this.lblPasskeyViolation.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Blue;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(262, 208);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 40);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(381, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPasskey
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(8)))), ((int)(((byte)(14)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(514, 268);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPasskeyViolation);
            this.Controls.Add(this.chkShowPasskey);
            this.Controls.Add(this.txtPasskey);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPasskey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Admin Access";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtPasskey;
        private System.Windows.Forms.CheckBox chkShowPasskey;
        private System.Windows.Forms.Label lblPasskeyViolation;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
