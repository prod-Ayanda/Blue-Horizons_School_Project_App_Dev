namespace PROJECTT
{
    partial class Home
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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.btnMyProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.btnBrowseAttractions = new System.Windows.Forms.Button();
            this.lblBrowseAttractionsSub = new System.Windows.Forms.Label();
            this.pnlOurStory = new System.Windows.Forms.Panel();
            this.lblStoryHeading = new System.Windows.Forms.Label();
            this.lblStoryBody = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlOurStory.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(37)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblCompanyName);
            this.pnlHeader.Controls.Add(this.btnMyProfile);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 51);
            this.pnlHeader.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(20, 6);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(40, 38);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lblCompanyName.Font = new System.Drawing.Font("Impact", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCompanyName.Location = new System.Drawing.Point(64, 0);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(1273, 742);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "Blue Horizon";
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.BackColor = System.Drawing.Color.White;
            this.btnMyProfile.Location = new System.Drawing.Point(745, 17);
            this.btnMyProfile.Margin = new System.Windows.Forms.Padding(2);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(97, 25);
            this.btnMyProfile.TabIndex = 2;
            this.btnMyProfile.Text = "My Profile";
            this.btnMyProfile.UseVisualStyleBackColor = false;
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.Location = new System.Drawing.Point(846, 17);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(93, 25);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblWelcome.Location = new System.Drawing.Point(371, 147);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(246, 62);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Welcome!";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.BackColor = System.Drawing.Color.Transparent;
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPrompt.ForeColor = System.Drawing.Color.Lavender;
            this.lblPrompt.Location = new System.Drawing.Point(294, 405);
            this.lblPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(414, 32);
            this.lblPrompt.TabIndex = 5;
            this.lblPrompt.Text = "Where would you like to go today?";
            // 
            // btnBrowseAttractions
            // 
            this.btnBrowseAttractions.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBrowseAttractions.Font = new System.Drawing.Font("Elephant", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseAttractions.Location = new System.Drawing.Point(401, 466);
            this.btnBrowseAttractions.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseAttractions.Name = "btnBrowseAttractions";
            this.btnBrowseAttractions.Size = new System.Drawing.Size(187, 58);
            this.btnBrowseAttractions.TabIndex = 6;
            this.btnBrowseAttractions.Text = "To Dashboard";
            this.btnBrowseAttractions.UseVisualStyleBackColor = false;
            this.btnBrowseAttractions.Click += new System.EventHandler(this.btnBrowseAttractions_Click);
            // 
            // lblBrowseAttractionsSub
            // 
            this.lblBrowseAttractionsSub.AutoSize = true;
            this.lblBrowseAttractionsSub.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblBrowseAttractionsSub.ForeColor = System.Drawing.Color.White;
            this.lblBrowseAttractionsSub.Location = new System.Drawing.Point(408, 526);
            this.lblBrowseAttractionsSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrowseAttractionsSub.Name = "lblBrowseAttractionsSub";
            this.lblBrowseAttractionsSub.Size = new System.Drawing.Size(180, 20);
            this.lblBrowseAttractionsSub.TabIndex = 7;
            this.lblBrowseAttractionsSub.Text = "Safaris, Events, Hikes, Stays";
            // 
            // pnlOurStory
            // 
            this.pnlOurStory.BackColor = System.Drawing.Color.Transparent;
            this.pnlOurStory.Controls.Add(this.lblStoryHeading);
            this.pnlOurStory.Controls.Add(this.lblStoryBody);
            this.pnlOurStory.Location = new System.Drawing.Point(321, 239);
            this.pnlOurStory.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOurStory.Name = "pnlOurStory";
            this.pnlOurStory.Size = new System.Drawing.Size(387, 154);
            this.pnlOurStory.TabIndex = 8;
            // 
            // lblStoryHeading
            // 
            this.lblStoryHeading.AutoSize = true;
            this.lblStoryHeading.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoryHeading.ForeColor = System.Drawing.Color.White;
            this.lblStoryHeading.Location = new System.Drawing.Point(23, 10);
            this.lblStoryHeading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStoryHeading.Name = "lblStoryHeading";
            this.lblStoryHeading.Size = new System.Drawing.Size(328, 31);
            this.lblStoryHeading.TabIndex = 0;
            this.lblStoryHeading.Text = "info to be updated in phase 2";
            this.lblStoryHeading.Click += new System.EventHandler(this.lblStoryHeading_Click);
            // 
            // lblStoryBody
            // 
            this.lblStoryBody.BackColor = System.Drawing.Color.Transparent;
            this.lblStoryBody.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStoryBody.ForeColor = System.Drawing.Color.White;
            this.lblStoryBody.Location = new System.Drawing.Point(2, 53);
            this.lblStoryBody.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStoryBody.Name = "lblStoryBody";
            this.lblStoryBody.Size = new System.Drawing.Size(391, 90);
            this.lblStoryBody.TabIndex = 1;
            this.lblStoryBody.Text = "info to be updated in phase-2 accessed by the admin dashboard which is to be made" +
    " in phase two";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(950, 714);
            this.Controls.Add(this.pnlOurStory);
            this.Controls.Add(this.lblBrowseAttractionsSub);
            this.Controls.Add(this.btnBrowseAttractions);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlOurStory.ResumeLayout(false);
            this.pnlOurStory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button btnMyProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Button btnBrowseAttractions;
        private System.Windows.Forms.Label lblBrowseAttractionsSub;
        private System.Windows.Forms.Panel pnlOurStory;
        private System.Windows.Forms.Label lblStoryHeading;
        private System.Windows.Forms.Label lblStoryBody;
    }
}
