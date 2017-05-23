using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Molmed.LargeFileTool.Data;
using LargeFileTool.IO.ReadGenotypFile;
using LargeFileTool.Data.Exceptions;

namespace LargeFileTool.Data
{
    public class GenotypefileManifestMapper : LargeFileToolData
    {
        private BackgroundWorker MyBackgroundWorker;
        private string MyGenotypeFilePath;
        private string MyManifestFilePath;
        private double MyMarkerValidationRatioRequirement;
        private StringCollection MyMissingMarkers;
        private int MyNumberComparableMarkers;
        private int MyNumberConsistentMarkers;
        private int MyNumberScannedRows;
        private double MyValidationRatio;
        private string MyOutputMarkerPath;
        private const string NA = "NA";
        private const string N_A = "N/A";
        private const string CG = "C/G";
        private const string AT = "A/T";
        private const string CG_rev = "G/C";
        private const string AT_rev = "T/A";

        public GenotypefileManifestMapper(string genotypeFilePath, string manifestFilePath, 
            double markerValidationRatioRequirement, 
            string outputMarkerFilePath, BackgroundWorker bgw)
        {
            MyBackgroundWorker = bgw;
            MyGenotypeFilePath = genotypeFilePath;
            MyManifestFilePath = manifestFilePath;
            MyNumberConsistentMarkers = NO_INDEX;
            MyNumberComparableMarkers = NO_INDEX;
            MyNumberScannedRows = NO_INDEX;
            MyValidationRatio = NO_INDEX;
            MyMarkerValidationRatioRequirement = markerValidationRatioRequirement;
            MyMissingMarkers = new StringCollection();
            MyOutputMarkerPath = outputMarkerFilePath;
            if (IsNull(Database))
            {
                LoginDataBase(null, null);
            }
            MyBackgroundWorker.DoWork += MapMarkers;
        }

        private void MapMarkers(object sender, EventArgs e)
        {
            StreamReader sr = null;
            ReadManifestFile manifestReader = null;
            ReadGenotypeFileMarkersInColumns readGenotypeFile;
            MarkerInfo markerInfo;
            Dictionary<string, MarkerInfo> markerDict = new Dictionary<string,MarkerInfo>();
            bool isComparable;
            StreamWriter outputMarkerWriter = null;
            string alleleResult;

            string[] row = null;
            string markerName;
            bool isIntensityOnly, hasIntensityOnlyColumn;
            string alleleVarPlus;
            int counter = 0;
            string[] delimiter = new string[1] { "\t"};
            string[] splittedRow = null;
            bool isMarkerValidationFullfilled = false;
            int validatedMarkerCounter = 0, rowCounter = 0;
            int numberMarkers;
            try
            {
                MyBackgroundWorker.ReportProgress(0, "Checking file ...");
                readGenotypeFile = new ReadGenotypeFileMarkersInColumns(MyGenotypeFilePath);
                outputMarkerWriter = null;
                if (!readGenotypeFile.CheckIfGenotypeFile())
                {
                    throw new OpenGenotypeFileException();
                }

                MyBackgroundWorker.ReportProgress(0, "Scanning markers from manifest file ...");
                sr = new StreamReader(MyManifestFilePath);
                manifestReader = new ReadManifestFile(sr, MyManifestFilePath);
                if (!manifestReader.HasPlusStrandColumns())
                {
                    MessageBox.Show("Manifest has no plus strand columns, exiting");
                    return;
                }
                hasIntensityOnlyColumn = manifestReader.HasIntensityOnlyColumn();
                MyNumberComparableMarkers = 0;
                while (manifestReader.NextRow(ref row))
                {
                    markerName = row[(int)ReadManifestFile.RowIndex.Marker];
                    if (hasIntensityOnlyColumn && row[(int)ReadManifestFile.RowIndex.Intensity_only] == "1")
                    {
                        isIntensityOnly = true;
                    }
                    else
                    {
                        isIntensityOnly = false;
                    }
                    if (!isIntensityOnly)
                    {
                        alleleVarPlus = ReadManifestFile.GetAlleleVariationInPlus(row);
                        if (alleleVarPlus != NA && alleleVarPlus != N_A)
                        {
                            isComparable = true;
                            if (alleleVarPlus == CG || alleleVarPlus == AT || alleleVarPlus == CG_rev || alleleVarPlus == AT_rev)
                            {
                                isComparable = false;
                            }
                            markerInfo = new MarkerInfo(markerName, alleleVarPlus, isComparable);
                            markerDict.Add(markerInfo.GetIdentifier(), markerInfo);
                        }
                    }
                    if (++counter %100 == 0)
                    {
                        MyBackgroundWorker.ReportProgress(0, "Scanning markers from manifest file: " + ParseInt(counter));
                        if (MyBackgroundWorker.CancellationPending)
                        {
                            return;
                        }
                    }
                }
                manifestReader.Close();

                numberMarkers = markerDict.Keys.Count;
                // Read first line in genotype file, extract markers and index markerDict
                MyBackgroundWorker.ReportProgress(0, "Scanning genotypefile, indexing markers");
                readGenotypeFile.ReadMarkerHeaderLine(ref splittedRow);
                for (int i = readGenotypeFile.GetFirstResultColIndex(); i < splittedRow.Length; i++)
                {
                    markerName = splittedRow[i];
                    if (markerDict.ContainsKey(markerName))
                    {
                        markerDict[markerName].SetGenotypeColumnIndex(i);                        
                    }
                    else
                    {
                        MyMissingMarkers.Add(markerName);
                    }
                }
                readGenotypeFile.GoToFirstResultLine();


                // Validate markers for consistency with the selected manifest file,
                // regarding plus strand reference
                MyBackgroundWorker.ReportProgress(0, "Scanning genotypefile, validating markers");
                MyNumberConsistentMarkers = 0;
                MyNumberScannedRows = 0;
                // Samples on rows, read more than one row if there is much N/A 
                while (readGenotypeFile.ReadRow(ref splittedRow) && !isMarkerValidationFullfilled)
                {
                    if (IsNull(splittedRow))
                    {
                        continue;
                    }
                    MyNumberScannedRows++;
                    MyBackgroundWorker.ReportProgress(0, "Scanning genotypefile, validating markers row: " + (++rowCounter).ToString());
                    foreach (MarkerInfo tmpMarkInfo in markerDict.Values)
                    {
                        if (!tmpMarkInfo.IsVerified() && tmpMarkInfo.GetGenotypeFileColumnIndex() != NO_INDEX)
                        {
                            alleleResult = splittedRow[tmpMarkInfo.GetGenotypeFileColumnIndex()];
                            ValidateAlleleVariation(tmpMarkInfo, alleleResult);
                            if (tmpMarkInfo.IsVerified())
                            {
                                validatedMarkerCounter++;
                                if (tmpMarkInfo.IsComparable() && tmpMarkInfo.IsConsistent())
                                {
                                    MyNumberConsistentMarkers++;
                                    MyNumberComparableMarkers++;
                                }
                                else if (tmpMarkInfo.IsComparable())
                                {
                                    MyNumberComparableMarkers++;
                                    if (IsNotEmpty(MyOutputMarkerPath))
                                    {
                                        if (IsNull(outputMarkerWriter))
                                        {
                                            WriteOutputFileHeader(ref outputMarkerWriter);
                                        }
                                        if (IsNull(alleleResult))
                                        {
                                            alleleResult = "";
                                        }
                                        outputMarkerWriter.WriteLine(tmpMarkInfo.GetIdentifier() + '\t'.ToString() + tmpMarkInfo.GetAlleleVariation() +
                                            '\t'.ToString() + alleleResult);
                                        
                                    }
                                }
                            }
                            else // is verified
                            {
                                if (IsNotEmpty(MyOutputMarkerPath))
                                {
                                    if (IsNull(outputMarkerWriter))
                                    {
                                        WriteOutputFileHeader(ref outputMarkerWriter);
                                    }
                                    if (IsNull(alleleResult))
                                    {
                                        alleleResult = "";
                                    }
                                    outputMarkerWriter.WriteLine(tmpMarkInfo.GetIdentifier() + '\t'.ToString() + tmpMarkInfo.GetAlleleVariation() +
                                        '\t'.ToString() + alleleResult);

                                }

                            }
                        }
                    }
                    MyValidationRatio = (float)validatedMarkerCounter / numberMarkers;
                    if (MyValidationRatio > MyMarkerValidationRatioRequirement)
                    {
                        break;
                    }
                }
                readGenotypeFile.Close();
                if (IsNotEmpty(MyOutputMarkerPath))
                {
                    if (IsNull(outputMarkerWriter))
                    {
                        WriteOutputFileHeader(ref outputMarkerWriter);
                    }
                    outputMarkerWriter.WriteLine("Export finished");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (outputMarkerWriter != null)
                {
                    outputMarkerWriter.Close();
                }
            }
        }

        private void WriteOutputFileHeader(ref StreamWriter sw)
        {
            sw = new StreamWriter(MyOutputMarkerPath);
            sw.WriteLine("Marker" + '\t'.ToString() + "Allele var in plus from manifest" + '\t'.ToString() + "1st Allele Result from genotype file");
        }

        public int GetNumberComparbleMarkers()
        {
            return MyNumberComparableMarkers;
        }

        public int GetNumberConsistentMarkers()
        {
            return MyNumberConsistentMarkers;
        }

        public int GetNumberScannedRows()
        {
            return MyNumberScannedRows;
        }

        public double GetValidationRatio()
        {
            return MyValidationRatio;
        }

        private void ValidateAlleleVariation(MarkerInfo markerInfo, string alleleVarFromGenotypeFile)
        {
            string firstAllele;
            if (IsNotEmpty(alleleVarFromGenotypeFile) &&
                alleleVarFromGenotypeFile != NA && alleleVarFromGenotypeFile != N_A)
            {
                firstAllele = alleleVarFromGenotypeFile.Substring(0, 1);
                if (markerInfo.GetAlleleVariation().Contains(firstAllele))
                {
                    markerInfo.SetIsConsistent(true);
                }
                else
                {
                    markerInfo.SetIsConsistent(false);
                }
                markerInfo.SetIsVerified(true);
            }
        }

        /// <summary>
        /// Markers in genotypefile that is not found in manifest
        /// </summary>
        /// <returns></returns>
        public StringCollection GetMissingMarkers()
        {
            return MyMissingMarkers;
        }

        public bool HasMissingMarkers()
        {
            return MyMissingMarkers.Count > 0;
        }

        private class MarkerInfo
        {
            private string MyMarkerIdentifier;
            private string MyAlleleVariationPlus;
            private int MyGenotypeColumnIndex;
            private bool MyIsVerified;
            private bool MyIsConsistent;
            private bool MyIsComparable;

            public MarkerInfo(string markerIdentifier, string alleleVariationPlus, bool isComparable)
            {
                MyMarkerIdentifier = markerIdentifier;
                if (IsNull(alleleVariationPlus))
                {
                    alleleVariationPlus = "";
                }
                MyAlleleVariationPlus = alleleVariationPlus;
                MyGenotypeColumnIndex = NO_INDEX;
                MyIsVerified = false;
                MyIsComparable = isComparable;
                MyIsConsistent = true;
            }

            #region Get functions
            public string GetIdentifier()
            {
                return MyMarkerIdentifier;
            }

            public string GetAlleleVariation()
            {
                return MyAlleleVariationPlus;
            }

            public int GetGenotypeFileColumnIndex()
            {
                return MyGenotypeColumnIndex;
            }
            
            #endregion

            #region Questions

            public bool IsVerified()
            {
                return MyIsVerified;
            }

            public bool IsComparable()
            {
                return MyIsComparable;
            }

            public bool IsConsistent()
            {
                return MyIsConsistent;
            }

            #endregion

            #region Set functions
            public void SetGenotypeColumnIndex(int colInd)
            {
                MyGenotypeColumnIndex = colInd;
            }

            public void SetIsVerified(bool isVerified)
            {
                MyIsVerified = isVerified;
            }

            public void SetIsConsistent(bool isConsistent)
            {
                MyIsConsistent = isConsistent;
            }

            public void SetIsComparable(bool isComparable)
            {
                MyIsComparable = isComparable;
            }
            
            #endregion


            public void Validate(string alleleResultFromGenotypeFile)
            {
                if (alleleResultFromGenotypeFile != NA && alleleResultFromGenotypeFile != N_A)
                {
                    MyIsVerified = true;

                }
            }

        }

    }
}
