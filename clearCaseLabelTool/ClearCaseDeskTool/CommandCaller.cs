using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearCaseDeskTool
{
    class CommandCaller
    {

        public CommandCaller() {

        }

        public Task<string> RunSingleCmdLineWithResult(List<string> cmdLines, Process cmdExeProcess)
        {
            lock (this)
            {
                cmdExeProcess.Start();

                return Task.Run(() =>
                {
                    using (StreamWriter sr = cmdExeProcess.StandardInput)
                    {
                        foreach (var v in cmdLines)
                        {
                            sr.WriteLine(v);
                        }
                        sr.Close();
                    }

                    cmdExeProcess.WaitForExit();

                    string outStr = cmdExeProcess.StandardOutput.ReadToEnd();

                    cmdExeProcess.Close();

                    return outStr;
                });

            }
        }
    }
}
