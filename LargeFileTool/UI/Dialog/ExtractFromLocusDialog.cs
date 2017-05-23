using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LargeFileTool.Data;

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class ExtractFromLocusDialog : Form
    {
        public ExtractFromLocusDialog()
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

        private void ParseSelectedMarkers(out StringCollection selectedMarkers)
        {
            string[] splittedLine;
            string[] delimiter = new string[] { "," };

            selectedMarkers = new StringCollection();
            splittedLine = SelectMarkersTextbox.Text.Trim().Split(delimiter, StringSplitOptions.None);
            foreach (string marker in splittedLine)
            {
                if (marker.Trim() != "")
                {
                    selectedMarkers.Add(marker);
                }
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            ExtractFromLocus extractFromLocus;
            StringCollection selectedMarkers;
            BackgroundWorkerDialog bwd;
            StreamReader sr = null;
            StreamWriter sw = null;
            StreamWriter markerSW = null;
            int markerCount, markerOffset;

            try
            {
                ParseSelectedMarkers(out selectedMarkers);
                sr = new StreamReader(LocusFileTextBox.Text.Trim());
                sw = new StreamWriter(ExtractToFileTextBox.Text.Trim());
                if (MarkerFileTextBox.Text.Trim() != "")
                {
                    markerSW = new StreamWriter(MarkerFileTextBox.Text.Trim());
                }
                bwd = new BackgroundWorkerDialog();
                if (!int.TryParse(MarkersToIncludeTextBox.Text.Trim(), out markerCount))
                {
                    markerCount = -1;
                }
                if (!int.TryParse(StartAtMarkerTextBox.Text.Trim(), out markerOffset))
                {
                    markerOffset = -1;
                }
                extractFromLocus = new ExtractFromLocus(SampleFilterTextBox.Text.Trim(),
                    selectedMarkers, markerCount, markerOffset, sr, LocusFileTextBox.Text.Trim(),
                    sw, markerSW, bwd.Worker);
                bwd.Start();
                MessageBox.Show("Extrac is finished, rows with ''Number DNAs'' and ''Number Loci'' must be " +
                    "updated in order to import it to Chiasma!");
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
                if (markerSW != null)
                {
                    markerSW.Close();
                }
            }

        }

        private void MarkerNamesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void MarkerNumberSelectionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void MarkerFileSelectionButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog;
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt) | *.txt";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                MarkerFileTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void SampleFilterButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                SampleFilterTextBox.Text = openFileDialog.FileName;
            }

        }
    }
}
