using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LargeFileTool.Data
{
    public class RowReader
    {
        private enum ReadingState
        { 
            EntireRows,
            RowCriterias
        }
        private String MySourceFilePath, MySeparatorText, MyTextLine;
        private List<ReadCriteria> MyReadCriterias;
        private StreamReader MyStreamReader;
        private ReadingState MyReadingState;
        private string[] MyTextLineSplitted;
        // test comment

        public RowReader(string sourceFilePath, string keyString, List<ReadCriteria> readCriterias, bool entireRows)
        {
            MySourceFilePath = sourceFilePath;
            MySeparatorText = GetKeyString(keyString);
            MyReadCriterias = readCriterias;
            MyTextLine = "";
            MyStreamReader = new StreamReader(sourceFilePath, Encoding.GetEncoding(1252));
            SetReadingState(entireRows);
        }

        public void Close()
        {
            if (MyStreamReader != null)
            {
                MyStreamReader.Close();
            }
        }

        public String FindReplace(String findText, String replaceText, out int occurenceCounter)
        {
            switch (MyReadingState)
            { 
                case ReadingState.EntireRows:
                    return FindReplaceEntireRow(findText, replaceText, out occurenceCounter);
                case ReadingState.RowCriterias:
                    return FindReplaceSplitted(findText, replaceText, out occurenceCounter);
                default:
                    return FindReplaceEntireRow(findText, replaceText, out occurenceCounter);
            }
        }

        private String FindReplaceEntireRow(String findText, String replaceText, out int occurenceCounter)
        {
            StringBuilder processedTextLine = new StringBuilder();
            String[] dummy;
            occurenceCounter = 0;

            dummy = MyTextLine.Split(new string[] { findText }, StringSplitOptions.None);
            occurenceCounter += (dummy.Length - 1);
            MyTextLine = MyTextLine.Replace(findText, replaceText);
            return MyTextLine;
        }

        private String FindReplaceSplitted(String findText, String replaceText, out int occurenceCounter)
        {
            StringBuilder processedTextLine = new StringBuilder();
            String[] dummy;

            occurenceCounter = 0;
            MyTextLineSplitted = MyTextLine.Split(new string[] { MySeparatorText }, StringSplitOptions.None);
            for (int i = 0; i < MyTextLineSplitted.Length; i++)
            {
                foreach (ReadCriteria rcriteria in MyReadCriterias)
                {
                    if (rcriteria.ContainSegment(i))
                    {
                        dummy = MyTextLineSplitted[i].Split(new string[] { findText }, StringSplitOptions.None);
                        occurenceCounter += (dummy.Length - 1);
                        MyTextLineSplitted[i] = MyTextLineSplitted[i].Replace(findText, replaceText);
                        break;
                    }
                }
                // Re-assemble the textline
                if (!(i == 0))
                {
                    processedTextLine.Append(MySeparatorText);
                }
                processedTextLine.Append(MyTextLineSplitted[i]);
            }
            MyTextLine = processedTextLine.ToString();
            return MyTextLine;
        }

        private String GetKeyString(String str)
        {
            char ch = '\t';
            if (str == "\\t")
            {
                return ch.ToString();
            }
            if (str == "\\n")
            {
                return '\n'.ToString();
            }
            return str;
        }

        public String GetLine()
        {
            switch (MyReadingState)
            {
                case ReadingState.EntireRows:
                    return GetLineEntireRow();
                case ReadingState.RowCriterias:
                    return GetLineWithCriterias();
                default:
                    return GetLineEntireRow();
            }
        }

        public int GetNumberColumns()
        {
            MyTextLineSplitted = MyTextLine.Split(new string[] { MySeparatorText }, StringSplitOptions.None);
            return MyTextLineSplitted.Length;
        }

        public String GetLineEntireRow()
        {
            return MyTextLine;
        }

        private String GetLineWithCriterias()
        {
            StringBuilder processedTextLine = new StringBuilder();

            MyTextLineSplitted = MyTextLine.Split(new string[] { MySeparatorText }, StringSplitOptions.None);
            if (MyTextLineSplitted.Length > 1)
            {
                // If there was any occurences of MySeparatorText in the line
                ProcessFirstCriteria(ref processedTextLine);
                ProcessRestOfCriterias(ref processedTextLine);
            }
            return processedTextLine.ToString();
        }

        private void ProcessFirstCriteria(ref StringBuilder processedTextLine)
        {
            ReadCriteria rcriteria;
            int segmentIndex;
            if (MyReadCriterias.Count > 0 && MyTextLineSplitted.Length > MyReadCriterias[0].GetFirstOccurence())
            {
                rcriteria = MyReadCriterias[0];
                segmentIndex = rcriteria.GetFirstOccurence();
                processedTextLine.Append(MyTextLineSplitted[segmentIndex]);
                for (int j = rcriteria.GetFirstOccurence() + 1; j < rcriteria.GetSecondOccurence(); j++)
                {
                    if (j >= MyTextLineSplitted.Length)
                    {
                        break;
                    }
                    processedTextLine.Append(MySeparatorText);
                    processedTextLine.Append(MyTextLineSplitted[j]);
                }

            }
        }

        private void ProcessRestOfCriterias(ref StringBuilder processedTextLine)
        {
            ReadCriteria rcriteria;
            for (int k = 1; k < MyReadCriterias.Count; k++)
            {
                rcriteria = MyReadCriterias[k];
                for (int j = rcriteria.GetFirstOccurence(); j < rcriteria.GetSecondOccurence(); j++)
                {
                    if (j >= MyTextLineSplitted.Length)
                    {
                        break;
                    }
                    processedTextLine.Append(MySeparatorText);
                    processedTextLine.Append(MyTextLineSplitted[j]);
                }
            }
        }

        public bool ReadLine()
        {
            return (MyTextLine = MyStreamReader.ReadLine()) != null;
        }

        public void Reset()
        {
            Close();
            MyStreamReader = new StreamReader(MySourceFilePath, Encoding.GetEncoding(1252));
        }

        public void SetReadingState(bool entireRows)
        {
            if (entireRows)
            {
                MyReadingState = ReadingState.EntireRows;
            }
            else
            {
                MyReadingState = ReadingState.RowCriterias;
            }
        }
    }
}
