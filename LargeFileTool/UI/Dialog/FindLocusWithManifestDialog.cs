using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LargeFileTool.Data;
using LargeFileTool.UI.Controller;

namespace LargeFileTool.UI.Dialog
{
    public partial class FindLocusWithManifestDialog : Form
    {
        private const string DEFAULT_ROOT_DIRECTORY = @"L:\Lab-SNP\Pågående projekt\2014";
        public FindLocusWithManifestDialog()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            RootDirectoryTextBox.Text = DEFAULT_ROOT_DIRECTORY;
            FindLocusButton.Enabled = false;
            InitListView();
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ManifestNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ManifestNameTextBox.Text.Length > 0)
            {
                FindLocusButton.Enabled = true;
            }
            else
            {
                FindLocusButton.Enabled = false;
            }
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog;
            try
            {
                folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.SelectedPath = DEFAULT_ROOT_DIRECTORY;
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RootDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FindLocusButton_Click(object sender, EventArgs e)
        {
            LocusFileSearcher locusFileSearcher;
            BackgroundWorkerDialog bgd;
            List<LocusFileInfo> matchingFiles;

            try
            {
                bgd = new BackgroundWorkerDialog();
                locusFileSearcher = new LocusFileSearcher(ManifestNameTextBox.Text, RootDirectoryTextBox.Text,
                    bgd.Worker);
                bgd.Start();
                matchingFiles = locusFileSearcher.GetMatchingFiles();
                LoadListView(matchingFiles);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitListView()
        {
            LocusListView.Columns.Add("File name", -2);
            LocusListView.Columns.Add("Manifest", -2);
            LocusListView.Columns.Add("Size (kB)", -2);
            LocusListView.Columns.Add("Full path", -2);
            new CopyListViewMenu(LocusListView);
            
        }

        private void LoadListView(List<LocusFileInfo> matchingFiles)
        {
            LocusListView.Items.Clear();
            if (matchingFiles == null)
            {
                return;
            }
            LocusListView.BeginUpdate();

            foreach (LocusFileInfo locusFileInfo in matchingFiles)
            {
                LocusListView.Items.Add(new LocusViewItem(locusFileInfo));
            }

            LocusListView.EndUpdate();
        }

        private class LocusViewItem : ListViewItem
        {
            private LocusFileInfo MyLocusFileInfo;

            public LocusViewItem(LocusFileInfo locusFileInfo)
                : base(locusFileInfo.FileInfo.Name)
            {
                MyLocusFileInfo = locusFileInfo;
                this.SubItems.Add(MyLocusFileInfo.ManifestFile);
                this.SubItems.Add((MyLocusFileInfo.FileInfo.Length / 1000).ToString());
                this.SubItems.Add(MyLocusFileInfo.FileInfo.DirectoryName);
            }
        }
    }
}
