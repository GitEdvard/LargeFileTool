using System;
using System.Windows.Forms;
using LargeFileTool.IO;

namespace LargeFileTool.UI.Dialog
{
    public partial class GetConflictsFromVCFExcportDialog : Form
    {
        public GetConflictsFromVCFExcportDialog()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string outputFolder, vcfFile;
            outputFolder = @"C:\Småjobb\2014\Augusti\VCF\Comparison_OriginalPlusRef";
            vcfFile = @"M:\Open\Per\VCF\vcf_export_test7_full_1M_quad.txt";
            OutputFolderTextBox.Text = outputFolder;
            VCFExportFileTextBox.Text = vcfFile;
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetVCFFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                VCFExportFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void OutputFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog;
            folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
            {
                OutputFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void CalculateConflictsButton_Click(object sender, EventArgs e)
        {
            GetConflictsInVCFExportFile getConflictsInVCFExportFile;
            BackgroundWorkerDialog bwd;
            try
            {
                bwd = new BackgroundWorkerDialog();
                getConflictsInVCFExportFile = new GetConflictsInVCFExportFile(VCFExportFileTextBox.Text.Trim(),
                    OutputFolderTextBox.Text.Trim(), bwd.Worker);
                bwd.Start();
                MessageBox.Show("Scanning completed");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
