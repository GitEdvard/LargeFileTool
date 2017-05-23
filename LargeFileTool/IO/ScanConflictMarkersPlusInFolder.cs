using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Collections;
using LargeFileTool.Data;
using Microsoft.Isam.Esent.Collections.Generic;

namespace LargeFileTool.IO
{
    public class ScanConflictMarkersPlusInFolder : LargeFileToolData
    {
        private string MyRootCatalog;
        private string MyOutputFolder;
        private string MyMarkerListFilePath;
        private BackgroundWorker MyBackgroundWorker;
        private const string SUMMARY_FILE = "Summary.txt";
        private const string LOG_FILE = "Log.txt";

        public ScanConflictMarkersPlusInFolder(string rootCatalog, 
            string outputFolder, string markerListFilePath, 
            BackgroundWorker bgw)
        {
            MyRootCatalog = rootCatalog;
            MyOutputFolder = outputFolder;
            MyMarkerListFilePath = markerListFilePath;
            MyBackgroundWorker = bgw;
            MyBackgroundWorker.DoWork += ScanManifests;
        }

        private void ScanManifests(object o, EventArgs e)
        {
            int totComparisons, investigatedComparisons = 0, comparisonsLeft = 0, completedComparisons = 0, noLegalManifestCounter = 0;
            GetConflictMarkersInPlus getConflictMarkersInPlus;
            ReadManifestFile manifestReader1 = null, manifestReader2 = null;
            Dictionary<string, bool> selectedMarkerDict;
            string[] manifestFiles = null;
            string manifest1, manifest2;
            string confictReportFileName;
            string summaryFilePath;
            string str;
            StreamWriter sw = null;
            //Dictionary<string, PersistentDictionary<string, bool>> dictionaryBank = null;
            MarkerDictionaryList dictionaryBank = null;
            ArrayList sortedManifests = null;
            int persistentDictFolderCounter;
            bool continueFlag = false;


            try
            {
                RemovePersistentDictFolders();
                totComparisons = GetNumberOfComparisons();
                comparisonsLeft = totComparisons;
                manifestFiles = Directory.GetFiles(MyRootCatalog, "*.csv");
                summaryFilePath = MyOutputFolder + @"\" + SUMMARY_FILE;
                sw = new StreamWriter(MyOutputFolder + @"\" + LOG_FILE);
                WriteSummaryHeader(summaryFilePath);

                if (IsNull(manifestFiles))
                {
                    throw new System.Exception("No files where found");
                }
                
                selectedMarkerDict = GetSelectedMarkerDictionary(MyMarkerListFilePath, MyBackgroundWorker);
                //dictionaryBank = new Dictionary<string, PersistentDictionary<string, bool>>();
                dictionaryBank = new MarkerDictionaryList();

                // Files are sorted according to the reversed file size
                // This is important for restricting the memory allocation!
                CopyToList(ref sortedManifests, manifestFiles);

                persistentDictFolderCounter = 1;
                for (int i = 0; i < sortedManifests.Count - 1; i++)
                {
                    continueFlag = false;
                    manifest1 = (string)sortedManifests[i];
                    if (!GetConflictMarkersInPlus.OpenManifestFile(ref manifestReader1, manifest1))
                    {
                        noLegalManifestCounter++;
                        continueFlag = true;
                    }
                    for (int j = i + 1; j < sortedManifests.Count; j++)
                    {
                        investigatedComparisons++;
                        comparisonsLeft--;
                        manifest2 = (string)sortedManifests[j];                       
                        if (continueFlag || !GetConflictMarkersInPlus.OpenManifestFile(ref manifestReader2, manifest2))
                        {
                            continue;
                        }
                        sw.WriteLine("Start comparing: " + manifest1 + ", " + manifest2 + ", " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        completedComparisons++;
                        confictReportFileName = GetConflictMarkersInPlus.GetConflictReportFileName(MyOutputFolder, manifest1, manifest2);
                        getConflictMarkersInPlus = new GetConflictMarkersInPlus(manifestReader1,
                            manifestReader2, summaryFilePath, selectedMarkerDict, confictReportFileName,
                            true, true, true, investigatedComparisons, comparisonsLeft,
                            completedComparisons, noLegalManifestCounter, ref dictionaryBank,
                            persistentDictFolderCounter,
                            false, MyBackgroundWorker);
                        getConflictMarkersInPlus.StartInsideThread();
                        persistentDictFolderCounter = getConflictMarkersInPlus.GetPersistentDictFolderCounter();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sw != null)
                {
                    str = "End calculations, investigated comparisons: " + investigatedComparisons.ToString() +
                        ", comparisons left: " + comparisonsLeft.ToString() + ", completed comparisons: " + completedComparisons.ToString() +
                        ", " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    sw.WriteLine(str);
                    sw.Close();
                }
                DisposePersistentDict(ref dictionaryBank);
                RemovePersistentDictFolders();
            }
        }

        private void DisposePersistentDict(ref MarkerDictionaryList dictBank)
        {
            foreach (DictionaryWithName dict in dictBank)
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

        private void CopyToList(ref ArrayList stringList, string[] stringArr)
        {
            stringList = new ArrayList();
            foreach (string str in stringArr)
            {
                stringList.Add(str);
            }
            // Files are sorted according to the reversed file size
            // This is important for restricting the memory allocation!
            stringList.Sort(new ManifestSorter());
        }

        private Dictionary<string, bool> GetSelectedMarkerDictionary(string filePath, BackgroundWorker bgw)
        {
            int counter;
            StreamReader sr = null;
            string message, marker;
            Dictionary<string, bool> dict = null;
            try
            {
                counter = 0;
                if (!OpenReadFile(ref sr, MyMarkerListFilePath, out message))
                {
                    return dict;
                }
                dict = new Dictionary<string, bool>();
                //bgw.ReportProgress(0, "Reading marker list");
                while (!sr.EndOfStream)
                {
                    marker = sr.ReadLine();
                    marker = marker.Trim().ToLower();
                    dict.Add(marker, false);
                    if (++counter % 1000 == 0)
                    {
                        //bgw.ReportProgress(0, "Reading marker list row: " + counter.ToString());
                    }
                }
                return dict;
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
            }
        }

        private string GetConflictReportFileName(string manifestPath1, string manifestPath2)
        {
            string name1, name2;
            string conflictFileName = "";

            name1 = manifestPath1.Substring(manifestPath1.LastIndexOf(@"\") + 1);
            name2 = manifestPath2.Substring(manifestPath2.LastIndexOf(@"\") + 1);

            conflictFileName = "ConflictReport_" + name1 + "__" + name2 + ".txt";

            return MyOutputFolder + @"\" + conflictFileName;
        }

        private int GetNumberOfComparisons()
        {
            string[] files = null;
            files = Directory.GetFiles(MyRootCatalog, "*.csv");
            if (IsNotNull(files))
            {
                return (int)(files.Length * files.Length - files.Length) / 2;
            }
            else
            {
                return 0;
            }
        }

        public class DictionaryWithName
        {
            private PersistentDictionary<string, bool> MyDictionary;
            private string MyName;

            public DictionaryWithName(string name, PersistentDictionary<string, bool> dict)
            {
                MyDictionary = dict;
                MyName = name;
            }

            public string GetName()
            {
                return MyName;
            }

            public PersistentDictionary<string, bool> GetDictionary()
            {
                return MyDictionary;
            }
        }

        public class MarkerDictionaryList : ArrayList
        {
            public bool HasDictionary(string name)
            {
                foreach (object item in this)
                {
                    if (((DictionaryWithName)item).GetName() == name)
                    {
                        return true;
                    }
                }
                return false;
            }

            public PersistentDictionary<string, bool> GetDictionary(string name)
            { 
                foreach (object item in this)
	            {
                    if (((DictionaryWithName)item).GetName() == name)
                    {
                        return ((DictionaryWithName)item).GetDictionary();
                    }
	            }
                return null;
            }
        }

        private class ManifestSorter : IComparer
        {
            public ManifestSorter()
            { 
            
            }

            public int Compare(object x, object y)
            {
                string a, b;
                FileInfo fiA, fiB;
                a = (string)x;
                b = (string)y;

                fiA = new FileInfo(a);
                fiB = new FileInfo(b);

                if (fiA.Length > fiB.Length)
                {
                    return -1;
                }
                else if (fiA.Length < fiB.Length)
                {
                    return 1;
                }
                else
                {
                    return 1;
                }
            }
        }

    }
}
