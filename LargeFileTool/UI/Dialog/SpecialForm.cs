using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Molmed.LargeFileTool.Data;

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class SpecialForm : Form
    {
        private string MyWorkingFolder;
        public SpecialForm()
        {
            InitializeComponent();
            MyWorkingFolder = "";
        }

        private void SplitInternalReportButton_Click(object sender, EventArgs e)
        {
            string internalRerpotFIlename;
            BackgroundWorkerDialog bwd;
            InternalReportSplitter internalReportSplitter;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.Trim().Length == 0)
            {
                return;
            }
            try
            {
                MyWorkingFolder = openFileDialog1.InitialDirectory;
                internalRerpotFIlename = openFileDialog1.FileName;
                bwd = new BackgroundWorkerDialog();
                internalReportSplitter = new InternalReportSplitter(internalRerpotFIlename, bwd.Worker);
                bwd.Start();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void MergeInternalReportButton_Click(object sender, EventArgs e)
        {
            string selectedPath;
            InternalReportMerger internalReportMerger;
            BackgroundWorkerDialog bwd;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath.Trim().Length == 0)
            {
                return;
            }
            selectedPath = folderBrowserDialog1.SelectedPath;
            //selectedPath = "C:/Småjobb/Augusti2010/Klistra_internrapport/Working";
            try
            {
                bwd = new BackgroundWorkerDialog();
                internalReportMerger = new InternalReportMerger(selectedPath, bwd.Worker);
                bwd.Start();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
