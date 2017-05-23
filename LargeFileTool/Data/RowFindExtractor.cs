using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using FlexibleStreamHandling;

namespace LargeFileTool.Data
{
    public class RowFindExtractor
    {
        private readonly String _findText;
        private readonly BackgroundWorker _backgroundWorker;
        private readonly RowReader _rowReader;
        private readonly FlexibleStream _targetStream;

        public RowFindExtractor(BackgroundWorker worker, RowReader rowReader, FlexibleStream targetStream, string findText, bool negCritera)
        {
            _backgroundWorker = worker;
            _findText = findText;
            _rowReader = rowReader;
            _targetStream = targetStream;
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
            int totalCounter = 0, occurrenceCounter = 0;

            try
            {
                while (_rowReader.ReadLine())
                {
                    var textLine = _rowReader.GetLine();
                    if (textLine.Contains(_findText))
                    {
                        _targetStream.WriteLine(_rowReader.GetLineEntireRow());
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
            }

        }

        private void ExtractNeg(object sender, DoWorkEventArgs e)
        {
            int totalCounter = 0, occurrenceCounter = 0;

            try
            {
                while (_rowReader.ReadLine())
                {
                    var textLine = _rowReader.GetLine();
                    if (!textLine.Contains(_findText))
                    {
                        _targetStream.WriteLine(_rowReader.GetLineEntireRow());
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
            }

        }

    }
}