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

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class ExtractRowsFromFilesDialog : Form
    {
        public ExtractRowsFromFilesDialog()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        { 
            string keypath, file1Path, delimiter, searchColInd, outputFOlder;
            keypath = @"C:\Småjobb\2014\Augusti\VCF\TestComparison\MarkerList.txt";
            file1Path = @"C:\Bulkkatalog\PB5\HumanOmni1-Quad_v1-0_C.csv";
            searchColInd = "1";
            delimiter = ",";
            outputFOlder = @"C:\Småjobb\2014\Augusti\VCF\TestComparison";
            KeyListFileTextBox.Text = keypath;
            File1PathTextBox.Text = file1Path;
            File1SearchColumnIndexTextBox.Text = searchColInd;
            File1DelimiterTextBox.Text = delimiter;
            OutputFolderTextBox.Text = outputFOlder;
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KeyFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                KeyListFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void File1Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                File1PathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void File2Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                File2PathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            BackgroundWorkerDialog bwd;
            RowExtractorGeneral rowExtractorGeneral;
            try
            {
                bwd = new BackgroundWorkerDialog();
                rowExtractorGeneral = new RowExtractorGeneral(KeyListFileTextBox.Text.Trim(),
                    File1PathTextBox.Text.Trim(), GetDelimiter(File1DelimiterTextBox.Text.Trim()),
                    GetSearchColumnIndex(File1SearchColumnIndexTextBox.Text.Trim()),
                    File2PathTextBox.Text.Trim(), GetDelimiter(File2DelimiterTextBox.Text.Trim()),
                    GetSearchColumnIndex(File2SearchColumnIndexTextBox.Text.Trim()),
                    OutputFolderTextBox.Text.Trim(), bwd.Worker);
                bwd.Start();
                MessageBox.Show("Export finished");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GetSearchColumnIndex(string fromUser)
        {
            int searchColumn;
            if (!int.TryParse(fromUser, out searchColumn))
            {
                return -1;
            }
            return searchColumn;
        }

        private string GetDelimiter(string fromUser)
        {
            if (fromUser == "\\t")
            {
                return '\t'.ToString();
            }
            else
            {
                return fromUser;
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

    }
}
