using System;
using System.Windows.Forms;
using LargeFileTool.Data;

namespace LargeFileTool.UI.Dialog
{
    public partial class GetUniqueItemsDialog : Form
    {
        public GetUniqueItemsDialog()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            InFileListView.Columns.Add("Input file", -2);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InputFilesButton_Click(object sender, EventArgs e)
        {
            string[] inFiles;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            inFiles = openFileDialog1.FileNames;
            if (inFiles.Length == 0)
            {
                return;
            }
            foreach (string str in inFiles)
            {
                InFileListView.Items.Add(new ListViewItem(str));
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            DateTime startTime, endTime;
            TimeSpan span;
            UniqueItemExtractor uniqueItemExtractor;
            BackgroundWorkerDialog bwd;
            string outFile, inFile;
            int i = 0;
            string[] inFiles = new string[InFileListView.Items.Count];
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            outFile = saveFileDialog1.FileName;
            if (outFile == "")
            {
                return;
            }
            try
            {
                startTime = DateTime.Now;

                bwd = new BackgroundWorkerDialog();
                foreach (ListViewItem viewItem in InFileListView.Items)
                {
                    inFile = viewItem.SubItems[0].Text;
                    inFiles[i++] = inFile;
                }
                uniqueItemExtractor = new UniqueItemExtractor(inFiles, outFile, bwd.Worker);
                bwd.Start();
                endTime = DateTime.Now;

                span = endTime.Subtract(startTime);
                MessageBox.Show("Finished, duration " + span.Seconds.ToString() + " s");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            InFileListView.Items.Clear();
        }
    }
}
