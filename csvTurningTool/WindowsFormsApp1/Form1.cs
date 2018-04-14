using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainWindow : Form
    {

        private TurnCsv2Excel turnTool;

        public MainWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void turnButton_Click(object sender, EventArgs e)
        {
            turnTool = new TurnCsv2Excel(this.progressBar1,
                selectTemplateFileButton, button15, selectExcelPathButton,
                button16, turnButton, groupBox1,this.label21,this.label2,
                this.label3,this.label11,this.label12);

            label21.Text = "Turning, please wait...";

            this.progressBar1.Value = 0;

            turnTool.turn();

            groupBox1.Enabled = false;

            selectTemplateFileButton.Enabled = false;

            button15.Enabled = false;

            selectExcelPathButton.Enabled = false;

            button16.Enabled = false;

            turnButton.Enabled = false;

            label2.Enabled = false;

            label3.Enabled = false;

            label11.Enabled = false;

            label12.Enabled = false;

        }

        private void selectTemplateFileButton_Click(object sender, EventArgs e)
        {
            if (selectPathForm.ShowDialog() == DialogResult.OK)
            {
                String templateFilePath = selectPathForm.SelectedPath;

                Program.templatesFilePath = templateFilePath;

                label11.Text = templateFilePath;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Program.templatesFilePath = null;

            label11.Text = null;
        }

        private void selectExcelPathButton_Click(object sender, EventArgs e)
        {
            if (selectPathForm.ShowDialog() == DialogResult.OK)
            {
                String excelFilePath = selectPathForm.SelectedPath;

                Program.excelFilePath = excelFilePath;

                label12.Text = excelFilePath;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Program.excelFilePath = null;

            label12.Text = null;
        }

        private void selectHanCsvButton_Click(object sender, EventArgs e)
        {
            if (selectFileForm.ShowDialog() == DialogResult.OK)
            {
                String hanCsvFilePath = selectFileForm.FileName;

                String hanCsvFileName = selectFileForm.SafeFileName;

                Program.handrailsCsvPath = hanCsvFilePath;

                Program.handrailsCsvName = hanCsvFileName;

                label13.Text = hanCsvFileName;
            }
        }

        private void delete1_Click(object sender, EventArgs e)
        {
            Program.handrailsCsvPath = null;

            label13.Text = null;
        }



        private void selectGraCsvButton_Click(object sender, EventArgs e)
        {
            if (selectFileForm.ShowDialog() == DialogResult.OK)
            {
                String graCsvFilePath = selectFileForm.FileName;

                String graCsvFileName = selectFileForm.SafeFileName;

                Program.gratingCsvPath = graCsvFilePath;

                Program.gratingCsvName = graCsvFileName;

                label14.Text = graCsvFileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Program.gratingCsvPath = null;

            label14.Text = null;
        }

        private void selectPlaCsvButton_Click(object sender, EventArgs e)
        {
            if (selectFileForm.ShowDialog() == DialogResult.OK)
            {
                String plaCsvFilePath = selectFileForm.FileName;

                String plaCsvFileName = selectFileForm.SafeFileName;

                Program.platesCsvPath = plaCsvFilePath;

                Program.platesCsvNmae = plaCsvFileName;

                label15.Text = plaCsvFileName;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Program.platesCsvPath = null; ;

            label15.Text = null;
        }

        private void selectLadCsvButton_Click(object sender, EventArgs e)
        {
            if (selectFileForm.ShowDialog() == DialogResult.OK)
            {
                String ladCsvFilePath = selectFileForm.FileName;

                String ladCsvFileName = selectFileForm.SafeFileName;

                Program.laddersCsvPath = ladCsvFilePath;

                Program.laddersCsvName = ladCsvFileName;

                label16.Text = ladCsvFileName;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Program.laddersCsvPath = null;

            label16.Text = null;
        }

    }
}
