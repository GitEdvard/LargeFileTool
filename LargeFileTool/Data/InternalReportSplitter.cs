using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace Molmed.LargeFileTool.Data
{
    public class InternalReportSplitter
    {
        private BackgroundWorker MyBackGroundWorker;
        private string MyInternalReportFilePath;
        public InternalReportSplitter(string internalReportFilePath, BackgroundWorker bwd)
        {
            MyBackGroundWorker = bwd;
            MyInternalReportFilePath = internalReportFilePath;
            MyBackGroundWorker.DoWork += new DoWorkEventHandler(SplitReport);
        }

        private void SplitReport(object sender, EventArgs e)
        {
            string filename_withoutSuffix;
            string textLine;
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                filename_withoutSuffix = MyInternalReportFilePath.Substring(0, MyInternalReportFilePath.IndexOf(".crp"));
                sr = new StreamReader(MyInternalReportFilePath);
                sw = new StreamWriter(filename_withoutSuffix + "_items.crp");
                while (!sr.EndOfStream)
                {
                    textLine = sr.ReadLine();
                    if (textLine.Contains("[markers]"))
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                        sw = new StreamWriter(filename_withoutSuffix + "_markers.crp");
                    }
                    if (textLine.Contains("[results]"))
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                        sw = new StreamWriter(filename_withoutSuffix + "_genotypes.crp");
                    }
                    sw.WriteLine(textLine);
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
