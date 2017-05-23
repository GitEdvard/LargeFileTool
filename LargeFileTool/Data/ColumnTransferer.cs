using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace Molmed.LargeFileTool.Data
{
    public class ColumnTransferer
    {
        private BackgroundWorker MyBackgroundWorker;
        private String MySourceFilePath;
        private String MyDestinationFilePath;
        private string[] MySourceFileDelimiters;
        private String MyDestinationFileDelimiter;
        private List<ColumnMapping> MyColumnMapping;
        private int MyFirstLine;
        private bool MySkipHeader;
        private String MyHeaderLine;

        public ColumnTransferer(String sourceFilePath, String destinationFilePath, 
            List<ColumnMapping> columnMapping, string[] sourceFileDelimiters, String destinationFileDelimiter, 
            int firstLine, bool skipHeader, String headerLine,
            BackgroundWorker bgw)
        {
            MySourceFilePath = sourceFilePath;
            MyDestinationFilePath = destinationFilePath;
            MyBackgroundWorker = bgw;
            MyColumnMapping = columnMapping;
            MySourceFileDelimiters = sourceFileDelimiters;
            MyDestinationFileDelimiter = destinationFileDelimiter;
            MyFirstLine = firstLine;
            MySkipHeader = skipHeader;
            MyHeaderLine = headerLine;
            MyBackgroundWorker.DoWork += new DoWorkEventHandler(TransferColumns);
        }

        // Add hoc 2
        public void TransferColumns(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = null;
            MappedColumnRowReader rowReader = null;
            string destinationFileTextLine;
            int rowCounter = 0;
            string str;

            try
            {
                sw = new StreamWriter(MyDestinationFilePath, false, Encoding.GetEncoding(1252));
                // Handle header
                if (MySkipHeader || MyHeaderLine != "")
                {
                    MyFirstLine++;
                }
                if (!MySkipHeader && MyHeaderLine != "")
                {
                    sw.WriteLine(MyHeaderLine);
                }
                rowReader = new MappedColumnRowReader(MySourceFilePath, MyFirstLine,
                    MyColumnMapping, MySourceFileDelimiters, MyDestinationFileDelimiter);

                // Loop rows in source file
                // Write the row to the outputfile
                while (rowReader.GetNextDestinationRow(out destinationFileTextLine))
                {
                    rowCounter++;
                    sw.WriteLine(destinationFileTextLine);
                    if (rowCounter % 100 == 0)
                    { 
                        str = "Transferring, rows: " + rowCounter.ToString();
                        MyBackgroundWorker.ReportProgress(0, str);
                        if (MyBackgroundWorker.CancellationPending) { return; }
                    }
                }
            }
            finally
            {
                rowReader.Close();
                if (sw != null)
                {
                    sw.Close();
                }
            }            
        }
    }
}
