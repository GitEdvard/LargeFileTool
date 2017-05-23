using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FlexibleStreamHandling;
using LargeFileTool.Data;

namespace LargeFileTool.UI.Dialog
{
    public partial class CopyPasteColumns : Form
    {
        private const string INTERNAL_DELIMITER = ",";
        public CopyPasteColumns()
        {
            InitializeComponent();
            saveGetSettingToolStripMenuItem.Visible = false;
            TestButton.Visible = false;
            TestButton.Enabled = false;
            InitExtraColumnsListView();
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitExtraColumnsListView()
        {
            ExtraColumnsListView.Columns.Add("Column name", -2);
            ExtraColumnsListView.Columns.Add("Column value", -2);
        }

        private void BrowseSourceFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            SourceFilePathTextBox.Text = openFileDialog1.FileName;
        }

        private string GetColumnDelimiterExplanation(string inputColumnDelimiter)
        {
            if (inputColumnDelimiter == ",")
            {
                return ", (comma)";
            }
            else if (inputColumnDelimiter == "\\t")
            {
                return "(tab)";
            }
            else if (inputColumnDelimiter == ";")
            {
                return "; (semicolon)";
            }
            else if (inputColumnDelimiter == ":")
            {
                return ": (colon)";
            }
            else
            {
                return inputColumnDelimiter;
            }
        }

        private String GetKeyString(String str)
        {
            char ch = '\t';
            if (str == "\\t")
            {
                return ch.ToString();
            }
            if (str == "\\n")
            {
                return '\n'.ToString();
            }
            return str;
        }

        private bool IsUserDefinedColumn(string columnName, out string value)
        {
            value = "";
            foreach (object item in ExtraColumnsListView.Items)
            {
                if (((ExtraColumnsViewItem)item).GetName() == columnName)
                {
                    value = ((ExtraColumnsViewItem)item).GetValue();
                    return true;
                }
            }
            return false;
        }

        private bool IsColumnMatch(string columnMapStr, string[] uppercaseColumnsStrArr)
        {
            for (int i = 0; i < uppercaseColumnsStrArr.Length; i++)
            {
                if (uppercaseColumnsStrArr[i].Trim() == columnMapStr.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        private bool ParseColumnMappingString(out List<ColumnMapping> columnMapping)
        {
            string[] columnMappingStr, uppercaseColumnsStrArr;
            string columnOrderString, str, userDefinedColumnValue;
            int column;
            bool forceUppercase;
            columnMapping = new List<ColumnMapping>();
            // Parse the column mapping string
            columnOrderString = TransferColumnsTextBox.Text.Trim();
            if (columnOrderString == "")
            {
                str = "Please specify the 'Inlcuded columns in output file!";
                MessageBox.Show(str, "Column specifiers missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;                
            }
            columnMappingStr = columnOrderString.Split(INTERNAL_DELIMITER.ToCharArray(), StringSplitOptions.None);
            uppercaseColumnsStrArr = ForceUppercaseTextBox.Text.Trim().Split(INTERNAL_DELIMITER.ToCharArray(), StringSplitOptions.None);
            columnMapping = new List<ColumnMapping>();
            for (int i = 0; i < columnMappingStr.Length; i++)
            {
                forceUppercase = IsColumnMatch(columnMappingStr[i], uppercaseColumnsStrArr);
                if( IsUserDefinedColumn(columnMappingStr[i].Trim(), out userDefinedColumnValue))
                {
                    columnMapping.Add(new ColumnMapping(userDefinedColumnValue, -1, true, forceUppercase));
                }
                else if (int.TryParse(columnMappingStr[i], out column))
                {
                    columnMapping.Add(new ColumnMapping("", column - 1, false, forceUppercase));
                }
                else
                {
                    str = "The 'Included columns in Output File' is not in the right format!";
                    MessageBox.Show(str, "Input string format error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;                
                }
            }
            return true;
        }

        private bool GetSourceFileDelimiter(out string[] sourceFileDelimiters)
        {
            string str, sourceFileDelimiter;
            int i = 0;
            sourceFileDelimiters = null;
            // Check if the list has any items
            if (DelimiterListBox.Items.Count > 0)
            {
                sourceFileDelimiters = new string[DelimiterListBox.Items.Count];
                foreach (object item in DelimiterListBox.Items)
                { 
                    sourceFileDelimiters[i++] = GetKeyString(((DelimiterViewItem)item).GetDelimiter());
                }
                return true;
            }

            // Check if the textbox is filled
            sourceFileDelimiter = GetKeyString(ColumnDelimiterSourceTextBox.Text.Trim());
            if (sourceFileDelimiter == "")
            {
                str = "Please enter column delimiter for the source file!";
                MessageBox.Show(str, "Column delimiter missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            sourceFileDelimiters = new string[1];
            sourceFileDelimiters[0] = sourceFileDelimiter;
            return true;        
        }

        private bool GetDestinationFileDelimiter(out string destinationFileDelimiter)
        {
            string str;
            destinationFileDelimiter = GetKeyString(ColumnDelimiterDestinationTextBox.Text.Trim());
            if (destinationFileDelimiter == "")
            {
                str = "Please enter column delimiter for the destination file!";
                MessageBox.Show(str, "Column delimiter missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool GetSourceFilePath(out string sourceFilePath)
        {
            string str;
            sourceFilePath = SourceFilePathTextBox.Text.Trim();
            if (sourceFilePath == "")
            {
                str = "Please specify the source file!";
                MessageBox.Show(str, "Source file not specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;                
            }
            return true;
        }

        private bool GetSettings(out List<ColumnMapping> columnMapping, out string[] sourceFileDelimiter,
            out string destinationFileDelimiter, out string sourceFilePath, out int firstLine)
        {
            firstLine = -1;
            columnMapping = null;
            sourceFileDelimiter = null;
            destinationFileDelimiter = "";
            sourceFilePath = "";
            if (!ParseColumnMappingString(out columnMapping))
            {
                return false;
            }
            if (!GetSourceFileDelimiter(out sourceFileDelimiter))
            {
                return false;
            }
            if (!GetDestinationFileDelimiter(out destinationFileDelimiter))
            {
                return false;
            }
            if (!GetSourceFilePath(out sourceFilePath))
            {
                return false;
            }
            firstLine = (int)FirstRowSourceNumericUpDown.Value;
            return true;
        }

        private bool GetHeaders(out string header)
        {
            String destinationFileDelimiter, sourceFilePath;
            string[] sourceFileDelimiters;
            List<ColumnMapping> columnMapping;
            int firstLine;
            header = "";
            MappedColumnRowReader rowReader = null;

            if (!GetSettings(out columnMapping, out sourceFileDelimiters,
                out destinationFileDelimiter, out sourceFilePath, out firstLine))
            {
                return false;
            }
            try
            {
                rowReader = new MappedColumnRowReader(sourceFilePath, firstLine,
                    columnMapping, sourceFileDelimiters, destinationFileDelimiter);
                if (!rowReader.GetNextDestinationRow(out header))
                {
                    return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                rowReader.Close();
            }
        }

        private void GetHeaderButton_Click(object sender, EventArgs e)
        {
            string headers = "";
            if (GetHeaders(out headers))
            {
                HeaderTextBox.Text = headers;
            }
        }

        private bool CheckSettings()
        {
            String str, sourceFileDelimiter;
            int firstLine;
            string dummy;
            StreamReader sr = null;
            try
            {
                sourceFileDelimiter = GetKeyString(ColumnDelimiterSourceTextBox.Text.Trim());
                firstLine = (int)FirstRowSourceNumericUpDown.Value;
                if (SourceFilePathTextBox.Text.Trim() == "")
                {
                    str = "Please enter the source file path!";
                    MessageBox.Show(str, "No input file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (!GetHeaders(out dummy))
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
            return true;
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            string destinationFilePath, sourceFilePath, destinationFileDelimiter;
            string[] sourceFileDelimiters;
            List<ColumnMapping> columnMapping;
            int firstLine;
            ColumnTransferer columnTransferer;
            BackgroundWorkerDialog bwd;

            if (!GetSettings(out columnMapping, out sourceFileDelimiters,
                out destinationFileDelimiter, out sourceFilePath, out firstLine))
            {
                return;
            }
            if (!(saveFileDialog1.ShowDialog() == DialogResult.OK))
            {
                return;
            }
            destinationFilePath = saveFileDialog1.FileName;
            try
            {
                bwd = new BackgroundWorkerDialog();
                columnTransferer = new ColumnTransferer(sourceFilePath, destinationFilePath,
                    columnMapping, sourceFileDelimiters, destinationFileDelimiter,
                    firstLine, SkipHeaderCheckBox.Checked, HeaderTextBox.Text.Trim(), bwd.Worker);
                bwd.Start();
                // Stop
                //if(bwd.th
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool CheckSettingFields()
        {
            if (ColumnDelimiterSourceTextBox.Text.Trim() == "")
            {
                return false;
            }
            if (ColumnDelimiterDestinationTextBox.Text.Trim() == "")
            {
                return false;
            }
            if (TransferColumnsTextBox.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void saveCurrentTransferSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str;
            SaveSettingsDialog saveSettingsDialog;
            if (!CheckSettingFields())
            {
                str = "Some of the fields\n\n'Column delimiter (source file)'\n'Column delimter (destination file)' or\n";
                str += "'Inluded columns in destination file'\n\nare empty!\nSave settings is canceled.";
                MessageBox.Show(str, "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            saveSettingsDialog = new SaveSettingsDialog(ColumnDelimiterSourceTextBox.Text.Trim(),
                ColumnDelimiterDestinationTextBox.Text.Trim(), TransferColumnsTextBox.Text.Trim());
            saveSettingsDialog.ShowDialog();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            FileSampler fileSampler;
            BackgroundWorkerDialog bwd;
            RowReader rowReader;
            string destinationFilePath, sourceFilePath, destinationFileDelimiter;
            string[] sourceFileDelimiters;
            List<ColumnMapping> columnMapping;
            int firstLine;

            if (!(saveFileDialog1.ShowDialog() == DialogResult.OK))
            {
                return;
            }
            destinationFilePath = saveFileDialog1.FileName;

            if (!GetSettings(out columnMapping, out sourceFileDelimiters,
                out destinationFileDelimiter, out sourceFilePath, out firstLine))
            {
                return;
            }

            
            bwd = new BackgroundWorkerDialog();
            var stream = new FileIOStream(sourceFilePath);
            rowReader = new RowReader(stream, "", null, true);

            fileSampler = new FileSampler(bwd.Worker, rowReader, destinationFilePath, 1, 0, 2450007);
            bwd.Start();
        }

        private void AddDelimiterButton_Click(object sender, EventArgs e)
        {
            DelimiterViewItem delimiterViewItem;
            string delimter;
            delimter = ColumnDelimiterSourceTextBox.Text.Trim();
            if (delimter != "")
            {
                // Check if the delimter is already contained in the list
                foreach (object item in DelimiterListBox.Items)
                {
                    if (((DelimiterViewItem)item).GetDelimiter() == delimter)
                    {
                        return;
                    }
                }
                delimiterViewItem = new DelimiterViewItem(delimter, GetColumnDelimiterExplanation(delimter));
                DelimiterListBox.Items.Add(delimiterViewItem);
            }
            ColumnDelimiterSourceTextBox.Text = "";
        }

        private class DelimiterViewItem
        {
            private string MyDelimiter;
            private string MyDelimiterExplanation;
            public DelimiterViewItem(string delimiter, string explanation)
            {
                MyDelimiter = delimiter;
                MyDelimiterExplanation = explanation;
            }
            public string GetDelimiter()
            {
                return MyDelimiter;
            }
            public override string ToString()
            {
                return MyDelimiterExplanation;
            }
        }

        private class ExtraColumnsViewItem : ListViewItem
        {
            private string MyColumnName;
            private string MyColumnValue;
            public ExtraColumnsViewItem(string name, string value)
                : base(name)
            {
                MyColumnName = name;
                MyColumnValue = value;
                this.SubItems.Add(value);
            }

            public string GetName()
            {
                return MyColumnName;
            }

            public string GetValue()
            {
                return MyColumnValue;
            }
        }

        private void ClearDelimiersButton_Click(object sender, EventArgs e)
        {
            DelimiterListBox.Items.Clear();
        }

        private void AddColumnButton_Click(object sender, EventArgs e)
        {
            string str;
            ExtraColumnsViewItem ecViewItem;
            if (ColumnNameTextBox.Text.Trim() == "")
            {
                str = "Please enter a name for the column!";
                MessageBox.Show(str, "Column name missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ecViewItem = new ExtraColumnsViewItem(ColumnNameTextBox.Text.Trim(), ColumnValueTextBox.Text.Trim());
            ExtraColumnsListView.BeginUpdate();
            ExtraColumnsListView.Items.Add(ecViewItem);
            ExtraColumnsListView.EndUpdate();
            ColumnNameTextBox.Text = "";
            ColumnValueTextBox.Text = "";
        }

        private void ClearColumnsButton_Click(object sender, EventArgs e)
        {
            ExtraColumnsListView.Items.Clear();
        }
    }
}
