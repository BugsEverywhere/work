using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using System.IO;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Threading;


namespace WindowsFormsApp1
{
    class TurnCsv2Excel
    {
        public static Object locker = new Object();
        public int finishedThread = 0;
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private ProgressBar progressbar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox;
        
        String graCsvFilePath = "";
        String hanCsvFilePath = "";
        String plaCsvFilePath = "";
        String ladCsvFilePath = "";

        String graCsvFileName = "";
        String hanCsvFileName = "";
        String plaCsvFileName = "";
        String ladCsvFileName = "";

        String graExcelPath = "";
        String hanExcelPath = "";
        String plaExcelPath = "";
        String ladExcelPath = "";

        String targetPath = "";
        String templateFilePath = "";

        public TurnCsv2Excel(
            ProgressBar inputBar,System.Windows.Forms.Button inputButton1, 
            System.Windows.Forms.Button inputButton2, System.Windows.Forms.Button inputButton3, 
            System.Windows.Forms.Button inputButton4, System.Windows.Forms.Button inputButton5, 
            System.Windows.Forms.GroupBox inputGroupBox, System.Windows.Forms.Label inputLabel1,
            System.Windows.Forms.Label inputLabel2, System.Windows.Forms.Label inputLabel3,
            System.Windows.Forms.Label inputLabel4, System.Windows.Forms.Label inputLabel5) {

            this.label1 = inputLabel1;
            this.label2 = inputLabel2;
            this.label3 = inputLabel3;
            this.label4 = inputLabel4;
            this.label5 = inputLabel5;
            this.progressbar = inputBar;
            this.button1 = inputButton1;
            this.button2 = inputButton2;
            this.button3 = inputButton3;
            this.button4 = inputButton4;
            this.button5 = inputButton5;
            this.groupBox = inputGroupBox;

        }

        //turn csv files into excel files
        public void turn()
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            String dateString = currentTime.ToString("yyyy-MM-dd");
            String[] dateStringArray = dateString.Split('-');
            String year = dateStringArray[0];
            String month = dateStringArray[1];
            String day = dateStringArray[2];

            graCsvFilePath = Program.gratingCsvPath;
            hanCsvFilePath = Program.handrailsCsvPath;
            plaCsvFilePath = Program.platesCsvPath;
            ladCsvFilePath = Program.laddersCsvPath;

            graCsvFileName = Program.gratingCsvName;
            hanCsvFileName = Program.handrailsCsvName;
            plaCsvFileName = Program.platesCsvNmae;
            ladCsvFileName = Program.laddersCsvName;

            targetPath = Program.excelFilePath;
            templateFilePath = Program.templatesFilePath;

            if (!String.IsNullOrEmpty(templateFilePath))
            {
                DirectoryInfo folder = new DirectoryInfo(templateFilePath);

                foreach (FileInfo file in folder.GetFiles("*.xls"))
                {
                    if (file.FullName.Contains("Grating"))
                    {
                        graExcelPath = file.CopyTo(targetPath + '\\'+year+month+day+ "_Grating_DE1038TR_12329.xls", true).FullName;
                    }
                    else if (file.FullName.Contains("Handrails"))
                    {
                        hanExcelPath = file.CopyTo(targetPath + '\\' + year + month + day + "_Handrails Report_DE1038TR_12215.xls", true).FullName;
                    }
                    else if (file.FullName.Contains("Ladders"))
                    {
                        plaExcelPath = file.CopyTo(targetPath + '\\' + year + month + day + "_Ladders Report_DE1038TR_12546.xls", true).FullName;
                    }
                    else if (file.FullName.Contains("Plates"))
                    {
                        ladExcelPath = file.CopyTo(targetPath + '\\'+ year+ month + day + "_Plates_DE1038TR_12536.xls", true).FullName;
                    }
                }

                List<Thread> threadList = new List<Thread>();

                if (!String.IsNullOrEmpty(graCsvFilePath))
                {
                    Thread graThread = new Thread(() => fillGraExcel(graCsvFilePath, graExcelPath));
                    graThread.Start();
                    threadList.Add(graThread);
                }

                if (!String.IsNullOrEmpty(hanCsvFilePath))
                {
                    Thread hanThread = new Thread(() => fillHanExcel(hanCsvFilePath, hanExcelPath));
                    hanThread.Start();
                    threadList.Add(hanThread);
                }

                if (!String.IsNullOrEmpty(ladCsvFilePath))
                {
                    Thread ladThread = new Thread(() => fillLadExcel(ladCsvFilePath, ladExcelPath));
                    ladThread.Start();
                    threadList.Add(ladThread);
                }

                if (!String.IsNullOrEmpty(plaCsvFilePath))
                {
                    Thread plaThread = new Thread(() => fillPlaExcel(plaCsvFilePath, plaExcelPath));
                    plaThread.Start();
                    threadList.Add(plaThread);
                }
            }
        }

        //fill Grating excel file
        private void fillGraExcel(String graCsvFilePath, String graExcelPath)
        {

            ExcelApplication excel = new ExcelApplication();

            Workbook wb = excel.Workbooks.Open(graExcelPath);

            Worksheet ws = wb.Worksheets[2] as Worksheet;

            FileInfo fi = new FileInfo(graCsvFilePath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }

            FileStream fs = new FileStream(graCsvFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            Encoding encoding = GetType(fs);
            fs = null;
            GC.Collect();
            FileStream fsAgain = new FileStream(graCsvFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader reader = new StreamReader(fsAgain, encoding);

            String singleLine = null;

            int lineIndex = 0;

            System.Data.DataTable dataTable = new System.Data.DataTable();

            dataTable.Columns.Add("Item");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Material");
            dataTable.Columns.Add("Thickness");
            dataTable.Columns.Add("NetProjectedArea");
            dataTable.Columns.Add("TotalProjectedArea");
            dataTable.Columns.Add("kg");
            dataTable.Columns.Add("NetWeight");
            dataTable.Columns.Add("Path");

            while ((singleLine = reader.ReadLine()) != null)
            {
                lineIndex++;
                if (lineIndex == 1)
                {
                    continue;
                }

                String[] values = singleLine.Split(';');

                dataTable.Rows.Add(values);

            }

            reader.Close();

            int rowNum = 14;

            double netProjectedAreaSum = 0;
            double totalProjectedAreaSum = 0;
            double netWeightSum = 0;

            for (int i = 1; i < dataTable.Rows.Count; i++)
            {
                string item = dataTable.Rows[i]["Item"].ToString();
                string name = dataTable.Rows[i]["Name"].ToString();
                string material = dataTable.Rows[i]["Material"].ToString();
                string thickness = dataTable.Rows[i]["Thickness"].ToString();
                string netProjectedArea = dataTable.Rows[i]["NetProjectedArea"].ToString();
                string totalProjectedArea = dataTable.Rows[i]["TotalProjectedArea"].ToString();
                string kg = dataTable.Rows[i]["kg"].ToString();
                string netWeight = dataTable.Rows[i]["NetWeight"].ToString();
                string path = dataTable.Rows[i]["Path"].ToString();

                ws.Cells[rowNum, 1] = item;
                ws.Cells[rowNum, 2] = name;
                ws.Cells[rowNum, 3] = material;
                ws.Cells[rowNum, 4] = thickness;
                ws.Cells[rowNum, 5] = netProjectedArea;
                ws.Cells[rowNum, 6] = totalProjectedArea;
                ws.Cells[rowNum, 7] = kg;
                ws.Cells[rowNum, 8] = netWeight;
                ws.Cells[rowNum, 9] = path;

                netProjectedAreaSum = netProjectedAreaSum + Double.Parse(netProjectedArea);
                totalProjectedAreaSum = totalProjectedAreaSum + Double.Parse(totalProjectedArea);
                netWeightSum = netWeightSum + Double.Parse(netWeight);

                rowNum++;
            }

            rowNum++;
            ws.Cells[rowNum, 4] = "Totals:";
            ws.Cells[rowNum, 5] = Math.Round(netProjectedAreaSum, 2);
            ws.Cells[rowNum, 6] = Math.Round(totalProjectedAreaSum,2);
            ws.Cells[rowNum, 8] = Math.Round(netWeightSum,2);

            rowNum++;
            ws.Cells[rowNum, 4] = "Totals:";
            ws.Cells[rowNum, 8] = Math.Round(netWeightSum, 2) / 1000;
            ws.Cells[rowNum, 9] = "tons";

            wb.Save();
            excel.Visible = true;

            lock (locker) {
                finishedThread++;
                this.progressbar.Value = this.progressbar.Value + 1;
                if (finishedThread==4) {
                    this.label1.Text = "Done!";
                    this.button1.Enabled = true;
                    this.button2.Enabled = true;
                    this.button3.Enabled = true;
                    this.button4.Enabled = true;
                    this.button5.Enabled = true;
                    this.groupBox.Enabled = true;

                    this.label2.Enabled = true;
                    this.label3.Enabled = true;
                    this.label4.Enabled = true;
                    this.label5.Enabled = true;
                }
            }
            
        }

        //fill handrails excel file
        private void fillHanExcel(String hanCsvFilePath, String hanExcelPath)
        {

            ExcelApplication excel = new ExcelApplication();

            Workbook wb = excel.Workbooks.Open(hanExcelPath);

            Worksheet ws = wb.Worksheets[2] as Worksheet;

            FileInfo fi = new FileInfo(hanCsvFilePath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }


            FileStream fs = new FileStream(hanCsvFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            Encoding encoding = GetType(fs);
            fs = null;
            GC.Collect();
            FileStream fsAgain = new FileStream(hanCsvFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader reader = new StreamReader(fsAgain, encoding);

            String singleLine = null;

            int lineIndex = 0;

            System.Data.DataTable dataTable = new System.Data.DataTable();
            
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Type");
            dataTable.Columns.Add("Length");
            dataTable.Columns.Add("Height");
            dataTable.Columns.Add("Path");

            while ((singleLine = reader.ReadLine()) != null)
            {
                lineIndex++;
                if (lineIndex == 1)
                {
                    continue;
                }

                String[] values = singleLine.Split(';');

                dataTable.Rows.Add(values);

            }

            reader.Close();

            int rowNum = 14;

            double heightSum = 0;

            for (int i = 1; i < dataTable.Rows.Count; i++)
            {
                string name = dataTable.Rows[i]["Name"].ToString();
                string type = dataTable.Rows[i]["Type"].ToString();
                string length = dataTable.Rows[i]["Length"].ToString();
                string height = dataTable.Rows[i]["Height"].ToString();
                string path = dataTable.Rows[i]["Path"].ToString();

                ws.Cells[rowNum, 1] = name;
                ws.Cells[rowNum, 2] = type;
                ws.Cells[rowNum, 3] = length;
                ws.Cells[rowNum, 4] = height;
                ws.Cells[rowNum, 5] = path;

                heightSum = heightSum + Double.Parse(height);
                rowNum++;
            }

            rowNum++;
            ws.Cells[rowNum, 2] = "Totals:";
            ws.Cells[rowNum, 3] = Math.Round(heightSum, 2);
            ws.Cells[rowNum, 4] = 'm';

            wb.Save();
            excel.Visible = true;

            lock (locker)
            {
                finishedThread++;
                this.progressbar.Value = this.progressbar.Value + 1;
                if (finishedThread == 4)
                {
                    this.label1.Text = "Done!";
                    this.button1.Enabled = true;
                    this.button2.Enabled = true;
                    this.button3.Enabled = true;
                    this.button4.Enabled = true;
                    this.button5.Enabled = true;
                    this.groupBox.Enabled = true;

                    this.label2.Enabled = true;
                    this.label3.Enabled = true;
                    this.label4.Enabled = true;
                    this.label5.Enabled = true;

                }
            }
            
        }

        //fill ladder excel file
        private void fillLadExcel(String ladCsvFilePath, String ladExcelPath)
        {

            ExcelApplication excel = new ExcelApplication();

            Workbook wb = excel.Workbooks.Open(ladExcelPath);

            Worksheet ws = wb.Worksheets[2] as Worksheet;

            FileInfo fi = new FileInfo(ladCsvFilePath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }


            FileStream fs = new FileStream(ladCsvFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            Encoding encoding = GetType(fs);
            fs = null;
            GC.Collect();
            FileStream fsAgain = new FileStream(ladCsvFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader reader = new StreamReader(fsAgain, encoding);

            String singleLine = null;

            int lineIndex = 0;

            System.Data.DataTable dataTable = new System.Data.DataTable();

            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Length");
            dataTable.Columns.Add("Width");
            dataTable.Columns.Add("Type");
            dataTable.Columns.Add("Path");

            while ((singleLine = reader.ReadLine()) != null)
            {
                lineIndex++;
                if (lineIndex == 1)
                {
                    continue;
                }

                String[] values = singleLine.Split(';');

                dataTable.Rows.Add(values);

            }

            reader.Close();

            int rowNum = 14;

            double lengthSum = 0;

            for (int i = 1; i < dataTable.Rows.Count; i++)
            {
                string name = dataTable.Rows[i]["Name"].ToString();
                string length = dataTable.Rows[i]["Length"].ToString();
                string height = dataTable.Rows[i]["Width"].ToString();
                string type = dataTable.Rows[i]["Type"].ToString();
                string path = dataTable.Rows[i]["Path"].ToString();

                ws.Cells[rowNum, 1] = name;
                ws.Cells[rowNum, 2] = length;
                ws.Cells[rowNum, 3] = height;
                ws.Cells[rowNum, 4] = type;
                ws.Cells[rowNum, 5] = path;

                lengthSum = lengthSum + Double.Parse(length);
                rowNum++;
            }

            rowNum++;
            ws.Cells[rowNum, 1] = "Totals:";
            ws.Cells[rowNum, 2] = Math.Round(lengthSum, 2);

            wb.Save();
            excel.Visible = true;

            lock (locker)
            {
                finishedThread++;
                this.progressbar.Value = this.progressbar.Value + 1;
                if (finishedThread == 4)
                {
                    this.label1.Text = "Done!";
                    this.button1.Enabled = true;
                    this.button2.Enabled = true;
                    this.button3.Enabled = true;
                    this.button4.Enabled = true;
                    this.button5.Enabled = true;
                    this.groupBox.Enabled = true;

                    this.label2.Enabled = true;
                    this.label3.Enabled = true;
                    this.label4.Enabled = true;
                    this.label5.Enabled = true;

                }
            }
            
        }

        //fill plates excel file
        private void fillPlaExcel(String plaCsvFilePath, String plaExcelPath)
        {

            ExcelApplication excel = new ExcelApplication();

            Workbook wookbook = excel.Workbooks.Open(plaExcelPath);

            Worksheet worksheet = wookbook.Worksheets[2] as Worksheet;

            FileInfo fileinfo = new FileInfo(plaCsvFilePath);

            if (!fileinfo.Directory.Exists)
            {
                fileinfo.Directory.Create();
            }

            FileStream fileStream = new FileStream(plaCsvFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            Encoding encoding = GetType(fileStream);

            fileStream = null;

            GC.Collect();

            FileStream fileStreamAgain = new FileStream(plaCsvFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            StreamReader reader = new StreamReader(fileStreamAgain, encoding);

            String singleLine = null;

            int lineIndex = 0;

            System.Data.DataTable dataTable = new System.Data.DataTable();

            dataTable.Columns.Add("Item");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Type");
            dataTable.Columns.Add("Spref");
            dataTable.Columns.Add("Material");
            dataTable.Columns.Add("Length");
            dataTable.Columns.Add("Width");
            dataTable.Columns.Add("Weight");
            dataTable.Columns.Add("SurfaceArea");
            dataTable.Columns.Add("Path");

            while ((singleLine = reader.ReadLine()) != null)
            {
                lineIndex++;
                if (lineIndex == 1)
                {
                    continue;
                }

                String[] values = singleLine.Split(';');

                dataTable.Rows.Add(values);

            }

            reader.Close();

            int rowNum = 14;

            double weightSum = 0;

            for (int i = 1; i < dataTable.Rows.Count; i++)
            {
                string item = dataTable.Rows[i]["Item"].ToString();
                string name = dataTable.Rows[i]["Name"].ToString();
                string type = dataTable.Rows[i]["Type"].ToString();
                string spref = dataTable.Rows[i]["Spref"].ToString();
                string material = dataTable.Rows[i]["Material"].ToString();
                string length = dataTable.Rows[i]["Length"].ToString();
                string width = dataTable.Rows[i]["Width"].ToString();
                string weight = dataTable.Rows[i]["Weight"].ToString();
                string surfaceArea = dataTable.Rows[i]["SurfaceArea"].ToString();             
                string path = dataTable.Rows[i]["Path"].ToString();

                worksheet.Cells[rowNum, 1] = item;
                worksheet.Cells[rowNum, 2] = name;
                worksheet.Cells[rowNum, 3] = type;
                worksheet.Cells[rowNum, 4] = spref;
                worksheet.Cells[rowNum, 5] = material;
                worksheet.Cells[rowNum, 6] = length;
                worksheet.Cells[rowNum, 7] = width;
                worksheet.Cells[rowNum, 8] = weight;
                worksheet.Cells[rowNum, 9] = surfaceArea;
                worksheet.Cells[rowNum, 10] = path;

                weightSum = weightSum + Double.Parse(weight);
                rowNum++;
            }

            rowNum++;
            worksheet.Cells[rowNum, 7] = "Totals:";
            worksheet.Cells[rowNum, 8] = Math.Round(weightSum, 2);

            rowNum++;
            worksheet.Cells[rowNum, 7] = "Totals:";
            worksheet.Cells[rowNum, 8] = "0.00";
            worksheet.Cells[rowNum, 8] = "to";

            wookbook.Save();
            excel.Visible = true;

            lock (locker)
            {
                finishedThread++;
                this.progressbar.Value = this.progressbar.Value + 1;
                if (finishedThread == 4)
                {
                    this.label1.Text = "Done!";
                    this.button1.Enabled = true;
                    this.button2.Enabled = true;
                    this.button3.Enabled = true;
                    this.button4.Enabled = true;
                    this.button5.Enabled = true;
                    this.groupBox.Enabled = true;

                    this.label2.Enabled = true;
                    this.label3.Enabled = true;
                    this.label4.Enabled = true;
                    this.label5.Enabled = true;

                }
            }
            
        }

        //parse encode of the csv files
        public static System.Text.Encoding GetType(FileStream fs)
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //带BOM 
            Encoding reVal = Encoding.Default;

            BinaryReader r = new BinaryReader(fs, System.Text.Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);
            if (IsUTF8Bytes(ss) || (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF))
            {
                reVal = Encoding.UTF8;
            }
            else if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
            {
                reVal = Encoding.BigEndianUnicode;
            }
            else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
            {
                reVal = Encoding.Unicode;
            }
            r.Close();
            return reVal;

        }

        //if the csv file is in utf-8
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;

            byte curByte; 

            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {                    
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }

                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("unkonwn byte format");
            }
            return true;
        }

    }
}
