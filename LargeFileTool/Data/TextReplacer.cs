using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Molmed.LargeFileTool.Data
{
    public class TextReplacer
    {
        String MyTargetFilePath, MyFindText, MyReplaceText, MySourceFilePath;
        BackgroundWorker MyBackgroundWorker;
        RowReader MyRowReader;
        int MyOccurences;

        public TextReplacer(BackgroundWorker worker, RowReader rowReader, string targetFilePath, string findText, string replaceText)
        {
            MyBackgroundWorker = worker;
            MyRowReader = rowReader;
            MyTargetFilePath = targetFilePath;
            MyFindText = GetText(findText);
            MyReplaceText = GetText(replaceText);
            MyOccurences = -1;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(SampleFile);
        }

        public TextReplacer(BackgroundWorker worker, string sourceFilePath, string targetFilePath, string findText, string replaceText)
        {
            MyBackgroundWorker = worker;
            MySourceFilePath = sourceFilePath;
            MyTargetFilePath = targetFilePath;
            MyFindText = GetText(findText);
            MyReplaceText = GetText(replaceText);
            MyOccurences = -1;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(SampleFile);
        }

        public int Occurences
        {
            get
            {
                return MyOccurences;
            }
        }

        private String GetText(String text)
        {
            char tab = '\t';
            string nlcr = Environment.NewLine.ToString();

            text = text.Replace("\\t", tab.ToString());
            text = text.Replace("\\n", nlcr);
            return text;
        }

        public void SampleFile(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = null;
            ChunkTextReplacer ctr;
            int occurrenceCounter = 0;

            try
            {
                ctr = new ChunkTextReplacer(MySourceFilePath, MyTargetFilePath, MyFindText, MyReplaceText);
                ctr.ReplaceText(out occurrenceCounter);
                MyOccurences = occurrenceCounter;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (MyRowReader != null)
                {
                    MyRowReader.Close();                    
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        private class ChunkTextReplacer
        {
            private const int CHUNKSIZE = 10000;
            String MyTargetFilePath, MyFindText, MyReplaceText, MySourceFilePath;
            StreamReader MyStreamReader;
            StreamWriter MyStreamWriter;
            

            public ChunkTextReplacer(string sourceFilePath, string targetFilePath, string findText, string replaceText)
            {
                MySourceFilePath = sourceFilePath;
                MyTargetFilePath = targetFilePath;
                MyFindText = findText;
                MyReplaceText = replaceText;
            }

            private bool IsSingleBufferTailMatching(string findText, string buffer, int charCount)
            {
                return findText.Substring(0, charCount) == buffer.Substring(buffer.Length - charCount, charCount);
            }

            private bool IsBufferTailMatching(string findText, string buffer, out int matchingChars)
            {
                matchingChars = -1;
                for (int i = findText.Length - 1; i  > 0; i--)
                {
                    if (IsSingleBufferTailMatching(findText, buffer, i))
                    {
                        matchingChars = i;
                        return true;
                    }
                }
                return false;
            }

            private int GetNoOccurences(string findText, string buffer)
            { 
                return Regex.Matches(buffer, "").Count;
            }

            public void ReplaceText(out int occurences)
            {
                char[] buffer = new char[CHUNKSIZE];
                int count, bufferCount;
                string strBuffer;
                string tail = "";
                Regex rgx;
                occurences = 0;
                MyStreamReader = new StreamReader(MySourceFilePath, Encoding.GetEncoding(1252), false, CHUNKSIZE);
                MyStreamWriter = new StreamWriter(MyTargetFilePath, false, Encoding.GetEncoding(1252));
                try
                {
                    rgx = new Regex(MyFindText);
                    while(!MyStreamReader.EndOfStream)
                    {
                        bufferCount = MyStreamReader.Read(buffer, 0, CHUNKSIZE);
                        strBuffer = new string(buffer);
                        strBuffer = tail + strBuffer.Substring(0, bufferCount);
                        if (IsBufferTailMatching(MyFindText, strBuffer, out count) &&
                            count < MyFindText.Length)
                        {
                            tail = MyFindText.Substring(0, count);
                            strBuffer = strBuffer.Substring(0, strBuffer.Length - count);
                        }
                        else
                        {
                            tail = "";
                        }
                        occurences += rgx.Matches(strBuffer).Count;
                        strBuffer = strBuffer.Replace(MyFindText, MyReplaceText);
                        MyStreamWriter.Write(strBuffer);
                    }
                    MyStreamWriter.Write(tail);
                }
                finally
                {
                    if (MyStreamReader != null)
                    {
                        MyStreamReader.Close();
                    }
                    if (MyStreamWriter != null)
                    {
                        MyStreamWriter.Close();
                    }
                }
            }
        }
    }
}