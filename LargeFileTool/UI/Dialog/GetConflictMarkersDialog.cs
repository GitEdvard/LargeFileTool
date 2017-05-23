using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LargeFileTool.IO;
using Molmed.LargeFileTool.Data;
using LargeFileTool.Data;

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class GetConflictMarkersDialog : LargeFileToolForm
    {
        public GetConflictMarkersDialog()
        {
            InitializeComponent();
            FastTrack();
        }

        private void FastTrack()
        {
            string file1, file2, confRepFile, sumFile;
            file1 = @"C:\Småjobb\2014\Juni\Undersökning strandreferens\header.csv";
            file2 = @"C:\Småjobb\2014\Juni\Undersökning strandreferens\header2.csv";
            confRepFile = @"C:\Småjobb\2014\Juni\Undersökning strandreferens\conf.txt";
            sumFile = @"C:\Småjobb\2014\Juni\Undersökning strandreferens\summary.txt";

            file1 = @"C:\Bulkkatalog\Manifest\HumanOmni5Exome-4v1_A.csv";
            file2 = @"C:\Bulkkatalog\Manifest\HumanOmni5Exome-4v1-1_A.csv";
            confRepFile = @"C:\Småjobb\2014\Oktober\Skanning av genotypdatafil\Skanning141006\ConflictReport_HumanOmni5Exome-4v1_AHumanOmni5Exome-4v1-1_A.txt";
            sumFile = @"C:\Småjobb\2014\Oktober\Skanning av genotypdatafil\Skanning141006\Summary.txt";


            Manifest1TextBox.Text = file1;
            Manifest2TextBox.Text = file2;
            ConflictReportFileTextBox.Text = confRepFile;
            SummaryFileTextBox.Text = sumFile;
        }

        private void ExportConflictsButton_Click(object sender, EventArgs e)
        {
            BackgroundWorkerDialog bwd;
            GetConflictMarkersInPlus getConflictMarkersInPlus;

            bwd = new BackgroundWorkerDialog();
            try
            {
                getConflictMarkersInPlus = new GetConflictMarkersInPlus(Manifest1TextBox.Text.Trim(),
                    Manifest2TextBox.Text.Trim(), SummaryFileTextBox.Text.Trim(), MarkerListFileTextBox.Text.Trim(),
                    ConflictReportFileTextBox.Text.Trim(), true, true, true, 
                    LargeFileToolData.NO_INDEX, LargeFileToolData.NO_INDEX,
                    true,
                    bwd.Worker);
                bwd.Start();
                if (bwd.ThrownException != null)
                {
                    throw bwd.ThrownException;
                }
                MessageBox.Show("Comparison completed ");
            }
            catch (Exception ex)
            {
                HandleError("Error when comparing manefests", ex);
            }
        }

        private void SelectManifestButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Manifest1TextBox.Text = openFileDialog.FileName;
            }
        }

        private void SelectManifest2Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Manifest2TextBox.Text = openFileDialog.FileName;
            }
        }

        private void MarkerListButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                MarkerListFileTextBox.Text = openFileDialog.FileName;
            }

        }

        private void ConflictReportFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog;
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Textfiles (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog(this) != DialogResult.Cancel)
            {
                ConflictReportFileTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void SummaryFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog;
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Textfiles (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog(this) != DialogResult.Cancel)
            {
                SummaryFileTextBox.Text = saveFileDialog.FileName;
            }
        }

    }
}

