using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LargeFileTool.Data
{
    public class FileInfoExtractor
    {
        BackgroundWorker MyBackgroundWorker;
        RowReader MyRowReader;

        public FileInfoExtractor(BackgroundWorker worker, RowReader rowReader)
        {
            MyBackgroundWorker = worker;
            MyRowReader = rowReader;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(Extract);
        }

        public void Extract(object sender, DoWorkEventArgs e)
        {
            long totalCounter = 0, occurrenceCounter = 0;
            int noOfChecks = 4;
            int proposedNoColumns = 0;
            string str;

            try
            {
                while (MyRowReader.ReadLine())
                {
                    if (occurrenceCounter < noOfChecks)
                    {
                        if (proposedNoColumns != MyRowReader.GetNumberColumns() &&
                            MyRowReader.GetNumberColumns() != 0)
                        {
                            proposedNoColumns = MyRowReader.GetNumberColumns();
                            occurrenceCounter = 0;
                        }
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
                str = "Rows:  " + totalCounter.ToString() + "\nColumns : " + proposedNoColumns.ToString();
                MessageBox.Show(str, "");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                MyRowReader.Close();
            }

        }
    }
}