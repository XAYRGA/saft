using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saft
{
    public partial class FileNamePrompt : Form
    {
        public string FileText;

        public FileNamePrompt()
        {
            InitializeComponent();
        }

        private void FileNamePrompt_Load(object sender, EventArgs e)
        {
            fileText.KeyDown += fileText_KeyDown;            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (fileText.TextLength > 16)
            {
                MessageBox.Show("AFC Name must be less than 16 bytes!");
                return;                    
            }
            FileText = fileText.Text;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fileText_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
