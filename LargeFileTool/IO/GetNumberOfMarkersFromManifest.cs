using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using LargeFileTool.Data;

namespace LargeFileTool.IO
{
    public class GetNumberOfMarkersFromManifest : LargeFileToolData
    {
        private BackgroundWorker MyBackGroundWorker;
        private ReadManifestFile MyReadManifestFile;
        private StreamReader MyStreamReader;
        private bool MyExcludeIntensityOnly;
        private int MyMarkerCount;
        private bool MyOnlyWithSnpVariation;

        public GetNumberOfMarkersFromManifest(string filePath, 
            bool excludeIntensityOnly, bool onlyWithSnpVariation, BackgroundWorker bwd)
        {
            MyBackGroundWorker = bwd;
            MyStreamReader = new StreamReader(filePath);
            MyExcludeIntensityOnly = excludeIntensityOnly;
            MyOnlyWithSnpVariation = onlyWithSnpVariation;
            MyReadManifestFile = new ReadManifestFile(MyStreamReader, filePath);
            MyBackGroundWorker.DoWork += new DoWorkEventHandler(CountMarkers);
        }

        private void CountMarkers(object sender, DoWorkEventArgs e)
        {
            string markerName = "";
            bool intensityOnly = false;
            int counter = 0;
            int markerCounter = 0;
            string version = "";
            short alleleVariantId = NO_ID_TINY;
            bool validLine;

            try
            {
                if (MyExcludeIntensityOnly)
                {
                    while (MyReadManifestFile.NextRow(ref markerName, ref intensityOnly, ref alleleVariantId,
                        ref version, out validLine))
                    {
                        if (counter % 100 == 0)
                        {
                            MyBackGroundWorker.ReportProgress(0, "Parsing line (" + ParseInt(counter) + ")");
                            if (MyBackGroundWorker.CancellationPending)
                            {
                                return;
                            }
                        }
                        if (validLine && !intensityOnly && CheckSnpVariation(alleleVariantId, version))
                        {
                            markerCounter++;
                        }
                        counter++;
                    }
                }
                if (!MyExcludeIntensityOnly)
                {
                    while (MyReadManifestFile.NextRow(ref markerName, ref alleleVariantId, ref version, out validLine, out intensityOnly))
                    {
                        if (counter % 100 == 0)
                        {
                            MyBackGroundWorker.ReportProgress(0, "Parsing line (" + ParseInt(counter) + ")");
                            if (MyBackGroundWorker.CancellationPending)
                            {
                                return;
                            }
                        }
                        if(validLine && CheckSnpVariation(alleleVariantId, version))
                        {
                            markerCounter++;
                        }
                        counter++;
                    }                    
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
