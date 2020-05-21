using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace open
{
    class Program
    {

        private void StartProcess(string path)
        {
            ProcessStartInfo StartInformation = new ProcessStartInfo();

            StartInformation.FileName = path;

            Process process = Process.Start(StartInformation);

            process.EnableRaisingEvents = true;
        }

        static void Main(string[] args)
        {
            string folderPath = Directory.GetCurrentDirectory();
            string dumpFile = String.Format("Current Directory is {0}", folderPath);
            Console.WriteLine(dumpFile);
            Process.Start("explorer.exe", folderPath);
            //Program test = new Program();
            //test.StartProcess(folderPath);
        }
    }
}
