using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LargeFileTool.Data;
using System.IO;

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class GenotypCompareDialog : Form
    {
        public GenotypCompareDialog()
        {
            InitializeComponent();
        }

        private void GetGFile1Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                GFile1TextBox.Text = openFileDialog.FileName;
            }
        }

        private void GetGFile2Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                GFile2TextBox.Text = openFileDialog.FileName;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetMessageString(GenotypeFileComparer genotypeFileComparer)
        {
            string str;
            str = genotypeFileComparer.GetMessage() + Environment.NewLine;
            str += "Row: " + genotypeFileComparer.GetDiffRow().ToString() + Environment.NewLine;
            str += "Row name: " + genotypeFileComparer.GetDiffRowName() + Environment.NewLine;
            str += "Column: " + genotypeFileComparer.GetDiffColumn() + Environment.NewLine;
            str += "Column name: " + genotypeFileComparer.GetDiffColumnName() + Environment.NewLine;
            str += "Number of differances: " + genotypeFileComparer.GetNumberDiffs() + Environment.NewLine;
            str += "Differing row index (1-based): " + genotypeFileComparer.GetDiffRows() + Environment.NewLine;
            str += "Differing column index (1-based): " + genotypeFileComparer.GetDiffColumns();
            return str;
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            GenotypeFileComparer genotypeFileComparer;
            BackgroundWorkerDialog bwd;
            StreamReader sr1 = null, sr2 = null;

            try
            {
                ResultTextBox.Text = "";
                sr1 = new StreamReader(GFile1TextBox.Text.Trim());
                sr2 = new StreamReader(GFile2TextBox.Text.Trim());
                bwd = new BackgroundWorkerDialog();
                genotypeFileComparer = new GenotypeFileComparer(sr1, sr2, bwd.Worker, SkipHeaderCheckBox.Checked);
                bwd.Start();
                ResultTextBox.Text = GetMessageString(genotypeFileComparer);
                MessageBox.Show("Comparison finished!");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sr1 != null)
                {
                    sr1.Close();
                }
                if (sr2 != null)
                {
                    sr2.Close();
                }
            }

        }
    }
}
