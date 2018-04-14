using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearCaseDeskTool
{
    public partial class AddLabelForm : Form
    {
        public AddLabelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.labelTypeTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please type something", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                this.Close();
            }
        }
    }
}
