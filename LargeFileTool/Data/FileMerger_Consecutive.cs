using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace LargeFileTool.Data
{
    public class FileMerger_Consecutive
    {
        BackgroundWorker MyBackgroundWorker;
        List<string> MyInputFiles;
        string MyOutputFile;

        public FileMerger_Consecutive(BackgroundWorker bw, string outputFile, List<string> inputFiles)
        {
            MyBackgroundWorker = bw;
            MyOutputFile = outputFile;
            MyInputFiles = inputFiles;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(MergeFiles);
        }

        private void MergeFiles(object sender, EventArgs e)
        {
            StreamReader sr = null;
            StreamWriter sw = null;
            char[] buffer;
            int bufferSize = 50000;
            int readCount;

            try
            {
                buffer = new char[bufferSize];
                sw = new StreamWriter(MyOutputFile);
                foreach (string str in MyInputFiles)
                {
                    sr = new StreamReader(str);

                    while (!sr.EndOfStream)
                    {
                        readCount = sr.Read(buffer, 0, bufferSize);
                        sw.Write(buffer, 0, readCount);
                    }
                    if (sr != null)
                    {
                        sr.Close();
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
