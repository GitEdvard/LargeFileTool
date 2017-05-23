using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LargeFileTool.Database;

namespace LargeFileTool.Data
{
    public class AlleleVariantManager : LargeFileToolData
    {
        // Change 2
        private static DataTable MyAlleleVariantTableFromDB;
        private static DataTable MyAlleleVariantTableIlluminaConsistent;
        private const string DI = "D/I";
        private const string ID = "I/D";

        // Add hoc 2
        public AlleleVariantManager()
        {
            MyAlleleVariantTableFromDB = null;
        }

        /// <summary>
        /// Alleles order in illumina consistent way, not as in db
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAlleleVariantTable()
        {
            if (IsNull(MyAlleleVariantTableIlluminaConsistent))
            {
                MyAlleleVariantTableIlluminaConsistent = FillAlleleVariantTableIlluminConsistent();
            }
            return MyAlleleVariantTableIlluminaConsistent;
        }

        /// <summary>
        /// From db: alleles always ordered in alphabetic order
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAlleleVariantTableFromDB()
        {
            if (IsNull(Database))
            {
                throw new Exception("Connection to Chiasma database is not initialized");
            }
            if (IsNull(MyAlleleVariantTableFromDB))
            {
                MyAlleleVariantTableFromDB = FillAlleleVariantTableFromDB();
            }
            return MyAlleleVariantTableFromDB;
        }

        private static DataTable FillAlleleVariantTableIlluminConsistent()
        {
            DataTable table = null;
            DataRow row;
            short fejkId = 1;
            table = GetAlleleVariantEmptyTable();

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "A/C");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "A/G");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "A/T");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "T/A");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "C/G");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "G/C");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "T/C");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "T/G");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "D/I");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "I/D");
            table.Rows.Add(row);

            row = table.NewRow();
            FillNewRow(ref row, fejkId++, "N/A");
            table.Rows.Add(row);

            return table;
        }

        private static void FillNewRow(ref DataRow row, short fejkId, string variant)
        {
            row[(int)AlleleVariantTable.AlleleVariantId] = fejkId;
            row[(int)AlleleVariantTable.Variant] = variant;
            row[(int)AlleleVariantTable.Complement] = GetCompement(variant);
        }

        private static string GetCompement(string alleleVar)
        {
            string complement = "", baseA, baseB;

            if (alleleVar == "N/A" || alleleVar == "D/I" || 
                alleleVar == "I/D")
            {
                return alleleVar;
            }
            baseA = GetComplementBase(alleleVar.Substring(0, 1));
            baseB = GetComplementBase(alleleVar.Substring(2, 1));
            complement = baseA + "/" + baseB;
            return complement;
        }

        private static string GetComplementBase(string baseStr)
        {
            switch (baseStr.ToUpper())
            {
                case "A":
                    return "T";
                case "C":
                    return "G";
                case "G":
                    return "C";
                case "T":
                    return "A";
                case "-":
                    return "-";
                case "":
                    return "";
                default:
                    throw new Exception("Unknown base: " + baseStr);
            }
        }

        private static DataTable FillAlleleVariantTableFromDB()
        {
            DataTable alleleVariantTable;
            DataReader dataReader = null;
            object[] tempRow;
            alleleVariantTable = GetAlleleVariantEmptyTable();

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

        private static DataTable GetAlleleVariantEmptyTable()
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

        public static bool IsInsertionAllele(string alleleVar)
        {
            return alleleVar == ID || alleleVar == DI;
        }

        public static bool IsAlleleVariant(string alleleResultStringWithSlash)
        {
            string alleleA, alleleB, alleleVar;
            alleleB = alleleResultStringWithSlash.Substring(2, 1);
            alleleA = alleleResultStringWithSlash.Substring(0, 1);
            foreach (DataRow row in GetAlleleVariantTable().Rows)
            {
                alleleVar = (string)row[(int)AlleleVariantTable.Variant];
                if (alleleVar.Contains(alleleA) && alleleVar.Contains(alleleB))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
