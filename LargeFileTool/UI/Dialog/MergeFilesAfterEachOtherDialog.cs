using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LargeFileTool.Data;

namespace LargeFileTool.UI.Dialog
{
    public partial class MergeFilesAfterEachOtherDialog : Form
    {
        public MergeFilesAfterEachOtherDialog()
        {
            InitializeComponent();
            InitListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitListView()
        {
            FilesListView.Columns.Add("File", -2);
        }
        private class FileViewItem : ListViewItem
        {
            private string MyFileName;
            public FileViewItem(string name)
                : base(name)
            {
                MyFileName = name;
            }

            public string GetName()
            {
                return MyFileName;
            }
        }

        private void AddFileButton_Click(object sender, EventArgs e)
        {
            string filePath;
            FileViewItem fileViewItem;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            filePath = openFileDialog1.FileName;
            fileViewItem = new FileViewItem(filePath);
            FilesListView.BeginUpdate();
            FilesListView.Items.Add(fileViewItem);
            FilesListView.EndUpdate();
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            string outputFile;
            FileMerger_Consecutive fileMerger;
            List<string> inputFiles = new List<string>();
            BackgroundWorkerDialog bwd = new BackgroundWorkerDialog();

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                outputFile = saveFileDialog1.FileName;
                foreach (FileViewItem viewItem in FilesListView.Items)
                {
                    inputFiles.Add(viewItem.GetName());
                }

                fileMerger = new FileMerger_Consecutive(bwd.Worker, outputFile, inputFiles);
                bwd.Start();
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

    }
}
