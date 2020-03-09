using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace TRPC_Core.Utils
{
    class 
        FileOperations
    {
        public static void SaveData(string[] lines, string fileName)
        {
            var docPath = Environment.CurrentDirectory;
            File.WriteAllLines(Path.Combine(docPath, fileName), lines);
        }

        public static string[] ReadData(string fileName)
        {
            return File.Exists(fileName) ? File.ReadAllLines(fileName) : new string[0];
        }
    }
}
