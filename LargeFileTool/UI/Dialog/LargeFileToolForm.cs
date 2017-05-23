using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Molmed.LargeFileTool.UI.Dialog
{
    public partial class LargeFileToolForm : Form
    {
        public LargeFileToolForm()
        {
            InitializeComponent();
        }

        public static void HandleError(String message, Exception exception)
        {
            ShowErrorDialog errorDialog;
            errorDialog = new ShowErrorDialog(message, exception);
            errorDialog.ShowDialog();
        }


        /// <summary>
        /// Get integers grouped in subsections of three numbers: x xxx xxx
        /// </summary>
        /// <param name="integer"></param>
        /// <returns></returns>
        protected string ParseInt(int integer)
        {
            string intStr, parsedInt = "";
            int subStrLen, subtractIndex = 0;
            intStr = integer.ToString();
            for (int i = 0; i <= (intStr.Length - 1) / 3; i++)
            {
                subStrLen = Math.Min((i+1)*3, intStr.Length)%3;
                if (subStrLen == 0)
                {
                    subStrLen = 3;
                }
                subtractIndex += subStrLen;
                if (i > 0)
                {
                    parsedInt = " " + parsedInt;
                }
                parsedInt = intStr.Substring(intStr.Length - subtractIndex, subStrLen) + parsedInt;
                if (i> 0)
                {
                    parsedInt += " ";
                }
            }
            return parsedInt;
        }

        public bool IsEmpty(string str)
        {
            return str == null || str.Trim() == "";
        }

        protected bool IsNotEmpty(string str)
        {
            return str != null && str.Trim() != "";
        }

        protected void ShowWarning(String message)
        {
            MessageBox.Show(message,
                           "LargeFileTool",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
        }

    }
}
