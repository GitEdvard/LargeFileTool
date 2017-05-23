using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using LargeFileTool.Data;

namespace LargeFileTool.IO
{
    /// <summary>
    /// Refering to comparison reports on plus strand conflicts in manifests
    /// 
    /// </summary>
    public class ExportMarkersFromComparisonReport : LargeFileToolData
    {
        private BackgroundWorker MyBackgroundWorker;
        private string MyOutputFilePath;
        private string MyManifestName1;
        private string MyManifestName2;
        ReadComparisonReportFile MyComparisonReportReader;
        private const string DI = "D/I";
        private const string ID = "I/D";


        public ExportMarkersFromComparisonReport(string outputFilePath,
            string comparisonReportFileDirectory, string manifestName1, string manifestName2,
            BackgroundWorker bgw)
        {
            MyOutputFilePath = outputFilePath;
            MyBackgroundWorker = bgw;
            MyManifestName1 = manifestName1;
            MyManifestName2 = manifestName2;
            MyComparisonReportReader = new ReadComparisonReportFile(comparisonReportFileDirectory,
                manifestName1, manifestName2);
            MyBackgroundWorker.DoWork += ExportComparisonReport;
        }

        private void ExportComparisonReport(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            string markerName = "", alleleVarPlus1 = "", alleleVarPlus2 = "";
            string textLine;
            int counter = 0;
            try
            {
                MyBackgroundWorker.ReportProgress(0, "Exporting markers to file");
                sw = new StreamWriter(MyOutputFilePath);
                WriteHeader(sw);
                while (MyComparisonReportReader.NextComparisonRow(ref markerName, ref alleleVarPlus1, ref alleleVarPlus2))
                {
                    textLine = markerName + '\t'.ToString() + alleleVarPlus1 + '\t'.ToString() + alleleVarPlus2;

                    if (!AlleleVariantManager.IsInsertionAllele(alleleVarPlus1))
                    {
                        sw.WriteLine(textLine);
                        if (++counter % 100 == 0)
                        {
                            MyBackgroundWorker.ReportProgress(0, "Exporting markers to file: " + ParseInt(counter));
                        }
                        
                    }
                }
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        private void WriteHeader(StreamWriter sw)
        {
            string textLine;
            textLine = "Manifest 1  = " + MyManifestName1;
            sw.WriteLine(textLine);
            textLine = "Manifest 2 = " + MyManifestName2;
            sw.WriteLine(textLine);
            textLine = "Marker" + '\t'.ToString() + "Allele var plus, manifest 1" + '\t'.ToString() + "Allele var plus, manifest 2";
            sw.WriteLine(textLine);
        }

    }
}
