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
    public class ReadVCFBaseReferenceFile : LargeFileToolData
    {

        #region Enums
        public enum RowIndex
        {
            SnpName = 0,
            SnpChr = 1,
            SnpPos = 2,
            SnpVar = 3,
            SnpRefStrand = 4,
            RefName = 5,
            RefComment = 6,
            RefBase = 7,
            RefLength = 8
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

        private const string KEY_WORD_REFBASE_DATA = "#refbase_data";

        private const string COLUMN_SNPNAME = "snp_name";
        private const string COLUMN_SNPCHR = "snp_chr";        
        private const string COLUMN_SNPPOS = "snp_pos";
        private const string COLUMN_SNPVAR = "snp_var";
        private const string COLUMN_SNPREFSTRAND = "snp_ref_strand";
        private const string COLUMN_REFNAME = "ref_name";
        private const string COLUMN_REFCOMMENT = "ref_comment";
        private const string COLUMN_REFBASE = "ref_base";
        private const string COLUMN_REFLENGTH = "ref_length";

        private const string N_A_SNP = "N/A";

        private int MySnpNameIndex;
        private int MySnpChrIndex;
        private int MySnpPosIndex;
        private int MySnpVarIndex;
        private int MySnpRefStrandIndex;
        private int MyRefNameIndex;
        private int MyRefCommentIndex;
        private int MyRefBaseIndex;
        private int MyRefLengthIndex;

        private int MyNumberOutputColumns;
        
        
        private string MyManifestName;
        private static string[] MyDelimiter = { '\t'.ToString() };
        private string[] MyInternalDelimiter;
        private string MyTextLine;
        private string MyHeaderColumnLine;
        private Dictionary<string, bool> MyMarkerDictionary;
        private StringCollection MyDuplicateMarkers;
        private StringCollection MyMarkersWithoutFlanks;
        private string MyFilePath;
        private DataTable MyAlleleVariantTable;

        #endregion

        public ReadVCFBaseReferenceFile(StreamReader sr, string filePath)
        {
            MyStreamReader = sr;

            MySnpNameIndex = NO_INDEX;



            //MyDelimiter = new string[1];
            //MyDelimiter[0] = ",";
            MyInternalDelimiter = new string[2];
            MyInternalDelimiter[0] = "[";
            MyInternalDelimiter[1] = "]";
            MyManifestName = GetVCFBaseReferenceName(filePath);
            MyFilePath = filePath;
            MyMarkerDictionary = new Dictionary<string, bool>();
            MyDuplicateMarkers = new StringCollection();
            MyMarkersWithoutFlanks = new StringCollection();
            if (IsNull(Database))
            {
                LoginDataBase(null, null);
            }
            Init();
        }

        public void Reset()
        {
            if (MyStreamReader != null)
            {
                MyStreamReader.Close();
            }
            MyMarkerDictionary = new Dictionary<string, bool>();
            MyStreamReader = new StreamReader(MyFilePath);
            Init();
        }

        public string FilePath
        {
            get
            {
                return MyFilePath;
            }
        }

        public void Close()
        {
            if (MyStreamReader != null)
            {
                MyStreamReader.Close();
            }
        }

        private string GetVCFBaseReferenceName(string filePath)
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
            MySnpNameIndex = NO_INDEX;
            MySnpChrIndex = NO_INDEX;
            MySnpPosIndex = NO_INDEX;
            MySnpVarIndex = NO_INDEX;
            MySnpRefStrandIndex = NO_INDEX;
            MyRefNameIndex = NO_INDEX;
            MyRefCommentIndex = NO_INDEX;
            MyRefBaseIndex = NO_INDEX;
            MyRefLengthIndex = NO_INDEX;

            if (!GoToLineZero())
            {
                throw new OpenManifestException("One or more of the columns ''" + COLUMN_SNPNAME + "'', ''" +
                    COLUMN_SNPCHR + "'', ''" + COLUMN_SNPPOS + "'', ''" + COLUMN_SNPREFSTRAND +
                    COLUMN_SNPVAR + "'', ''" + COLUMN_REFLENGTH + "'', ''" + COLUMN_REFBASE + "'', ''" +
                    " is missing in the VCF base reference file!");
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
                    if (splittedLine[i] == COLUMN_SNPNAME)
                    {
                        MySnpNameIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_SNPCHR)
                    {
                        MySnpChrIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_SNPPOS)
                    {
                        MySnpPosIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_SNPREFSTRAND)
                    {
                        MySnpRefStrandIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_SNPVAR)
                    {
                        MySnpVarIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_REFBASE) 
                    {
                        MyRefBaseIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_REFCOMMENT)
                    {
                        MyRefCommentIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_REFLENGTH)
                    {
                        MyRefLengthIndex = i;
                    }
                    if (splittedLine[i] == COLUMN_REFNAME)
                    {
                        MyRefNameIndex = i;
                    }
                }
                isHeaderFound = MyRefNameIndex != NO_INDEX && MyRefLengthIndex != NO_INDEX &&
                    MyRefCommentIndex != NO_INDEX && MyRefBaseIndex != NO_INDEX && MySnpVarIndex != NO_INDEX &&
                    MySnpRefStrandIndex != NO_INDEX && MySnpPosIndex != NO_INDEX && MySnpChrIndex != NO_INDEX &&
                    MySnpNameIndex != NO_INDEX;

            }

            MyHeaderColumnLine = MyTextLine;
            return isHeaderFound;
        }

        public string GetHeaderColumnLine()
        {
            return MyHeaderColumnLine;
        }

        public StringCollection GetDuplicateMarkerList()
        {
            return MyDuplicateMarkers;
        }

        public bool NextRow(ref String[] row)
        {

            return NextRowOrdinary(ref row);
        }

        private bool NextRowOrdinary(ref String[] row)
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
                if (!MyMarkerDictionary.ContainsKey(splittedLine[MySnpNameIndex].Trim()))
                {
                    row[(int)RowIndex.RefBase] = splittedLine[MyRefBaseIndex].Trim();
                    row[(int)RowIndex.RefComment] = splittedLine[MyRefCommentIndex].Trim();
                    row[(int)RowIndex.RefLength] = splittedLine[MyRefLengthIndex].Trim();
                    row[(int)RowIndex.RefName] = splittedLine[MyRefNameIndex].Trim();
                    row[(int)RowIndex.SnpChr] = splittedLine[MySnpChrIndex].Trim();
                    row[(int)RowIndex.SnpName] = splittedLine[MySnpNameIndex].Trim();
                    row[(int)RowIndex.SnpPos] = splittedLine[MySnpPosIndex].Trim();
                    row[(int)RowIndex.SnpRefStrand] = splittedLine[MySnpRefStrandIndex].Trim();
                    row[(int)RowIndex.SnpVar] = GetSNPVariation(splittedLine[MySnpVarIndex].Trim());

                    MyMarkerDictionary.Add(splittedLine[MySnpNameIndex].Trim(), false);
                }
                else
                {
                    MyDuplicateMarkers.Add(splittedLine[MySnpNameIndex].Trim());
                    row = null;
                }
            }
            if (MyTextLine == null)
            {
            }

            return MyTextLine != null;
        }

        public bool NextRow(ref string markerName, out bool validLine)
        {
            string[] splittedLine;

            validLine = false;
            MyTextLine = MyStreamReader.ReadLine();
            if (MyTextLine != null)
            {
                splittedLine = MyTextLine.Split(MyDelimiter, StringSplitOptions.None);
                if (!MyMarkerDictionary.ContainsKey(splittedLine[MySnpNameIndex]))
                {
                    markerName = splittedLine[MySnpNameIndex];
                    validLine = true;
                }
                else
                {
                    MyDuplicateMarkers.Add(splittedLine[MySnpNameIndex]);
                }
            }
            if (MyTextLine == null)
            {
                return false;
            }

            return MyTextLine != null;
        }


        public string GetCurrentTextLine()
        {
            return MyTextLine;
        }

        private static bool ParseAlleleVariant(string alleleVariant, out string parsedAlleleVariant)
        {
            // Transforms allele variant of format A/B or B/A to A/B, (in alphabetic order)
            int slashIndex;
            string alleleVar1, alleleVar2;
            parsedAlleleVariant = "";
            //Find allele variants.
            if (!alleleVariant.Contains("/"))
            {
                return false;
            }
            slashIndex = alleleVariant.IndexOf("/");
            alleleVar1 = alleleVariant.Substring(slashIndex - 1, 1);
            alleleVar2 = alleleVariant.Substring(slashIndex + 1, 1);

            //Arrange SNP type in alphabetical order.
            if (alleleVar1.CompareTo(alleleVar2) > 0 && alleleVariant != N_A_SNP)
            {
                parsedAlleleVariant = alleleVar2 + "/" + alleleVar1;
            }
            else
            {
                parsedAlleleVariant = alleleVar1 + "/" + alleleVar2;
            }
            return true;
        }

        private int GetAlleleID(string parsedAlleleVariant, bool forward)
        {
            // Get allele_variant_id matching the input alleleVariant and 
            // forward flag, if forward, search
            // the id by matching alleleVariant with variant in 
            // table, otherwise match with the complement
            DataTable alleleVariantTable;
            alleleVariantTable = GetFilledAlleleVariantTable();
            foreach (DataRow row in alleleVariantTable.Rows)
            {
                if (forward)
                {
                    if (parsedAlleleVariant == (String)row[(int)AlleleVariantTable.Variant])
                    {
                        return (int)row[(int)AlleleVariantTable.AlleleVariantId];
                    }
                }
                else
                {
                    if (parsedAlleleVariant == (String)row[(int)AlleleVariantTable.Complement])
                    {
                        return (int)row[(int)AlleleVariantTable.AlleleVariantId];
                    }
                }
            }
            return NO_ID_TINY;
        }

        private DataTable GetFilledAlleleVariantTable()
        {
            if (IsNull(MyAlleleVariantTable))
            {
                MyAlleleVariantTable = FillAlleleVariantTable();
            }
            return MyAlleleVariantTable;
        }

        public static DataTable FillAlleleVariantTable()
        {
            DataTable alleleVariantTable;
            DataReader dataReader = null;
            object[] tempRow;
            alleleVariantTable = GetAlleleVariantTable();

            try
            {
                dataReader = Database.GetAlleleVariants();
                while (dataReader.Read())
                {
                    tempRow = new object[3];
                    tempRow[(int)AlleleVariantTable.AlleleVariantId] = dataReader.GetTinyint(AlleleVariantData.ID);
                    tempRow[(int)AlleleVariantTable.Variant] = dataReader.GetString(AlleleVariantData.VARIANT);
                    tempRow[(int)AlleleVariantTable.Complement] = dataReader.GetString(AlleleVariantData.COMPLEMENT);
                    alleleVariantTable.Rows.Add(tempRow);
                }
            }
            finally
            {
                CloseDataReader(dataReader);
            }
            return alleleVariantTable;
        }

        private static DataTable GetAlleleVariantTable()
        {
            DataColumn column;
            DataTable alleleVariantTable;

            alleleVariantTable = new DataTable("AlleleVariant");

            // Define columns.
            column = new DataColumn(AlleleVariantTable.AlleleVariantId.ToString(), typeof(int));
            column.AllowDBNull = false;
            column.Unique = true;
            alleleVariantTable.Columns.Add(column);

            column = new DataColumn(AlleleVariantTable.Variant.ToString(), typeof(String));
            column.AllowDBNull = false;
            column.Unique = true;
            alleleVariantTable.Columns.Add(column);

            column = new DataColumn(AlleleVariantTable.Complement.ToString(), typeof(String));
            column.AllowDBNull = false;
            column.Unique = true;
            alleleVariantTable.Columns.Add(column);

            return alleleVariantTable;
        }

        private string GetSNPVariation(string parsedSNPVariation)
        {
            if (parsedSNPVariation.Contains("["))
            {
                parsedSNPVariation = parsedSNPVariation.Substring(parsedSNPVariation.IndexOf("[") + 1);
            }
            if (parsedSNPVariation.Contains("]"))
            {
                parsedSNPVariation = parsedSNPVariation.Substring(0, parsedSNPVariation.IndexOf("]"));
            }
            parsedSNPVariation = parsedSNPVariation.Trim();
            if (parsedSNPVariation.Length != 3)
            {
                throw new System.Exception("The snp variation has a length other than 3! SNP = " + parsedSNPVariation);
            }
            return parsedSNPVariation;
        }

    }
}
