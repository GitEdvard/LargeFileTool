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

    public class ReadManifestFile : LargeFileToolData
    {

        #region Enums
        public enum RowIndex
        {
            Marker = 0,
            FivePrimeFlank = 1,
            ThreePrimeFlank = 2,
            MarkerReference = 3,
            Chromosome = 4,
            Position = 5,
            PositionReference = 6,
            SNP_Variation = 7,
            Forward_Reverse = 8,
            ForwardVersion = 9,
            Top_Bot = 10,
            Plus_minus = 11,
            Genome_Build = 12,
            Intensity_only = 13
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
        protected StreamReader MyStreamReader;
        protected const string KEY_WORD_ASSAY = "[Assay]";
        protected const string KEY_WORD_CONTROLS = "[Controls]";
        protected const string COLUMN_NAME = "Name";
        protected const string COLUMN_ = "Name";
        protected const string COLUMN_SOURCE_SEQ = "SourceSeq";
        protected const string COLUMN_CHROMOSOME = "Chr";
        protected const string COLUMN_SNP = "SNP";
        protected const string COLUMN_ILMNID = "IlmnID";
        protected const string COLUMN_ILMNSTRAND = "IlmnStrand"; // TOP/BOT, or PLUS/MINUS for indels
        protected const string COLUMN_SOURCE_STRAND = "SourceStrand";
        protected const string COLUMN_POSITION = "MapInfo"; // Basepair position on relevant chromosome

        protected const string COLUMN_GENOME_BUILD = "GenomeBuild"; // Genomic build referes to ref strand (plus or minus);
        protected const string COLUMN_REF_STRAND = "RefStrand"; // Plus or minus;
        protected const string COLUMN_INTENSITY_ONLY = "Intensity_Only";
        protected const string REF_STRAND_PLUS = "+";
        protected const string REF_STRAND_MINUS = "-";

        protected const string N_A_SNP = "N/A";
        protected const string BLANK = "";
        protected const int OUTPUT_COLUMNS = 13;
        protected const int INTERNAL_FIVE_PRIME_INDEX = 0;
        protected const int INTERNAL_THREE_PRIME_INDEX = 2;
        protected char[] MyTrimChars = { ' ', '\t', ',' };
        protected int MyNameIndex;
        protected int MySourceSeqIndex;
        protected int MyChromosomeIndex;
        protected int MySNPIndex;
        protected int MyIlmnIdIndex;
        protected int MyIlmnStrandIndex;
        protected int MySourceStrandIndex;
        protected int MyGenomicBuildIndex;
        protected int MyRefStrandIndex;
        protected int MyIntensityOnlyIndex;
        protected int MyBasepairIndex;
        protected int MyNumberOutputColumns;
        protected string MyManifestName;
        protected bool MyIsAnyTopStrandFound;
        protected static string[] MyDelimiter = {","};
        protected string[] MyInternalDelimiter;
        protected string MyTextLine;
        protected string MyHeaderColumnLine;
        protected Dictionary<string, bool> MyMarkerDictionary;
        protected StringCollection MyDuplicateMarkers;
        protected StringCollection MyMarkersWithoutFlanks;
        protected string MyFilePath;
        protected DataTable MyAlleleVariantTable;
        protected bool MyHasColumnsForPlusStrand;
        protected bool MySkipParsingIlluminaId;
        protected string[] MySplittedLine;
        protected bool MyPermitDuplicateMarkers;
        
        #endregion

        public ReadManifestFile()
        {
            MyNameIndex = NO_INDEX;
            MySourceSeqIndex = NO_INDEX;
            MyChromosomeIndex = NO_INDEX;
            //MyDelimiter = new string[1];
            //MyDelimiter[0] = ",";
            MyInternalDelimiter = new string[2];
            MyInternalDelimiter[0] = "[";
            MyInternalDelimiter[1] = "]";
            MyIntensityOnlyIndex = NO_INDEX;
            MyIsAnyTopStrandFound = false;
            MySkipParsingIlluminaId = false;
            MyMarkerDictionary = new Dictionary<string, bool>();
            MyDuplicateMarkers = new StringCollection();
            MyMarkersWithoutFlanks = new StringCollection();
            MyPermitDuplicateMarkers = false;
            if (IsNull(Database))
            {
                LoginDataBase(null, null);
            }
        }

        public ReadManifestFile(StreamReader sr, string filePath)
        {
            MyStreamReader = sr;
            MyNameIndex = NO_INDEX;
            MySourceSeqIndex = NO_INDEX;
            MyChromosomeIndex = NO_INDEX;
            //MyDelimiter = new string[1];
            //MyDelimiter[0] = ",";
            MyInternalDelimiter = new string[2];
            MyInternalDelimiter[0] = "[";
            MyInternalDelimiter[1] = "]";
            MyIntensityOnlyIndex = NO_INDEX;
            MyIsAnyTopStrandFound = false;
            MySkipParsingIlluminaId = false;
            MyManifestName = GetManifestName(filePath);
            MyFilePath = filePath;
            MyMarkerDictionary = new Dictionary<string, bool>();
            MyDuplicateMarkers = new StringCollection();
            MyMarkersWithoutFlanks = new StringCollection();
            MyPermitDuplicateMarkers = false;
            if (IsNull(Database))
            {
                LoginDataBase(null, null);
            }
            Init();
        }

        public void InitManifestFile(string filePath)
        {
            MyManifestName = GetManifestName(filePath);
            MyFilePath = filePath;
            MyStreamReader = new StreamReader(filePath);
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

        public bool SkipParsingIlluminaId
        {
            get
            {
                return MySkipParsingIlluminaId;
            }
            set
            {
                MySkipParsingIlluminaId = value;
            }
        }

        public void Close()
        {
            if (MyStreamReader != null)
            {
                MyStreamReader.Close();
            }
        }

        protected string GetManifestName(string filePath)
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

        protected virtual void Init()
        {
            MyBasepairIndex = NO_INDEX;
            MyChromosomeIndex = NO_INDEX;
            MyIlmnIdIndex = NO_INDEX;
            MyIlmnStrandIndex = NO_INDEX;
            MyNameIndex = NO_INDEX;
            MySNPIndex = NO_INDEX;
            MySourceSeqIndex = NO_INDEX;
            MyGenomicBuildIndex = NO_INDEX;
            MyRefStrandIndex = NO_INDEX;
            MyIntensityOnlyIndex = NO_INDEX;
            if (!GoToLineZero())
            {
                throw new OpenManifestException("One or more of the columns ''" + COLUMN_NAME + "'', ''" +
                    COLUMN_SOURCE_SEQ + "'', ''" + COLUMN_CHROMOSOME + "'', ''" + COLUMN_SNP +
                    COLUMN_ILMNID + "'', ''" + COLUMN_ILMNSTRAND + "'', ''"  + COLUMN_SOURCE_STRAND + "'', ''" +
                    " is missing in the manifest file!");
            }
            MyNumberOutputColumns = Enum.GetValues(typeof(RowIndex)).Length;
        }

        protected bool GoToLineZero()
        {
            int N_headerRows = 50;
            int counter;
            bool isHeaderFound;
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
                
                MySplittedLine = MyTextLine.Split(MyDelimiter, StringSplitOptions.None);
                for (int i = 0; i < MySplittedLine.Length; i++)
                {
                    if (MySplittedLine[i] == COLUMN_NAME)
                    {
                        MyNameIndex = i;
                    }
                    if (MySplittedLine[i] == COLUMN_SOURCE_SEQ)
                    {
                        MySourceSeqIndex = i;
                    }
                    if (MySplittedLine[i] == COLUMN_CHROMOSOME)
                    {
                        MyChromosomeIndex = i;
                    }
                    if (MySplittedLine[i] == COLUMN_SNP)
                    {
                        MySNPIndex = i;
                    }
                    if (MySplittedLine[i] == COLUMN_ILMNID)
                    {
                        MyIlmnIdIndex = i;
                    }
                    if (MySplittedLine[i] == COLUMN_ILMNSTRAND) // top/bot, (plus/minus for indels)
                    {
                        MyIlmnStrandIndex = i;
                    }
                    if(MySplittedLine[i] == COLUMN_SOURCE_STRAND)
                    {
                        MySourceStrandIndex = i;
                    }
                    if (MySplittedLine[i] == COLUMN_INTENSITY_ONLY)
                    {
                        MyIntensityOnlyIndex = i;
                    }
                    if (MySplittedLine[i] == COLUMN_POSITION)
                    {
                        MyBasepairIndex = i;
                    }
                    if (MySplittedLine[i] == COLUMN_SOURCE_SEQ)
                    {
                        MySourceSeqIndex = i;
                    }

                }
                isHeaderFound = MyNameIndex != NO_INDEX && MySourceSeqIndex != NO_INDEX &&
                    MyChromosomeIndex != NO_INDEX && MySNPIndex != NO_INDEX && MyIlmnIdIndex != NO_INDEX &&
                    MyIlmnStrandIndex != NO_INDEX && MySourceStrandIndex != NO_INDEX && MyBasepairIndex != NO_INDEX;

            }
            if (isHeaderFound)
            {
                CheckForPlusStrandColumns(MySplittedLine);
            }

            MyHeaderColumnLine = MyTextLine;
            return isHeaderFound;
        }

        protected void CheckForPlusStrandColumns(string[] columns)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i] == COLUMN_GENOME_BUILD)
                {
                    MyGenomicBuildIndex = i;
                }
                if (columns[i] == COLUMN_REF_STRAND)
                {
                    MyRefStrandIndex = i;
                }
                if (columns[i] == COLUMN_INTENSITY_ONLY)
                {
                    MyIntensityOnlyIndex = i;
                }
            }
            // Intensity only not mandatory, 
            // Name and snp columns also mandatory, but are checked in GoToLineZero
            MyHasColumnsForPlusStrand = MyGenomicBuildIndex > NO_INDEX && MyRefStrandIndex > NO_INDEX;
        }

        public bool HasPlusStrandColumns()
        {
            return MyHasColumnsForPlusStrand;
        }

        public static string GetAlleleVariationInPlus(string[] manifestRow)
        {
            string alleleVariation, alleleVarPlus, plusMinStr;
            ReadManifestFile.PlusMinusReference plusMinusRef;

            plusMinStr = manifestRow[(int)ReadManifestFile.RowIndex.Plus_minus];
            plusMinusRef = (ReadManifestFile.PlusMinusReference)Enum.Parse(typeof(ReadManifestFile.PlusMinusReference), plusMinStr);
            alleleVariation = manifestRow[(int)ReadManifestFile.RowIndex.SNP_Variation];
            alleleVarPlus = GetAlleleVariationInPlus(alleleVariation, plusMinusRef);
            return alleleVarPlus;
        }

        protected static string GetSortedAlleleVariation(string alleleVariation)
        {
            string sortedAlleleVar = "";
            char aAllele, bAllele;
            aAllele = alleleVariation[0];
            bAllele = alleleVariation[2];

            if (aAllele > bAllele)
            {
                sortedAlleleVar = bAllele.ToString() + "/" + aAllele.ToString();
            }
            else
            {
                sortedAlleleVar = aAllele.ToString() + "/" + bAllele.ToString();
            }
            return sortedAlleleVar;
        }


        protected static string GetAlleleVariationInPlus(string alleleVariation, ReadManifestFile.PlusMinusReference plusMinusReference)
        {
            string alleleVariationPlus = "";
            if (plusMinusReference == ReadManifestFile.PlusMinusReference.P)
            {
                alleleVariationPlus = alleleVariation;
            }
            else
            {
                foreach (DataRow row in AlleleVariantManager.GetAlleleVariantTable().Rows)
                {
                    if (alleleVariation == row[(int)AlleleVariantTable.Variant].ToString())
                    {
                        alleleVariationPlus = row[(int)AlleleVariantTable.Complement].ToString();
                        break;
                    }
                }
            }
            return alleleVariationPlus;
        }


        public string GetHeaderColumnLine()
        {
            return MyHeaderColumnLine;
        }

        public bool IsTopBotAbsent()
        {
            return MyIlmnIdIndex != NO_INDEX && !MyIsAnyTopStrandFound;
        }

        public StringCollection GetDuplicateMarkerList()
        {
            return MyDuplicateMarkers;
        }

        public StringCollection GetMarkersWithoutFlanks()
        {
            return MyMarkersWithoutFlanks;
        }

        public bool NextRow(ref string markerName, ref string chromosome, ref string fivePrime_flank,
            ref string threePrime_flank, ref string markerReference, ref string snpVariation,
            ref string forward_reverse, ref string version, ref string top_bot, ref string sourceStrand,
            ref string ilmnStrand, out string textLine)
        {
            string[] genomicSequenceParts;
            string forwardReverse, versionInternal;
            bool isTopInForward;
            TopBotReference topBotReference;

            MyTextLine = MyStreamReader.ReadLine();
            textLine = MyTextLine;
            if (MyTextLine != null && MyTextLine.Trim(MyTrimChars) != KEY_WORD_CONTROLS)
            {
                MySplittedLine = MyTextLine.Split(MyDelimiter, StringSplitOptions.None);
                if (!MyMarkerDictionary.ContainsKey(MySplittedLine[MyNameIndex]))
                {
                    genomicSequenceParts = MySplittedLine[MySourceSeqIndex].Split(MyInternalDelimiter, StringSplitOptions.None);
                    ParseIlluminaId(MySplittedLine[MyIlmnIdIndex], out forwardReverse, out versionInternal, out isTopInForward,
                        out topBotReference);
                    markerName = MySplittedLine[MyNameIndex];
                    chromosome = MySplittedLine[MyChromosomeIndex];
                    if (genomicSequenceParts.Length > INTERNAL_FIVE_PRIME_INDEX &&
                        genomicSequenceParts.Length > INTERNAL_THREE_PRIME_INDEX)
                    {
                        fivePrime_flank = genomicSequenceParts[INTERNAL_FIVE_PRIME_INDEX].ToUpper();
                        threePrime_flank = genomicSequenceParts[INTERNAL_THREE_PRIME_INDEX].ToUpper();
                    }
                    else
                    {
                        fivePrime_flank = "";
                        threePrime_flank = "";
                        MyMarkersWithoutFlanks.Add(MySplittedLine[MyNameIndex]);
                    }
                    markerReference = MySplittedLine[MyNameIndex] + "; " + MyManifestName;
                    snpVariation = GetSNPVariation(MySplittedLine[MySNPIndex]);
                    forward_reverse = forwardReverse;
                    version = versionInternal;
                    top_bot = GetTopBotReference(MySplittedLine, MyIlmnStrandIndex);
                    sourceStrand = MySplittedLine[MySourceStrandIndex];
                    ilmnStrand = MySplittedLine[MyIlmnStrandIndex];
                    MyMarkerDictionary.Add(MySplittedLine[MyNameIndex], false);
                }
                else
                {
                    MyDuplicateMarkers.Add(MySplittedLine[MyNameIndex]);
                }
            }
            if (MyTextLine == null)
            {
                MessageBox.Show("Key word ''" + KEY_WORD_CONTROLS + "'' is not found in the file. (File imported anyway)",
                    "Key word missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return MyTextLine != null && MyTextLine.Trim(MyTrimChars) != KEY_WORD_CONTROLS;
        }

        public bool NextRow(ref string markerName, ref bool intensityOnly, 
            ref short alleleVariantId, ref string version, out bool validLine)
        {
            bool isTopInForward;
            string forwardReverse, versionInternal;
            string snpVariation;
            TopBotReference topBotReference;

            validLine = false;
            MyTextLine = MyStreamReader.ReadLine();
            if (MyTextLine != null && MyTextLine.Trim(MyTrimChars) != KEY_WORD_CONTROLS)
            {
                MySplittedLine = MyTextLine.Split(MyDelimiter, StringSplitOptions.None);
                if (!MyMarkerDictionary.ContainsKey(MySplittedLine[MyNameIndex]))
                {
                    markerName = MySplittedLine[MyNameIndex];
                    if (MyIntensityOnlyIndex == NO_INDEX || MySplittedLine[MyIntensityOnlyIndex].Trim() == "0")
                    {
                        intensityOnly = false;
                    }
                    else
                    {
                        intensityOnly = true;
                    }
                    ParseIlluminaId(MySplittedLine[MyIlmnIdIndex], out forwardReverse, out versionInternal, 
                        out isTopInForward, out topBotReference);
                    version = versionInternal;
                    snpVariation = GetSNPVariation(MySplittedLine[MySNPIndex]);
                    GetAlleleForwardData(snpVariation, forwardReverse, topBotReference.ToString(),
                        out alleleVariantId, out isTopInForward);
                    MyMarkerDictionary.Add(MySplittedLine[MyNameIndex], false);
                    validLine = true;
                }
                else
                {
                    MyDuplicateMarkers.Add(MySplittedLine[MyNameIndex]);
                }
            }
            if (MyTextLine == null)
            {
                MessageBox.Show("Key word ''" + KEY_WORD_CONTROLS + "'' is not found in the file. (File imported anyway)",
                    "Key word missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return MyTextLine != null && MyTextLine.Trim(MyTrimChars) != KEY_WORD_CONTROLS;
        }

        public bool NextRow(ref string markerName, ref short alleleVariantIdForward, ref string version, out bool validLine, 
            out bool isIntensityOnly)
        {
            bool isTopInForward;
            string forwardReverse, versionInternal;
            string snpVariation;
            TopBotReference topBotReference;

            isIntensityOnly = false;
            validLine = false;
            alleleVariantIdForward = NO_ID_TINY;
            MyTextLine = MyStreamReader.ReadLine();
            if (MyTextLine != null && MyTextLine.Trim(MyTrimChars) != KEY_WORD_CONTROLS)
            {
                MySplittedLine = MyTextLine.Split(MyDelimiter, StringSplitOptions.None);
                if (!MyMarkerDictionary.ContainsKey(MySplittedLine[MyNameIndex]))
                {
                    markerName = MySplittedLine[MyNameIndex];
                    snpVariation = GetSNPVariation(MySplittedLine[MySNPIndex]);
                    ParseIlluminaId(MySplittedLine[MyIlmnIdIndex], out forwardReverse, out versionInternal, 
                        out isTopInForward, out topBotReference);
                    version = versionInternal;

                    if (MyIntensityOnlyIndex != NO_INDEX &&
                        MySplittedLine[MyIntensityOnlyIndex].Trim() == "1")
                    {
                        isIntensityOnly = true;
                    }

                    GetAlleleForwardData(snpVariation, forwardReverse, topBotReference.ToString(),
                        out alleleVariantIdForward, out isTopInForward);
                    MyMarkerDictionary.Add(MySplittedLine[MyNameIndex], false);
                    validLine = true;
                }
                else
                {
                    MyDuplicateMarkers.Add(MySplittedLine[MyNameIndex]);
                }
            }
            if (MyTextLine == null)
            {
                //MessageBox.Show("Key word ''" + KEY_WORD_CONTROLS + "'' is not found in the file. (File imported anyway)",
                //    "Key word missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return MyTextLine != null && MyTextLine.Trim(MyTrimChars) != KEY_WORD_CONTROLS;
        }

        public bool NextRow(ref String[] row)
        {

            if (MyHasColumnsForPlusStrand)
            {
                return NextRowWithPlusImport(ref row);
            }
            else
            {
                return NextRowOrdinary(ref row);
            }
        }

        protected bool NextRowOrdinary(ref String[] row)
        {
            string[] genomicSequenceParts;
            string forwardReverse, version;
            bool isTopInForward;
            TopBotReference topBotReference;

            row = new string[MyNumberOutputColumns];
            for (int i = 0; i < MyNumberOutputColumns; i++)
            {
                row[i] = "";
            }

            MyTextLine = MyStreamReader.ReadLine();
            if (MyTextLine != null && MyTextLine.Trim(MyTrimChars) != KEY_WORD_CONTROLS)
            {
                MySplittedLine = MyTextLine.Split(MyDelimiter, StringSplitOptions.None);
                version = "0";
                forwardReverse = ForwardReverseReference.F.ToString();
                if (!MyMarkerDictionary.ContainsKey(MySplittedLine[MyNameIndex].Trim()))
                {
                    if (MySourceSeqIndex != NO_INDEX)
                    {
                        genomicSequenceParts = MySplittedLine[MySourceSeqIndex].Split(MyInternalDelimiter, StringSplitOptions.None);
                    }
                    else
                    {
                        genomicSequenceParts = null;
                    }
                    if (!SkipParsingIlluminaId)
                    {
                        ParseIlluminaId(MySplittedLine[MyIlmnIdIndex], out forwardReverse, out version, out isTopInForward, out topBotReference);
                    }
                    row[(int)RowIndex.Marker] = MySplittedLine[MyNameIndex].Trim();
                    row[(int)RowIndex.Chromosome] = MySplittedLine[MyChromosomeIndex];
                    if (genomicSequenceParts != null &&
                        genomicSequenceParts.Length > INTERNAL_FIVE_PRIME_INDEX &&
                        genomicSequenceParts.Length > INTERNAL_THREE_PRIME_INDEX)
                    {
                        row[(int)RowIndex.FivePrimeFlank] = genomicSequenceParts[INTERNAL_FIVE_PRIME_INDEX].ToUpper().Trim();
                        row[(int)RowIndex.ThreePrimeFlank] = genomicSequenceParts[INTERNAL_THREE_PRIME_INDEX].ToUpper().Trim();
                    }
                    else
                    {
                        row[(int)RowIndex.FivePrimeFlank] = "";
                        row[(int)RowIndex.ThreePrimeFlank] = "";
                        MyMarkersWithoutFlanks.Add(MySplittedLine[MyNameIndex].Trim());
                    }
                    row[(int)RowIndex.MarkerReference] = MySplittedLine[MyNameIndex] + "; " + MyManifestName;
                    row[(int)RowIndex.SNP_Variation] = GetSNPVariation(MySplittedLine[MySNPIndex].Trim());
                    row[(int)RowIndex.Forward_Reverse] = forwardReverse;
                    row[(int)RowIndex.ForwardVersion] = version.Trim();
                    row[(int)RowIndex.Top_Bot] = GetTopBotReference(MySplittedLine, MyIlmnStrandIndex);
                    row[(int)RowIndex.Position] = MySplittedLine[MyBasepairIndex].Trim();
                    MyMarkerDictionary.Add(MySplittedLine[MyNameIndex].Trim(), false);
                }
                else
                {
                    MyDuplicateMarkers.Add(MySplittedLine[MyNameIndex].Trim());
                    row = null;
                }
            }
            if (MyTextLine == null)
            {
                //throw new Data.Exception.ManifestKeyWordMissingException("Key word ''" + KEY_WORD_CONTROLS + "'' is not found in the file. (File imported anyway)");
            }

            return MyTextLine != null && MyTextLine.Trim(MyTrimChars) != KEY_WORD_CONTROLS;
        }

        protected virtual bool NextRowWithPlusImport(ref String[] row)
        {

            MyTextLine = MyStreamReader.ReadLine();
            return GetSplittedLineWithPlus(MyTextLine, ref row, true);
        }

        public bool GetSplittedLineWithPlus(string textline, ref string[] row, bool firstTimeRead)
        {
            string[] genomicSequenceParts;
            string forwardReverse, version, plusMinus;
            bool isTopInForward;
            TopBotReference topBotReference;

            row = new string[MyNumberOutputColumns];
            for (int i = 0; i < MyNumberOutputColumns; i++)
            {
                row[i] = "";
            }

            if (textline == null)
            {
                return false;
            }

            MySplittedLine = textline.Split(MyDelimiter, StringSplitOptions.None);
            version = "0";
            forwardReverse = ForwardReverseReference.F.ToString();
            plusMinus = PlusMinusReference.P.ToString();
            if (textline != null && textline.Trim(MyTrimChars) != KEY_WORD_CONTROLS)
            {
                if (!firstTimeRead || MyPermitDuplicateMarkers ||
                    !MyMarkerDictionary.ContainsKey(MySplittedLine[MyNameIndex].Trim()))
                {
                    if (MySourceSeqIndex != NO_INDEX)
                    {
                        genomicSequenceParts = MySplittedLine[MySourceSeqIndex].Split(MyInternalDelimiter, StringSplitOptions.None);
                    }
                    else
                    {
                        genomicSequenceParts = null;
                    }
                    if (!SkipParsingIlluminaId)
                    {
                        ParseIlluminaId(MySplittedLine[MyIlmnIdIndex], out forwardReverse, out version, out isTopInForward, out topBotReference);
                    }
                    row[(int)RowIndex.Marker] = MySplittedLine[MyNameIndex].Trim();
                    row[(int)RowIndex.Chromosome] = MySplittedLine[MyChromosomeIndex];
                    if (genomicSequenceParts != null &&
                        genomicSequenceParts.Length > INTERNAL_FIVE_PRIME_INDEX &&
                        genomicSequenceParts.Length > INTERNAL_THREE_PRIME_INDEX)
                    {
                        row[(int)RowIndex.FivePrimeFlank] = genomicSequenceParts[INTERNAL_FIVE_PRIME_INDEX].ToUpper().Trim();
                        row[(int)RowIndex.ThreePrimeFlank] = genomicSequenceParts[INTERNAL_THREE_PRIME_INDEX].ToUpper().Trim();
                    }
                    else
                    {
                        row[(int)RowIndex.FivePrimeFlank] = "";
                        row[(int)RowIndex.ThreePrimeFlank] = "";
                        MyMarkersWithoutFlanks.Add(MySplittedLine[MyNameIndex].Trim());
                    }
                    if (MySplittedLine[MyRefStrandIndex] == REF_STRAND_MINUS)
                    {
                        plusMinus = PlusMinusReference.M.ToString();
                    }
                    row[(int)RowIndex.MarkerReference] = MySplittedLine[MyNameIndex] + "; " + MyManifestName;
                    row[(int)RowIndex.SNP_Variation] = GetSNPVariation(MySplittedLine[MySNPIndex].Trim());
                    row[(int)RowIndex.Forward_Reverse] = forwardReverse;
                    row[(int)RowIndex.ForwardVersion] = version.Trim();
                    row[(int)RowIndex.Top_Bot] = GetTopBotReference(MySplittedLine, MyIlmnStrandIndex);
                    row[(int)RowIndex.Position] = MySplittedLine[MyBasepairIndex].Trim();
                    row[(int)RowIndex.Genome_Build] = MySplittedLine[MyGenomicBuildIndex].Trim();
                    row[(int)RowIndex.Plus_minus] = plusMinus;
                    if (MyIntensityOnlyIndex > NO_INDEX)
                    {
                        row[(int)RowIndex.Intensity_only] = MySplittedLine[MyIntensityOnlyIndex];
                    }
                    if (firstTimeRead && !MyPermitDuplicateMarkers)
                    {
                        MyMarkerDictionary.Add(MySplittedLine[MyNameIndex].Trim(), false);
                    }
                }
                else
                {
                    MyDuplicateMarkers.Add(MySplittedLine[MyNameIndex].Trim());
                    row = null;
                }
            }
            if (MyTextLine == null)
            {
            }

            return textline != null && textline.Trim(MyTrimChars) != KEY_WORD_CONTROLS;
        }

        public string GetCurrentTextLine()
        {
            return MyTextLine;
        }

        protected bool GetAlleleForwardData(string SNPVariation, string forwardStrand, string illuminaStrand,
            out Int16 alleleVariantIdInForward, out bool isTopInForward)
        {
            string parsedAlleleVariant;
            bool isForward, isTop;
            alleleVariantIdInForward = NO_ID_TINY;
            isTopInForward = false;
            if (forwardStrand == ForwardReverseReference.F.ToString() || forwardStrand.ToLower() == "forward")
            {
                isForward = true;
            }
            else
            {
                isForward = false;
            }
            if (!ParseAlleleVariant(SNPVariation, out parsedAlleleVariant))
            {
                return false;
            }
            alleleVariantIdInForward = (Int16)GetAlleleID(parsedAlleleVariant, isForward);
            if (alleleVariantIdInForward == NO_ID_TINY)
            {
                return false;
            }
            if (illuminaStrand == TopBotReference.T.ToString() || illuminaStrand.ToLower() == "top")
            {
                isTop = true;
            }
            else
            {
                isTop = false;
            }
            if ((isForward && isTop) || (!isForward && !isTop))
            {
                isTopInForward = true;
            }
            else
            {
                isTopInForward = false;
            }
            return true;
        }

        protected static bool ParseAlleleVariant(string alleleVariant, out string parsedAlleleVariant)
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

        protected int GetAlleleID(string parsedAlleleVariant, bool forward)
        {
            // Get allele_variant_id matching the input alleleVariant and 
            // forward flag, if forward, search
            // the id by matching alleleVariant with variant in 
            // table, otherwise match with the complement
            DataTable alleleVariantTable;
            alleleVariantTable = AlleleVariantManager.GetAlleleVariantTableFromDB();
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

        protected string GetTopBotReference(string[] splittedLine, int illuminaStrandIndex)
        {
            if (illuminaStrandIndex == NO_INDEX)
            {
                return "";
            }
            if (splittedLine[illuminaStrandIndex] == PlusMinusKeyWords.MINUS.ToString() ||
                splittedLine[illuminaStrandIndex] == PlusMinusKeyWords.PLUS.ToString())
            {
                // Indels do not have top-bot reference
                // Top or Bot designation is irrelevant, but must be set (top), 
                return TopBotReference.T.ToString();
            }
            else if (splittedLine[illuminaStrandIndex] == TopBotKeyWords.TOP.ToString())
            {
                MyIsAnyTopStrandFound = true;
                return TopBotReference.T.ToString();
            }
            else if (splittedLine[illuminaStrandIndex] == TopBotKeyWords.BOT.ToString())
            {
                MyIsAnyTopStrandFound = true;
                return TopBotReference.B.ToString();
            }
            return "";
        }

        protected void ParseIlluminaId(string illuminaId, out string forwardReverse, out string version,
            out bool isTopInForward, out TopBotReference topBotReference)
        {
            string[] delimiter, nameParts;
            string strand;
            int versionIndex, strandIndex, forwardIndex;
            bool isForward;

            delimiter = new string[2] { "-", "_" };

            nameParts = illuminaId.Split(delimiter, StringSplitOptions.None);

            // Get version number
            // Verify that the version number really is a number
            if (!GetParseInfo(nameParts, illuminaId, out versionIndex, out strandIndex, out forwardIndex))
            {
                throw new Exception("Error, could not achieve version number from illuminaId '" + illuminaId + "'");
            }

            version = nameParts[versionIndex];
            isForward = (nameParts[forwardIndex] == "F") ? true : false;
            strand = nameParts[strandIndex];

            if (strand == "T" || strand == "P")
            {
                topBotReference = TopBotReference.T;
            }
            else
            {
                topBotReference = TopBotReference.B;
            }

            if (isForward)
            {
                forwardReverse = ForwardReverseReference.F.ToString();
            }
            else
            {
                forwardReverse = ForwardReverseReference.R.ToString();
            }
            // Get top/bot notation, then convert it to the top/bot notation in forward notation
            // If strand is "M" or "P" it's a indel marker, then IsTopInForward doesn't matter, we pick true
            if ((strand == "T" && isForward) || (strand == "B" && !isForward) ||
                strand == "M" || strand == "P")
            {
                isTopInForward = true;
            }
            else
            {
                isTopInForward = false;
            }
        }

        protected Boolean GetParseInfo(string[] nameParts, string illuminaId, out int versionIndex,
            out int strandIndex, out int forwardIndex)
        {
            if (IsVersionIndexFound(1, nameParts))
            {
                versionIndex = 1;
                strandIndex = 2;
                forwardIndex = 3;
                return true;
            }
            else
            {
                // Go through the strings in nameParts
                // Look for a string that is numeric and that
                // has a string after with either T or B
                for (int i = 4; i < nameParts.Length; i++)
                {
                    if (IsVersionIndexFound(i - 2, nameParts))
                    {
                        versionIndex = i - 2;
                        strandIndex = i - 1;
                        forwardIndex = i;
                        if (illuminaId.IndexOf(nameParts[i - 3]) < 0)
                        {
                            return false;
                        }
                        return true;
                    }
                }
                versionIndex = -1;
                strandIndex = -1;
                forwardIndex = -1;
                return false;
            }
        }

        protected bool IsVersionIndexFound(int versionTrialIndex, string[] nameParts)
        {
            bool isNum;
            double dummy;
            isNum = double.TryParse(nameParts[versionTrialIndex], out dummy);
            if (isNum && (nameParts[versionTrialIndex + 1] == "T" || nameParts[versionTrialIndex + 1] == "B" ||
                nameParts[versionTrialIndex + 1] == "M" || nameParts[versionTrialIndex + 1] == "P") &&
                (nameParts[versionTrialIndex + 2] == "F" || nameParts[versionTrialIndex + 2] == "R"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected string GetSNPVariation(string parsedSNPVariation)
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

        public bool HasIntensityOnlyColumn()
        {
            return MyIntensityOnlyIndex != NO_INDEX;
        }

    }
}
