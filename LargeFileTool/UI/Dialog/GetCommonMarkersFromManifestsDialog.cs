using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Molmed.LargeFileTool.Data;
using LargeFileTool.IO;

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class GetCommonMarkersFromManifestsDialog : Form
    {
        public GetCommonMarkersFromManifestsDialog()
        {
            InitializeComponent();
        }

        private void ParseFileButton_Click(object sender, EventArgs e)
        {
            BackgroundWorkerDialog bwd;
            GetCommonMarkersFromManifest getCommonMarkersFromManifest;

            bwd = new BackgroundWorkerDialog();
            try
            {
                getCommonMarkersFromManifest = new GetCommonMarkersFromManifest(
                    Manifest1TextBox.Text.Trim(), Manifest2TextBox.Text.Trim(), ExcludeIntensityOnlyCheckBox.Checked,
                    InlcudeOnlySNPVariationCheckBox.Checked, bwd.Worker);
                bwd.Start();
                MessageBox.Show("Number of markers: " + getCommonMarkersFromManifest.GetMarkerCount().ToString());
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
                Manifest1TextBox.Text = openFileDialog.FileName;
            }
        }

        private void SelectManifest2Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Manifest2TextBox.Text = openFileDialog.FileName;
            }
        }

    }
}
