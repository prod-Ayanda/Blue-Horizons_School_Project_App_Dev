using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROJECTT
{
    public partial class EditStory : Form
    {
       
     
        public string StoryText
        {
            get { return txtStory.Text; }
            set { txtStory.Text = value; }
        }

        public EditStory()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       

        private void EditStory_Load(object sender, EventArgs e)
        {

        }
    }
}