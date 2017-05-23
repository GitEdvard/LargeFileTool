using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using LargeFileTool.Data;

namespace LargeFileTool.IO
{
    public class GetCommonMarkersFromManifest : LargeFileToolData
    {
        #region Declarations
        private BackgroundWorker MyBackGroundWorker;
        private ReadManifestFile MyReadManifestFile;
        private StreamReader MyStreamReader;
        private bool MyExcludeIntensityOnly;
        private int MyMarkerCount;
        private string MyFilePath2;
        private string MyFilePath1;
        private bool MyOnlyWithSnpVariation;
        
        #endregion

        public GetCommonMarkersFromManifest(string filePath1,  string filePath2,
            bool excludeIntensityOnly, bool onlyWithSnpVariation, BackgroundWorker bwd)
        {
            MyBackGroundWorker = bwd;
            MyStreamReader = new StreamReader(filePath1);
            MyExcludeIntensityOnly = excludeIntensityOnly;
            MyFilePath2 = filePath2;
            MyFilePath1 = filePath1;
            MyOnlyWithSnpVariation = onlyWithSnpVariation;
            MyReadManifestFile = new ReadManifestFile(MyStreamReader, filePath1);
            MyBackGroundWorker.DoWork += new DoWorkEventHandler(CountMarkers);
        }

        private void CountMarkers(object sender, DoWorkEventArgs e)
        {
            string markerName = "";
            bool intensityOnly = false;
            int counter = 0;
            int markerCounter = 0;
            short alleleVariantId = NO_ID_TINY;
            string version = "";
            bool validLine;
            StreamReader sr;
            Dictionary<string, bool> markerDicitionary = new Dictionary<string,bool>();

            try
            {
                while (MyReadManifestFile.NextRow(ref markerName, ref intensityOnly, ref alleleVariantId,
                    ref version, out validLine))
                {
                    if (counter % 100 == 0)
                    {
                        MyBackGroundWorker.ReportProgress(0, "Parsing line, file 1 (" + counter.ToString() + ")");
                        if (MyBackGroundWorker.CancellationPending)
                        {
                            return;
                        }
                    }
                    if (validLine && !intensityOnly && CheckSnpVariation(alleleVariantId, version))
                    {
                        markerDicitionary.Add(markerName, false);
                    }
                    counter++;
                }

                counter = 0;
                MyReadManifestFile.Close();
                sr = new StreamReader(MyFilePath2);
                MyReadManifestFile = new ReadManifestFile(sr, MyFilePath2);
                while (MyReadManifestFile.NextRow(ref markerName, ref intensityOnly, ref alleleVariantId,
                    ref version, out validLine))
                {
                    if (counter % 100 == 0)
                    {
                        MyBackGroundWorker.ReportProgress(0, "Parsing line, file 2 (" + counter.ToString() + ")");
                        if (MyBackGroundWorker.CancellationPending)
                        {
                            return;
                        }
                    }
                    if (validLine && 
                        ((MyExcludeIntensityOnly && !intensityOnly) ||
                        !MyExcludeIntensityOnly) &&
                        CheckSnpVariation(alleleVariantId, version) &&
                        markerDicitionary.ContainsKey(markerName))
                    {
                        markerCounter++;
                    }
                    counter++;
                }

                
                MyMarkerCount = markerCounter;
            }
            finally
            {
                if (MyStreamReader != null)
                {
                    MyStreamReader.Close();
                }
            }                    
        }

        private bool CheckSnpVariation(short alleleVariantId, string version)
        {
            return !MyOnlyWithSnpVariation ||
                (alleleVariantId > 0 && !IsEmpty(version));
        }

        public int GetMarkerCount()
        {
            return MyMarkerCount;
        }
    }
}
