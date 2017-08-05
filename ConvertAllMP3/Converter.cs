using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertAllMP3
{
	class Converter
	{
        private string fileName;
        private string outputPath;
        public void Convert(string inputPath, string outputPath)
        {
            string faadLocation = "E:\\faad.exe";
            string lameLocation = "E:\\lame.exe";
            //string faadLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\faad.exe";
            //string lameLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lame.exe";
            fileName = Path.GetFileNameWithoutExtension(inputPath);
            this.outputPath = outputPath;

            Process process = ProcessSetup();
            process.Start();

            //Convert .m4a to .wav using faad.exe
            string faadCommand = String.Format("{0} -o \"{1}\\{2}.wav\" \"{3}\"",
                faadLocation, outputPath, fileName, inputPath);

            process.StandardInput.WriteLine(faadCommand);

            //Convert .wav .mp3 using lame.exe
            string lameCommand = String.Format("{0} --preset standard \"{1}\\{2}.wav\" \"{1}\\{2}.mp3\"",
                lameLocation, outputPath, fileName);

            process.StandardInput.WriteLine(lameCommand);

            //Closes cmd window
            process.StandardInput.WriteLine("Exit");

        }

        //Configures process settings
        private Process ProcessSetup()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(process_Exited);
            return process;
        }

        private void process_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("Complete!!!");
            Process[] matchingProcesses = Process.GetProcessesByName("lame");
            if (matchingProcesses.Length != 0)
            {
                matchingProcesses[0].Kill();
            }

            File.Delete(String.Format("{0}\\{1}.wav", outputPath, fileName));
        }


    }
}
