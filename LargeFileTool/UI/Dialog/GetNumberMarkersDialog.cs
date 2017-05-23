using System;
using System.Windows.Forms;
using LargeFileTool.IO;

namespace LargeFileTool.UI.Dialog
{
    public partial class GetNumberMarkersDialog : Form
    {
        public GetNumberMarkersDialog()
        {
            InitializeComponent();
        }

        private void ParseFileButton_Click(object sender, EventArgs e)
        {
            BackgroundWorkerDialog bwd;
            GetNumberOfMarkersFromManifest getNumberOfMarkersFromManifest;
            
            bwd = new BackgroundWorkerDialog();
            try
            {
                getNumberOfMarkersFromManifest = new GetNumberOfMarkersFromManifest(
                    ManifestTextBox.Text.Trim(), ExcludeIntensityOnlyCheckBox.Checked, 
                    OnlyAlleleCheckBox.Checked, bwd.Worker);
                bwd.Start();
                MessageBox.Show("Number of markers: " + getNumberOfMarkersFromManifest.GetMarkerCount().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void SelectManifestButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                ManifestTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
