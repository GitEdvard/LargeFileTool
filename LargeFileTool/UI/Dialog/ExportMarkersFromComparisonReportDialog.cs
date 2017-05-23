using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LargeFileTool.IO;
using LargeFileTool.Data;

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class ExportMarkersFromComparisonReportDialog : LargeFileToolForm
    {
        public ExportMarkersFromComparisonReportDialog()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string manifest1, manifest2, comparisonFolder, outputFile;
            manifest1 = @"HumanOmni5Exome-4v1_A";
            manifest2 = @"HumanOmni5Exome-4v1-1_A";
            comparisonFolder = @"C:\Bulkkatalog\Output files 7";
            outputFile = @"C:\Småjobb\2014\Oktober\Skanning av genotypdatafil\MarkerExport.txt";
            Manifest1NameTextBox.Text = manifest1;
            ManifestFile2TextBox.Text = manifest2;
            ComparisonFileFolderTextBox.Text = comparisonFolder;
            OutputFileTextBox.Text = outputFile;
        }

        public void PresetTextboxes(string manifestFile1)
        {
            Manifest1NameTextBox.Text = manifestFile1;
        }

        private void MyCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Manifest1NameButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Manifest1NameTextBox.Text = openFileDialog.FileName;
            }
        }

        private void Manifest2NameButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ManifestFile2TextBox.Text = openFileDialog.FileName;
            }

        }

        private void OutputFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog;
            saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OutputFileTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void ComparisonFileFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog;
            folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
            {
                ComparisonFileFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            BackgroundWorkerDialog bwd;
            bwd = new BackgroundWorkerDialog();
            ExportMarkersFromComparisonReport exportMarkersFromComparisonReport;
            try
            {
                exportMarkersFromComparisonReport = new ExportMarkersFromComparisonReport(
                    OutputFileTextBox.Text.Trim(), ComparisonFileFolderTextBox.Text.Trim(),
                    Manifest1NameTextBox.Text.Trim(), ManifestFile2TextBox.Text.Trim(),
                    bwd.Worker);
                bwd.Start();

                if (bwd.ThrownException != null)
                {
                    throw bwd.ThrownException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
