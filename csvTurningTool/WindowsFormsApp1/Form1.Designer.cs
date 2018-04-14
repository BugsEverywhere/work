namespace WindowsFormsApp1
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.turnButton = new System.Windows.Forms.Button();
            this.selectFileForm = new System.Windows.Forms.OpenFileDialog();
            this.selectHanCsvButton = new System.Windows.Forms.Button();
            this.selectTemplateFileButton = new System.Windows.Forms.Button();
            this.selectExcelPathButton = new System.Windows.Forms.Button();
            this.selectPathForm = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.delete1 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.selectLadCsvButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.selectPlaCsvButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.selectGraCsvButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Handrails";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(121, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "please indicate the path of the template files";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 356);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(370, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "please indicate the folder where you want to save the Excel files";
            // 
            // turnButton
            // 
            this.turnButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.turnButton.Location = new System.Drawing.Point(430, 412);
            this.turnButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.turnButton.Name = "turnButton";
            this.turnButton.Size = new System.Drawing.Size(80, 41);
            this.turnButton.TabIndex = 6;
            this.turnButton.Text = "Turn";
            this.turnButton.UseVisualStyleBackColor = true;
            this.turnButton.Click += new System.EventHandler(this.turnButton_Click);
            // 
            // selectFileForm
            // 
            this.selectFileForm.FileName = "openFileDialog1";
            // 
            // selectHanCsvButton
            // 
            this.selectHanCsvButton.Location = new System.Drawing.Point(121, 33);
            this.selectHanCsvButton.Name = "selectHanCsvButton";
            this.selectHanCsvButton.Size = new System.Drawing.Size(59, 24);
            this.selectHanCsvButton.TabIndex = 7;
            this.selectHanCsvButton.Text = "Browse";
            this.selectHanCsvButton.UseVisualStyleBackColor = true;
            this.selectHanCsvButton.Click += new System.EventHandler(this.selectHanCsvButton_Click);
            // 
            // selectTemplateFileButton
            // 
            this.selectTemplateFileButton.Location = new System.Drawing.Point(386, 285);
            this.selectTemplateFileButton.Name = "selectTemplateFileButton";
            this.selectTemplateFileButton.Size = new System.Drawing.Size(75, 24);
            this.selectTemplateFileButton.TabIndex = 8;
            this.selectTemplateFileButton.Text = "Browse";
            this.selectTemplateFileButton.UseVisualStyleBackColor = true;
            this.selectTemplateFileButton.Click += new System.EventHandler(this.selectTemplateFileButton_Click);
            // 
            // selectExcelPathButton
            // 
            this.selectExcelPathButton.Location = new System.Drawing.Point(386, 356);
            this.selectExcelPathButton.Name = "selectExcelPathButton";
            this.selectExcelPathButton.Size = new System.Drawing.Size(75, 23);
            this.selectExcelPathButton.TabIndex = 9;
            this.selectExcelPathButton.Text = "Browse";
            this.selectExcelPathButton.UseVisualStyleBackColor = true;
            this.selectExcelPathButton.Click += new System.EventHandler(this.selectExcelPathButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.delete1);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.selectLadCsvButton);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.selectPlaCsvButton);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.selectGraCsvButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.selectHanCsvButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 249);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "please add the csv files";
            // 
            // button14
            // 
            this.button14.Enabled = false;
            this.button14.Location = new System.Drawing.Point(186, 184);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(59, 24);
            this.button14.TabIndex = 37;
            this.button14.Text = "Clear";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Enabled = false;
            this.button13.Location = new System.Drawing.Point(483, 184);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(59, 24);
            this.button13.TabIndex = 36;
            this.button13.Text = "Clear";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Enabled = false;
            this.button12.Location = new System.Drawing.Point(480, 134);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(59, 24);
            this.button12.TabIndex = 35;
            this.button12.Text = "Clear";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(480, 84);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(59, 24);
            this.button11.TabIndex = 34;
            this.button11.Text = "Clear";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(186, 134);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(59, 24);
            this.button10.TabIndex = 33;
            this.button10.Text = "Clear";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(186, 84);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(59, 24);
            this.button9.TabIndex = 32;
            this.button9.Text = "Clear";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(480, 33);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(59, 24);
            this.button8.TabIndex = 31;
            this.button8.Text = "Clear";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // delete1
            // 
            this.delete1.Location = new System.Drawing.Point(186, 33);
            this.delete1.Name = "delete1";
            this.delete1.Size = new System.Drawing.Size(59, 24);
            this.delete1.TabIndex = 30;
            this.delete1.Text = "Clear";
            this.delete1.UseVisualStyleBackColor = true;
            this.delete1.Click += new System.EventHandler(this.delete1_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(340, 217);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 12);
            this.label20.TabIndex = 29;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(48, 217);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 12);
            this.label19.TabIndex = 28;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(340, 161);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 12);
            this.label18.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(48, 161);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 12);
            this.label17.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(291, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 12);
            this.label16.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(48, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 12);
            this.label15.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(340, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 12);
            this.label14.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(48, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 12);
            this.label13.TabIndex = 22;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(415, 184);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(58, 24);
            this.button6.TabIndex = 21;
            this.button6.Text = "Browse";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(271, 188);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Steel Structure Summarized";
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(121, 184);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(59, 24);
            this.button7.TabIndex = 19;
            this.button7.Text = "Browse";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 178);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.MaximumSize = new System.Drawing.Size(100, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 30);
            this.label10.TabIndex = 18;
            this.label10.Text = "MemberParts Start End Location";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(414, 134);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 24);
            this.button5.TabIndex = 17;
            this.button5.Text = "Browse";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(290, 138);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Steel Structure General";
            // 
            // selectLadCsvButton
            // 
            this.selectLadCsvButton.Location = new System.Drawing.Point(415, 84);
            this.selectLadCsvButton.Name = "selectLadCsvButton";
            this.selectLadCsvButton.Size = new System.Drawing.Size(59, 24);
            this.selectLadCsvButton.TabIndex = 15;
            this.selectLadCsvButton.Text = "Browse";
            this.selectLadCsvButton.UseVisualStyleBackColor = true;
            this.selectLadCsvButton.Click += new System.EventHandler(this.selectLadCsvButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(365, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ladders";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(120, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 24);
            this.button3.TabIndex = 13;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Report";
            // 
            // selectPlaCsvButton
            // 
            this.selectPlaCsvButton.Location = new System.Drawing.Point(121, 84);
            this.selectPlaCsvButton.Name = "selectPlaCsvButton";
            this.selectPlaCsvButton.Size = new System.Drawing.Size(59, 24);
            this.selectPlaCsvButton.TabIndex = 11;
            this.selectPlaCsvButton.Text = "Browse";
            this.selectPlaCsvButton.UseVisualStyleBackColor = true;
            this.selectPlaCsvButton.Click += new System.EventHandler(this.selectPlaCsvButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Plates";
            // 
            // selectGraCsvButton
            // 
            this.selectGraCsvButton.Location = new System.Drawing.Point(414, 33);
            this.selectGraCsvButton.Name = "selectGraCsvButton";
            this.selectGraCsvButton.Size = new System.Drawing.Size(60, 24);
            this.selectGraCsvButton.TabIndex = 9;
            this.selectGraCsvButton.Text = "Browse";
            this.selectGraCsvButton.UseVisualStyleBackColor = true;
            this.selectGraCsvButton.Click += new System.EventHandler(this.selectGraCsvButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(366, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Grating";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(184, 318);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 12);
            this.label11.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(184, 389);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 12);
            this.label12.TabIndex = 12;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(471, 285);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 24);
            this.button15.TabIndex = 13;
            this.button15.Text = "Clear";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(471, 355);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 24);
            this.button16.TabIndex = 14;
            this.button16.Text = "Clear";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Green;
            this.progressBar1.Location = new System.Drawing.Point(91, 421);
            this.progressBar1.Maximum = 4;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(283, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(91, 451);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(0, 12);
            this.label21.TabIndex = 16;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 474);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.selectExcelPathButton);
            this.Controls.Add(this.selectTemplateFileButton);
            this.Controls.Add(this.turnButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainWindow";
            this.Text = "csv2excel tool";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button turnButton;
        private System.Windows.Forms.OpenFileDialog selectFileForm;
        private System.Windows.Forms.Button selectHanCsvButton;
        private System.Windows.Forms.Button selectTemplateFileButton;
        private System.Windows.Forms.Button selectExcelPathButton;
        private System.Windows.Forms.FolderBrowserDialog selectPathForm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button delete1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button selectLadCsvButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button selectPlaCsvButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button selectGraCsvButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label label21;
    }
}

