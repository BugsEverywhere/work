using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearCaseDeskTool
{
    class Encriptor : CommandCaller
    {

        private string localOriginalPath;

        private string localOperatePath;

        private string targetProPath;

        private Dictionary<string, string> fileNamePathMap;

        public Encriptor(string originalPath, string operatePath, string targetPath, Dictionary<string, string> namePathMap)
        {

            localOriginalPath = originalPath;

            localOperatePath = operatePath;

            targetProPath = targetPath;

            fileNamePathMap = namePathMap;

        }
        
        public void EncriptApply()
        {

            string rootPath = Path.GetPathRoot(localOperatePath);

            Process process = new Process();

            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            if (localOperatePath != null && localOriginalPath != null)
            {
                List<string> cmdLines = new List<string>();

                cmdLines.Add(rootPath + ":");

                cmdLines.Add("cd "+ localOperatePath);

                cmdLines.Add("pmlencrypt.exe -pmllib " + Path.GetFileName(localOriginalPath) + " pmllib");

                cmdLines.Add("exit");

                process.Start();

                //this tool is not suitable for running in async way, that may cause some problem
                using (StreamWriter sr = process.StandardInput)
                {
                    foreach (var v in cmdLines)
                    {
                        sr.WriteLine(v);
                    }
                    sr.Close();
                }

                process.Close();
            }

            CopyFiles2ProductEnvironment();

        }

        public List<string> CompareFolders(string originalFolder, string newFolder)
        {

            DirectoryInfo oldFolderDirectoryInfo = new DirectoryInfo(originalFolder);
            DirectoryInfo newFolderDirectoryInfo = new DirectoryInfo(newFolder);

            List<string> differentFilePathList = new List<string>();

            FileInfo[] oldFolderFileInfoArray = oldFolderDirectoryInfo.GetFiles("*", SearchOption.AllDirectories);
            FileInfo[] newFolderFileInfoArray = newFolderDirectoryInfo.GetFiles("*", SearchOption.AllDirectories);

            Dictionary<string, string> oldFolderFileNameFullPathMap = new Dictionary<string, string>();
            Dictionary<string, string> newFolderFileNameFullPathMap = new Dictionary<string, string>();


            foreach (FileInfo singleFileInfo in oldFolderFileInfoArray)
            {
                oldFolderFileNameFullPathMap.Add(singleFileInfo.Name, singleFileInfo.FullName);
            }

            foreach (FileInfo singleFileInfo in newFolderFileInfoArray)
            {
                newFolderFileNameFullPathMap.Add(singleFileInfo.Name, singleFileInfo.FullName);
            }

            //store the paths of all the distinct files into differentFilePathList
            foreach (var singleEntry in oldFolderFileNameFullPathMap)
            {
                if (!newFolderFileNameFullPathMap.ContainsKey(singleEntry.Key))
                {
                    differentFilePathList.Add(singleEntry.Value);
                }
            }

            return differentFilePathList;

        }
        
        private void ClearAll(string folderDirectory)
        {

            File.SetAttributes(folderDirectory, FileAttributes.Normal);

            string[] files = Directory.GetFiles(folderDirectory);
            string[] dirs = Directory.GetDirectories(folderDirectory);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                ClearAll(dir);
                Directory.Delete(dir);
            }

        }

        private void CopyFromOriginalToPmllib()
        {

            List<string> distinctFileList = CompareFolders(localOriginalPath, localOperatePath + "\\pmllib");

            foreach (string singleDistinctFilePath in distinctFileList)
            {

                FileInfo originalFileInfo = new FileInfo(singleDistinctFilePath);

                string newFullPath = singleDistinctFilePath.Replace("pmllib_original", "pmllib");

                FileInfo newFileInfo = new FileInfo(newFullPath);

                if (Directory.Exists(newFileInfo.DirectoryName))
                {

                    originalFileInfo.CopyTo(newFullPath);

                }
                else
                {

                    Directory.CreateDirectory(newFileInfo.DirectoryName);

                    originalFileInfo.CopyTo(newFullPath);

                }
            }


        }

        public void CopyFolder2Local()
        {
            ClearAll(localOriginalPath);

            foreach (var singleFileNamePath in fileNamePathMap)
            {
                //copy
                CopyClearCaseAll(singleFileNamePath.Value, localOriginalPath + '\\' + singleFileNamePath.Key);
                
            }

        }

        public void CopyFiles2ProductEnvironment()
        {

            //make sure all the files are in pmllib folder
            CopyFromOriginalToPmllib();

            if (localOperatePath != null)
            {

                CopyAll(localOperatePath + "\\pmllib", targetProPath);

            }

        }

        private void CopyAll(string source, string target)
        {

            Directory.CreateDirectory(target);

            File.SetAttributes(source, FileAttributes.Normal);

            string[] files = Directory.GetFiles(source);
            string[] dirs = Directory.GetDirectories(source);

            foreach (string file in files)
            {
                try
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Copy(file, target + '\\' + Path.GetFileName(file), true);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(file + " copy denied. "+e.Message);
                }
            }

            foreach (string dir in dirs)
            {
                CopyAll(source + '\\' + Path.GetFileName(dir), target + '\\' + Path.GetFileName(dir));
            }

        }

        private void CopyClearCaseAll(string source, string target) {

            DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(source);

            FileInfo[] sourceFileInfos = sourceDirectoryInfo.GetFiles();
            DirectoryInfo[] sourceDirectoryInfos = sourceDirectoryInfo.GetDirectories();

            foreach (FileInfo singleFileInfo in sourceFileInfos) {
                if (Directory.Exists(target))
                {
                    singleFileInfo.CopyTo(target + '\\' + Path.GetFileName(singleFileInfo.FullName), true);
                }
                else {
                    Directory.CreateDirectory(target);
                    singleFileInfo.CopyTo(target + '\\' + Path.GetFileName(singleFileInfo.FullName), true);
                }
                
            }

            foreach(DirectoryInfo singleDirectoryInfo in sourceDirectoryInfos)
            {
                CopyClearCaseAll(singleDirectoryInfo.FullName, target+'\\'+Path.GetFileName(singleDirectoryInfo.FullName));
            }
        }
    }
}
