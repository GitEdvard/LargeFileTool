using System;
using System.Windows.Forms;

namespace LargeFileTool.Data
{
    public class ColumnMapping
    {
        // Change 2
        private bool MyIsReferingToUserDefined;
        private bool MyForceUppercase;
        private int MySourceColumnIndex;
        private string MyUserDefinedValue;
        private const string COLUMN_ENCAPSULATION_START = "[[";
        private const string COLUMN_ENCAPSULATION_END = "]]";

        public ColumnMapping(String userDefinedValue, int sourceColumnIndex, 
            bool isReferingToUserDefined, bool forceUppercase)
        {
            MyUserDefinedValue = userDefinedValue;
            MySourceColumnIndex = sourceColumnIndex;
            MyIsReferingToUserDefined = isReferingToUserDefined;
            MyForceUppercase = forceUppercase;
        }

        public bool GetColumnString(string[] sourceColumns, int rowCounter, out string columnString)
        {
            string str;
            columnString = "";
            if (MyIsReferingToUserDefined)
            {
                if (!ParseUserDefinedValue(sourceColumns, rowCounter, out columnString))
                {
                    return false;
                }
            }
            else
            {
                if (MySourceColumnIndex >= sourceColumns.Length)
                {
                    str = "Warning, the specified column (" + (MySourceColumnIndex + 1).ToString() + ") is non existent in the source file";
                    str += ", which only have " + sourceColumns.Length.ToString() + " columns!\n";
                    str += "Row " + rowCounter.ToString();
                    str += "\n(Did you specify the right column delimiter for the source file?)";
                    str += "Transfer is stopped at row " + rowCounter.ToString() + "!";
                    MessageBox.Show(str, "Column reference error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                columnString = sourceColumns[MySourceColumnIndex];
            }
            if (MyForceUppercase)
            {
                columnString = columnString.ToUpper();
            }
            return true;
        }

        private bool ParseUserDefinedValue(string[] sourceColumns, int rowCounter, out string columnString)
        {
            // Walk through the MyUserDefinedValue,
            // Search for [[ and ]]
            // Check consistency
            // Try parse column reference
            int startBracketsPosition = -1;
            int closingBracketsPosition = -1;
            int parseLength;
            int textBlockIndex, parseIndex;
            string parseStr;
            int referenceColumn;
            string str;
            columnString = "";
            startBracketsPosition = MyUserDefinedValue.IndexOf(COLUMN_ENCAPSULATION_START);
            textBlockIndex = 0;
            while (startBracketsPosition > -1)
            {
                if (startBracketsPosition > -1 && !MyUserDefinedValue.Substring(startBracketsPosition).Contains(COLUMN_ENCAPSULATION_END))
                {
                    str = "Error, unbalanced brackets in user defined column: " + MyUserDefinedValue;
                    MessageBox.Show(str, "User defined column error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                parseLength = startBracketsPosition - textBlockIndex;
                columnString += MyUserDefinedValue.Substring(textBlockIndex, parseLength);
                closingBracketsPosition = MyUserDefinedValue.IndexOf(COLUMN_ENCAPSULATION_END,startBracketsPosition);
                textBlockIndex = closingBracketsPosition + COLUMN_ENCAPSULATION_END.Length;
                parseIndex = startBracketsPosition + COLUMN_ENCAPSULATION_START.Length;
                parseLength = closingBracketsPosition - parseIndex;
                parseStr = MyUserDefinedValue.Substring(parseIndex, parseLength).Trim();
                if (!int.TryParse(parseStr, out referenceColumn))
                {
                    str = "Error, reference in user defined column is not a number: " + MyUserDefinedValue;
                    MessageBox.Show(str, "Column reference error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                referenceColumn--;
                if (referenceColumn >= sourceColumns.Length || referenceColumn < 0)
                {
                    str = "Warning, the specified column (" + (referenceColumn + 1).ToString() + ") is non existent in the source file";
                    str += ", which only have " + sourceColumns.Length.ToString() + " columns!\n";
                    str += "Row " + rowCounter.ToString();
                    str += "\n(Did you specify the right column delimiter for the source file?)";
                    str += "Transfer is stopped at row " + rowCounter.ToString() + "!";
                    MessageBox.Show(str, "Column reference error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                columnString += sourceColumns[referenceColumn];
                startBracketsPosition = MyUserDefinedValue.IndexOf(COLUMN_ENCAPSULATION_START, closingBracketsPosition);
            }
            columnString += MyUserDefinedValue.Substring(textBlockIndex);
            return true;
        }
    }
}
