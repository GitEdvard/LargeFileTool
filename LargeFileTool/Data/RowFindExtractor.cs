using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace LargeFileTool.Data
{
    public class RowFindExtractor
    {
        private readonly String _targetFilePath;
        private readonly String _findText;
        private readonly BackgroundWorker _backgroundWorker;
        private readonly RowReader _rowReader;

        public RowFindExtractor(BackgroundWorker worker, RowReader rowReader, string targetFilePath, string findText, bool negCritera)
        {
            _backgroundWorker = worker;
            _targetFilePath = targetFilePath;
            _findText = findText;
            _rowReader = rowReader;
            if (negCritera)
            {
                _backgroundWorker.DoWork += ExtractNeg;
            }
            else
            {
                _backgroundWorker.DoWork += Extract;
            }
        }

        private void Extract(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = null;
            int totalCounter = 0, occurrenceCounter = 0;

            try
            {
                sw = new StreamWriter(_targetFilePath, false, Encoding.GetEncoding(1252));

                while (_rowReader.ReadLine())
                {
                    var textLine = _rowReader.GetLine();
                    if (textLine.Contains(_findText))
                    {
                        sw.WriteLine(_rowReader.GetLineEntireRow());
                        occurrenceCounter++;
                    }
                    if (++totalCounter % 1000 == 0)
                    {
                        _backgroundWorker.ReportProgress(0, "Processing line " + totalCounter);
                        if (_backgroundWorker.CancellationPending)
                        {
                            return;
                        }
                    }
                }
                e.Result = "Extracted " + occurrenceCounter + " lines containing the specified text.";
            }
            finally
            {
                _rowReader.Close();
                sw?.Close();
            }

        }

        private void ExtractNeg(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = null;
            int totalCounter = 0, occurrenceCounter = 0;

            try
            {
                sw = new StreamWriter(_targetFilePath, false, Encoding.GetEncoding(1252));

                while (_rowReader.ReadLine())
                {
                    var textLine = _rowReader.GetLine();
                    if (!textLine.Contains(_findText))
                    {
                        sw.WriteLine(_rowReader.GetLineEntireRow());
                        occurrenceCounter++;
                    }
                    if (++totalCounter % 1000 == 0)
                    {
                        _backgroundWorker.ReportProgress(0, "Processing line " + totalCounter);
                        if (_backgroundWorker.CancellationPending)
                        {
                            return;
                        }
                    }
                }
                e.Result = "Extracted " + occurrenceCounter + " lines containing the specified text.";
            }
            finally
            {
                _rowReader.Close();
                sw?.Close();
            }

        }

    }
}