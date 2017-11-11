using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConvertAllMP3.Classes;

namespace ConvertAllMP3
{
	class Converter  
	{
        private string fileName;
        private string outputPath;


        public void ConvertDirectory(string root)
        {
            Stack<string> dirs = new Stack<string>();

            dirs.Push(root);

            while(dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;

                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                catch(UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch(System.IO.DirectoryNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                string[] files = null;

                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch(System.IO.DirectoryNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }


                Process process = ProcessSetup();
                process.Start();

                foreach(string file in files)
                {
                    try
                    {
                        Convert(process, file, @"E:\");
                    }
                    catch(FileNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }

                foreach(string str in subDirs)
                {
                    dirs.Push(str);
                }
            }
        }

        private void Convert(Process process, string inputPath, string outputPath)
        {
            fileName = Path.GetFileNameWithoutExtension(inputPath);
            this.outputPath = outputPath;


            //Convert .m4a to .wav using faad.exe
            string faadCommand = GetFaadCommand(inputPath, outputPath);

            process.StandardInput.WriteLine(faadCommand);

            //Convert .wav .mp3 using lame.exe

            string lameCommand = GetLameCommand(inputPath, outputPath);
            process.StandardInput.WriteLine(lameCommand);

            //Closes cmd window
            process.StandardInput.WriteLine("Exit");

        }

        private string GetFaadCommand(string inputPath, string outputPath)
        {
            string faadCommand = String.Format("{0} -o \"{1}\\{2}.wav\" \"{3}\"",
                FileLocations.faadLocation, outputPath, fileName, inputPath);
            return faadCommand;
        }

        private string GetLameCommand(string inputPath, string outputPath)
        {
            string lameCommand = String.Format("{0} --preset standard \"{1}\\{2}.wav\" \"{1}\\{2}.mp3\"",
                FileLocations.lameLocation, outputPath, fileName);
            return lameCommand;
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
