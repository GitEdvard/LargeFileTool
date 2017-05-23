using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LargeFileTool.UI.Dialog
{
    public partial class ExportConlictingForwardFromManifest : Form
    {
        public ExportConlictingForwardFromManifest()
        {
            InitializeComponent();
        }

        private void SelectManifestButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                ManifestNameTextBox.Text = openFileDialog.FileName;
            }
        }

        private void ExportFileNameButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog;
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                ExportNameTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {

        }


    }
}
