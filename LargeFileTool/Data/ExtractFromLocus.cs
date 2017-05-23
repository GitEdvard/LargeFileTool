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
    public class ExtractFromLocus
    {
        private StreamReader MyLocusReader;
        private StreamWriter MyLocusExtractWriter;
        private StreamWriter MyMarkerWriter;
        private BackgroundWorker MyBackgroundWorker;
        private string MyLocusFilePath;
        private List<int> MySelectedMarkerColumns;
        private StringCollection MySelectedMarkers;
        private int MyMarkerCountSelection;
        private int MyMarkerOffsetSelection;
        private Dictionary<string, bool> MySampleDictionary;
        private const string HEADER_VALUE_KEY_WORD = "oligoPoolId,recordType,data";
        private const string BULK_KEY_WORD = "instituteLabel,plateWell,imageDate,oligoPoolId,bundleId,status,recordType,data";
        private const string LOCUS_NAMES = "locusNames";

        public ExtractFromLocus(string sampleListPath, StringCollection selectedMarkers,
            int markerCount, int markerOffset, StreamReader sr, string locusFilePath, 
            StreamWriter sw, StreamWriter markerSW, BackgroundWorker bwd)
        {
            MyLocusReader = sr;
            MyLocusExtractWriter = sw;
            MyBackgroundWorker = bwd;
            MySelectedMarkers = selectedMarkers;
            MyLocusFilePath = locusFilePath;
            MyMarkerCountSelection = markerCount;
            MyMarkerOffsetSelection = markerOffset;
            if (MyMarkerOffsetSelection < 0)
            {
                MyMarkerOffsetSelection = 0;
            }
            MyMarkerWriter = markerSW;
            InitSampleDictionary(sampleListPath);
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(Extract);
        }

        private void InitSampleDictionary(string sampleListPath)
        {
            StreamReader sr = null;
            string sample;
            MySampleDictionary = new Dictionary<string, bool>();
            if (sampleListPath == null || sampleListPath == "")
            {
                return;
            }
            try
            {
                sr = new StreamReader(sampleListPath);
                while (!sr.EndOfStream)
	            {
	                sample = sr.ReadLine().ToLower();
                    if (!MySampleDictionary.ContainsKey(sample))
                    {
                        MySampleDictionary.Add(sample, false);
                    }
	            }

            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        private void FindMarkerIndex(string[] splittedLine, out List<int> markerIndex, out int headerValueStartColumn)
        {
            if (MyMarkerCountSelection > 0)
            {
                FindMarkerIndexByCountAndOffset(splittedLine, out markerIndex, out headerValueStartColumn);
            }
            else
            {
                markerIndex = new List<int>();
            }
            FindMarkerIndexByIdentifiers(splittedLine, ref markerIndex, out headerValueStartColumn);
            if (MyMarkerCountSelection > 0)
            {
                SetMarkerIdentifiers(splittedLine, markerIndex);            
            }
        }

        private void FindMarkerIndexByCountAndOffset(string[] splittedLine, out List<int> markerIndex, out int headerValueStartColumn)
        {
            int index = 0;
            bool isKeyWordFound = false;
            bool isValueColumnFound = false;
            markerIndex = new List<int>();
            headerValueStartColumn = -1;
            foreach (string extractedMarker in splittedLine)
            {
                if (isKeyWordFound &&
                    !isValueColumnFound &&
                    extractedMarker.Trim() != "")
                {
                    isValueColumnFound = true;
                    headerValueStartColumn = index;
                    break;
                }
                if (!isKeyWordFound &&
                    extractedMarker.Trim() == LOCUS_NAMES)
                {
                    isKeyWordFound = true;
                }
                index++;
            }
            if (!isValueColumnFound)
            {
                throw new Exception("Value column not found in row for " + LOCUS_NAMES);
            }
            for (index = headerValueStartColumn + MyMarkerOffsetSelection;
                index < headerValueStartColumn + MyMarkerOffsetSelection + MyMarkerCountSelection;
                index++)
            {
                markerIndex.Add(index);
            }
        }

        private void SetMarkerIdentifiers(string[] splittedLine, List<int> markerIndex)
        {
            StringCollection existingMarkers;
            if (MySelectedMarkers == null)
            {
                MySelectedMarkers = new StringCollection();
            }
            existingMarkers = MySelectedMarkers;
            MySelectedMarkers = new StringCollection();
            foreach (int index in markerIndex)
            {
                MySelectedMarkers.Add(splittedLine[index]);
            }
            foreach (string str in existingMarkers)
            {
                if (!MySelectedMarkers.Contains(str))
                {
                    MySelectedMarkers.Add(str);
                }
            }
        }

        private void FindMarkerIndexByIdentifiers(string[] splittedLine, ref List<int> markerIndex, out int headerValueStartColumn)
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
                }
                if (!isKeyWordFound &&
                    extractedMarker.Trim() == LOCUS_NAMES)
                {
                    isKeyWordFound = true;
                }
                foreach (string selMarker in MySelectedMarkers)
                {
                    if (selMarker.Trim() == extractedMarker.Trim() &&
                        !markerIndex.Contains(index))
                    {
                        markerIndex.Add(index);
                    }
                }
                index++;
            }
            markerIndex.Sort();
        }
        

        private bool HasLocusNamesKeyWord(string[] splittedLine)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i < splittedLine.Length &&
                    splittedLine[i].Trim() == LOCUS_NAMES)
                {
                    return true;
                }
            
            }
            return false;
        }

        private bool FindBulkValueStartColumn(string[] splittedLine, out int bulkStartColumn)
        {
            const string CALLS = "calls";
            bool isCallsFound = false;
            bool isEmptyColumnFound = false;
            int callsIndex;
            bulkStartColumn = -1;
            for (int i = 0; i < 100; i++)
            {
                if (isEmptyColumnFound && splittedLine[i].Trim() != "")
                {
                    bulkStartColumn = i;
                    return true;
                }
                if (isCallsFound && splittedLine[i].Trim() == "")
                {
                    isEmptyColumnFound = true;
                }
                if (splittedLine[i].Trim() == CALLS)
                {
                    callsIndex = i;
                    isCallsFound = true;
                }
            }
            return false;
        }

        private void WriteMarkerFile()
        {
            for (int i = 0; i < MySelectedMarkers.Count; i++)
            {
                MyMarkerWriter.WriteLine(MySelectedMarkers[i]);
            }
        }

        private void Extract(object sender, DoWorkEventArgs e)
        {
            int headerValueStartRow = -1;
            int bulkStartRow = -1;
            int columnOffsetForBulk = -1;
            string textLine;
            int row = 0;
            string[] delimiter = new string[1] { "," };
            string[] splittedLine;
            bool isLocusNamesFound = false;
            bool isHeaderValueStartRowFound = false;
            bool isBulkFound = false;
            int headerValueStartColumn = -1;
            int bulkValueStartColumn = -1;
            int numberMatchingSamples = 0;
            bool writeLine = false;

            // Find out whitch row in header that values for markers starts
            // Find out columns for selected markers
            // Find out which row bulk starts, and
            // columns shift between header and bulk

            MyBackgroundWorker.ReportProgress(0, "Extracting header information");
            while (!MyLocusReader.EndOfStream)
            {
                row++;
                MyBackgroundWorker.ReportProgress(0, "Extracting header information, row " + row.ToString());
                if (MyBackgroundWorker.CancellationPending)
                {
                    return;
                }
                textLine = MyLocusReader.ReadLine();
                if (textLine.Trim() == HEADER_VALUE_KEY_WORD)
                {
                    headerValueStartRow = row + 1;
                    isHeaderValueStartRowFound = true;
                }
                splittedLine = textLine.Split(delimiter, StringSplitOptions.None);
                if (isHeaderValueStartRowFound && 
                    !isLocusNamesFound &&
                    HasLocusNamesKeyWord(splittedLine))
                {
                    FindMarkerIndex(splittedLine, out MySelectedMarkerColumns, out headerValueStartColumn);
                    isLocusNamesFound = true;

                }
                if (textLine.StartsWith(BULK_KEY_WORD))
                {
                    isBulkFound = true;
                    bulkStartRow = row + 1;
                }
                if (bulkStartRow == row)
                {
                    if (!FindBulkValueStartColumn(splittedLine, out bulkValueStartColumn))
                    {
                        throw new Exception("Bulk start column not found");
                    }
                    columnOffsetForBulk = bulkValueStartColumn - headerValueStartColumn;
                    break;
                }
            }

            if (!isHeaderValueStartRowFound || !isBulkFound || !isLocusNamesFound)
            {
                throw new Exception("Locus could not be parsed!");
            }

            if (MyMarkerWriter != null)
            {
                WriteMarkerFile();
            }

            // Start reader again from top
            MyLocusReader = new StreamReader(MyLocusFilePath);
            row = 0;
            while (!MyLocusReader.EndOfStream)
            {
                row++;
                MyBackgroundWorker.ReportProgress(0, "Parsing row " + row.ToString());
                if (MyBackgroundWorker.CancellationPending)
                {
                    return;
                }
                textLine = MyLocusReader.ReadLine();
                if (row < headerValueStartRow)
                {
                    writeLine = true;
                }
                else if (row < bulkStartRow - 1)
                {
                    writeLine = true;
                    splittedLine = textLine.Split(delimiter, StringSplitOptions.None);
                    if (splittedLine.Length > headerValueStartColumn)
                    {
                        GetExtractedRow(splittedLine, headerValueStartColumn, 0, out textLine);
                    }
                }
                else if (row == bulkStartRow - 1)
                {
                    writeLine = true;
                }
                else if (row >= bulkStartRow)
                {
                    writeLine = false;
                    splittedLine = textLine.Split(delimiter, StringSplitOptions.None);
                    if (IsWithinSampleFilter(splittedLine[0].ToLower()))
                    {
                        writeLine = true;
                        numberMatchingSamples++;
                        GetExtractedRow(splittedLine, bulkValueStartColumn, columnOffsetForBulk, out textLine);
                    }
                }
                if (writeLine)
                {
                    MyLocusExtractWriter.WriteLine(textLine);
                }
            }
        }

        private bool IsWithinSampleFilter(string sample)
        {
            sample = sample.Substring(0, sample.LastIndexOf("_"));
            return MySampleDictionary.Count == 0 || MySampleDictionary.ContainsKey(sample);
        }

        private void GetExtractedRow(string[] splittedLine, int valueStartColumn, 
            int markerColumnOffset, out string outTextLine)
        {
            StringBuilder str = new StringBuilder();
            outTextLine = "";
            for (int i = 0; i < valueStartColumn; i++)
            {
                str.Append(splittedLine[i] + ",");
            }
            foreach (int index in MySelectedMarkerColumns)
            {
                str.Append(splittedLine[index + markerColumnOffset] + ",");
            }
            outTextLine = str.ToString();
            if (MySelectedMarkerColumns.Count > 0)
            {
                outTextLine = outTextLine.Substring(0, outTextLine.Length - 1);
            }
        }
    }
}
