using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LargeFileTool.Data
{
    public class ReadComparisonReportFile : ReadManifestFile
    {
        public new enum RowIndex
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
            Intensity_only = 13,
            Allele_var_plus = 14,
            Manifest = 15
        }


        bool MyIsFirstRowInPair;
        private string MyManifest1;
        private string MyManifest2;
        private bool MyIsManifestOrderInitialized;
        private bool MyIsManifest1OnFirstRow;
        private int MyManifestIndex;
        private int MyAlleleVarPlusIndex;

        protected const string COLUMN_MANIFEST = "Manifest";
        protected const string COLUMN_ALLELE_VAR_PLUS = "Allele var plus";
        protected const string REVERSED_ALLELES = "(reversed alleles)";
        private const string CG = "C/G";
        private const string AT = "A/T";

        public ReadComparisonReportFile(string directory, string manifest1, string manifest2)
        {
            InitManifestFile(GetFilePath(directory, manifest1, manifest2));
            MyIsFirstRowInPair = true;
            MyIsManifestOrderInitialized = false;
            MyIsManifest1OnFirstRow = false;
            MyManifest1 = manifest1;
            MyManifest2 = manifest2;
            MyPermitDuplicateMarkers = true;
        }

        protected override void Init()
        {
            MyManifestIndex = NO_INDEX;
            MyAlleleVarPlusIndex = NO_INDEX;
            base.Init();
            MyNumberOutputColumns = Enum.GetValues(typeof(RowIndex)).Length;
            InitColumnIndex();
        }

        protected void InitColumnIndex()
        {
            string[] splittedLine;
            splittedLine = MyHeaderColumnLine.Split(MyDelimiter, StringSplitOptions.None);
            for (int i = 0; i < splittedLine.Length; i++)
            {
                if (splittedLine[i].Trim() == COLUMN_MANIFEST)
                {
                    MyManifestIndex = i;
                }
                if (splittedLine[i].Trim() == COLUMN_ALLELE_VAR_PLUS)
                {
                    MyAlleleVarPlusIndex = i;
                }
            }
        }

        private string GetFilePath(string directory, string manifest1, string manifest2)
        {
            string[] files;
            string fileName;
            files = Directory.GetFiles(directory, "*.txt");
            foreach (string filePath in files)
            {
                fileName = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                if (fileName.Contains(manifest1) && fileName.Contains(manifest2))
                {
                    return filePath;
                }
            }
            return "";
        }

        public bool NextComparisonRow(ref string markerName)
        {
            bool readRow;
            string[] row = null;
            readRow = NextRow(ref row);
            if (!MyIsFirstRowInPair)
            {
                readRow = NextRow(ref row);
                if (!readRow)
                {
                    markerName = null;
                    return false;
                }
                MyIsFirstRowInPair = true;
            }
            markerName = row[(int)RowIndex.Marker];
            MyIsFirstRowInPair = false;
            return readRow;                

        }

        private void InitManifestOrder(string manifestFileFromFirstRow)
        {
            if (manifestFileFromFirstRow.ToLower().Contains(MyManifest1.ToLower()))
            {
                MyIsManifest1OnFirstRow = true;
            }
            else if(manifestFileFromFirstRow.ToLower().Contains(MyManifest2.ToLower()))
            {
                MyIsManifest1OnFirstRow = false;
            }
            else
            {
                throw new Exception("Refered manifest file not matched in comparison file");
            }
            MyIsManifestOrderInitialized = true;
        }

        public bool NextComparisonRow(ref string markerName, ref string alleleVarPlus1, ref string alleleVarPlus2)
        {
            bool readRow;
            string[] row = null;
            if (!MyIsFirstRowInPair)
            {
                throw new Exception("First row in comparison pair is expected");
            }
            readRow = NextRow(ref row);

            if (!readRow)
            {
                return false;
            }

            if (!MyIsManifestOrderInitialized)
            {
                InitManifestOrder(row[(int)RowIndex.Manifest]);
            }

            markerName = row[(int)RowIndex.Marker];

            if (MyIsManifest1OnFirstRow)
            {
                alleleVarPlus1 = GetAlleleVariationInPlus(row);
            }
            else
            {
                alleleVarPlus2 = GetAlleleVariationInPlus(row);
            }

            readRow = NextRow(ref row);
            if (!readRow)
            {
                throw new Exception("Second row in comparison pair is not found");
            }
            if (markerName != row[(int)RowIndex.Marker])
            {
                throw new Exception("Marker mismatch");
            }

            if (MyIsManifest1OnFirstRow)
            {
                alleleVarPlus2 = GetAlleleVariationInPlus(row);
            }
            else
            {
                alleleVarPlus1 = GetAlleleVariationInPlus(row);
            }

            //if (alleleVarPlus2 == CG || alleleVarPlus2 == AT)
            //{
            //    alleleVarPlus2 = alleleVarPlus2 + " " + REVERSED_ALLELES;
            //}

            return readRow;            
        }

        protected override bool NextRowWithPlusImport(ref string[] row)
        {
            bool readLine;
            readLine = base.NextRowWithPlusImport(ref row);
            if (!readLine)
            {
                return false;
            }
            row[(int)RowIndex.Manifest] = MySplittedLine[MyManifestIndex].Trim();
            row[(int)RowIndex.Allele_var_plus] = MySplittedLine[MyAlleleVarPlusIndex].Trim();
            return true;
        }

    }
}
