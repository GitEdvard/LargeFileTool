using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using LargeFileTool.Data;

namespace LargeFileTool.IO
{
    public class ExportConflictingForwardFromManifest
    {
        private StreamWriter MyStreamWriter;
        private BackgroundWorker MyBackGroundWorker;
        private ReadManifestFile MyReadManifestFile;
        private StreamReader MyStreamReader;

        public ExportConflictingForwardFromManifest(string manifestFilePath,
            string exportFilePath, BackgroundWorker bwd)
        {
            MyStreamWriter = new StreamWriter(exportFilePath);
            MyBackGroundWorker = bwd;
            MyStreamReader = new StreamReader(manifestFilePath);
            MyReadManifestFile = new ReadManifestFile(MyStreamReader, manifestFilePath);
            MyBackGroundWorker.DoWork += new DoWorkEventHandler(Export);
        }

        private void Export(object sender, DoWorkEventArgs e)
        {
            string markerName = "";
            string chromosome = "";
            string fivePrime_flank = "";
            string threePrime_flank = "";
            string markerReference = "";
            string snpVariation = "";
            string forward_reverse = "";
            string version = "";
            string top_bot = "";
            string sourceStrand = "";
            string ilmnStrand = "";
            string textLine;
            int counter = 0;

            try
            {
                MyStreamWriter.WriteLine(MyReadManifestFile.GetHeaderColumnLine());
                while (MyReadManifestFile.NextRow(ref markerName, ref chromosome, ref fivePrime_flank,
                    ref threePrime_flank, ref markerReference, ref snpVariation, ref forward_reverse,
                    ref version, ref top_bot, ref sourceStrand, ref ilmnStrand, out textLine))
                {
                    if ((sourceStrand.Trim() == ilmnStrand.Trim() && forward_reverse == ForwardReverseReference.R.ToString()) ||
                        (sourceStrand.Trim() != ilmnStrand.Trim() && forward_reverse == ForwardReverseReference.F.ToString()))
                    {
                        MyStreamWriter.WriteLine(textLine);
                    }
                    if (counter % 100 == 0)
                    {
                        MyBackGroundWorker.ReportProgress(0, "Parsing line (" + counter.ToString() + ")");
                        if (MyBackGroundWorker.CancellationPending)
                        {
                            return;
                        }
                    }
                    counter++;
                }
            }
            finally
            {
                if (MyStreamWriter != null)
                {
                    MyStreamWriter.Close();
                }
                if (MyStreamReader != null)
                {
                    MyStreamReader.Close();
                }
            }
        }
    }
}
