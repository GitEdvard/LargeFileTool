using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class MergeFiles_Columns : Form
    {
        private const string INTERNAL_DELIMITER = ",";
        public MergeFiles_Columns()
        {
            InitializeComponent();
        }

        private void BrowseFileAButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            FileAPathTextBox.Text = openFileDialog1.FileName;
        }

        private void BrowseFileBButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            FileBPathTextBox.Text = openFileDialog1.FileName;
        }

        private bool GetHeader(string fileHeaders, string delimiter, int columnNumber, out string header)
        {
            int firstIndex, secondIndex;
            string str;
            firstIndex = 0;
            secondIndex = 0;
            header = "";
            for (int i = 0; i < columnNumber; i++)
            {
                firstIndex = secondIndex;
                if(fileHeaders.Length < firstIndex + 1)
                {
                    str = "File header not found!";
                    MessageBox.Show(str, "Header not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                secondIndex = fileHeaders.IndexOf(delimiter, firstIndex + 1);
                if (secondIndex == -1)
                {
                    secondIndex = fileHeaders.Length - 1;
                }
            }
            header = fileHeaders.Substring(firstIndex + 1, secondIndex - firstIndex - 1).Trim();
            return true;
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

        private bool GetOutPutLine(string[] columnOrders, string[] fileAColumns, string[] fileBColumns, out string outputLine)
        {
            String columnStr, str, mergeFileDelimiter, outputColumn = "", fileADelimiter, fileBDelimiter;
            char fileChr;
            int columnNumber;
            outputLine = "";
            fileADelimiter = GetKeyString(FileADelimiterTextBox.Text.Trim());
            fileBDelimiter = GetKeyString(FileBDelimiterTextBox.Text.Trim());
            mergeFileDelimiter = GetKeyString(MergeFileColumnDelimiterTextBox.Text.Trim());

            for(int i = 0; i < columnOrders.Length; i++)
            {
                columnStr = columnOrders[i].Trim();
                fileChr = columnStr[0];
                if (!int.TryParse(columnStr.Substring(1), out columnNumber) ||
                    !(fileChr == 'a' || fileChr == 'A' || fileChr == 'b' || fileChr == 'B'))
                {
                    str = "The 'Included columns in Merge File' is not in the right format!";
                    MessageBox.Show(str, "Input string format error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                columnNumber--;
                outputColumn = "x";
                if (fileChr == 'a' || fileChr == 'A')
                {
                    outputColumn = fileAColumns[columnNumber];
                }
                else if (fileChr == 'b' || fileChr == 'B')
                {
                    outputColumn = fileBColumns[columnNumber];
                }
                outputLine = outputLine + outputColumn + mergeFileDelimiter;
            }
            outputLine = outputLine.Substring(0, outputLine.Length - 1);
            return true;        
        }

        private bool GetHeaders(string columnOrderString, string fileAHeaders, string fileBHeaders, out string headers)
        {
            String columnStr, str, mergeFileDelimiter, header = "", fileADelimiter, fileBDelimiter;
            char fileChr;
            int columnNumber;
            string[] columns, headerAColumns, headerBColumns;
            headers = "";
            fileADelimiter = GetKeyString(FileADelimiterTextBox.Text.Trim());
            fileBDelimiter = GetKeyString(FileBDelimiterTextBox.Text.Trim());
            mergeFileDelimiter = GetKeyString(MergeFileColumnDelimiterTextBox.Text.Trim());
            columns = columnOrderString.Split(new string[] { INTERNAL_DELIMITER }, StringSplitOptions.None);
            headerAColumns = fileAHeaders.Split(new string[] {fileADelimiter}, StringSplitOptions.None);
            headerBColumns = fileBHeaders.Split(new string[] {fileBDelimiter}, StringSplitOptions.None);
            for (int i = 0; i < columns.Length; i++)
            {
                columnStr = columns[i].Trim();
                fileChr = columnStr[0];
                if(!int.TryParse(columnStr.Substring(1), out columnNumber) ||
                    !(fileChr == 'a' || fileChr == 'A' || fileChr == 'b' || fileChr == 'B'))
                {
                    str = "The 'Included columns in Merge File' is not in the right format!";
                    MessageBox.Show(str, "Input string format error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                columnNumber--;
                header = "x";
                if (fileChr == 'a' || fileChr == 'A')
                {
                    if (FileAHeaderCheckBox.Checked)
                    {
                        header = headerAColumns[columnNumber];
                    }
                }
                else if (fileChr == 'b' || fileChr == 'B')
                {
                    if (FileBHeaderCheckBox.Checked)
                    {
                        header = headerBColumns[columnNumber];
                    }
                }
                headers = headers + header + mergeFileDelimiter;
            }
            headers = headers.Substring(0, headers.Length - 1);
            return true;
        }

        private String GetMergeFileHeaders()
        {
            StreamReader srA = null, srB = null;
            string columnOrderString, str, headers = "", fileAHeaders, fileBHeaders;
            int firstAline, firstBline;
            try
            {
                if ((FileBPathTextBox.Text.Trim() == "" || FileBHeaderCheckBox.Checked == false) &&
                    FileAPathTextBox.Text.Trim() == "" || FileAHeaderCheckBox.Checked == false)
                { 
                    str = "Either file A or file B have to have a header in first row. If so, please enter file A and B, and check the checkbox!";
                    MessageBox.Show(str, "No input files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "";
                }
                if (MergeFileColumnOrderTextBox.Text.Trim() == "")
                {
                    str = "Please enter the column order string!";
                    MessageBox.Show(str, "Column order missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "";
                }
                firstAline = (int)FileAFirstRowNumericUpDown.Value;
                firstBline = (int)FileBFirstRowNumericUpDown.Value;
                columnOrderString = MergeFileColumnOrderTextBox.Text.Trim();
                srA = new StreamReader(FileAPathTextBox.Text.Trim(), Encoding.GetEncoding(1252));
                srB = new StreamReader(FileBPathTextBox.Text.Trim(), Encoding.GetEncoding(1252));
                fileAHeaders = "";
                if (FileAHeaderCheckBox.Checked)
                {
                    for (int i = 0; i < firstAline; i++)
                    {
                        fileAHeaders = srA.ReadLine();
                    }
                }
                fileBHeaders = "";
                if (FileBHeaderCheckBox.Checked)
                {
                    for (int i = 0; i < firstBline; i++)
                    {
                        fileBHeaders = srB.ReadLine();
                    }
                }
                GetHeaders(columnOrderString, fileAHeaders, fileBHeaders, out headers);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (srA != null)
                {
                    srA.Close();
                }
                if (srB != null)
                {
                    srB.Close();
                }
            }
            return headers;
        }

        private void GetHeadersButton_Click(object sender, EventArgs e)
        {
            MergeFileHeaderTextBox.Text = GetMergeFileHeaders();
        }

        private void Merge_NoChunk_ExactMatch(string outputFileName)
        {
            StreamReader srA = null, srB = null;
            StreamWriter sw = null;
            string columnOrderString, str;
            int firstAline, firstBline, lineCounter;
            int fileAKeyColumnIndex, fileBKeyColumnIndex;
            string textLine, outputLine;
            string[] columns, fileAColumns, fileBcolumns, columnOrders;
            string fileADelimiter, fileBDelimiter, fileAKeyColumn;
            Dictionary<string, string> fileBDict;
            List<string> NoMatchKeys = new List<string>();
            bool filterFlag = false;

            // Check input arguments
            if (FileBPathTextBox.Text.Trim() == ""  || FileAPathTextBox.Text.Trim() == "" )
            {
                str = "Please enter filenames for file A and file B!";
                MessageBox.Show(str, "No input files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MergeFileColumnOrderTextBox.Text.Trim() == "")
            {
                str = "Please enter the column order string!";
                MessageBox.Show(str, "Column order missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                firstAline = (int)FileAFirstRowNumericUpDown.Value;
                firstBline = (int)FileBFirstRowNumericUpDown.Value;
                if (FileAHeaderCheckBox.Checked)
                {
                    firstAline++;
                }
                if (FileBHeaderCheckBox.Checked)
                {
                    firstBline++;
                }
                columnOrderString = MergeFileColumnOrderTextBox.Text.Trim();
                columnOrders = columnOrderString.Split(new string[] { INTERNAL_DELIMITER }, StringSplitOptions.None);
                srA = new StreamReader(FileAPathTextBox.Text.Trim(), Encoding.GetEncoding(1252));
                srB = new StreamReader(FileBPathTextBox.Text.Trim(), Encoding.GetEncoding(1252));
                sw = new StreamWriter(outputFileName, false, Encoding.GetEncoding(1252));
                fileADelimiter = GetKeyString(FileADelimiterTextBox.Text.Trim());
                fileBDelimiter = GetKeyString(FileBDelimiterTextBox.Text.Trim());
                fileAKeyColumnIndex = (int)FileAKeyColumnNumericUpDown.Value - 1;
                fileBKeyColumnIndex = (int)FileBKeyColumnNumericUpDown.Value - 1;

                if (includeHeaderCheckbox.Checked && MergeFileHeaderTextBox.Text.Trim().Length > 0)
                {
                    sw.WriteLine(MergeFileHeaderTextBox.Text);
                }

                fileBDict = new Dictionary<string, string>();
                // Load file B into memory
                lineCounter = 1;
                while (!srB.EndOfStream && lineCounter < firstBline)
                {
                    textLine = srB.ReadLine();
                    lineCounter++;
                }
                while (!srB.EndOfStream)
                {
                    textLine = srB.ReadLine();
                    columns = textLine.Split(new string[] { fileBDelimiter }, StringSplitOptions.None);
                    if (!fileBDict.ContainsKey(columns[fileBKeyColumnIndex]))
                    {
                        fileBDict.Add(columns[fileBKeyColumnIndex], textLine);
                    }
                    else
                    {
                        filterFlag = true;
                    }
                }

                // Loop through rows in file A, match keycolumn in file B
                lineCounter = 1;
                while (!srA.EndOfStream && lineCounter < firstAline)
                {
                    textLine = srA.ReadLine();
                    lineCounter++;
                }

                while (!srA.EndOfStream)
                {
                    textLine = srA.ReadLine();
                    fileAColumns = textLine.Split(new string[] { fileADelimiter }, StringSplitOptions.None);
                    fileAKeyColumn = fileAColumns[fileAKeyColumnIndex];
                    if (fileBDict.ContainsKey(fileAKeyColumn))
                    {
                        textLine = fileBDict[fileAKeyColumn];
                        fileBcolumns = textLine.Split(new string[] {fileBDelimiter}, StringSplitOptions.None);
                        // Assemble an output row                     
                        GetOutPutLine(columnOrders, fileAColumns, fileBcolumns, out outputLine);
                        sw.WriteLine(outputLine);
                    }
                    else
                    {
                        NoMatchKeys.Add(fileAKeyColumn);
                    }

                }

                if (NoMatchKeys.Count > 0 && !filterFlag)
                {
                    str = "Number of no matches : " + NoMatchKeys.Count;
                    MessageBox.Show(str, "No matches", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (NoMatchKeys.Count > 0 && filterFlag)
                {
                    str = "Number of no matches : " + NoMatchKeys.Count + "\nThere were duplicates in file B key column that were filtered away!";
                    MessageBox.Show(str, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                }
                else if (NoMatchKeys.Count == 0 && filterFlag)
                {
                    str = "There were duplicates in file B key column that were filtered away!";
                    MessageBox.Show(str, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (srA != null)
                {
                    srA.Close();
                }
                if (srB != null)
                {
                    srB.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }

        }

        private void Merge_NoChunk_Instring(string outputFileName)
        {
            StreamReader srA = null, srB = null;
            StreamWriter sw = null;
            string columnOrderString, str;
            int firstAline, firstBline, lineCounter;
            int fileAKeyColumnIndex, fileBKeyColumnIndex;
            string textLine, outputLine;
            string[] columns, fileAColumns, fileBcolumns, columnOrders;
            string fileADelimiter, fileBDelimiter, fileAKeyColumn;
            Dictionary<string, string> fileBDict;
            Dictionary<string, string> fileADict;
            List<string> NoMatchKeysInA = new List<string>();
            List<string> NoMatchKeysInB = new List<string>();
            bool filterFlag = false;

            // Check input arguments
            if (FileBPathTextBox.Text.Trim() == "" || FileAPathTextBox.Text.Trim() == "")
            {
                str = "Please enter filenames for file A and file B!";
                MessageBox.Show(str, "No input files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MergeFileColumnOrderTextBox.Text.Trim() == "")
            {
                str = "Please enter the column order string!";
                MessageBox.Show(str, "Column order missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                firstAline = (int)FileAFirstRowNumericUpDown.Value;
                firstBline = (int)FileBFirstRowNumericUpDown.Value;
                if (FileAHeaderCheckBox.Checked)
                {
                    firstAline++;
                }
                if (FileBHeaderCheckBox.Checked)
                {
                    firstBline++;
                }
                columnOrderString = MergeFileColumnOrderTextBox.Text.Trim();
                columnOrders = columnOrderString.Split(new string[] { INTERNAL_DELIMITER }, StringSplitOptions.None);
                srB = new StreamReader(FileBPathTextBox.Text.Trim(), Encoding.GetEncoding(1252));
                sw = new StreamWriter(outputFileName, false, Encoding.GetEncoding(1252));
                fileADelimiter = GetKeyString(FileADelimiterTextBox.Text.Trim());
                fileBDelimiter = GetKeyString(FileBDelimiterTextBox.Text.Trim());
                fileAKeyColumnIndex = (int)FileAKeyColumnNumericUpDown.Value - 1;
                fileBKeyColumnIndex = (int)FileBKeyColumnNumericUpDown.Value - 1;

                if (includeHeaderCheckbox.Checked && MergeFileHeaderTextBox.Text.Trim().Length > 0)
                {
                    sw.WriteLine(MergeFileHeaderTextBox.Text);
                }

                fileBDict = new Dictionary<string, string>();
                // Load file B into memory
                lineCounter = 1;
                while (!srB.EndOfStream && lineCounter < firstBline)
                {
                    textLine = srB.ReadLine();
                    lineCounter++;
                }
                while (!srB.EndOfStream)
                {
                    textLine = srB.ReadLine();
                    columns = textLine.Split(new string[] { fileBDelimiter }, StringSplitOptions.None);
                    if (!fileBDict.ContainsKey(columns[fileBKeyColumnIndex]))
                    {
                        fileBDict.Add(columns[fileBKeyColumnIndex], textLine);
                    }
                    else
                    {
                        filterFlag = true;
                    }
                }

                srA = new StreamReader(FileAPathTextBox.Text.Trim(), Encoding.GetEncoding(1252));

                // Loop through rows in file A, match keycolumn in file B
                lineCounter = 1;
                while (!srA.EndOfStream && lineCounter < firstAline)
                {
                    textLine = srA.ReadLine();
                    lineCounter++;
                }

                while (!srA.EndOfStream)
                {
                    textLine = srA.ReadLine();
                    fileAColumns = textLine.Split(new string[] { fileADelimiter }, StringSplitOptions.None);
                    fileAKeyColumn = fileAColumns[fileAKeyColumnIndex];
                    if (ContainsKeyInstr(fileBDict, fileAKeyColumn, out textLine))
                    {
                        fileBcolumns = textLine.Split(new string[] { fileBDelimiter }, StringSplitOptions.None);
                        // Assemble an output row                     
                        GetOutPutLine(columnOrders, fileAColumns, fileBcolumns, out outputLine);
                        sw.WriteLine(outputLine);
                    }
                    else
                    {
                        NoMatchKeysInA.Add(fileAKeyColumn);
                    }

                }

                if (ShowAllUnmatchedCheckBox.Checked)
                {
                    // Load file A in memory
                    srA = new StreamReader(FileAPathTextBox.Text.Trim(), Encoding.GetEncoding(1252));
                    fileADict = new Dictionary<string, string>();
                    while (!srA.EndOfStream && lineCounter < firstAline)
                    {
                        textLine = srA.ReadLine();
                        lineCounter++;
                    }
                    while (!srA.EndOfStream)
                    {
                        textLine = srA.ReadLine();
                        columns = textLine.Split(new string[] { fileADelimiter }, StringSplitOptions.None);
                        if (!fileADict.ContainsKey(columns[fileAKeyColumnIndex]))
                        {
                            fileADict.Add(columns[fileAKeyColumnIndex], textLine);
                        }
                        else
                        {
                            filterFlag = true;
                        }
                    }
                    // Find all entries in B not matching A
                    foreach (string fileBEntry in fileBDict.Keys)
                    {
                        if (!ContainsKeyInstr(fileADict, fileBEntry, out textLine))
                        {
                            NoMatchKeysInB.Add(fileBEntry);
                        }
                    }
                }

                if (NoMatchKeysInA.Count + NoMatchKeysInB.Count > 0)
                {
                    ShowUnmatchedEntries(NoMatchKeysInA, NoMatchKeysInB, filterFlag);
                }
                else if (filterFlag && ShowAllUnmatchedCheckBox.Checked)
                {
                    str = "There were duplicates in file A and B key column that were filtered away!";
                    MessageBox.Show(str, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (filterFlag && !ShowAllUnmatchedCheckBox.Checked)
                {
                    str = "There were duplicates in file B key column that were filtered away!";
                    MessageBox.Show(str, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (srA != null)
                {
                    srA.Close();
                }
                if (srB != null)
                {
                    srB.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }

        }

        private void ShowUnmatchedEntries(List<string> unmatchedInA, List<string> unmatchedInB, bool filterFlag)
        {
            ListDialog listDialog;
            ColumnHeader[] headers = new ColumnHeader[2];
            ListViewItem[] viewItems = new ListViewItem[unmatchedInA.Count + unmatchedInB.Count];
            ColumnHeader header;
            ListViewItem viewItem;
            int i;
            string fileAName, fileBName;
            string[] delimiter = new string[] {@"/", @"\"};
            string[] filePath;
            string message;

            filePath = FileAPathTextBox.Text.Split(delimiter, StringSplitOptions.None);
            fileAName = filePath[filePath.Length - 1];
            filePath = FileBPathTextBox.Text.Split(delimiter, StringSplitOptions.None);
            fileBName = filePath[filePath.Length - 1];
            header = new ColumnHeader();
            header.Text = "Unmatched entry";
            headers[0] = header;
            header = new ColumnHeader();
            header.Text = "File";
            headers[1] = header;

            i = 0;
            foreach (string unmatched in unmatchedInA)
            {
                viewItem = new ListViewItem();
                viewItem.SubItems[0].Text = unmatched;
                viewItem.SubItems.Add(fileAName);
                viewItems[i++] = viewItem;
            }

            foreach (string unmatched in unmatchedInB)
            {
                viewItem = new ListViewItem();
                viewItem.SubItems[0].Text = unmatched;
                viewItem.SubItems.Add(fileBName);
                viewItems[i++] = viewItem;
            }

            if (ShowAllUnmatchedCheckBox.Checked)
            {
                message = "All unmatched entries from both file A and B";
            }
            else
            {
                message = "Unmatched entries (file A only, file B not investigated)";
            }

            if (filterFlag && ShowAllUnmatchedCheckBox.Checked)
            {
                message += Environment.NewLine;
                message += "There were duplicates in file A and B key columns that were filtered away!";
            }
            else if (filterFlag && !ShowAllUnmatchedCheckBox.Checked)
            {
                message += Environment.NewLine;
                message += "There were duplicates in file B key columns that were filtered away!";                
            }

            listDialog = new ListDialog(headers, viewItems, "Unmatched entries", ListDialog.DialogMode.ShowList, message);
            //listDialog.SetRowLimitFilterStatus(true);
            listDialog.ShowDialog();

        }

        private bool ContainsKeyInstr(Dictionary<string, string> dict, string key, out string textLine)
        {
            textLine = "";
            foreach(string dictKey in dict.Keys)
            {
                if (dictKey.Contains(key) || key.Contains(dictKey))
                {
                    textLine = dict[dictKey];
                    return true;
                }
            }
            return false;
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Trim().Length == 0)
            {
                return;
            }
            if (ExactMatchOptionRadioButton.Checked)
            {
                Merge_NoChunk_ExactMatch(saveFileDialog1.FileName);
            }
            else if (InstringOptionRadioButton.Checked)
            {
                Merge_NoChunk_Instring(saveFileDialog1.FileName);
            }
        }

    }
}
