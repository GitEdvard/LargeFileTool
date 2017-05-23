using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FlexibleStreamHandling;

namespace LargeFileTool.Data
{
    public class RowReader
    {
        private enum ReadingState
        { 
            EntireRows,
            RowCriterias
        }
        private readonly String _separatorText;
        private String _textLine;
        private readonly List<ReadCriteria> _readCriterias;
        private StreamReader _streamReader;
        private ReadingState _readingState;
        private string[] _textLineSplitted;
        private FlexibleStream _stream;
        // test comment

        public RowReader(FlexibleStream sourceStream, string keyString, List<ReadCriteria> readCriterias, bool entireRows)
        {
            _separatorText = GetKeyString(keyString);
            _readCriterias = readCriterias;
            _textLine = "";
            _stream = sourceStream;
            _streamReader = _stream.GetReader();
            SetReadingState(entireRows);
        }

        public void Close()
        {
            _streamReader?.Close();
        }

        private String GetKeyString(String str)
        {
            char ch = '\t';
            if (str == "\\t")
            {
                return ch.ToString();
            }
            if (str == "\\n")
            {
                return '\n'.ToString();
            }
            return str;
        }

        public String GetLine()
        {
            switch (_readingState)
            {
                case ReadingState.EntireRows:
                    return GetLineEntireRow();
                case ReadingState.RowCriterias:
                    return GetLineWithCriterias();
                default:
                    return GetLineEntireRow();
            }
        }

        public int GetNumberColumns()
        {
            _textLineSplitted = _textLine.Split(new[] { _separatorText }, StringSplitOptions.None);
            return _textLineSplitted.Length;
        }

        public String GetLineEntireRow()
        {
            return _textLine;
        }

        private String GetLineWithCriterias()
        {
            StringBuilder processedTextLine = new StringBuilder();

            _textLineSplitted = _textLine.Split(new[] { _separatorText }, StringSplitOptions.None);
            if (_textLineSplitted.Length > 1)
            {
                // If there was any occurences of _separatorText in the line
                ProcessFirstCriteria(ref processedTextLine);
                ProcessRestOfCriterias(ref processedTextLine);
            }
            return processedTextLine.ToString();
        }

        private void ProcessFirstCriteria(ref StringBuilder processedTextLine)
        {
            if (_readCriterias.Count > 0 && _textLineSplitted.Length > _readCriterias[0].GetFirstOccurence())
            {
                var rcriteria = _readCriterias[0];
                var segmentIndex = rcriteria.GetFirstOccurence();
                processedTextLine.Append(_textLineSplitted[segmentIndex]);
                for (int j = rcriteria.GetFirstOccurence() + 1; j < rcriteria.GetSecondOccurence(); j++)
                {
                    if (j >= _textLineSplitted.Length)
                    {
                        break;
                    }
                    processedTextLine.Append(_separatorText);
                    processedTextLine.Append(_textLineSplitted[j]);
                }

            }
        }

        private void ProcessRestOfCriterias(ref StringBuilder processedTextLine)
        {
            for (int k = 1; k < _readCriterias.Count; k++)
            {
                var rcriteria = _readCriterias[k];
                for (int j = rcriteria.GetFirstOccurence(); j < rcriteria.GetSecondOccurence(); j++)
                {
                    if (j >= _textLineSplitted.Length)
                    {
                        break;
                    }
                    processedTextLine.Append(_separatorText);
                    processedTextLine.Append(_textLineSplitted[j]);
                }
            }
        }

        public bool ReadLine()
        {
            return (_textLine = _streamReader.ReadLine()) != null;
        }

        public void Reset()
        {
            _streamReader = _stream.GetReader();
        }

        private void SetReadingState(bool entireRows)
        {
            _readingState = entireRows ? ReadingState.EntireRows : ReadingState.RowCriterias;
        }
    }
}
