using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearCaseDeskTool
{
    class LabelStuff : CommandCaller
    {
        private Dictionary<string, string> nameDirectoryMap;

        private Dictionary<string, string> nameRootMap;

        public LabelStuff(Dictionary<string, string> nameDirectoryMapRef, Dictionary<string, string> nameRootMapRef) {

            nameDirectoryMap = nameDirectoryMapRef;

            nameRootMap = nameRootMapRef;

        }

        async public void LabelOn() {


        }

        async public Task<Dictionary<string, string>> GetVersionResultMap() {

            Process process = new Process();

            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "C:\\Program Files (x86)\\IBM\\RationalSDLC\\ClearCase\\bin\\cleartool.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            Dictionary<string, string> filesVersionResultMap = new Dictionary<string, string>();

            foreach (var singleFileNameDirectory in nameDirectoryMap)
            {

                process.Start();

                string result;

                List<string> commandLines = new List<string>();

                commandLines.Add(nameRootMap[singleFileNameDirectory.Key]+":");

                commandLines.Add("cd " + singleFileNameDirectory.Value);

                commandLines.Add("lsvtree " + singleFileNameDirectory.Key);

                commandLines.Add("exit");

                result = await RunSingleCmdLineWithResult(commandLines, process);

                filesVersionResultMap.Add(singleFileNameDirectory.Key, result);

                process.Close();
            }

            return filesVersionResultMap;

        }


        //Since the version tree result from cleartool for a single file looks like this (label on last version):

        //"setSubstDrive.pmlfnc@@\main
        //setSubstDrive.pmlfnc@@\main\1 (IsoTools_V1.45)
        //setSubstDrive.pmlfnc@@\main\2 (IsoTools_V1.46)
        //setSubstDrive.pmlfnc@@\main\4 (IsoTools_V1.48)
        //setSubstDrive.pmlfnc@@\main\6 (IsoTools_V1.50, IsoTools_V1.49)
        //setSubstDrive.pmlfnc@@\main\8 (IsoTools_V1.52, IsoTools_V1.51)
        //setSubstDrive.pmlfnc@@\main\9"

        //or this (no label on last version):

        //sieCleanAttributes.pmlfrm@@\main
        //sieCleanAttributes.pmlfrm@@\main\1

        //So we have to parse the version result of each file, getting the latest version label, 
        //which In this case, is "IsoTools_V1.52".
        //current version label should be "IsoTools_V1.53"
        public DataTable GetCurrentVersionLabel(Dictionary<string,string> filesVersionResultMap) {

            DataTable dataTable = new DataTable();
            DataColumn fileName = new DataColumn("File Name", typeof(string));
            DataColumn fileLabel = new DataColumn("Label to be added", typeof(string));
            dataTable.Columns.Add(fileName);
            dataTable.Columns.Add(fileLabel);

            foreach (var singleVersionTree in filesVersionResultMap)
            {

                string currentVersionTypeName = "";
                string currentVersionNum = "";
                string currentVersionLabel = "";
                
                //split the result into lines
                string[] labelArray = singleVersionTree.Value.Split('\r');
                //get last version line, the third last line.
                //for instance: 
                string lastVersionLabelSingleLine = labelArray[labelArray.Length - 3];

                string[] tempArray = lastVersionLabelSingleLine.Split('\\');
                if (tempArray.Length == 2 && tempArray[1].Equals("main"))
                {
                    //Current version is the first version, no label on the last one
                    AddLabelForm addLabelForm = new AddLabelForm();

                    addLabelForm.label1.Text = addLabelForm.label1.Text + singleVersionTree.Key;

                    var dialogResult = addLabelForm.ShowDialog();

                    dataTable.Rows.Add(singleVersionTree.Key, ""); 

                }
                else
                {
                    //there is a label on last version
                    string[] lastVersionLabelArray = tempArray[2].Split(' ');

                    string lastVersionLabel = null;

                    //pick the latest version label to lastVersionLabel
                    //for instance: "(IsoTools_V1.45)" or "(IsoTools_V1.50," or "IsoTools_V1.49)"
                    lastVersionLabel = lastVersionLabelArray[1];
                    
                    if (lastVersionLabel != null)
                    {
                        //if there is a label on last version

                        //clean up the string
                        if (lastVersionLabel.Contains("(") || lastVersionLabel.Contains(")")|| lastVersionLabel.Contains(","))
                        {
                            lastVersionLabel = lastVersionLabel.Replace("(", "");
                            lastVersionLabel = lastVersionLabel.Replace(")", "");
                            lastVersionLabel = lastVersionLabel.Replace(",", "");
                        }

                        //get the label type name
                        int lastIndexOfDash = lastVersionLabel.LastIndexOf("_");
                        currentVersionTypeName = lastVersionLabel.Remove(lastIndexOfDash);

                        string[] labelSplitWithDash = lastVersionLabel.Split('_');

                        //version numbers are always the last one, splited by "_"
                        string labelVersionNum = labelSplitWithDash[labelSplitWithDash.Length-1];

                        string[] labelVersionStringArray = labelVersionNum.Split('.');

                        int[] labelVersionNumArray = new int[labelVersionStringArray.Length];

                        int i = 0;

                        foreach (string singleLabelNum in labelVersionStringArray)
                        {

                            labelVersionNumArray[i] = int.Parse(singleLabelNum);

                            i++;

                        }

                        //summarize the version number into currentVersionNum
                        string[] currentVersionNumStringArray = GetCurrentVersionNum(labelVersionNumArray).Cast<string>().ToArray();
                        foreach (string singleNum in currentVersionNumStringArray) {
                            currentVersionNum = currentVersionNum + "." + singleNum;
                        }
                        currentVersionNum.Remove(0,1);
                        
                    }

                    currentVersionLabel = currentVersionTypeName + "_V" + currentVersionNum;
                    dataTable.Rows.Add(singleVersionTree.Key, currentVersionLabel);

                }
                
            }
            
            return dataTable;

        }

        private int[] GetCurrentVersionNum(int[] versionNumArray)
        {

            int[] currentVersionNum = new int[versionNumArray.Length];

            if (versionNumArray.Length > 1)
            {

                string lastOneStringOriginal = versionNumArray[versionNumArray.Length - 1].ToString();

                int lastOneDigitCountOriginal = lastOneStringOriginal.Length;

                int lastDigitVersionNum = versionNumArray[versionNumArray.Length - 1] + 1;

                if (lastDigitVersionNum.ToString().Length > lastOneDigitCountOriginal)
                {

                    //if there is a carry of lastDigitVersionNum
                    int[] lowDigitVersionNumArray = new int[1];

                    lowDigitVersionNumArray[0] = 0;

                    int[] hignDigitVersionNumArrayOriginal = new int[versionNumArray.Length - 1];

                    Array.Copy(versionNumArray, hignDigitVersionNumArrayOriginal, versionNumArray.Length - 1);

                    currentVersionNum = MergerArray(GetCurrentVersionNum(hignDigitVersionNumArrayOriginal), lowDigitVersionNumArray);

                }
                else
                {

                    //No carry of lastDigitVersionNum
                    int[] lowDigitVersionNumArray = new int[1];

                    lowDigitVersionNumArray[0] = lastDigitVersionNum;

                    int[] hignDigitVersionNumArrayOriginal = new int[versionNumArray.Length - 1];

                    Array.Copy(versionNumArray, hignDigitVersionNumArrayOriginal, versionNumArray.Length - 1);

                    currentVersionNum = MergerArray(hignDigitVersionNumArrayOriginal, lowDigitVersionNumArray);

                }
            }
            else {

                currentVersionNum[0] = versionNumArray[0] + 1;

            }

            return currentVersionNum;

        }

        private int[] MergerArray(int[] First, int[] Second)
        {
            int[] result = new int[First.Length + Second.Length];
            First.CopyTo(result, 0);
            Second.CopyTo(result, First.Length);
            return result;
        }


    }
}
