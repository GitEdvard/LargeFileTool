using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace Molmed.LargeFileTool.Data
{
    public class RowFindExtractor
    {
        String MyTargetFilePath, MyFindText;
        BackgroundWorker MyBackgroundWorker;
        RowReader MyRowReader;

        public RowFindExtractor(BackgroundWorker worker, RowReader rowReader, string targetFilePath, string findText, bool negCritera)
        {
            MyBackgroundWorker = worker;
            MyTargetFilePath = targetFilePath;
            MyFindText = findText;
            MyRowReader = rowReader;
            if (negCritera)
            {
                MyBackgroundWorker.DoWork += new DoWorkEventHandler(ExtractNeg);
            }
            else
            {
                MyBackgroundWorker.DoWork += new DoWorkEventHandler(Extract);
            }
        }

        public void Extract(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = null;
            int totalCounter = 0, occurrenceCounter = 0;
            string textLine;

            try
            {
                sw = new StreamWriter(MyTargetFilePath, false, Encoding.GetEncoding(1252));

                while (MyRowReader.ReadLine())
                {
                    textLine = MyRowReader.GetLine();
                    if (textLine.Contains(MyFindText))
                    {
                        sw.WriteLine(MyRowReader.GetLineEntireRow());
                        occurrenceCounter++;
                    }
                    if (++totalCounter % 1000 == 0)
                    {
                        MyBackgroundWorker.ReportProgress(0, "Processing line " + totalCounter.ToString());
                        if (MyBackgroundWorker.CancellationPending)
                        {
                            return;
                        }
                    }
                }
                e.Result = "Extracted " + occurrenceCounter.ToString() + " lines containing the specified text.";
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

        public void ExtractNeg(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = null;
            int totalCounter = 0, occurrenceCounter = 0;
            string textLine;

            try
            {
                sw = new StreamWriter(MyTargetFilePath, false, Encoding.GetEncoding(1252));

                while (MyRowReader.ReadLine())
                {
                    textLine = MyRowReader.GetLine();
                    if (!textLine.Contains(MyFindText))
                    {
                        sw.WriteLine(MyRowReader.GetLineEntireRow());
                        occurrenceCounter++;
                    }
                    if (++totalCounter % 1000 == 0)
                    {
                        MyBackgroundWorker.ReportProgress(0, "Processing line " + totalCounter.ToString());
                        if (MyBackgroundWorker.CancellationPending)
                        {
                            return;
                        }
                    }
                }
                e.Result = "Extracted " + occurrenceCounter.ToString() + " lines containing the specified text.";
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