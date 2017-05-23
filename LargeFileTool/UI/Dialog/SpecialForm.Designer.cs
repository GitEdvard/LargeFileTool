namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class SpecialForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.SplitInternalReportButton = new System.Windows.Forms.Button();
            this.MergeInternalReportButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(250, 268);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(86, 25);
            this.MyCancelButton.TabIndex = 0;
            this.MyCancelButton.Text = "Close";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            // 
            // SplitInternalReportButton
            // 
            this.SplitInternalReportButton.Location = new System.Drawing.Point(36, 63);
            this.SplitInternalReportButton.Name = "SplitInternalReportButton";
            this.SplitInternalReportButton.Size = new System.Drawing.Size(125, 23);
            this.SplitInternalReportButton.TabIndex = 1;
            this.SplitInternalReportButton.Text = "Split internal report";
            this.SplitInternalReportButton.UseVisualStyleBackColor = true;
            this.SplitInternalReportButton.Click += new System.EventHandler(this.SplitInternalReportButton_Click);
            // 
            // MergeInternalReportButton
            // 
            this.MergeInternalReportButton.Location = new System.Drawing.Point(36, 116);
            this.MergeInternalReportButton.Name = "MergeInternalReportButton";
            this.MergeInternalReportButton.Size = new System.Drawing.Size(120, 25);
            this.MergeInternalReportButton.TabIndex = 2;
            this.MergeInternalReportButton.Text = "MergeInternalReport";
            this.MergeInternalReportButton.UseVisualStyleBackColor = true;
            this.MergeInternalReportButton.Click += new System.EventHandler(this.MergeInternalReportButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SpecialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(348, 305);
            this.Controls.Add(this.MergeInternalReportButton);
            this.Controls.Add(this.SplitInternalReportButton);
            this.Controls.Add(this.MyCancelButton);
            this.Name = "SpecialForm";
            this.Text = "SpecialForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button SplitInternalReportButton;
        private System.Windows.Forms.Button MergeInternalReportButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}