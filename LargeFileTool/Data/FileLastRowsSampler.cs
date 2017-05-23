using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace LargeFileTool.Data
{
    public class FileLastRowsSampler
    {
        string MyTargetFilePath;
        int MyNumberRows;
        BackgroundWorker MyBackgroundWorker;
        RowReader MyRowReader;

        public FileLastRowsSampler(BackgroundWorker worker, RowReader rowReader, string targetFilePath, int numberRows)
        {
            MyBackgroundWorker = worker;
            MyRowReader = rowReader;
            MyTargetFilePath = targetFilePath;
            MyNumberRows = numberRows;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(SampleFile);
        }

        public void SampleFile(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = null;
            string textLine;
            int startRow;
            int totalRows = 0;
            int currentRow = 0;

            try
            {
                sw = new StreamWriter(MyTargetFilePath, false, Encoding.GetEncoding(1252));

                // Loop through the file, get number of rows

                while (MyRowReader.ReadLine())
                {
                    totalRows++;
                }
                // Get startrow, it is zero indexed
                startRow = totalRows - MyNumberRows;

                // Loop through the file again, start reading/writing at startRow
                MyRowReader.Reset();
                currentRow = 0;
                while (currentRow < startRow && MyRowReader.ReadLine())
                {
                    currentRow++;
                }

                while (MyRowReader.ReadLine())
                {
                    textLine = MyRowReader.GetLine();
                    sw.WriteLine(textLine);
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
