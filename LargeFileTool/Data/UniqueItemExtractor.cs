using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;

namespace LargeFileTool.Data
{
    public class UniqueItemExtractor
    {
        private string[] MyInFiles;
        private string MyOutFile;
        private BackgroundWorker MyBackGroundWorker;

        public UniqueItemExtractor(string[] inFiles, string outFile, BackgroundWorker bwd)
        {
            MyInFiles = inFiles;
            MyOutFile = outFile;
            MyBackGroundWorker = bwd;
            MyBackGroundWorker.DoWork += new DoWorkEventHandler(ExtractUniqueItems);
        }

        private void ExtractUniqueItems(object sender, EventArgs e)
        { 
            // Build a list with unique items,
            // add item to the list if it is not already in it.
            // Loop through each file
            List<string> uniqueItems = new List<string>();
            DataTable uniqueItemsTable;
            DataRow dataRow;
            DataColumn column;
            DataColumn[] keyColumns = new DataColumn[1];
            StreamReader sr = null;
            StreamWriter sw = null;
            string textLine, str;
            int counter = 0;
            try
            {
                uniqueItemsTable = new DataTable("uniqueItemsTable");
                column = new DataColumn("Name", typeof(String));
                column.AllowDBNull = false;
                column.Unique = true;
                column.MaxLength = 500;
                uniqueItemsTable.Columns.Add(column);
                keyColumns[0] = column;
                uniqueItemsTable.PrimaryKey = keyColumns;
                uniqueItemsTable.BeginLoadData();
                foreach (string file in MyInFiles)
                {
                    sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {
                        textLine = sr.ReadLine();
                        if (!uniqueItemsTable.Rows.Contains(textLine))
                        {
                            dataRow = uniqueItemsTable.NewRow();
                            dataRow["Name"] = textLine;
                            uniqueItemsTable.Rows.Add(dataRow);
                        }
                        if (++counter % 100 == 0)
                        {
                            MyBackGroundWorker.ReportProgress(0, "Reading file " + file + "\nRow " + counter);
                            if (MyBackGroundWorker.CancellationPending)
                            {
                                return;
                            }
                        }
                    }
                    sr.Close();
                }
                uniqueItemsTable.EndLoadData();
                sw = new StreamWriter(MyOutFile);
                counter = 0;
                foreach (DataRow row in uniqueItemsTable.Rows)
                {
                    str = row["Name"].ToString();
                    sw.WriteLine(str);
                    if (++counter % 100 == 0)
                    {
                        MyBackGroundWorker.ReportProgress(0, "Writing to file " + MyOutFile + "\nRow " + counter);
                        if (MyBackGroundWorker.CancellationPending)
                        {
                            return;
                        }
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
