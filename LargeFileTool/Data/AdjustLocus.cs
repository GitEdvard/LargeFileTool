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
    public class AdjustLocus
    {
        // Change 2
        private StreamReader MyStreamReader;
        private StreamWriter MyWriter;
        private BackgroundWorker MyBackgroundWorker;
        private bool MyIncludeScoreCall;
        private const string HEADER_VALUE_KEY_WORD = "oligoPoolId,recordType,data";
        private const string BULK_KEY_WORD = "instituteLabel,plateWell,imageDate,oligoPoolId,bundleId,status,recordType,data";
        private const string LOCUS_NAMES = "locusNames";
        private const string SNPS = "snps";
        private const string PLUS_MINUS_STRAND = "plusMinusStrand";
        private const string ILLMNA_IDS = "ilmnIds";
        private const string SCORE_CALL = "Score_Call";

        public AdjustLocus(bool includeScoreCall, 
            StreamReader sr, StreamWriter sw, BackgroundWorker bwd)
        {
            MyStreamReader = sr;
            MyWriter = sw;
            MyBackgroundWorker = bwd;
            MyIncludeScoreCall = includeScoreCall;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(HandleLocus);
        }

        private bool HasRowKeyWord(string[] splittedLine, string keyWord)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i < splittedLine.Length &&
                    splittedLine[i].Trim() == keyWord)
                {
                    return true;
                }
            }
            return false;
        }

        void ExportHeaderLine(string[] splittedLine, int headerValueStartColumn)
        {
            StringBuilder textLine = new StringBuilder();
            textLine.Append(splittedLine[1] + "\t ");
            for (int i = headerValueStartColumn; i < splittedLine.Length; i++)
            {
                if (i < splittedLine.Length - 1)
                {
                    textLine.Append(splittedLine[i] + "\t ");
                }
                else
                {
                    textLine.Append(splittedLine[i]);
                }
            }
            MyWriter.WriteLine(textLine.ToString());
        }

        void ExportBulkLine(string[] splittedLine, int valueStartColumn)
        {
            StringBuilder textLine = new StringBuilder();
            textLine.Append(splittedLine[0] + "\t ");
            for (int i = valueStartColumn; i < splittedLine.Length; i++)
            {
                if (i < splittedLine.Length - 1)
                {
                    textLine.Append(splittedLine[i] + "\t ");
                }
                else
                {
                    textLine.Append(splittedLine[i]);                
                }
            }
            MyWriter.WriteLine(textLine.ToString());
        }


        void HandleLocus(object sender, DoWorkEventArgs e)
        {
            string textLine;
            string[] splittedLine;
            string[] delimiter = new string[] { "," };
            bool isHeaderFinished = false;
            bool isHeaderValueColumnSet = false;
            int bulkColumnOffset = 5;
            int headerValueStartColumn = -1;
            int row = 0;
            MyBackgroundWorker.ReportProgress(0, "Parsing header");
            while (!MyStreamReader.EndOfStream)
            {
                row++;
                MyBackgroundWorker.ReportProgress(0, "Row " + row.ToString());
                if (MyBackgroundWorker.CancellationPending)
                {
                    return;
                }
                textLine = MyStreamReader.ReadLine();
                if (textLine.Trim() == BULK_KEY_WORD)
                {
                    isHeaderFinished = true;
                    continue;
                }
                splittedLine = textLine.Split(delimiter, StringSplitOptions.None);
                if (!isHeaderValueColumnSet &&
                    HasRowKeyWord(splittedLine, ILLMNA_IDS))
                {
                    FindHeaderStartColumn(splittedLine, out headerValueStartColumn, ILLMNA_IDS);
                    isHeaderValueColumnSet = true;
                    ExportHeaderLine(splittedLine, headerValueStartColumn);
                }

                if (!isHeaderFinished &&
                    HasRowKeyWord(splittedLine, LOCUS_NAMES)||
                    HasRowKeyWord(splittedLine, SNPS) ||
                    HasRowKeyWord(splittedLine, PLUS_MINUS_STRAND))
                {
                    ExportHeaderLine(splittedLine, headerValueStartColumn);
                }
                if (isHeaderFinished &&
                    (MyIncludeScoreCall || !HasRowKeyWord(splittedLine, SCORE_CALL)))
                {
                    ExportBulkLine(splittedLine, headerValueStartColumn + bulkColumnOffset);
                }
            }

        }

        private void FindHeaderStartColumn(string[] splittedLine, out int headerValueStartColumn, string keyWord)
        {
            int index = 0;
            bool isKeyWordFound = false;
            bool isValueColumnFound = false;
            headerValueStartColumn = -1;
            foreach (string extractedMarker in splittedLine)
            {
                if (isKeyWordFound &&
                    !isValueColumnFound &&
                    extractedMarker.Trim() != "")
                {
                    isValueColumnFound = true;
                    headerValueStartColumn = index;
                    return;
                }
                if (!isKeyWordFound &&
                    extractedMarker.Trim() == keyWord)
                {
                    isKeyWordFound = true;
                }
                index++;
            }
        }


    }
}
