using System;
using System.IO;
using System.Windows.Forms;
using LargeFileTool.Data;

namespace LargeFileTool.UI.Dialog
{
    public partial class AdjustLocusDialog : Form
    {
        public AdjustLocusDialog()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                LocusFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void OutputFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                ExtractToFileTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            StreamWriter sw = null;
            BackgroundWorkerDialog bwd = new BackgroundWorkerDialog();

            try
            {
                sr = new StreamReader(LocusFileTextBox.Text.Trim());
                sw = new StreamWriter(ExtractToFileTextBox.Text.Trim());
                AdjustLocus adjustLocus = new AdjustLocus(IncludeCallScoreCheckBox.Checked,
                    sr, sw, bwd.Worker);
                bwd.Start();
                MessageBox.Show("Task is finished");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
}
