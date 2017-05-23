using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Molmed.LargeFileTool.Data;
using LargeFileTool.Data;
using LargeFileTool.IO;

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class GetConflictsInPlusVCF_ManifestDialog : Form
    {
        public GetConflictsInPlusVCF_ManifestDialog()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string manifestFile, vcfFIle, outputFolder;
            //manifestFile = @"C:\Småjobb\2014\Augusti\VCF\TestComparison\HumanOmni1-Quad_v1-0_C_extracted.csv";
            //vcfFIle = @"C:\Småjobb\2014\Augusti\VCF\TestComparison\VCF_BaseReference_Extract_1MQuad_extracted.txt";
            //outputFolder = @"C:\Småjobb\2014\Augusti\VCF\TestComparison";
            
            vcfFIle = @"M:\Open\Per\VCF\refbases_out_HumanOmni1-Quad_v1-0_C.txt";
            manifestFile = @"C:\Bulkkatalog\PB5\HumanOmni1-Quad_v1-0_C.csv";
            outputFolder = @"C:\Småjobb\2014\Augusti\VCF\Comparison_OriginalPlusRef";
            ManifestFileTextBox.Text = manifestFile;
            VCFFileTextBox.Text = vcfFIle;
            OutputFolderTextBox.Text = outputFolder;
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectManifestButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                ManifestFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void SelectVCFFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                VCFFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void SelectMarkersButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                SelectedMarkersTextBox.Text = openFileDialog.FileName;
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

        private void ExportConflictsButton_Click(object sender, EventArgs e)
        {
            BackgroundWorkerDialog bwd;
            GetConflictMarkersInPlus getConflictMarkersInPlus;

            bwd = new BackgroundWorkerDialog();
            try
            {
                getConflictMarkersInPlus = new GetConflictMarkersInPlus(ManifestFileTextBox.Text.Trim(),
                    VCFFileTextBox.Text.Trim(), SelectedMarkersTextBox.Text.Trim(), OutputFolderTextBox.Text.Trim(),
                    bwd.Worker);
                bwd.Start();
                MessageBox.Show("Comparison completed ");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
