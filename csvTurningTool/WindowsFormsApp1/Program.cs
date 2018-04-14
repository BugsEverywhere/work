using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        public static String handrailsCsvPath;
        public static String gratingCsvPath;
        public static String platesCsvPath;
        public static String laddersCsvPath;

        public static String handrailsCsvName;
        public static String gratingCsvName;
        public static String platesCsvNmae;
        public static String laddersCsvName;

        public static String excelFilePath;
        public static String templatesFilePath;
        
        /// <summary>
        /// main function
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainWindow());
        }
    }
}
