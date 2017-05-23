using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LargeFileTool.Data;
using LargeFileTool.UI.Dialog;
using FlexibleStreamHandling;

namespace LargeFileTool.UI
{
    public partial class MainForm : Form
    {
        private String _keyString;
        private List<ReadCriteria> _criterias;
        private RowReader _rowReader;
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
            var firstOccurence = (int)KeyStringNumeric1.Value;
            var secondOccurence = (int)KeyStringNumeric2.Value;
            if (CheckKeyStringCriteria(firstOccurence, secondOccurence))
            { 
                _criterias.Add(new ReadCriteria(firstOccurence, secondOccurence));
                var criteriaText = GetCriteriaString(firstOccurence, secondOccurence);
                MultipleReadCriteriaListBox.Items.Add(criteriaText);
            }
            else
            {
                ShowWarning("The entered criteria is (probably) nested with an existing criteria, addition aborted!");
            }
        }

        private void AddLastCriteria()
        {
            var firstOccurence = (int)KeyStringNumeric1.Value;
            var secondOccurence = (int)KeyStringNumeric2.Value;
            if (CheckKeyStringCriteria(firstOccurence, secondOccurence))
            {
                _criterias.Add(new ReadCriteria(firstOccurence, secondOccurence));
                MultipleReadCriteriaListBox.Items.Add(GetCriteriaString(firstOccurence, secondOccurence));
            }
        }

        private bool CheckForm()
        {
            if (ReadBetweenColumnsRadioButton.Checked)
            {
                if (_keyString == "")
                {
                    ShowWarning("No key string is entered!");
                    return false;
                }
                AddLastCriteria();
                if (_criterias.Count == 0)
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
            foreach (ReadCriteria criteria in _criterias)
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
            _criterias.Clear();
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
            return "the " + firstNumber + "to the " + secondNumber + "of the string '" + _keyString + "'";
        }
        private void Init()
        {
            _keyString = "";
            KeyStringTextBox.Text = ",";
            _criterias = new List<ReadCriteria>();
            SetControlStatus();
            SetReadingStatus();
            _rowReader = null;
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
            _keyString = KeyStringTextBox.Text;
            KeyStringLabel.Text = "'" + _keyString + "'";
            KeyStringLabel2.Text = "'" + _keyString + "'";
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            FileSampler fs;
            FileLastRowsSampler flrs;
            TextReplacer tr = null;
            RowStartExtractor rse;
            RowFindExtractor rfe;
            FileInfoExtractor fie;

            if (!CheckForm())
            {
                return; 
            }
            if (!SetRowReader())
            {
                ShowWarning("Please select input file!");
                return;
            }

            var bwd = new BackgroundWorkerDialog();
            var infoStr = "Task is finished!";

            if (FileInfoRadiobutton.Checked)
            {
                fie = new FileInfoExtractor(bwd.Worker, _rowReader);
                bwd.Start();
                return;
            }

            MySaveFileDialog.ShowDialog(this);
            if (MySaveFileDialog.FileName == "")
            {
                return;
            }
            var targetFilePath = MySaveFileDialog.FileName;
            using (var targetStream = new FileIOStream(targetFilePath, FileMode.Create, FileAccess.Write))
            {
                if (SampleRadioButton.Checked)
                {
                    fs = new FileSampler(bwd.Worker, _rowReader, targetFilePath, (int) SampleIntervalNumeric.Value,
                        (int) SampleFirstNumeric.Value, -1);
                }
                else if (SampleLastRadioButton.Checked)
                {
                    flrs = new FileLastRowsSampler(bwd.Worker, _rowReader, targetFilePath,
                        (int) LastRowsNumericUpDown.Value);
                }
                else if (FindReplaceRadioButton.Checked)
                {
                    //tr = new TextReplacer(bwd.Worker, _rowReader, targetFilePath, FindTextBox.Text, ReplaceTextBox.Text);
                    tr = new TextReplacer(bwd.Worker, InputFileTextBox.Text, targetFilePath, FindTextBox.Text,
                        ReplaceTextBox.Text);
                }
                else if (ExtractRadioButton.Checked)
                {
                    rfe = new RowFindExtractor(bwd.Worker, _rowReader, targetStream, ExtractTextBox.Text,
                        NegCriteriaCheckBox.Checked);
                }
                else if (ReadRowStartsRadioButton.Checked)
                {
                    rse = new RowStartExtractor(bwd.Worker, _rowReader, targetFilePath,
                        (int) RowStartCharactersNumeric.Value);
                }


                bwd.Start();
            }
            if (FindReplaceRadioButton.Checked && tr != null)
            {
                infoStr = tr.Occurences + " matches replaced!";                
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
            _rowReader?.Close();
            _rowReader = new RowReader(InputFileTextBox.Text, _keyString, _criterias, ReadEntireRowsRadioButton.Checked);
            return true;
        }

        private void ShowWarning(String message)
        {
            MessageBox.Show(message,
                           "Warning",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
        }

        private void mergeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void copyPasteColumnsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var copyPasteColumns = new CopyPasteColumns();
            copyPasteColumns.ShowDialog();
        }

        private void specialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var specialForm = new SpecialForm();
            specialForm.ShowDialog();
        }

        private void columnWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mergeFiles_Columns = new MergeFiles_Columns();
            mergeFiles_Columns.ShowDialog();
        }

        private void afterEachOtherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mergeFilesDialog = new MergeFilesAfterEachOtherDialog();
            mergeFilesDialog.ShowDialog();
        }

        private void getUniqueItemsFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var getUniqueItemsDialog = new GetUniqueItemsDialog();
            getUniqueItemsDialog.ShowDialog();
        }

        private void getConflictInForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exportConlictDialog = new ExportConlictingForwardFromManifestDialog();
            exportConlictDialog.ShowDialog();
        }

        private void getNumberOfMarkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var getNumberMarkersDialog = new GetNumberMarkersDialog();
            getNumberMarkersDialog.ShowDialog();
        }

        private void getCommonMarkersFromManifestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var getCommonMarkersFromManifestsDialog = new GetCommonMarkersFromManifestsDialog();
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
            var extractFromLocusDialog = new ExtractFromLocusDialog();
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
            var getConflictMarkersDialog = new GetConflictMarkersDialog();
            getConflictMarkersDialog.ShowDialog();
        }

        private void scanDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var scanManifestConflictsPlusDialog = new ScanManifestConflictsPlusDialog();
            scanManifestConflictsPlusDialog.ShowDialog();
        }

        private void findLocusForSpecificManfiestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var findLocusWithManifestDialog = new FindLocusWithManifestDialog();
            findLocusWithManifestDialog.ShowDialog();
        }

        private void compareVCFVsManifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var getConflictsInPlusVCF_ManifestDialog = new GetConflictsInPlusVCF_ManifestDialog();
            getConflictsInPlusVCF_ManifestDialog.ShowDialog();
        }

        private void extractFromFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var extractRowsFromFilesDialog = new ExtractRowsFromFilesDialog();
            extractRowsFromFilesDialog.ShowDialog();
        }

        private void scanVCFExportFileForConflictsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var getConflictsFromVCFExcportDialog = new GetConflictsFromVCFExcportDialog();
            getConflictsFromVCFExcportDialog.ShowDialog();
        }

        private void findManifestOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var genotypefileManifestMapperDialog = new GenotypefileManifestMapperDialog();
            genotypefileManifestMapperDialog.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var testForm = new TestForm();
            testForm.ShowDialog();
        }

        private void exportMarkersFromCompReportplusToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var exportMarkersFromComparisonReportDialog = new ExportMarkersFromComparisonReportDialog();
            exportMarkersFromComparisonReportDialog.ShowDialog();
        }

    }
}