using System;
using System.Collections.Specialized;

namespace LargeFileTool.UI.Dialog
{
    public partial class TestForm : LargeFileToolForm
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            //int integer;
            //int.TryParse(InputTextBox.Text.Trim(), out integer);
            //OutputTextBox.Text = ParseInt(integer);
            ListDialog listDialog;
            StringCollection straArr = new StringCollection();

            straArr.Add("ett");
            straArr.Add("tva");
            listDialog = new ListDialog("Test column", straArr, "Title", ListDialog.DialogMode.ShowList, "Message");
            listDialog.ShowDialog();
        }


    }
}
