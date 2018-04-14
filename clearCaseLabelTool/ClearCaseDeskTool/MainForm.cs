using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearCaseDeskTool
{
    public partial class MainForm : Form
    {
        private string localOperatePath;

        private string localCopyPath;

        private string targetFolderPath;

        private Dictionary<string, string> fileNamePathMap;

        private Dictionary<string, string> fileNameDirectoryMap;

        private DataTable fileNameLabelTable;

        private Dictionary<string, string> fileNameRootDirectoryMap;

        private BindingSource bindingSource1;

        private LabelDealer labelDealer;

        private Encriptor encriptor;

        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            fileNamePathMap = new Dictionary<String, String>();
            fileNameDirectoryMap = new Dictionary<string, string>();
            fileNameLabelTable = new DataTable();
            fileNameRootDirectoryMap = new Dictionary<string, string>();
            bindingSource1 = new BindingSource();
        }

        async private void Browse_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog.SelectedPath!=null) {

                    //making them map is for the extension of multi-selection in the future, maybe~
                    fileNamePathMap.Add(System.IO.Path.GetFileName(folderBrowserDialog.SelectedPath), folderBrowserDialog.SelectedPath);

                    fileNameDirectoryMap.Add(System.IO.Path.GetFileName(folderBrowserDialog.SelectedPath), System.IO.Path.GetDirectoryName(folderBrowserDialog.SelectedPath));

                    fileNameRootDirectoryMap.Add(System.IO.Path.GetFileName(folderBrowserDialog.SelectedPath), System.IO.Path.GetPathRoot(folderBrowserDialog.SelectedPath));

                    //initialize the label dealer
                    labelDealer = new LabelDealer(fileNameDirectoryMap, fileNameRootDirectoryMap);

                    Dictionary<string, string> fileNameVersionResultMap = await labelDealer.GetVersionResultMap();

                    //get label for the current version, and fill into datatable 
                    fileNameLabelTable = labelDealer.GetCurrentVersionLabel(fileNameVersionResultMap);

                    //Bind data of dataTable to dataGridView
                    bindingSource1.DataSource = fileNameLabelTable;
                    dataGridView1.DataSource = bindingSource1;
                }
            }
        }

        private void selectLocalOriginalPath_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                localCopyPath = folderBrowserDialog.SelectedPath;

                localOperatePath = Path.GetDirectoryName(localCopyPath);

            }

            label2.Text = folderBrowserDialog.SelectedPath;

        }
        
        private void select_target_folder_button_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {

                targetFolderPath = folderBrowserDialog.SelectedPath;

            }

            label3.Text = folderBrowserDialog.SelectedPath;

        }

        private void encriptButton_Click(object sender, EventArgs e)
        {




            if (localCopyPath==null|| localOperatePath==null|| targetFolderPath==null|| fileNamePathMap.Count==0|| fileNameLabelTable.Rows.Count==0) {

                MessageBox.Show("Please fill the needed data", "Data missed",MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else {

                encriptor = new Encriptor(localCopyPath, localOperatePath, targetFolderPath, fileNamePathMap);

                labelDealer.LabelOn(fileNameLabelTable);

                encriptor.CopyFolder2Local();

                encriptor.EncriptApply();

            }
            
            this.fileNameDirectoryMap.Clear();
            this.fileNamePathMap.Clear();
            this.fileNameLabelTable.Clear();
            this.fileNameRootDirectoryMap.Clear();
            label2.Text = "";
            localCopyPath = null;
            localOperatePath = null;
            label3.Text = "";
            targetFolderPath = null;

        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {

            int currentRowIndex = dataGridView1.CurrentRow.Index;
            string fileNameOfCurrentRow = this.fileNameLabelTable.Rows[currentRowIndex][0].ToString();
            this.fileNameLabelTable.Rows.RemoveAt(currentRowIndex);
            this.fileNameDirectoryMap.Remove(fileNameOfCurrentRow);
            this.fileNamePathMap.Remove(fileNameOfCurrentRow);
            this.fileNameRootDirectoryMap.Remove(fileNameOfCurrentRow);

        }

        private void Browse1Delete_Click(object sender, EventArgs e)
        {

            this.fileNameDirectoryMap.Clear();
            this.fileNamePathMap.Clear();
            this.fileNameLabelTable.Clear();
            this.fileNameRootDirectoryMap.Clear();

        }

        private void Browse2Delete_Click(object sender, EventArgs e)
        {

            label2.Text = "";

            localCopyPath = null;

            localOperatePath = null;
            
        }

        private void Browse3Delete_Click(object sender, EventArgs e)
        {

            label3.Text = "";

            targetFolderPath = null;

        }
        
    }
}
