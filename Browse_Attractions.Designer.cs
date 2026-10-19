namespace PROJECTT
{
    partial class Browse_Attractions
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
                        this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblDescription1 = new System.Windows.Forms.Label();
            this.btnSelect1 = new System.Windows.Forms.Button();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblDescription2 = new System.Windows.Forms.Label();
            this.btnSelect2 = new System.Windows.Forms.Button();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblName3 = new System.Windows.Forms.Label();
            this.lblDescription3 = new System.Windows.Forms.Label();
            this.btnSelect3 = new System.Windows.Forms.Button();
            this.btnProceedToPayment = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(37)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1206, 51);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.SlateGray;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Location = new System.Drawing.Point(20, 13);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 26);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Perpetua Titling MT", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTitle.Location = new System.Drawing.Point(185, 13);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(484, 36);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Choose Your Attraction";
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard1.Controls.Add(this.lblName1);
            this.pnlCard1.Controls.Add(this.lblDescription1);
            this.pnlCard1.Controls.Add(this.btnSelect1);
            this.pnlCard1.Location = new System.Drawing.Point(40, 77);
            this.pnlCard1.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(720, 70);
            this.pnlCard1.TabIndex = 1;
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblName1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblName1.Location = new System.Drawing.Point(13, 13);
            this.lblName1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(342, 32);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Table Mountain Sunrise Hike";
            // 
            // lblDescription1
            // 
            this.lblDescription1.AutoSize = true;
            this.lblDescription1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblDescription1.ForeColor = System.Drawing.Color.LightGray;
            this.lblDescription1.Location = new System.Drawing.Point(15, 47);
            this.lblDescription1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription1.Name = "lblDescription1";
            this.lblDescription1.Size = new System.Drawing.Size(370, 23);
            this.lblDescription1.TabIndex = 1;
            this.lblDescription1.Text = "Half-day guided hike, ends with a summit sunrise";
            // 
            // btnSelect1
            // 
            this.btnSelect1.BackColor = System.Drawing.Color.White;
            this.btnSelect1.Location = new System.Drawing.Point(620, 20);
            this.btnSelect1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect1.Name = "btnSelect1";
            this.btnSelect1.Size = new System.Drawing.Size(80, 29);
            this.btnSelect1.TabIndex = 2;
            this.btnSelect1.Text = "Select";
            this.btnSelect1.UseVisualStyleBackColor = false;
            this.btnSelect1.Click += new System.EventHandler(this.btnSelect1_Click);
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard2.Controls.Add(this.lblName2);
            this.pnlCard2.Controls.Add(this.lblDescription2);
            this.pnlCard2.Controls.Add(this.btnSelect2);
            this.pnlCard2.Location = new System.Drawing.Point(40, 160);
            this.pnlCard2.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(720, 70);
            this.pnlCard2.TabIndex = 2;
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblName2.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblName2.Location = new System.Drawing.Point(13, 13);
            this.lblName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(355, 32);
            this.lblName2.TabIndex = 0;
            this.lblName2.Text = "Cape Peninsula Wildlife Safari";
            // 
            // lblDescription2
            // 
            this.lblDescription2.AutoSize = true;
            this.lblDescription2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblDescription2.ForeColor = System.Drawing.Color.LightGray;
            this.lblDescription2.Location = new System.Drawing.Point(13, 47);
            this.lblDescription2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription2.Name = "lblDescription2";
            this.lblDescription2.Size = new System.Drawing.Size(345, 23);
            this.lblDescription2.TabIndex = 1;
            this.lblDescription2.Text = "Full-day safari drive along the Cape Peninsula";
            // 
            // btnSelect2
            // 
            this.btnSelect2.BackColor = System.Drawing.Color.White;
            this.btnSelect2.Location = new System.Drawing.Point(620, 20);
            this.btnSelect2.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect2.Name = "btnSelect2";
            this.btnSelect2.Size = new System.Drawing.Size(80, 29);
            this.btnSelect2.TabIndex = 2;
            this.btnSelect2.Text = "Select";
            this.btnSelect2.UseVisualStyleBackColor = false;
            this.btnSelect2.Click += new System.EventHandler(this.btnSelect2_Click);
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard3.Controls.Add(this.lblName3);
            this.pnlCard3.Controls.Add(this.lblDescription3);
            this.pnlCard3.Controls.Add(this.btnSelect3);
            this.pnlCard3.Location = new System.Drawing.Point(40, 243);
            this.pnlCard3.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(720, 70);
            this.pnlCard3.TabIndex = 3;
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblName3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblName3.Location = new System.Drawing.Point(13, 13);
            this.lblName3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(349, 32);
            this.lblName3.TabIndex = 0;
            this.lblName3.Text = "Boulders Beach Penguin Tour";
            // 
            // lblDescription3
            // 
            this.lblDescription3.AutoSize = true;
            this.lblDescription3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblDescription3.ForeColor = System.Drawing.Color.LightGray;
            this.lblDescription3.Location = new System.Drawing.Point(13, 45);
            this.lblDescription3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription3.Name = "lblDescription3";
            this.lblDescription3.Size = new System.Drawing.Size(356, 23);
            this.lblDescription3.TabIndex = 1;
            this.lblDescription3.Text = "Morning tour to see the African penguin colony";
            // 
            // btnSelect3
            // 
            this.btnSelect3.BackColor = System.Drawing.Color.White;
            this.btnSelect3.Location = new System.Drawing.Point(620, 20);
            this.btnSelect3.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect3.Name = "btnSelect3";
            this.btnSelect3.Size = new System.Drawing.Size(80, 29);
            this.btnSelect3.TabIndex = 2;
            this.btnSelect3.Text = "Select";
            this.btnSelect3.UseVisualStyleBackColor = false;
            this.btnSelect3.Click += new System.EventHandler(this.btnSelect3_Click);
            // 
            // btnProceedToPayment
            // 
            this.btnProceedToPayment.BackColor = System.Drawing.Color.LightGray;
            this.btnProceedToPayment.Enabled = false;
            this.btnProceedToPayment.Location = new System.Drawing.Point(613, 352);
            this.btnProceedToPayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnProceedToPayment.Name = "btnProceedToPayment";
            this.btnProceedToPayment.Size = new System.Drawing.Size(147, 32);
            this.btnProceedToPayment.TabIndex = 4;
            this.btnProceedToPayment.Text = "Proceed to Payment";
            this.btnProceedToPayment.UseVisualStyleBackColor = false;
            this.btnProceedToPayment.Click += new System.EventHandler(this.btnProceedToPayment_Click);
            // 
            // Browse_Attractions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1206, 582);
            this.Controls.Add(this.btnProceedToPayment);
            this.Controls.Add(this.pnlCard3);
            this.Controls.Add(this.pnlCard2);
            this.Controls.Add(this.pnlCard1);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Browse_Attractions";
            this.Text = "Browse Attractions";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblDescription1;
        private System.Windows.Forms.Button btnSelect1;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblDescription2;
        private System.Windows.Forms.Button btnSelect2;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.Label lblDescription3;
        private System.Windows.Forms.Button btnSelect3;
        private System.Windows.Forms.Button btnProceedToPayment;
    }
}
