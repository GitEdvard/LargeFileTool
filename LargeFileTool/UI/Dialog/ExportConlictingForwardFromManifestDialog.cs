﻿using System;
using System.Windows.Forms;
using LargeFileTool.IO;

namespace LargeFileTool.UI.Dialog
{
    public partial class ExportConlictingForwardFromManifestDialog : Form
    {
        public ExportConlictingForwardFromManifestDialog()
        {
            InitializeComponent();
        }

        private void SelectManifestButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                ManifestNameTextBox.Text = openFileDialog.FileName;
            }
        }

        private void ExportFileNameButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                ExportNameTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            ExportConflictingForwardFromManifest exportConflicts;   
            BackgroundWorkerDialog bwd = new BackgroundWorkerDialog();
            try
            {
                exportConflicts = new ExportConflictingForwardFromManifest(
                    ManifestNameTextBox.Text.Trim(), ExportNameTextBox.Text.Trim(), bwd.Worker);
                bwd.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
