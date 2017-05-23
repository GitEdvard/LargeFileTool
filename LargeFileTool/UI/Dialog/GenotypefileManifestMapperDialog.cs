using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using LargeFileTool.Data;
using LargeFileTool.Data.Exceptions;

namespace LargeFileTool.UI.Dialog
{
    public partial class GenotypefileManifestMapperDialog : LargeFileToolForm
    {
        public GenotypefileManifestMapperDialog()
        {
            InitializeComponent();
            Init();
        }

        #region Init functions

        private void Init()
        {
            string genotypeFile, manifestFile, outputPath;
            genotypeFile = @"C:\Småjobb\2014\Oktober\Skanning av genotypdatafil\Kort_Genotypfil1.txt";
            genotypeFile = @" P:\Projekt\Genotypning\Pågående projekt\MI-0355(MattiasJakobsson)\Resultatrapport\MI-0355_131217_ResultReport\MI-0355_131217_ResultReport_PCF_PLUS\MI-0355_131217_SNPGenotypeExport_PCF_PLUS.txt";
            genotypeFile = @" P:\Projekt\Genotypning\Pågående projekt\MI-0355(MattiasJakobsson)\Resultatrapport\MI-0355_141002_ResultReport\MI-0355_141002_ResultReport_ICF_PLUS\MI-0355_141002_SNPGenotypeExport_ICF_PLUS.txt";
            manifestFile = @"C:\Småjobb\2014\Oktober\Skanning av genotypdatafil\HumanOmni5Exome-4v1_A_extracted.csv";
            //manifestFile = @"L:\Labsystem\Illumina SNP genotyping\INFINIUM\HumanOmni5Exome-4_v1.0\HumanOmni5Exome-4v1_A.csv";
            manifestFile = @"L:\Labsystem\Illumina SNP genotyping\INFINIUM\HumanOmni5Exome-4_v1.1\HumanOmni5Exome-4v1-1_A.csv";
            //manifestFile = @"L:\Labsystem\Illumina SNP genotyping\INFINIUM\HumanOmni5\humanomni5-4v1_c.csv";
            //outputFile = @"C:\Småjobb\2014\Oktober\Skanning av genotypdatafil\OutputMarkers.txt";
            outputPath = @"C:\Småjobb\2014\Oktober\Skanning av genotypdatafil\ConflictMarkers.txt";
            GenotypeFileTextBox.Text = genotypeFile;
            ManifestFileTextBox.Text = manifestFile;
            ConflictMarkerFileTextBox.Text = outputPath;
        }

        #endregion

        #region Events
		        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetGenotypeFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GenotypeFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void GetManifestFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ManifestFileTextBox.Text = openFileDialog.FileName;
            }
        }

	    #endregion    

        private void FindButton_Click(object sender, EventArgs e)
        {
            BackgroundWorkerDialog bgd;
            double requiredRatio;
            string dummy;
            try
            {
                requiredRatio = 0.95;
                GenotypefileManifestMapper genotypefileManifestMapper;
                bgd = new BackgroundWorkerDialog();
                genotypefileManifestMapper = new GenotypefileManifestMapper(GenotypeFileTextBox.Text.Trim(),
                    ManifestFileTextBox.Text.Trim(), requiredRatio, 
                    ConflictMarkerFileTextBox.Text.Trim(), bgd.Worker);
                bgd.Start();
                if (bgd.ThrownException != null)
                {
                    throw bgd.ThrownException;
                }
                if (genotypefileManifestMapper.HasMissingMarkers())
                {
                    HandleMissingMarkers(genotypefileManifestMapper.GetMissingMarkers());
                }
                ResultTextBox.Text = GetResultString(genotypefileManifestMapper.GetNumberComparbleMarkers(), 
                    genotypefileManifestMapper.GetNumberConsistentMarkers(),
                    genotypefileManifestMapper.GetNumberScannedRows(),
                    genotypefileManifestMapper.GetValidationRatio());
            }
            catch (OpenGenotypeFileException ex)
            {
                dummy = ex.Message;
                MessageBox.Show("Selected file is not a genotype file! Exiting");
            }
            catch (Exception ex)
            {
                HandleError("Error when mapping genotype file to manifest", ex);
            }
        }

        private void HandleMissingMarkers(StringCollection missingMarkers)
        {
            ListDialog listDialog;
            listDialog = new ListDialog("Marker", missingMarkers, "Missing markers", ListDialog.DialogMode.ShowList,
                "These markers from the genotype file were not found in the manifest");
            listDialog.ShowDialog();
        }

        private string GetResultString(int numberComparableMarkers, int numberConsistentMarkers,
            int numberScannedRows, double validationRatio)
        {
            return "Number comparable markers: " + ParseInt(numberComparableMarkers) + Environment.NewLine + 
                "Number consistent markers: " + ParseInt(numberConsistentMarkers) + Environment.NewLine + 
                "Number scanned rows: " + numberScannedRows.ToString() + Environment.NewLine + 
                "Validation ratio:" + validationRatio.ToString();
        }

        private void ExportMarkersButton_Click(object sender, EventArgs e)
        {
            string manifestFileName;
            ExportMarkersFromComparisonReportDialog exportMarkersFromComparisonReportDialog;
            manifestFileName = ManifestFileTextBox.Text.Trim();
            manifestFileName = manifestFileName.Substring(manifestFileName.LastIndexOf(@"\") + 1);
            exportMarkersFromComparisonReportDialog = new ExportMarkersFromComparisonReportDialog();
            exportMarkersFromComparisonReportDialog.PresetTextboxes(manifestFileName);
            exportMarkersFromComparisonReportDialog.ShowDialog();
        }

        private void ConflictMarkerFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog;
            saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ConflictMarkerFileTextBox.Text = saveFileDialog.FileName;
            }
        }
    }
}
