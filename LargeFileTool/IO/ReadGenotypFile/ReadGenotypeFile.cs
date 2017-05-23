using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LargeFileTool.Data;

namespace LargeFileTool.IO.ReadGenotypFile
{
    public abstract class ReadGenotypeFile : LargeFileToolData
    {
        public enum GenotypeFileType
        { 
            MarkersInRows
        }

        protected StreamReader MyStreamReader;
        protected string MyFilePath;
        protected string[] MySplittedLine;
        protected bool MyIsLineLoadedFirstTime;

        public ReadGenotypeFile(string filePath)
        {
            MyFilePath = filePath;
            MyIsLineLoadedFirstTime = false;
        }

        public abstract bool CheckIfGenotypeFile();

        public abstract bool GoToFirstResultLine();

        protected abstract bool IsResultLine(string textLine, out string[] splittedLine);

        protected abstract string[] GetSplitLine(string textLine);

        public abstract bool ReadRow(ref string[] splittedLine);

        public void Close()
        {
            if (MyStreamReader != null)
            {
                MyStreamReader.Close();
            }
        }

    }
}
