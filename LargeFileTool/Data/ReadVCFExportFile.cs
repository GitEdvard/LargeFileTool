using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using LargeFileTool.Data.Exceptions;
using LargeFileTool.Database;

namespace LargeFileTool.Data
{
    public class ReadVCFExportFile : LargeFileToolData
    {
        #region Enums
        public enum RowIndex
        {
            ID = 0,
            REF = 1,
            ALT = 2
        }

        public enum TopBotKeyWords
        {
            TOP,
            BOT
        }

        public enum PlusMinusKeyWords
        {
            PLUS,
            MINUS
        }

        public enum TopBotReference
        {
            T,
            B
        }

        public enum PlusMinusReference
        {
            P,
            M
        }

        public enum ForwardReverseReference
        {
            F,
            R
        }

        #endregion

        #region Declarations
        private StreamReader MyStreamReader;

        private const string COLUMN_REF = "REF";
        private const string COLUMN_ALT = "ALT";
        private const string COLUMN_ID = "ID";
    
        private const string N_A_SNP = "N/A";

        private int MyREFIndex;
        private int MyALTIndex;
        private int MyIDIndex;

        private int MyNumberOutputColumns;


        private string MyManifestName;
        private static string[] MyDelimiter = { '\t'.ToString() };
        private string MyTextLine;
        private string MyHeaderColumnLine;
        private Dictionary<string, bool> MyMarkerDictionary;
        private StringCollection MyDuplicateMarkers;
        private string MyFilePath;
        //private DataTable MyAlleleVariantTable;

        #endregion

        public ReadVCFExportFile(StreamReader sr, string filePath)
        {
            MyREFIndex = NO_INDEX;
            MyALTIndex = NO_INDEX;
            MyIDIndex = NO_INDEX;
            MyMarkerDictionary = new Dictionary<string, bool>();
            MyDuplicateMarkers = new StringCollection();
            MyStreamReader = sr;
            MyManifestName = GetVCFExportName(filePath);
            MyFilePath = filePath;
            Init();
        }

        private string GetVCFExportName(string filePath)
        {
            string fileNameWithExtension;
            string fileNameWithoutExtension;
            if (filePath.Contains("\\"))
            {
                fileNameWithExtension = filePath.Substring(filePath.LastIndexOf("\\") + 1);
            }
            else
            {
                fileNameWithExtension = filePath;
            }
            if (fileNameWithExtension.Contains("."))
            {
                fileNameWithoutExtension = fileNameWithExtension.Substring(0, fileNameWithExtension.LastIndexOf("."));
            }
            else
            {
                fileNameWithoutExtension = fileNameWithExtension;
            }
            return fileNameWithoutExtension;
        }

        private void Init()
        {
            if (!GoToLineZero())
            {
                throw new OpenManifestException("One or more of the columns ''" + COLUMN_ID + "'', ''" +
                    COLUMN_REF + "'', ''" + COLUMN_ALT + "'', ''" +
                    " is missing in the VCF export file!");
            }
            MyNumberOutputColumns = Enum.GetValues(typeof(RowIndex)).Length;

        }

        private bool GoToLineZero()
        {
            string[] splittedLine = null;
            int N_headerRows = 1000;
            int counter;
            bool isHeaderFound, dummy = false;
            MyTextLine = "";
            // Search for key columns in the header rows (number = x)
            // If no match was found, loop again and search for the best match
            // show error message with the missing columns
            counter = 0;
            isHeaderFound = false;
            while (counter < N_headerRows && !MyStreamReader.EndOfStream && !isHeaderFound)
            {
                counter++;
                MyTextLine = MyStreamReader.ReadLine();

                if (MyTextLine.Substring(0, 2) != "##")
                {
                    dummy = true;
                }

                if (dummy)
                {
                    dummy = false;
                }

                splittedLine = MyTextLine.Split(MyDelimiter, StringSplitOptions.None);
                for (int i = 0; i < splittedLine.Length; i++)
                {
                    if (splittedLine[i] == COLUMN_ID)
                    {
                        MyIDIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_REF)
                    {
                        MyREFIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_ALT)
                    {
                        MyALTIndex = i;
                    }
                }
                isHeaderFound = MyIDIndex != NO_INDEX && MyREFIndex != NO_INDEX && MyALTIndex != NO_INDEX;
            }

            MyHeaderColumnLine = MyTextLine;
            return isHeaderFound;
        }

        public bool NextRow(ref string marker, ref string refAllele, ref string alternateAllele)
        {
            bool success;
            string[] row = null;
            success = NextRow(ref row);
            if (success)
            {
                marker = row[(int)RowIndex.ID];
                refAllele = row[(int)RowIndex.REF];
                alternateAllele = row[(int)RowIndex.ALT];
                
            } 
            return success;
        }

        private bool NextRow(ref String[] row)
        {
            string[] splittedLine;

            row = new string[MyNumberOutputColumns];
            for (int i = 0; i < MyNumberOutputColumns; i++)
            {
                row[i] = "";
            }

            MyTextLine = MyStreamReader.ReadLine();
            if (MyTextLine != null)
            {
                splittedLine = MyTextLine.Split(MyDelimiter, StringSplitOptions.None);
                if (!MyMarkerDictionary.ContainsKey(splittedLine[MyIDIndex].Trim()))
                {
                    row[(int)RowIndex.ID] = splittedLine[MyIDIndex].Trim();
                    row[(int)RowIndex.REF] = splittedLine[MyREFIndex].Trim();
                    row[(int)RowIndex.ALT] = splittedLine[MyALTIndex].Trim();

                    MyMarkerDictionary.Add(splittedLine[MyIDIndex].Trim(), false);
                }
                else
                {
                    MyDuplicateMarkers.Add(splittedLine[MyIDIndex].Trim());
                    row = null;
                }
            }
            if (MyTextLine == null)
            {
            }

            return MyTextLine != null;
        }

        public string GetVCFExportName()
        {
            return MyManifestName;
        }
    }
}
