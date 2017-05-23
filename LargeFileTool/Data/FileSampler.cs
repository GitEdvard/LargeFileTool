using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace Molmed.LargeFileTool.Data
{
    public class FileSampler
    {
        string MyTargetFilePath;
        int MySamplingInterval;
        int MyFirstRows;
        int MyStartRow;
        BackgroundWorker MyBackgroundWorker;
        RowReader MyRowReader;

        public FileSampler(BackgroundWorker worker, RowReader rowReader, string targetFilePath, int samplingInterval, 
                                int firstRows, int startRow)
        {
            MyBackgroundWorker = worker;
            MyRowReader = rowReader;
            MyTargetFilePath = targetFilePath;
            MySamplingInterval = samplingInterval;
            MyFirstRows = firstRows;
            MyStartRow = startRow;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(SampleFile);
        }

        public void SampleFile(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = null;
			int counter = 0, totalCounter = 0;
            string textLine;

            try
            {
                sw = new StreamWriter(MyTargetFilePath, false, Encoding.GetEncoding(1252));

                if (MyStartRow > -1)
                { 
                    for(int i = 0; i < MyStartRow; i++)
                    {
                        MyRowReader.ReadLine();
                    }
                }
                while (MyRowReader.ReadLine())
                {
                    textLine = MyRowReader.GetLine();
                    totalCounter++;
                    if (++counter == MySamplingInterval || totalCounter <= MyFirstRows)
                    {
                        sw.WriteLine(textLine);
                        counter = 0;
                    }
                    if (totalCounter % 1000 == 0)
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
