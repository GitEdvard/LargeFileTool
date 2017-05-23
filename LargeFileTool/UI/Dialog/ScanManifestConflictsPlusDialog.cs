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
    public partial class ScanManifestConflictsPlusDialog : LargeFileToolForm
    {
        public ScanManifestConflictsPlusDialog()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ManifestDirectoryTextBox.Text = @"C:\Manifests";
            OutputDirectoryTextBox.Text = @"C:\OutputFolder";
            MarkerListFileTextBox.Text = @"";
        }

        private void ExportConflictsButton_Click(object sender, EventArgs e)
        {
            BackgroundWorkerDialog bwd;
            ScanConflictMarkersPlusInFolder scanConflictMarkersPlusInFolder;

            bwd = new BackgroundWorkerDialog();
            try
            {
                scanConflictMarkersPlusInFolder = new ScanConflictMarkersPlusInFolder(ManifestDirectoryTextBox.Text.Trim(),
                    OutputDirectoryTextBox.Text.Trim(), MarkerListFileTextBox.Text.Trim(), bwd.Worker);

                bwd.Start();
                if (bwd.ThrownException != null)
                {
                    throw bwd.ThrownException;
                }
                MessageBox.Show("Comparison completed ");
            }
            catch (Exception ex)
            {
                HandleError(ex.Message, ex);
            }
        }

        private void SelectManifestDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog;
            folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
            {
                ManifestDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void SelectOutputDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog;
            folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
            {
                OutputDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
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
    }
}

