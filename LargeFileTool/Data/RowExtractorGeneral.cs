using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace LargeFileTool.Data
{
    public class RowExtractorGeneral
    {
        // Extracts row from two files. Rows containing key-words from a third file are extracted.
        // The third file contains a single column with key words

        private BackgroundWorker MyBackgroundWorker;
        private string MyKeyFilePath;
        private string MyFile1Path;
        private string MyFile2Path;
        private string MyFile1ColumnDelimiter;
        private int MyFile1SearchColumnIndex;
        private string MyFile2ColumnDelimiter;
        private int MyFile2SearchColumnIndex;
        private string MyOutputFolder;
        private string MyOutputFile1Path;
        private string MyOutputFile2Path;

        public RowExtractorGeneral(string keyFilePath, string file1Path, 
            string file1ColumnDelimiter, int file1SearchColumnIndex,
            string file2Path, string file2ColumnDelimiter, int file2SearchColumnIndex,
            string outputFolder, BackgroundWorker bgw)
        {
            MyBackgroundWorker = bgw;
            MyKeyFilePath = keyFilePath;
            MyFile1Path = file1Path;
            MyFile2Path = file2Path;
            MyOutputFolder = outputFolder;
            MyFile1ColumnDelimiter = file1ColumnDelimiter;
            MyFile1SearchColumnIndex = file1SearchColumnIndex;
            MyFile2ColumnDelimiter = file2ColumnDelimiter;
            MyFile2SearchColumnIndex = file2SearchColumnIndex;

            MyOutputFile1Path = GetOutputFilePath(file1Path);
            MyOutputFile2Path = GetOutputFilePath(file2Path);

            MyBackgroundWorker.DoWork += ExtractFromFiles;
        }

        private string GetOutputFilePath(string origFilePath)
        {
            string fileName, extension;

            if (IsFilePathEmpty(origFilePath))
            {
                return "";
            }
            fileName = origFilePath.Substring(origFilePath.LastIndexOf(@"\") + 1);
            extension = fileName.Substring(fileName.LastIndexOf(".") + 1);
            fileName = fileName.Substring(0, fileName.LastIndexOf("."));
            return MyOutputFolder + @"\" + fileName + "_extracted." + extension;
        }

        private bool IsFilePathEmpty(string filePath)
        {
            return filePath == null || filePath.Trim() == "" ||
                filePath.LastIndexOf(@"\") == -1;
        }

        private void ExtractFromFiles(object sender, EventArgs e)
        {
            StreamReader sr = null;
            StreamWriter sw = null;
            string textLine;
            string[] splittedLine;
            string[] delimiter;
            Dictionary<string, bool> searchKeys = null;
            try
            {
                // Fill upp collection with searching keys
                searchKeys = new Dictionary<string, bool>();
                sr = new StreamReader(MyKeyFilePath);
                while (!sr.EndOfStream)
                {
                    textLine = sr.ReadLine();
                    searchKeys.Add(textLine, false);
                }
                sr.Close();

                // Fill up dictionary for file 1

                if (!IsFilePathEmpty(MyFile1Path))
                {
                    sr = new StreamReader(MyFile1Path);
                    sw = new StreamWriter(MyOutputFile1Path);
                    delimiter = new string[] {MyFile1ColumnDelimiter};
                    while (!sr.EndOfStream)
                    {
                        textLine = sr.ReadLine();
                        splittedLine = textLine.Split(delimiter, StringSplitOptions.None);
                        if (splittedLine != null &&
                            splittedLine.Length > MyFile1SearchColumnIndex &&
                            searchKeys.ContainsKey(splittedLine[MyFile1SearchColumnIndex]))
                        {
                            sw.WriteLine(textLine);
                        }
                    }
                    sr.Close();
                    sw.Close();
                }

                // Fill up dictionary for file 2
                if (!IsFilePathEmpty(MyFile2Path))
                {
                    sr = new StreamReader(MyFile2Path);
                    sw = new StreamWriter(MyOutputFile2Path);
                    delimiter = new string[] { MyFile2ColumnDelimiter};
                    while (!sr.EndOfStream)
                    {
                        textLine = sr.ReadLine();
                        splittedLine = textLine.Split(delimiter, StringSplitOptions.None);
                        if (splittedLine != null &&
                            splittedLine.Length > MyFile2SearchColumnIndex &&
                            searchKeys.ContainsKey(splittedLine[MyFile2SearchColumnIndex]))
                        {
                            sw.WriteLine(textLine);
                        }
                    }
                    sr.Close();
                    sw.Close();
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
