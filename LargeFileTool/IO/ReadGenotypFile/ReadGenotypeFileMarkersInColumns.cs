using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LargeFileTool.Data;

namespace LargeFileTool.IO.ReadGenotypFile
{
    public class ReadGenotypeFileMarkersInColumns : ReadGenotypeFile
    {
        private const int NUMBER_TEST_LINES = 2;
        private const int START_TEST_LINE = 3;
        private const int MINIMUM_NUMBER_COLS = 2;
        private const int FIRST_RESULT_COL_IND = 1;
        private string[] MyDelimiter;
        public ReadGenotypeFileMarkersInColumns(string filePath)
            : base(filePath)
        {
            MyDelimiter = new string[] { "\t"};
        }

        #region Questions
        public override bool CheckIfGenotypeFile()
        {
            string[] splittedLine;
            string textLine;
            string alleleResultWithSlash;
            int counter = 1;

            MyStreamReader = new StreamReader(MyFilePath);
            while (!MyStreamReader.EndOfStream && counter < START_TEST_LINE)
            {
                textLine = MyStreamReader.ReadLine();
                if (IsEmpty(textLine))
                {
                    continue;
                }
                counter++;
            }

            while (!MyStreamReader.EndOfStream && counter++ < START_TEST_LINE + NUMBER_TEST_LINES)
            {
                textLine = MyStreamReader.ReadLine();
                splittedLine = textLine.Split(MyDelimiter, StringSplitOptions.None);
                if (splittedLine.Length > FIRST_RESULT_COL_IND)
                {
                    alleleResultWithSlash = splittedLine[FIRST_RESULT_COL_IND];
                    if (AlleleVariantManager.IsAlleleVariant(alleleResultWithSlash))
                    {
                        Close();
                        return true;
                    }
                }

            }

            Close();
            return false;
        }

        protected override bool IsResultLine(string textLine, out string[] splittedLine)
        {
            splittedLine = GetSplitLine(textLine);
            return IsNotNull(splittedLine) && splittedLine.Length >= MINIMUM_NUMBER_COLS &&
                AlleleVariantManager.IsAlleleVariant(splittedLine[FIRST_RESULT_COL_IND]);
        }


        #endregion

        public int GetFirstResultColIndex()
        {
            return FIRST_RESULT_COL_IND;
        }

        public bool ReadMarkerHeaderLine(ref string[] markerLine)
        {
            bool markerLineFound = false;
            string textLine;
            
            if (IsNull(MyStreamReader) || IsNull(MyStreamReader.BaseStream))
            {
                MyStreamReader = new StreamReader(MyFilePath);
            }
            while (!MyStreamReader.EndOfStream && !markerLineFound)
            {
                textLine = MyStreamReader.ReadLine();
                if (IsEmpty(textLine))
                {
                    continue;
                }
                markerLine = textLine.Split(MyDelimiter, StringSplitOptions.None);
                if (markerLine.Length >= MINIMUM_NUMBER_COLS)
                {
                    markerLineFound = true;
                }
            }
            return markerLineFound;
        }

        public override bool GoToFirstResultLine()
        {
            string textLine;
            bool resultLineFound = false;
            if (IsNull(MyStreamReader) || IsNull(MyStreamReader.BaseStream))
            {
                MyStreamReader = new StreamReader(MyFilePath);
            }
            while (!MyStreamReader.EndOfStream && !resultLineFound)
            {
                textLine = MyStreamReader.ReadLine();
                if (IsResultLine(textLine, out MySplittedLine))
                {
                    MyIsLineLoadedFirstTime = true;
                    resultLineFound = true;
                }
            }
            return resultLineFound;
        }

        public override bool ReadRow(ref string[] splittedLine)
        {
            string textLine;
            bool rowRed = false;

            if (MyIsLineLoadedFirstTime)
            {
                splittedLine = MySplittedLine;
                MyIsLineLoadedFirstTime = false;
                rowRed = true;
            }
            else
            {
                if (!MyStreamReader.EndOfStream)
                {
                    textLine = MyStreamReader.ReadLine();
                    MySplittedLine = null;
                    splittedLine = GetSplitLine(textLine);
                    rowRed = true;
                }
            }
            return rowRed;
        }

        protected override string[] GetSplitLine(string textLine)
        {
            if (IsNotEmpty(textLine))
            {
                return textLine.Split(MyDelimiter, StringSplitOptions.None);
            }
            else
            {
                return null;
            }
        }

    }
}
