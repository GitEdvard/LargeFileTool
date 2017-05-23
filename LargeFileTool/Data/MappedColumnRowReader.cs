using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Molmed.LargeFileTool.Data
{
    public class MappedColumnRowReader
    {
        private StreamReader MySr;
        private int MyRowCounter;
        private int MyFirstLine;
        private List<ColumnMapping> MyColumnMapping;
        private string[] MySourceFileDelimiters;
        private string MyDestinationFileDelimiter;
        private string MyCurrentRow;
        public MappedColumnRowReader(string sourceFilePath, int firstLine, List<ColumnMapping> columnMapping,
                string[] sourceFileDelimiters, string destinationFileDelimiter)
        {
            try
            {
                MySr = new StreamReader(sourceFilePath, Encoding.GetEncoding(1252));
                MyRowCounter = -1;
                MyFirstLine = firstLine;
                MySourceFileDelimiters = sourceFileDelimiters;
                MyDestinationFileDelimiter = destinationFileDelimiter;
                MyColumnMapping = columnMapping;
                MyCurrentRow = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            if (MySr != null)
            {
                MySr.Close();
            }
        }

        private bool GoNextLine()
        {
            if (MyRowCounter == -1)
            {
                return GoFirstLine();
            }
            if (MySr.EndOfStream)
            {
                return false;
            }
            else
            {
                MyCurrentRow = MySr.ReadLine();
                MyRowCounter++;
                return true;
            }
        }

        private bool GoFirstLine()
        {
            string str;
            MyRowCounter = 0;
            while (MyRowCounter < MyFirstLine && !MySr.EndOfStream)
            {
                MyCurrentRow = MySr.ReadLine();
                MyRowCounter++;
            }
            if (MyRowCounter != MyFirstLine)
            {
                str = "Error, the specified 'First row to read from' exceeds the number of rows in source file!";
                MessageBox.Show(str, "Source file error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        public bool GetNextDestinationRow(out string destinationFileTextLine)
        {
            // Loop through the column mappings, get selected columns from 
            // source file,
            // put them in the output string in the right order
            destinationFileTextLine = "";
            if (!GoNextLine())
            {
                return false;
            }
            string[] sourceFileColumnsStrArr;
            string columnString;
            if (MyCurrentRow.Trim() == "")
            {
                return true;
            }
            sourceFileColumnsStrArr = MyCurrentRow.Split(MySourceFileDelimiters, StringSplitOptions.None);
            foreach (ColumnMapping columnMapping in MyColumnMapping)
            {
                if (!columnMapping.GetColumnString(sourceFileColumnsStrArr, MyRowCounter, out columnString))
                {
                    return false;
                }
                destinationFileTextLine += MyDestinationFileDelimiter + columnString;
            }
            destinationFileTextLine = destinationFileTextLine.Substring(1);
            return true;
        }

    }
}
