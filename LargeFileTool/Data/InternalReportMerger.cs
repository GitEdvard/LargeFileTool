using System;
using System.ComponentModel;
using System.IO;

namespace LargeFileTool.Data
{
    public class InternalReportMerger
    {
        private BackgroundWorker MyBackgroundWorker;
        private string MySelectedPath;
        public InternalReportMerger(string  selectedPath, BackgroundWorker bw)
        {
            MyBackgroundWorker = bw;
            MySelectedPath = selectedPath;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(MergeReport);
        }
        private void MergeReport(object sender, EventArgs e)
        {
            string[] IR_files;
            string textLine;
            string fileName_withoutSuffix;
            StreamReader sr = null;
            StreamWriter sw = null;

            IR_files = Directory.GetFiles(MySelectedPath, "*.crp");
            try
            {
                foreach (string file in IR_files)
                {
                    if (file.Contains("_items"))
                    {
                        fileName_withoutSuffix = file.Substring(0, file.IndexOf("_items"));
                        sw = new StreamWriter(fileName_withoutSuffix + "_merged.crp");
                        sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            textLine = sr.ReadLine();
                            sw.WriteLine(textLine);
                        }
                        sr.Close();
                        break;
                    }
                }
                foreach (string file in IR_files)
                {
                    if (file.Contains("_markers"))
                    {
                        sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            textLine = sr.ReadLine();
                            sw.WriteLine(textLine);
                        }
                        sr.Close();
                        break;
                    }
                }
                foreach (string file in IR_files)
                {
                    if (file.Contains("_genotypes"))
                    {
                        sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            textLine = sr.ReadLine();
                            sw.WriteLine(textLine);
                        }
                        sr.Close();
                        break;
                    }
                }
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }        
        }
    }
}
