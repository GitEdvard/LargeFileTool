using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Molmed.LargeFileTool.UI.Dialog;
using Molmed.LargeFileTool.Data;
using LargeFileTool.Data;

namespace Molmed.LargeFileTool.UI
{
    public partial class MainForm : Form
    {
        private String MyKeyString;
        private List<ReadCriteria> MyCriterias;
        private RowReader MyRowReader;
        public MainForm()
        {
            InitializeComponent();
            Init();
            //mergeFilesToolStripMenuItem.Visible = false;
            FastTrack();
        }

        private void FastTrack()
        {
            //findManifestOriginToolStripMenuItem_Click(null, null);            
            //exportMarkersFromCompReportplusToolStripMenuItem_Click_1(null, null);
            //compareTwoFilesToolStripMenuItem_Click(null, null);
            
        }

        private void AddCriteriaButton_Click(object sender, EventArgs e)
        {
            int firstOccurence, secondOccurence;
            String criteriaText;
            firstOccurence = (int)KeyStringNumeric1.Value;
            secondOccurence = (int)KeyStringNumeric2.Value;
            if (CheckKeyStringCriteria(firstOccurence, secondOccurence))
            { 
                MyCriterias.Add(new ReadCriteria(firstOccurence, secondOccurence));
                criteriaText = GetCriteriaString(firstOccurence, secondOccurence);
                MultipleReadCriteriaListBox.Items.Add(criteriaText);
            }
            else
            {
                ShowWarning("The entered criteria is (probably) nested with an existing criteria, addition aborted!");
            }
        }

        private void AddLastCriteria()
        {
            int firstOccurence, secondOccurence;
            firstOccurence = (int)KeyStringNumeric1.Value;
            secondOccurence = (int)KeyStringNumeric2.Value;
            if (CheckKeyStringCriteria(firstOccurence, secondOccurence))
            {
                MyCriterias.Add(new ReadCriteria(firstOccurence, secondOccurence));
                MultipleReadCriteriaListBox.Items.Add(GetCriteriaString(firstOccurence, secondOccurence));
            }
        }

        private bool CheckForm()
        {
            if (ReadBetweenColumnsRadioButton.Checked)
            {
                if (MyKeyString == "")
                {
                    ShowWarning("No key string is entered!");
                    return false;
                }
                AddLastCriteria();
                if (MyCriterias.Count == 0)
                {
                    ShowWarning("There is no valid criterias for reading the file!");
                    return false;
                }
            }
            return true;
        }

        private bool CheckKeyStringCriteria(int firstOccurence, int secondOccurence)
        {
            if (firstOccurence >= secondOccurence)
            {
                return false;
            }
            foreach (ReadCriteria criteria in MyCriterias)
            {
                if (criteria.IsNested(firstOccurence, secondOccurence))
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearCriteriaButton_Click(object sender, EventArgs e)
        {
            MyCriterias.Clear();
            MultipleReadCriteriaListBox.Items.Clear();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private String GetCriteriaString(int firstOccurence, int secondOccurence)
        {
            String firstNumber, secondNumber;
            switch (firstOccurence)
            {
                case 0:
                    firstNumber = "beginning of row ";
                    break;
                case 1:
                    firstNumber = "1st ";
                    break;
                case 2:
                    firstNumber = "2nd ";
                    break;
                default:
                    firstNumber = firstOccurence + "th ";
                    break;
            }
            switch (secondOccurence)
            {
                case 1:
                    secondNumber = "1st occurence ";
                    break;
                case 2:
                    secondNumber = "2nd occurence ";
                    break;
                default:
                    secondNumber = secondOccurence + "th occurence ";
                    break;
            }
            return "the " + firstNumber + "to the " + secondNumber + "of the string '" + MyKeyString + "'";
        }
        private void Init()
        {
            MyKeyString = "";
            KeyStringTextBox.Text = ",";
            MyCriterias = new List<ReadCriteria>();
            SetControlStatus();
            SetReadingStatus();
            MyRowReader = null;
        }

        private void InputFileBrowseButton_Click(object sender, EventArgs e)
        {
            if (MyOpenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (MyOpenFileDialog.FileName != "")
                {
                    InputFileTextBox.Text = MyOpenFileDialog.FileName;
                }
            }
        }

        private void KeyStringTextBox_TextChanged(object sender, EventArgs e)
        {
            MyKeyString = KeyStringTextBox.Text;
            KeyStringLabel.Text = "'" + MyKeyString + "'";
            KeyStringLabel2.Text = "'" + MyKeyString + "'";
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            BackgroundWorkerDialog bwd;
            FileSampler fs;
            FileLastRowsSampler flrs;
            TextReplacer tr = null;
            RowStartExtractor rse;
            RowFindExtractor rfe;
            FileInfoExtractor fie;
            string targetFilePath;
            string infoStr;

            if (!CheckForm())
            {
                return; 
            }
            if (!SetRowReader())
            {
                ShowWarning("Please select input file!");
                return;
            }

            bwd = new BackgroundWorkerDialog();
            infoStr = "Task is finished!";

            if (FileInfoRadiobutton.Checked)
            {
                fie = new FileInfoExtractor(bwd.Worker, MyRowReader);
                bwd.Start();
                return;
            }

            MySaveFileDialog.ShowDialog(this);
            if (MySaveFileDialog.FileName == "")
            {
                return;
            }
            targetFilePath = MySaveFileDialog.FileName;

            if (SampleRadioButton.Checked)
            {
                fs = new FileSampler(bwd.Worker, MyRowReader, targetFilePath, (int)SampleIntervalNumeric.Value, (int)SampleFirstNumeric.Value, -1);
            }
            else if (SampleLastRadioButton.Checked)
            { 
                flrs = new FileLastRowsSampler(bwd.Worker, MyRowReader, targetFilePath, (int)LastRowsNumericUpDown.Value);
            }
            else if (FindReplaceRadioButton.Checked)
            {
                //tr = new TextReplacer(bwd.Worker, MyRowReader, targetFilePath, FindTextBox.Text, ReplaceTextBox.Text);
                tr = new TextReplacer(bwd.Worker, InputFileTextBox.Text, targetFilePath, FindTextBox.Text, ReplaceTextBox.Text);
            }
            else if (ExtractRadioButton.Checked)
            {
                rfe = new RowFindExtractor(bwd.Worker, MyRowReader, targetFilePath, ExtractTextBox.Text, NegCriteriaCheckBox.Checked);
            }
            else if (ReadRowStartsRadioButton.Checked)
            {
                rse = new RowStartExtractor(bwd.Worker, MyRowReader, targetFilePath, (int)RowStartCharactersNumeric.Value);
            }


            bwd.Start();
            if (FindReplaceRadioButton.Checked && tr != null)
            {
                infoStr = tr.Occurences.ToString() + " matches replaced!";                
            }
            MessageBox.Show(infoStr, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OptionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStatus();
        }

        private void ReadingCriteriasRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetReadingStatus();
        }

        private void SetControlStatus()
        {
            SampleIntervalNumeric.Enabled = false;
            SampleFirstNumeric.Enabled = false;
            FindTextBox.Enabled = false;
            ReplaceTextBox.Enabled = false;
            RowStartCharactersNumeric.Enabled = false;
            ExtractTextBox.Enabled = false;
            NegCriteriaCheckBox.Enabled = false;

            if (SampleRadioButton.Checked)
            {
                SampleIntervalNumeric.Enabled = true;
                SampleFirstNumeric.Enabled = true;
            }
            else if (FindReplaceRadioButton.Checked)
            {
                FindTextBox.Enabled = true;
                ReplaceTextBox.Enabled = true;
            }
            else if (ExtractRadioButton.Checked)
            {
                ExtractTextBox.Enabled = true;
                NegCriteriaCheckBox.Enabled = true;
            }
            else if (ReadRowStartsRadioButton.Checked)
            {
                RowStartCharactersNumeric.Enabled = true;
            }
        }

        private void SetReadingStatus()
        {
            KeyStringTextBox.Enabled = false;
            KeyStringNumeric1.Enabled = false;
            KeyStringNumeric2.Enabled = false;
            AddCriteriaButton.Enabled = false;
            ClearCriteriaButton.Enabled = false;
            MultipleReadCriteriaListBox.BackColor = System.Drawing.SystemColors.Control;            

            if (ReadBetweenColumnsRadioButton.Checked)
            {
                KeyStringTextBox.Enabled = true;
                KeyStringNumeric1.Enabled = true;
                KeyStringNumeric2.Enabled = true;
                AddCriteriaButton.Enabled = true;
                ClearCriteriaButton.Enabled = true;
                MultipleReadCriteriaListBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private bool SetRowReader()
        {
            if (InputFileTextBox.Text == "")
            {
                return false;
            }
            if (MyRowReader != null)
            {
                MyRowReader.Close();
            }
            MyRowReader = new RowReader(InputFileTextBox.Text, MyKeyString, MyCriterias, ReadEntireRowsRadioButton.Checked);
            return true;
        }

        protected void ShowWarning(String message)
        {
            MessageBox.Show(message,
                           "Warning",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
        }

        private void copyPasteColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mergeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void copyPasteColumnsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CopyPasteColumns copyPasteColumns;
            copyPasteColumns = new CopyPasteColumns();
            copyPasteColumns.ShowDialog();
        }

        private void specialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecialForm specialForm;
            specialForm = new SpecialForm();
            specialForm.ShowDialog();
        }

        private void columnWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MergeFiles_Columns mergeFiles_Columns;
            mergeFiles_Columns = new MergeFiles_Columns();
            mergeFiles_Columns.ShowDialog();

        }

        private void afterEachOtherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MergeFilesAfterEachOtherDialog mergeFilesDialog;
            mergeFilesDialog = new MergeFilesAfterEachOtherDialog();
            mergeFilesDialog.ShowDialog();
        }

        private void getUniqueItemsFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetUniqueItemsDialog getUniqueItemsDialog;
            getUniqueItemsDialog = new GetUniqueItemsDialog();
            getUniqueItemsDialog.ShowDialog();
        }

        private void getConflictInForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportConlictingForwardFromManifestDialog exportConlictDialog;
            exportConlictDialog = new ExportConlictingForwardFromManifestDialog();
            exportConlictDialog.ShowDialog();
        }

        private void getNumberOfMarkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetNumberMarkersDialog getNumberMarkersDialog;
            getNumberMarkersDialog = new GetNumberMarkersDialog();
            getNumberMarkersDialog.ShowDialog();
        }

        private void getCommonMarkersFromManifestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCommonMarkersFromManifestsDialog getCommonMarkersFromManifestsDialog;
            getCommonMarkersFromManifestsDialog = new GetCommonMarkersFromManifestsDialog();
            getCommonMarkersFromManifestsDialog.ShowDialog();
        }

        private void mooreToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compareGenotypeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenotypCompareDialog genotypCompareDialog = new GenotypCompareDialog();
            genotypCompareDialog.ShowDialog();
        }

        private void ëxtractFromLocusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractFromLocusDialog extractFromLocusDialog;
            extractFromLocusDialog = new ExtractFromLocusDialog();
            extractFromLocusDialog.ShowDialog();
        }

        private void handleLocusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adjustLocusToReadableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdjustLocusDialog adjustLocusDialg = new AdjustLocusDialog();
            adjustLocusDialg.ShowDialog();
        }

        private void addSamplePrefixToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compareTwoFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetConflictMarkersDialog getConflictMarkersDialog;
            getConflictMarkersDialog = new GetConflictMarkersDialog();
            getConflictMarkersDialog.ShowDialog();

        }

        private void scanDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanManifestConflictsPlusDialog scanManifestConflictsPlusDialog;
            scanManifestConflictsPlusDialog = new ScanManifestConflictsPlusDialog();
            scanManifestConflictsPlusDialog.ShowDialog();
        }

        private void findLocusForSpecificManfiestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindLocusWithManifestDialog findLocusWithManifestDialog;
            findLocusWithManifestDialog = new FindLocusWithManifestDialog();
            findLocusWithManifestDialog.ShowDialog();
        }

        private void compareVCFVsManifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetConflictsInPlusVCF_ManifestDialog getConflictsInPlusVCF_ManifestDialog;
            getConflictsInPlusVCF_ManifestDialog = new GetConflictsInPlusVCF_ManifestDialog();
            getConflictsInPlusVCF_ManifestDialog.ShowDialog();
        }

        private void extractFromFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractRowsFromFilesDialog extractRowsFromFilesDialog;
            extractRowsFromFilesDialog = new ExtractRowsFromFilesDialog();
            extractRowsFromFilesDialog.ShowDialog();
        }

        private void scanVCFExportFileForConflictsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetConflictsFromVCFExcportDialog getConflictsFromVCFExcportDialog;
            getConflictsFromVCFExcportDialog = new GetConflictsFromVCFExcportDialog();
            getConflictsFromVCFExcportDialog.ShowDialog();
        }

        private void findManifestOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenotypefileManifestMapperDialog genotypefileManifestMapperDialog;
            genotypefileManifestMapperDialog = new GenotypefileManifestMapperDialog();
            genotypefileManifestMapperDialog.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestForm testForm;
            testForm = new TestForm();
            testForm.ShowDialog();
        }

        private void exportMarkersFromCompReportplusToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ExportMarkersFromComparisonReportDialog exportMarkersFromComparisonReportDialog;
            exportMarkersFromComparisonReportDialog = new ExportMarkersFromComparisonReportDialog();
            exportMarkersFromComparisonReportDialog.ShowDialog();
        }

    }
}