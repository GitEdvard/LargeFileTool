using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Data;
using LargeFileTool.Data;
using Microsoft.Isam.Esent.Collections.Generic;

namespace LargeFileTool.IO
{
    public class GetConflictsInVCFExportFile : LargeFileToolData
    {
        #region Declarations
        private BackgroundWorker MyBackGroundWorker;
        private ReadVCFExportFile MyReadVCFExportFile;
        private StreamReader MyStreamReader;
        private string MyFilePath;
        private string MySummaryFile;
        private string MyOutputPath;

        #endregion

        public GetConflictsInVCFExportFile(string filePath, string outputFolder, BackgroundWorker bwd)
        {
            MyBackGroundWorker = bwd;
            MyFilePath = filePath;
            MyOutputPath = outputFolder;
            MyStreamReader = null;
            MyReadVCFExportFile = null;
            MyBackGroundWorker.DoWork += GetNumberConflicts;
        }

        private void GetNumberConflicts(object sender, EventArgs e)
        {
            string marker = "", refBase = "", altBase = "";
            StreamWriter sw = null;
            string textLine;
            int numberComparisons = 0, numberConflicts = 0;
            MyBackGroundWorker.ReportProgress(0, "Start scanning file");

            try
            {
                MyStreamReader = new StreamReader(MyFilePath);
                MyReadVCFExportFile = new ReadVCFExportFile(MyStreamReader, MyFilePath);
                MySummaryFile = MyOutputPath + @"\" + "Summary_" + MyReadVCFExportFile.GetVCFExportName() + "_conflicts.txt";
                while (MyReadVCFExportFile.NextRow(ref marker, ref refBase, ref altBase))
                {
                    if (refBase.ToUpper() != "N")
                    {
                        numberComparisons++;
                        if (altBase.Contains(","))
                        {
                            numberConflicts++;
                        }
                    }
                }
                sw = new StreamWriter(MySummaryFile);
                textLine = "Compared markers: " + numberComparisons.ToString();
                sw.WriteLine(textLine);
                textLine = "Number conflicts (alt bases > 1 and ref base != ''N'': " + numberConflicts.ToString();
                sw.WriteLine(textLine);
                sw.Close();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (MyStreamReader != null)
                {
                    MyStreamReader.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

    }
}
