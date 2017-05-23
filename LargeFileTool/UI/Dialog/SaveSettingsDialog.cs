using System;
using System.Windows.Forms;
using LargeFileTool.Data;

namespace LargeFileTool.UI.Dialog
{
    public partial class SaveSettingsDialog : Form
    {
        private string MyColumnDelimiterSourceFile;
        private string MyColumnDelimiterDestinationFile;
        private string MyColumnOrderString;

        public SaveSettingsDialog(string columnDelimiterSourceFile, string columnDelimiterDestinationFile, 
            string columnOrderString)
        {
            InitializeComponent();
            MyColumnDelimiterSourceFile = columnDelimiterSourceFile;
            MyColumnDelimiterDestinationFile = columnDelimiterDestinationFile;
            MyColumnOrderString = columnOrderString;
            ColumnDelimiterSourceFileLabel.Text = GetColumnDelimiterExplanation(columnDelimiterSourceFile);
            ColumnDelimiterDestinationFileLabel.Text = GetColumnDelimiterExplanation(columnDelimiterDestinationFile);
            ColumnOrderLabel.Text = columnOrderString;
            SaveButton.Enabled = false;
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

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name;
            name = SettingNameTextBox.Text.Trim();
            ConfigurationManager.SaveCopyPasteColumnSetting(name, MyColumnDelimiterSourceFile, MyColumnDelimiterDestinationFile,
                MyColumnOrderString);
            Close();
        }

        private void SettingNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = SettingNameTextBox.Text.Trim() != "";
        }
    }
}
