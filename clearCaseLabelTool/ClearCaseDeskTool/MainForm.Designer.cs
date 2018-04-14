namespace ClearCaseDeskTool
{
    partial class MainForm
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
            this.SelectToolBrowse = new System.Windows.Forms.Button();
            this.selectFileLabel = new System.Windows.Forms.Label();
            this.select_target_folder_button = new System.Windows.Forms.Button();
            this.selectTargetFolderLabel = new System.Windows.Forms.Label();
            this.encriptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.selectLocalOriginalPath = new System.Windows.Forms.Button();
            this.Browse1Delete = new System.Windows.Forms.Button();
            this.Browse2Delete = new System.Windows.Forms.Button();
            this.Browse3Delete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteSelectedButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectToolBrowse
            // 
            this.SelectToolBrowse.Location = new System.Drawing.Point(27, 69);
            this.SelectToolBrowse.Name = "SelectToolBrowse";
            this.SelectToolBrowse.Size = new System.Drawing.Size(80, 27);
            this.SelectToolBrowse.TabIndex = 0;
            this.SelectToolBrowse.Text = "Browse";
            this.SelectToolBrowse.UseVisualStyleBackColor = true;
            this.SelectToolBrowse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // selectFileLabel
            // 
            this.selectFileLabel.AutoSize = true;
            this.selectFileLabel.Location = new System.Drawing.Point(113, 74);
            this.selectFileLabel.Name = "selectFileLabel";
            this.selectFileLabel.Size = new System.Drawing.Size(224, 17);
            this.selectFileLabel.TabIndex = 1;
            this.selectFileLabel.Text = "select the files you need to encript";
            // 
            // select_target_folder_button
            // 
            this.select_target_folder_button.Location = new System.Drawing.Point(27, 33);
            this.select_target_folder_button.Name = "select_target_folder_button";
            this.select_target_folder_button.Size = new System.Drawing.Size(80, 29);
            this.select_target_folder_button.TabIndex = 2;
            this.select_target_folder_button.Text = "Browse";
            this.select_target_folder_button.UseVisualStyleBackColor = true;
            this.select_target_folder_button.Click += new System.EventHandler(this.select_target_folder_button_Click);
            // 
            // selectTargetFolderLabel
            // 
            this.selectTargetFolderLabel.AutoSize = true;
            this.selectTargetFolderLabel.Location = new System.Drawing.Point(113, 39);
            this.selectTargetFolderLabel.Name = "selectTargetFolderLabel";
            this.selectTargetFolderLabel.Size = new System.Drawing.Size(150, 17);
            this.selectTargetFolderLabel.TabIndex = 3;
            this.selectTargetFolderLabel.Text = "select the target folder";
            // 
            // encriptButton
            // 
            this.encriptButton.Location = new System.Drawing.Point(12, 473);
            this.encriptButton.Name = "encriptButton";
            this.encriptButton.Size = new System.Drawing.Size(136, 56);
            this.encriptButton.TabIndex = 4;
            this.encriptButton.Text = "encript and label";
            this.encriptButton.UseVisualStyleBackColor = true;
            this.encriptButton.Click += new System.EventHandler(this.encriptButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "select your local copy folder";
            // 
            // selectLocalOriginalPath
            // 
            this.selectLocalOriginalPath.Location = new System.Drawing.Point(26, 32);
            this.selectLocalOriginalPath.Name = "selectLocalOriginalPath";
            this.selectLocalOriginalPath.Size = new System.Drawing.Size(80, 29);
            this.selectLocalOriginalPath.TabIndex = 5;
            this.selectLocalOriginalPath.Text = "Browse";
            this.selectLocalOriginalPath.UseVisualStyleBackColor = true;
            this.selectLocalOriginalPath.Click += new System.EventHandler(this.selectLocalOriginalPath_Click);
            // 
            // Browse1Delete
            // 
            this.Browse1Delete.Location = new System.Drawing.Point(27, 102);
            this.Browse1Delete.Name = "Browse1Delete";
            this.Browse1Delete.Size = new System.Drawing.Size(80, 28);
            this.Browse1Delete.TabIndex = 7;
            this.Browse1Delete.Text = "Clear";
            this.Browse1Delete.UseVisualStyleBackColor = true;
            this.Browse1Delete.Click += new System.EventHandler(this.Browse1Delete_Click);
            // 
            // Browse2Delete
            // 
            this.Browse2Delete.Location = new System.Drawing.Point(25, 67);
            this.Browse2Delete.Name = "Browse2Delete";
            this.Browse2Delete.Size = new System.Drawing.Size(80, 26);
            this.Browse2Delete.TabIndex = 8;
            this.Browse2Delete.Text = "Clear";
            this.Browse2Delete.UseVisualStyleBackColor = true;
            this.Browse2Delete.Click += new System.EventHandler(this.Browse2Delete_Click);
            // 
            // Browse3Delete
            // 
            this.Browse3Delete.Location = new System.Drawing.Point(27, 68);
            this.Browse3Delete.Name = "Browse3Delete";
            this.Browse3Delete.Size = new System.Drawing.Size(80, 26);
            this.Browse3Delete.TabIndex = 9;
            this.Browse3Delete.Text = "Clear";
            this.Browse3Delete.UseVisualStyleBackColor = true;
            this.Browse3Delete.Click += new System.EventHandler(this.Browse3Delete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.deleteSelectedButton);
            this.groupBox1.Controls.Add(this.SelectToolBrowse);
            this.groupBox1.Controls.Add(this.selectFileLabel);
            this.groupBox1.Controls.Add(this.Browse1Delete);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 200);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select the folder you want to deploy";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.fileLabel});
            this.dataGridView1.Location = new System.Drawing.Point(344, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(350, 132);
            this.dataGridView1.TabIndex = 14;
            // 
            // fileName
            // 
            this.fileName.DataPropertyName = "fileName";
            this.fileName.HeaderText = "File Name";
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            // 
            // fileLabel
            // 
            this.fileLabel.DataPropertyName = "fileLabel";
            this.fileLabel.HeaderText = "Label to be added";
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.ReadOnly = true;
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.Location = new System.Drawing.Point(355, 160);
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(126, 34);
            this.deleteSelectedButton.TabIndex = 13;
            this.deleteSelectedButton.Text = "Delete Selected";
            this.deleteSelectedButton.UseVisualStyleBackColor = true;
            this.deleteSelectedButton.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Browse2Delete);
            this.groupBox2.Controls.Add(this.selectLocalOriginalPath);
            this.groupBox2.Location = new System.Drawing.Point(13, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 103);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select the folder of pmllib_original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.Browse3Delete);
            this.groupBox3.Controls.Add(this.select_target_folder_button);
            this.groupBox3.Controls.Add(this.selectTargetFolderLabel);
            this.groupBox3.Location = new System.Drawing.Point(12, 345);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(706, 107);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select the remote deploy folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 558);
            this.Controls.Add(this.encriptButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "MainForm";
            this.Text = "Encript Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SelectToolBrowse;
        private System.Windows.Forms.Label selectFileLabel;
        private System.Windows.Forms.Button select_target_folder_button;
        private System.Windows.Forms.Label selectTargetFolderLabel;
        private System.Windows.Forms.Button encriptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectLocalOriginalPath;
        private System.Windows.Forms.Button Browse1Delete;
        private System.Windows.Forms.Button Browse2Delete;
        private System.Windows.Forms.Button Browse3Delete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button deleteSelectedButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLabel;
    }
}

