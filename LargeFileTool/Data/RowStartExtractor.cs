using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace Molmed.LargeFileTool.Data
{
    public class RowStartExtractor
    {
        String MyTargetFilePath;
        int MyNumberCharacters;
        BackgroundWorker MyBackgroundWorker;
        RowReader MyRowReader;

        public RowStartExtractor(BackgroundWorker worker, RowReader rowReader, string targetFilePath, int numberCharacters)
        {
            MyBackgroundWorker = worker;
            MyRowReader = rowReader;
            MyTargetFilePath = targetFilePath;
            MyNumberCharacters = numberCharacters;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(ExtractRowStart);
        }
        
        public void ExtractRowStart(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = null;
            int totalCounter = 0, numberChars;
            char[] buffer = null;
            String textLine, processedLine;

            try
            {
                sw = new StreamWriter(MyTargetFilePath, false, Encoding.GetEncoding(1252));

                buffer = new char[MyNumberCharacters];

                while (MyRowReader.ReadLine())
                {
                    //Read the specified number of characters from the line.
                    textLine = MyRowReader.GetLine();
                    numberChars = Math.Min(MyNumberCharacters, textLine.Length);
                    processedLine = textLine.Substring(0, numberChars);
                    sw.WriteLine(processedLine);

                    if (++totalCounter % 1000 == 0)
                    {
                        MyBackgroundWorker.ReportProgress(0, "Processing line " + totalCounter.ToString());
                        if (MyBackgroundWorker.CancellationPending)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                MyRowReader.Close();
                if (sw != null)
                {
                    sw.Close();
                }
            }

        }

    }
}