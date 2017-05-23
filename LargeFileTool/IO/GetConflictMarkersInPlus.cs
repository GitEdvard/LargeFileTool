using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Data;
using LargeFileTool.Data;
using Microsoft.Isam.Esent.Collections.Generic;



namespace LargeFileTool.IO
{
    public class GetConflictMarkersInPlus : LargeFileToolData
    {
        #region Declarations
        private BackgroundWorker MyBackGroundWorker;
        private ReadManifestFile MyReadManifestFile1;
        private ReadManifestFile MyReadManifestFile2;
        private ReadVCFBaseReferenceFile MyReadVCFBaseReferenceFile;
        private StreamReader MyStreamReader;
        private bool MyExcludeIntensityOnly;
        private string MyFilePath2;
        private string MyFilePath1;
        private string MySummaryFile;
        private bool MyOnlyWithSnpVariation;
        private bool MyIncludeOnlyPlusConflict;
        private string MyMarkerListFilePath;
        private string MyOutputPath;
        private DataTable MyAlleleVariantTable;
        private int MyInvestigatedComparisons;
        private int MyCompletedComparisons;
        private int MyNoLegalManifests;
        private int MyFileComaprisonWaiting;
        private bool MyCleanDictionaryBank;
        private bool MyUseAlternatePlusStrandExtraction;
        private Dictionary<string, bool> MySelectedMarkersDictionary;
        //private Dictionary<string, Dictionary<string, bool>> MyMarkerDictionaryBank;
        //private Dictionary<string, PersistentDictionary<string, bool>> MyMarkerDictionaryBank;
        private ScanConflictMarkersPlusInFolder.MarkerDictionaryList MyMarkerDictionaryBank;
        public const string MyPersistentDictionaryFolder = "PersistentDictDB";
        private int MyPersistentFolderCounter;
        private const string MyCommonMarkerDictFolder = "CommonMarkerDictDB";
        private const string SUMMARY_FILE = "Summary.txt";
        private const string LOG_FILE = "Log.txt";


        #endregion

        public GetConflictMarkersInPlus(string filePath1, string filePath2, string summaryFile,
            string markerListFilePath, string outputPath, bool includeOnlyPlusConflict,
            bool excludeIntensityOnly, bool onlyWithSnpVariation, 
            int investiagatedComparison, int fileComparisonWaiting, 
            bool resetSummaryfile, BackgroundWorker bwd)
        {
            MyBackGroundWorker = bwd;
            MyMarkerListFilePath = markerListFilePath;
            MyCleanDictionaryBank = true;
            MyOutputPath = outputPath;
            MyExcludeIntensityOnly = excludeIntensityOnly;
            MyFilePath2 = filePath2;
            MyFilePath1 = filePath1;
            MySummaryFile = summaryFile;
            MyAlleleVariantTable = null;
            MyMarkerDictionaryBank = null;
            MyInvestigatedComparisons = investiagatedComparison;
            MyCompletedComparisons = NO_INDEX;
            MyNoLegalManifests = NO_INDEX;
            MyFileComaprisonWaiting = fileComparisonWaiting;
            MyIncludeOnlyPlusConflict = includeOnlyPlusConflict;
            MyOnlyWithSnpVariation = onlyWithSnpVariation;
            MySelectedMarkersDictionary = null;
            MyReadManifestFile1 = null;
            MyUseAlternatePlusStrandExtraction = false;
            if (resetSummaryfile &&
                File.Exists(MySummaryFile))
            {
                File.Delete(MySummaryFile);
            }
            if (File.Exists(MyOutputPath))
            {
                File.Delete(MyOutputPath);
            }
            WriteSummaryHeader(MySummaryFile);

            if (!OpenManifestFile(ref MyReadManifestFile1, filePath1))
            {
                return;
            }

            if (!OpenManifestFile(ref MyReadManifestFile2, filePath2))
            {
                return;
            }
            MyPersistentFolderCounter = 1;
            MyBackGroundWorker.DoWork += new DoWorkEventHandler(ExportConflictsLines);
        }

        public GetConflictMarkersInPlus(ReadManifestFile manifest1, ReadManifestFile manifest2, string summaryFile,
            Dictionary<string, bool> markerFileDictionary, string outputPath, bool includeOnlyPlusConflict,
            bool excludeIntensityOnly, bool onlyWithSnpVariation,
            int investigatedComparison, int fileComparisonWaiting, int completedComparisons,
            int noLegalManifests, ref ScanConflictMarkersPlusInFolder.MarkerDictionaryList markerDictionaryBank,
            int persistentDictFolderCounter,
            bool resetSummaryfile, BackgroundWorker bwd)
        {
            MyBackGroundWorker = bwd;
            MySelectedMarkersDictionary = markerFileDictionary;
            MyUseAlternatePlusStrandExtraction = false;
            MyOutputPath = outputPath;
            MyCleanDictionaryBank = false;
            MyExcludeIntensityOnly = excludeIntensityOnly;
            MyReadManifestFile1 = manifest1;
            MyReadManifestFile2 = manifest2;
            MyFilePath1 = MyReadManifestFile1.FilePath;
            MyFilePath2 = MyReadManifestFile2.FilePath;
            MySummaryFile = summaryFile;
            MyAlleleVariantTable = null;
            MyInvestigatedComparisons = investigatedComparison;
            MyCompletedComparisons = completedComparisons;
            MyNoLegalManifests = noLegalManifests;
            MyFileComaprisonWaiting = fileComparisonWaiting;
            MyIncludeOnlyPlusConflict = includeOnlyPlusConflict;
            MyOnlyWithSnpVariation = onlyWithSnpVariation;
            MyMarkerDictionaryBank = markerDictionaryBank;
            if (resetSummaryfile &&
                File.Exists(MySummaryFile))
            {
                File.Delete(MySummaryFile);
            }
            if (File.Exists(MyOutputPath))
            {
                File.Delete(MyOutputPath);
            }
            MyPersistentFolderCounter = persistentDictFolderCounter;
            MyBackGroundWorker.DoWork += new DoWorkEventHandler(ExportConflictsLines);
        }

        public GetConflictMarkersInPlus(string manifestFilePath, string vcfFilePath, 
            string markerListFilePath, string outputFolderPath,
            BackgroundWorker bwd)
        {
            MyFilePath1 = manifestFilePath;
            MyFilePath2 = vcfFilePath;
            MyBackGroundWorker = bwd;

            MyCleanDictionaryBank = true;
            MyUseAlternatePlusStrandExtraction = false;
            MySummaryFile = outputFolderPath + @"\" + SUMMARY_FILE;
            MyMarkerListFilePath = markerListFilePath;
            MyOutputPath = GetConflictReportFileName(outputFolderPath, manifestFilePath, vcfFilePath);
            MyAlleleVariantTable = null;
            MyInvestigatedComparisons = 0;
            MyCompletedComparisons = 0;
            MyNoLegalManifests = 0;
            MyFileComaprisonWaiting = 0;
            MyMarkerDictionaryBank = null;
            MyPersistentFolderCounter = 1;

            if (File.Exists(MySummaryFile))
            {
                File.Delete(MySummaryFile);
            }
            if (File.Exists(MyOutputPath))
            {
                File.Delete(MyOutputPath);
            }
            WriteSummaryHeader(MySummaryFile);

            if (!OpenManifestFile(ref MyReadManifestFile1, manifestFilePath))
            {
                return;
            }

            if (!OpenVcfBaseReferenceFile(ref MyReadVCFBaseReferenceFile, vcfFilePath))
            {
                return;
            }
            MyBackGroundWorker.DoWork += new DoWorkEventHandler(ExportConflictsLinesWithVCF);
        }

        public static string GetConflictReportFileName(string outputFolder, string manifestPath1, string manifestPath2)
        {
            string name1, name2;
            string conflictFileName = "";

            name1 = manifestPath1.Substring(manifestPath1.LastIndexOf(@"\") + 1);
            name2 = manifestPath2.Substring(manifestPath2.LastIndexOf(@"\") + 1);

            conflictFileName = "ConflictReport_" + name1 + "__" + name2 + ".txt";

            return outputFolder + @"\" + conflictFileName;
        }

        private void DisposePersistentDict(ref ScanConflictMarkersPlusInFolder.MarkerDictionaryList dictBank)
        {
            foreach (ScanConflictMarkersPlusInFolder.DictionaryWithName dict in dictBank)
            {
                dict.GetDictionary().Dispose();
            }
        }

        private void RemovePersistentDictFolders()
        {
            string[] folders;
            try
            {

                folders = Directory.GetDirectories(Directory.GetCurrentDirectory());
                foreach (string folder in folders)
                {
                    if (folder.Contains(GetConflictMarkersInPlus.MyPersistentDictionaryFolder))
                    {
                        RemoveDirectory(folder);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ExportConflictsLines(object sender, DoWorkEventArgs e)
        {
            PersistentDictionary<string, bool> manifestMarkers1 = null;
            PersistentDictionary<string, bool> manifestMarkers2 = null;
            PersistentDictionary<string, string> commonMarkerDict = null;
            string marker = "";
            string currentTextLine;
            string outputLine1, outputLine2;
            string[] manifestRow = null;
            int counter = 0, conflictCounter = 0;
            StreamWriter sw = null;
            string fileName1, fileName2;
            int commonMarkerCount = 0;
            
            try
            {
                fileName1 = MyFilePath1.Substring(MyFilePath1.LastIndexOf(@"\") + 1);
                fileName2 = MyFilePath2.Substring(MyFilePath2.LastIndexOf(@"\") + 1);
                commonMarkerDict = new PersistentDictionary<string, string>(MyCommonMarkerDictFolder);

                // Read markers from marker table, if any
                if (IsNull(MySelectedMarkersDictionary) && IsNotEmpty(MyMarkerListFilePath))
                {
                    FillSelectedMarkersDictionary(ref MySelectedMarkersDictionary, MyMarkerListFilePath);
                }

                // Read both manifest the first time, extract the marker names and
                // put in dictionary

                // Extract the marker name and put in a dictionary
                // Manifest 1
                if (IsNotNull(MyMarkerDictionaryBank) && MyMarkerDictionaryBank.HasDictionary(fileName1))
                {
                    manifestMarkers1 = MyMarkerDictionaryBank.GetDictionary(fileName1);
                }
                else
                {
                    FillMarkerDictionary(ref manifestMarkers1, MyReadManifestFile1);
                    if (IsNull(MyMarkerDictionaryBank))
                    {
                        MyMarkerDictionaryBank = new ScanConflictMarkersPlusInFolder.MarkerDictionaryList();
                    }
                    MyMarkerDictionaryBank.Add(new ScanConflictMarkersPlusInFolder.DictionaryWithName(fileName1, manifestMarkers1));
                }

                // Manifest 2
                if (IsNotNull(MyMarkerDictionaryBank) && MyMarkerDictionaryBank.HasDictionary(fileName2))
                {
                    manifestMarkers2 = MyMarkerDictionaryBank.GetDictionary(fileName2);
                }
                else
                {
                    FillMarkerDictionary(ref manifestMarkers2, MyReadManifestFile2);
                    if (IsNull(MyMarkerDictionaryBank))
                    {
                        MyMarkerDictionaryBank = new ScanConflictMarkersPlusInFolder.MarkerDictionaryList();
                    }
                    MyMarkerDictionaryBank.Add(new ScanConflictMarkersPlusInFolder.DictionaryWithName(fileName2, manifestMarkers2));
                }


                // Init common marker dictionary, 
                // Markers that are common in the two manifest files and,
                // occurs in the selected list, if it is initialized
                counter = 0;
                MyBackGroundWorker.ReportProgress(0, "Sorting out common markers, " + Environment.NewLine + MyFilePath1 +
                    Environment.NewLine + MyFilePath2 + GetComparisonStatusString());
                foreach (string markerMan1 in manifestMarkers1.Keys)
                {
                    if (manifestMarkers2.ContainsKey(markerMan1))
                    {

                        commonMarkerCount++;
                        if ((IsNull(MySelectedMarkersDictionary) ||
                                MySelectedMarkersDictionary.ContainsKey(markerMan1)))
                        {
                            commonMarkerDict.Add(markerMan1, null);
                            if (++counter % 1000 == 0)
                            {
                                MyBackGroundWorker.ReportProgress(0, "Sorting out common markers: " + MyFilePath1 +
                                    Environment.NewLine + "Row " + ParseInt(counter) + GetComparisonStatusString());
                            }
                            
                        }
                    }
                }

                if (commonMarkerDict.Count == 0)
                {
                    return;
                }

                // Loop through the manifests one more time
                // Check if row for current marker should be saved
                // Save in common marker dictionary
                MyReadManifestFile1.Reset();

                counter = 0;
                MyBackGroundWorker.ReportProgress(0, "Extracting manifest file: " + MyFilePath1 + GetComparisonStatusString());
                while (MyReadManifestFile1.NextRow(ref manifestRow))
                {
                    marker = manifestRow[(int)ReadManifestFile.RowIndex.Marker];
                    marker = marker.Trim().ToLower();
                    if (commonMarkerDict.ContainsKey(marker))
                    {
                        currentTextLine = MyReadManifestFile1.GetCurrentTextLine();
                        commonMarkerDict[marker] = currentTextLine;
                        if (++counter % 1000 == 0)
                        {
                            MyBackGroundWorker.ReportProgress(0, "Extracting manifest file: " + MyFilePath1 + Environment.NewLine +
                                "row: " + ParseInt(counter) + GetComparisonStatusString());
                        }

                    }
                }

                MyReadManifestFile2.Reset();
                counter = 0;
                conflictCounter = 0;
                MyBackGroundWorker.ReportProgress(0, "Extracting manifest file: " + MyFilePath2 + GetComparisonStatusString());
                while (MyReadManifestFile2.NextRow(ref manifestRow))
                {
                    marker = manifestRow[(int)ReadManifestFile.RowIndex.Marker];
                    marker = marker.Trim().ToLower();
                    if (commonMarkerDict.ContainsKey(marker))
                    {
                        if (IsConflictInPlus(commonMarkerDict[marker], manifestRow,
                            MyReadManifestFile1, MyReadManifestFile2,
                            fileName1, fileName2,
                            out outputLine1, out outputLine2))
                        {
                            conflictCounter++;
                            if (sw == null)
                            {
                                sw = new StreamWriter(MyOutputPath);
                                currentTextLine = MyReadManifestFile1.GetHeaderColumnLine();
                                currentTextLine += ", Allele var plus, Manifest";
                                sw.WriteLine(currentTextLine);
                            }
                            sw.WriteLine(outputLine1);
                            sw.WriteLine(outputLine2);

                        }
                        if (++counter % 1000 == 0)
                        {
                            MyBackGroundWorker.ReportProgress(0, "Extracting manifest file: " + MyFilePath2 + Environment.NewLine +
                                "row: " + ParseInt(counter) + GetComparisonStatusString());
                        }
                    }
                }

                if (sw != null)
                {
                    sw.Close();
                }

                // Write sumary information 
                if (counter > 0)
                {
                    // counter = number of conflicts
                    currentTextLine = fileName1 + "\t " + manifestMarkers1.Count.ToString() + "\t" + 
                        fileName2 + "\t" + manifestMarkers2.Count.ToString() + "\t" + 
                        commonMarkerCount.ToString() + "\t" + conflictCounter.ToString();
                    WriteToSummary(currentTextLine);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (MyStreamReader != null)
                {
                    MyStreamReader.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
                RemoveCommonDictFolder(commonMarkerDict);

                if (MyCleanDictionaryBank)
                {
                    DisposePersistentDict(ref MyMarkerDictionaryBank);
                    RemovePersistentDictFolders();
                }
            }
        }

        private void ExportConflictsLinesWithVCF(object sender, DoWorkEventArgs e)
        {
            PersistentDictionary<string, bool> manifestMarkers1 = null;
            PersistentDictionary<string, bool> vcfMarkers = null;
            PersistentDictionary<string, string> commonMarkerDict = null;
            string marker = "";
            string currentTextLine;
            string outputLine1, outputLine2;
            string[] manifestRow = null;
            int counter = 0, conflictCounter = 0;
            StreamWriter sw = null;
            string fileName1, fileName2;
            int commonMarkerCount = 0;
            try
            {
                fileName1 = MyFilePath1.Substring(MyFilePath1.LastIndexOf(@"\") + 1);
                fileName2 = MyFilePath2.Substring(MyFilePath2.LastIndexOf(@"\") + 1);
                commonMarkerDict = new PersistentDictionary<string, string>(MyCommonMarkerDictFolder);

                // Read markers from marker table, if any
                if (IsNull(MySelectedMarkersDictionary) && IsNotEmpty(MyMarkerListFilePath))
                {
                    FillSelectedMarkersDictionary(ref MySelectedMarkersDictionary, MyMarkerListFilePath);
                }

                // Read both manifest the first time, extract the marker names and
                // put in dictionary

                // Extract the marker name and put in a dictionary
                // Manifest 1
                if (IsNotNull(MyMarkerDictionaryBank) && MyMarkerDictionaryBank.HasDictionary(fileName1))
                {
                    manifestMarkers1 = MyMarkerDictionaryBank.GetDictionary(fileName1);
                }
                else
                {
                    FillMarkerDictionary(ref manifestMarkers1, MyReadManifestFile1);
                    if (IsNull(MyMarkerDictionaryBank))
                    {
                        MyMarkerDictionaryBank = new ScanConflictMarkersPlusInFolder.MarkerDictionaryList();
                    }
                    MyMarkerDictionaryBank.Add(new ScanConflictMarkersPlusInFolder.DictionaryWithName(fileName1, manifestMarkers1));
                }

                // Manifest 2
                if (IsNotNull(MyMarkerDictionaryBank) && MyMarkerDictionaryBank.HasDictionary(fileName2))
                {
                    vcfMarkers = MyMarkerDictionaryBank.GetDictionary(fileName2);
                }
                else
                {
                    FillMarkerDictionary(ref vcfMarkers, MyReadVCFBaseReferenceFile);
                    if (IsNull(MyMarkerDictionaryBank))
                    {
                        MyMarkerDictionaryBank = new ScanConflictMarkersPlusInFolder.MarkerDictionaryList();
                    }
                    MyMarkerDictionaryBank.Add(new ScanConflictMarkersPlusInFolder.DictionaryWithName(fileName2, vcfMarkers));
                }

                // Init common marker dictionary, 
                // Markers that are common in the two files and,
                // occurs in the selected list, if it is initialized
                counter = 0;
                MyBackGroundWorker.ReportProgress(0, "Sorting out common markers, " + Environment.NewLine + MyFilePath1 +
                    Environment.NewLine + MyFilePath2 + GetComparisonStatusString());
                foreach (string markerMan1 in manifestMarkers1.Keys)
                {
                    if (vcfMarkers.ContainsKey(markerMan1))
                    {

                        commonMarkerCount++;
                        if ((IsNull(MySelectedMarkersDictionary) ||
                                MySelectedMarkersDictionary.ContainsKey(markerMan1)))
                        {
                            commonMarkerDict.Add(markerMan1, null);
                            if (++counter % 1000 == 0)
                            {
                                MyBackGroundWorker.ReportProgress(0, "Sorting out common markers: " + MyFilePath1 +
                                    Environment.NewLine + "Row " + ParseInt(counter) + GetComparisonStatusString());
                            }

                        }
                    }
                }

                if (commonMarkerDict.Count == 0)
                {
                    return;
                }

                // Loop through the manifests one more time
                // Check if row for current marker should be saved
                // Save in common marker dictionary
                MyReadManifestFile1.Reset();

                counter = 0;
                MyBackGroundWorker.ReportProgress(0, "Extracting manifest file: " + MyFilePath1 + GetComparisonStatusString());
                while (MyReadManifestFile1.NextRow(ref manifestRow))
                {
                    marker = manifestRow[(int)ReadManifestFile.RowIndex.Marker];
                    marker = marker.Trim().ToLower();
                    if (commonMarkerDict.ContainsKey(marker))
                    {
                        currentTextLine = MyReadManifestFile1.GetCurrentTextLine();
                        commonMarkerDict[marker] = currentTextLine;
                        if (++counter % 1000 == 0)
                        {
                            MyBackGroundWorker.ReportProgress(0, "Extracting manifest file: " + MyFilePath1 + Environment.NewLine +
                                "row: " + ParseInt(counter) + GetComparisonStatusString());
                        }

                    }
                }

                MyReadVCFBaseReferenceFile.Reset();
                counter = 0;
                conflictCounter = 0;
                MyBackGroundWorker.ReportProgress(0, "Extracting VCF base reference file: " + MyFilePath2 + GetComparisonStatusString());
                while (MyReadVCFBaseReferenceFile.NextRow(ref manifestRow))
                {
                    marker = manifestRow[(int)ReadVCFBaseReferenceFile.RowIndex.SnpName];
                    marker = marker.Trim().ToLower();
                    if (commonMarkerDict.ContainsKey(marker))
                    {
                        if (IsConflictInPlus_VCF(commonMarkerDict[marker], manifestRow,
                            MyReadManifestFile1, MyReadVCFBaseReferenceFile,
                            fileName1, fileName2,
                            out outputLine1, out outputLine2))
                        {
                            conflictCounter++;
                            if (sw == null)
                            {
                                sw = new StreamWriter(MyOutputPath);
                                sw.WriteLine("Columns for manifest file:");
                                currentTextLine = MyReadManifestFile1.GetHeaderColumnLine();
                                currentTextLine += ", Allele var plus, Manifest";
                                sw.WriteLine(currentTextLine);
                                sw.WriteLine("Columns for VCF base reference file:");
                                currentTextLine = MyReadVCFBaseReferenceFile.GetHeaderColumnLine();
                                currentTextLine += ", Allele var plus, VCF base reference file";
                                sw.WriteLine(currentTextLine);
                            }
                            sw.WriteLine(outputLine1);
                            sw.WriteLine(outputLine2);

                        }
                        if (++counter % 1000 == 0)
                        {
                            MyBackGroundWorker.ReportProgress(0, "Extracting VCF base reference file: " + MyFilePath2 + Environment.NewLine +
                                "row: " + ParseInt(counter) + GetComparisonStatusString());
                        }
                    }
                }

                if (sw != null)
                {
                    sw.Close();
                }

                // Write sumary information 
                if (counter > 0)
                {
                    // counter = number of conflicts
                    currentTextLine = fileName1 + "\t " + manifestMarkers1.Count.ToString() + "\t" +
                        fileName2 + "\t" + vcfMarkers.Count.ToString() + "\t" +
                        commonMarkerCount.ToString() + "\t" + conflictCounter.ToString();
                    WriteToSummary(currentTextLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (MyStreamReader != null)
                {
                    MyStreamReader.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
                RemoveCommonDictFolder(commonMarkerDict);
                if (MyCleanDictionaryBank)
                {
                    DisposePersistentDict(ref MyMarkerDictionaryBank);
                    RemovePersistentDictFolders();
                }
            }
        }

        private bool IsConflictInPlus(string manifestRow1, string[] splittedLineFrom2, 
            ReadManifestFile readManifest1, ReadManifestFile readManifest2,
            string manifestName1, string manifestName2,
            out string outputRow1, out string outputRow2)
        {
            string alleleVarPlus1, alleleVarPlus2;
            string[] splittedManifestRow1 = null;
            bool hasConflict;


            outputRow1 = "";
            outputRow2 = "";
            readManifest1.GetSplittedLineWithPlus(manifestRow1, ref splittedManifestRow1, false);
            alleleVarPlus1 = GetAlleleVariationInPlus(splittedManifestRow1);
            alleleVarPlus2 = GetAlleleVariationInPlus(splittedLineFrom2);

            hasConflict = !AlleleVariantManager.IsInsertionAllele(alleleVarPlus1) && alleleVarPlus1 != alleleVarPlus2;

            if (hasConflict)
            {
                outputRow1 = manifestRow1 + ", " + alleleVarPlus1 + ", " + manifestName1;
                outputRow2 = readManifest2.GetCurrentTextLine() + ", " + alleleVarPlus2 + ", " + manifestName2;
            }
            return hasConflict;
        }

        private bool IsConflictInPlus_VCF(string manifestRow1, string[] splittedLineFrom2,
            ReadManifestFile readManifest1, ReadVCFBaseReferenceFile readVCF2,
            string manifestName1, string vcfBaseReferenceName2,
            out string outputRow1, out string outputRow2)
        {
            string alleleVarPlus1, alleleVarPlus2;
            string[] splittedManifestRow1 = null;
            bool hasConflict;


            outputRow1 = "";
            outputRow2 = "";
            readManifest1.GetSplittedLineWithPlus(manifestRow1, ref splittedManifestRow1, false);
            alleleVarPlus1 = GetAlleleVariationInPlus(splittedManifestRow1);
            alleleVarPlus2 = splittedLineFrom2[(int)ReadVCFBaseReferenceFile.RowIndex.RefBase];

            hasConflict = !alleleVarPlus1.Contains(alleleVarPlus2);

            if (hasConflict)
            {
                outputRow1 = manifestRow1 + ", " + alleleVarPlus1 + ", " + manifestName1;
                outputRow2 = readVCF2.GetCurrentTextLine() + ", " + alleleVarPlus2 + ", " + vcfBaseReferenceName2;
            }
            return hasConflict;
        }

        public int GetPersistentDictFolderCounter()
        {
            return MyPersistentFolderCounter;
        }

        private void RemoveCommonDictFolder(PersistentDictionary<string, string> dict)
        {
            string path;
            if (dict != null)
            {
                dict.Dispose();
            }
            path = Directory.GetCurrentDirectory() + @"\" + MyCommonMarkerDictFolder;
            if (Directory.Exists(path))
            {
                RemoveDirectory(path);
            }
        }

        private void FillSelectedMarkersDictionary(ref Dictionary<string, bool> selectedMarkersDict, string filePath)
        {
            int counter;
            string message, marker;
            if (IsNull(selectedMarkersDict) && IsNotEmpty(filePath))
            {
                counter = 0;
                if (!OpenReadFile(ref MyStreamReader, filePath, out message))
                {
                    return;
                }
                selectedMarkersDict = new Dictionary<string, bool>();
                MyBackGroundWorker.ReportProgress(0, "Reading marker list" + GetComparisonStatusString());
                while (!MyStreamReader.EndOfStream)
                {
                    marker = MyStreamReader.ReadLine();
                    marker = marker.Trim().ToLower();
                    selectedMarkersDict.Add(marker, false);
                    if (++counter % 1000 == 0)
                    {
                        MyBackGroundWorker.ReportProgress(0, "Reading marker list row: " + ParseInt(counter) + GetComparisonStatusString());
                    }
                }
            }        
        }

        private void FillMarkerDictionary(ref PersistentDictionary<string, bool> manifestMarkers, ReadManifestFile readManifestFile)
        {
            int counter;
            string filePath;
            string marker = "", version = "";
            short dummyId = 0;
            bool isValidLine, isIntensityOnly;
            filePath = readManifestFile.FilePath;
            manifestMarkers = new PersistentDictionary<string, bool>(MyPersistentDictionaryFolder + (MyPersistentFolderCounter++).ToString());
            MyBackGroundWorker.ReportProgress(0, "Reading manifest file: " + filePath + GetComparisonStatusString());
            counter = 0;
            while (readManifestFile.NextRow(ref marker, ref dummyId, ref version, out isValidLine, out isIntensityOnly))
            {
                if (!isIntensityOnly)
                {
                    manifestMarkers.Add(marker.ToLower(), false);
                    
                } 
                if (++counter % 1000 == 0)
                {
                    MyBackGroundWorker.ReportProgress(0, "Reading manifest file: " + filePath + Environment.NewLine +
                        "row: " + ParseInt(counter) + GetComparisonStatusString());
                }
            }        
        }

        private void FillMarkerDictionary(ref PersistentDictionary<string, bool> manifestMarkers, ReadVCFBaseReferenceFile readVCFBaseReferenceFile)
        {
            int counter;
            string filePath;
            string marker = "";
            bool isValidLine;
            filePath = readVCFBaseReferenceFile.FilePath;
            manifestMarkers = new PersistentDictionary<string, bool>(MyPersistentDictionaryFolder + (MyPersistentFolderCounter++).ToString());
            MyBackGroundWorker.ReportProgress(0, "Reading VCF base reference file: " + filePath + GetComparisonStatusString());
            counter = 0;
            while (readVCFBaseReferenceFile.NextRow(ref marker, out isValidLine))
            {
                manifestMarkers.Add(marker.ToLower(), false);
                if (++counter % 1000 == 0)
                {
                    MyBackGroundWorker.ReportProgress(0, "Reading VCF base reference file: " + filePath + Environment.NewLine +
                        "row: " + ParseInt(counter) + GetComparisonStatusString());
                }
            }
        }

        public void StartInsideThread()
        {
            ExportConflictsLines(null, null);
        }

        public static bool OpenManifestFile(ref ReadManifestFile readManifestFile, string filePath)
        {
            string line;
            string fileName;
            string message;
            StreamReader sr = null;
            try
            {
                if (!OpenReadFile(ref sr, filePath, out message))
                {
                    return false;
                }

                if (readManifestFile != null)
                {
                    readManifestFile.Close();
                }
                readManifestFile = new ReadManifestFile(sr, filePath);
                if (!readManifestFile.HasPlusStrandColumns())
	            {
                    fileName = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                    line = "Manifest has no plus strand columns: " + fileName;
                    //WriteToSummary(line);
                    return false;
	            }
                return true;
            }
            catch (Exception)
            {
                fileName = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                line = "File is not recognized as a manifest file: " + fileName;
                //WriteToSummary(line);
                return false;
            }
        }

        public static bool OpenVcfBaseReferenceFile(ref ReadVCFBaseReferenceFile readVCFBaseReferenceFile, string filePath)
        {
            string line;
            string fileName;
            string message;
            StreamReader sr = null;
            try
            {
                if (!OpenReadFile(ref sr, filePath, out message))
                {
                    return false;
                }

                if (readVCFBaseReferenceFile != null)
                {
                    readVCFBaseReferenceFile.Close();
                }
                readVCFBaseReferenceFile = new ReadVCFBaseReferenceFile(sr, filePath);
                return true;
            }
            catch (Exception)
            {
                fileName = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                line = "File is not recognized as a vcf base reference file: " + fileName;
                return false;
            }
        }

        private string GetComparisonStatusString()
        {
            if (MyInvestigatedComparisons == NO_INDEX || MyFileComaprisonWaiting == NO_INDEX || 
                MyCompletedComparisons == NO_INDEX)
            {
                return "";
            }
            else
            {
                return Environment.NewLine + 
                    "File comparisons investigated: " + MyInvestigatedComparisons + 
                    Environment.NewLine + 
                    "File comparisons left: " + MyFileComaprisonWaiting + 
                    Environment.NewLine + 
                    "Completed comparisons: " + MyCompletedComparisons + 
                    Environment.NewLine + 
                    "Number of no legal manifests found: " + MyNoLegalManifests;
            }
        }

        private void WriteSummaryHeader(string filePath)
        {
            StreamWriter sw = null;
            string header;
            try
            {
                sw = new StreamWriter(filePath, false);
                header = "Manifest 1\tNo markers\tManifest 2\tNo markers\tMarkers compared\tNumber of conflicts";
                sw.WriteLine(header);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        private void WriteToSummary(string textline)
        {
            StreamWriter sw;
            sw = new StreamWriter(MySummaryFile, true);
            sw.WriteLine(textline);
            sw.Close();        
        }

        private bool CheckSnpVariation(short alleleVariantId, string version)
        {
            return !MyOnlyWithSnpVariation ||
                (alleleVariantId > 0 && !IsEmpty(version));
        }

        private DataTable GetAlleleVariantTable()
        {
            if (MyAlleleVariantTable == null)
            {
                MyAlleleVariantTable = AlleleVariantManager.GetAlleleVariantTable();
            }
            return MyAlleleVariantTable;
        }

        private string GetSortedAlleleVariation(string alleleVariation)
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

        private string GetAlleleVariationInPlus(string alleleVariation, ReadManifestFile.PlusMinusReference plusMinusReference)
        {
            string alleleVariationPlus = "";
            if (plusMinusReference == ReadManifestFile.PlusMinusReference.P)
            {
                alleleVariationPlus = alleleVariation;
            }
            else
            {
                foreach (DataRow row in GetAlleleVariantTable().Rows)
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

        private string GetAlleleVariationInPlus_Alternative(string alleleVariation, ReadManifestFile.PlusMinusReference plusMinusReference,
            ReadManifestFile.TopBotReference topBotReference)
        {
            string alleleVariationPlus = "";
            bool getComplement;
            alleleVariation = GetSortedAlleleVariation(alleleVariation);
            if ((topBotReference == ReadManifestFile.TopBotReference.T && plusMinusReference == ReadManifestFile.PlusMinusReference.M) ||
                (topBotReference == ReadManifestFile.TopBotReference.B && plusMinusReference == ReadManifestFile.PlusMinusReference.P))
            {
                getComplement = true;
            }
            else
            {
                getComplement = false;
            }

            if (getComplement)
            {
                alleleVariationPlus = GetComplement(alleleVariation);
            }
            else
            {
                alleleVariationPlus = alleleVariation;
            }
            return alleleVariationPlus;
        }

        private string GetComplement(string alleleVariation)
        {
            string complement = "";
            foreach (DataRow row in GetAlleleVariantTable().Rows)
            {
                if (alleleVariation == row[(int)AlleleVariantTable.Variant].ToString())
                {
                    complement = row[(int)AlleleVariantTable.Complement].ToString();
                    break;
                }
            }
            return complement;
        }

        public string GetAlleleVariationInPlus(string[] manifestRow)
        {
            if (MyUseAlternatePlusStrandExtraction)
            {
                return GetAlleleVariationInPlus_Alternative(manifestRow);
            }
            else
            {
                return GetAlleleVariationInPlus_Original(manifestRow);
            }
        }

        public string GetAlleleVariationInPlus_Original(string[] manifestRow)
        {
            string alleleVariation, alleleVarPlus, plusMinStr;
            ReadManifestFile.PlusMinusReference plusMinusRef;

            plusMinStr = manifestRow[(int)ReadManifestFile.RowIndex.Plus_minus];
            plusMinusRef = (ReadManifestFile.PlusMinusReference)Enum.Parse(typeof(ReadManifestFile.PlusMinusReference), plusMinStr);
            alleleVariation = manifestRow[(int)ReadManifestFile.RowIndex.SNP_Variation];
            alleleVarPlus = GetAlleleVariationInPlus(alleleVariation, plusMinusRef);
            return alleleVarPlus;
        }


        public string GetAlleleVariationInPlus_Alternative(string[] manifestRow)
        {
            string alleleVariation, alleleVarPlus, plusMinStr, topBotStr;
            ReadManifestFile.PlusMinusReference plusMinusRef;
            ReadManifestFile.TopBotReference topBotRef;

            plusMinStr = manifestRow[(int)ReadManifestFile.RowIndex.Plus_minus];
            plusMinusRef = (ReadManifestFile.PlusMinusReference)Enum.Parse(typeof(ReadManifestFile.PlusMinusReference), plusMinStr);
            topBotStr = manifestRow[(int)ReadManifestFile.RowIndex.Top_Bot];
            topBotRef = (ReadManifestFile.TopBotReference)Enum.Parse(typeof(ReadManifestFile.TopBotReference), topBotStr);
            alleleVariation = manifestRow[(int)ReadManifestFile.RowIndex.SNP_Variation];
            alleleVarPlus = GetAlleleVariationInPlus_Alternative(alleleVariation, plusMinusRef, topBotRef);
            return alleleVarPlus;
        }

        private class ManifestRowComparison
        {
            private string MyRowFromManifest1;
            private string MyRowFromManifest2;
            private bool MyHasConflict;
            private bool MyIsComparisonCompleted;
            private string MyAlleleVariationPlusFrom1;
            private string MyAlleleVariationPlusFrom2;


            public ManifestRowComparison(string rowFromManifest1, string alleleVariatinPlusFrom1)
            {
                MyAlleleVariationPlusFrom1 = alleleVariatinPlusFrom1;
                MyRowFromManifest1 = rowFromManifest1;
                MyRowFromManifest2 = "";
                MyAlleleVariationPlusFrom2 = "";
                MyHasConflict = false;
                MyIsComparisonCompleted = false;
            }

            public void SetManifest2Row(string rowFromManifest2, string alleleVariationPlusFrom2)
            {
                MyRowFromManifest2 = rowFromManifest2;
                MyAlleleVariationPlusFrom2 = alleleVariationPlusFrom2;
                if (MyAlleleVariationPlusFrom1 != MyAlleleVariationPlusFrom2)
                {
                    MyHasConflict = true;
                }
                MyIsComparisonCompleted = true;
            }

            #region Questions
            public bool IsComparisonCompleted()
            {
                return MyIsComparisonCompleted;
            }

            public bool HasConflict()
            {
                return MyHasConflict;
            }
            
            #endregion


            #region Get functions
            public string GetRowFrom1()
            {
                return MyRowFromManifest1;
            }

            public string GetRowFrom2()
            {
                return MyRowFromManifest2;
            }


            public string GetAlleleVariationPlus1()
            {
                return MyAlleleVariationPlusFrom1;
            }

            public string GetAlleleVariationPlus2()
            {
                return MyAlleleVariationPlusFrom2;
            }
            
            #endregion
        }
    }
}
