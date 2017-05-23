using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.ComponentModel;

namespace LargeFileTool.Data
{
    public class GenotypeFileComparer
    {
        private StreamReader MyGReader1;
        private StreamReader MyGReader2;
        private BackgroundWorker MyBackgroundWorker;
        private string MyMessage;
        private int MyDiffRow;
        private int MyDiffColumn;
        private string MyDiffColumnName;
        private string MyDiffRowName;
        private bool MySkipHeader;
        private List<int> MyDiffColumns;
        private List<int> MyDiffRows;
        private int MyNumberDiffs;

        public GenotypeFileComparer(StreamReader gReader1, StreamReader gReader2, BackgroundWorker bwd,
            bool skipHeader)
        {
            MyBackgroundWorker = bwd;
            MyGReader1 = gReader1;
            MyGReader2 = gReader2;
            MyMessage = "Files are identical";
            MyDiffRow = -1;
            MyDiffColumn = -1;
            MyDiffColumnName = "";
            MyDiffRowName = "";
            MySkipHeader = skipHeader;
            MyDiffColumns = new List<int>();
            MyDiffRows = new List<int>();
            MyNumberDiffs = 0;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(Compare);
        }

        public string GetMessage()
        {
            return MyMessage;
        }

        public int GetDiffColumn()
        {
            return MyDiffColumn;
        }

        public string GetDiffColumnName()
        {
            return MyDiffColumnName;
        }

        public int GetDiffRow()
        {
            return MyDiffRow;
        }

        public string GetDiffRowName()
        {
            return MyDiffRowName;
        }

        public string GetDiffRows()
        {
            string str = "";
            MyDiffRows.Sort();
            foreach (int row in MyDiffRows)
            {
                str += row.ToString() + ", ";
            }
            if (str.Length > 1)
            {
                str = str.Substring(0, str.Length - 2);
            }
            return str;
        }

        public string GetDiffColumns()
        {
            string str = "";
            MyDiffColumns.Sort();
            foreach (int row in MyDiffColumns)
            {
                str += row.ToString() + ", ";
            }
            if (str.Length > 1)
            {
                str = str.Substring(0, str.Length - 2);
            }
            return str;
        }

        public string GetNumberDiffs()
        {
            return MyNumberDiffs.ToString();
        }

        private void Compare(object sender, DoWorkEventArgs e)
        { 
            string[] MyDelimiter = new string[1];
            string[] splittedLine1, splittedLine2;
            string[] splittedHeader1 = null, splittedHeader2 = null;
            string textLine1, textLine2;
            bool firstLine = true;
            bool isHeader = true;
            bool diffInHeader = false;
            bool firstDiffHandled = false;
            string firstColumnum;
            int row = 0;
            MyDelimiter[0] = '\t'.ToString();
            MyBackgroundWorker.ReportProgress(0, "Starting...");
            while (!MyGReader1.EndOfStream && !MyGReader2.EndOfStream)
            {
                textLine1 = MyGReader1.ReadLine();
                textLine2 = MyGReader2.ReadLine();
                if(firstLine)
                {
                    splittedHeader1 = textLine1.Split(MyDelimiter, StringSplitOptions.None);
                    splittedHeader2 = textLine2.Split(MyDelimiter, StringSplitOptions.None);
                    firstLine = false;
                }
                row++;
                if (MyBackgroundWorker.CancellationPending)
                {
                    return;
                }
                MyBackgroundWorker.ReportProgress(0, "Row " + row.ToString());
                if (textLine1 != textLine2)
                {
                    splittedLine1 = textLine1.Split(MyDelimiter, StringSplitOptions.None);
                    splittedLine2 = textLine2.Split(MyDelimiter, StringSplitOptions.None);
                    firstColumnum = splittedLine1[0].Trim().ToLower();
                    if (firstColumnum == "individual" || firstColumnum == "sample" ||
                        firstColumnum == "")
                    {
                        isHeader = true;
                    }
                    else
                    {
                        isHeader = false;
                    }
                    if (splittedLine1.Length == splittedLine2.Length)
                    {
                        for (int i = 0; i < splittedLine1.Length; i++)
                        {
                            if (splittedLine1[i].Trim() != splittedLine2[i].Trim())
                            {
                                if (isHeader)
                                {
                                    diffInHeader = true;
                                }
                                if (MySkipHeader && isHeader)
                                {
                                    MyMessage = "(Diff in header)";
                                }
                                else if(!firstDiffHandled)
                                {
                                    firstDiffHandled = true;
                                    MyMessage = "First occurence of differance";
                                    MyDiffRow = row;
                                    MyDiffRowName = splittedLine1[0];
                                    MyDiffColumn = i + 1;
                                    MyDiffColumnName = splittedHeader1[i];
                                    MyNumberDiffs++;
                                    MyDiffColumns.Add(MyDiffColumn);
                                    MyDiffRows.Add(MyDiffRow);
                                }
                                else if (firstDiffHandled)
                                {
                                    MyNumberDiffs++;
                                    if (!MyDiffRows.Contains(row))
                                    {
                                        MyDiffRows.Add(row);
                                    }
                                    if (!MyDiffColumns.Contains(i + 1))
                                    {
                                        MyDiffColumns.Add(i + 1);
                                    }
                                }
                            }
                            if (i % 1000 == 0)
                            {
                                if (MyBackgroundWorker.CancellationPending)
                                {
                                    return;
                                }
                                MyBackgroundWorker.ReportProgress(0, "Row " + row.ToString() +
                                    " Column " + (i + 1).ToString());
                            }
                        }
                    }
                    else
                    {
                        if (MySkipHeader && isHeader)
                        {
                            MyMessage = "(Column count differ in header)";
                        }
                        else
                        {
                            MyMessage = "Column count differ";
                            MyDiffRow = row;
                            MyDiffRowName = splittedLine1[0];
                            return;
                        }
                    }
                }
            }
            if (MySkipHeader && diffInHeader)
            { 
                MyMessage += " (diff in header)";
            }

        }
    }
}
