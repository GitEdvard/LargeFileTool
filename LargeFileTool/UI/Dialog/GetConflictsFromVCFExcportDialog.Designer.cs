namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class GetConflictsFromVCFExcportDialog
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
            this.CalculateConflictsButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.VCFExportFileTextBox = new System.Windows.Forms.TextBox();
            this.OutputFolderTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GetVCFFileButton = new System.Windows.Forms.Button();
            this.OutputFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CalculateConflictsButton
            // 
            this.CalculateConflictsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CalculateConflictsButton.Location = new System.Drawing.Point(12, 256);
            this.CalculateConflictsButton.Name = "CalculateConflictsButton";
            this.CalculateConflictsButton.Size = new System.Drawing.Size(110, 23);
            this.CalculateConflictsButton.TabIndex = 0;
            this.CalculateConflictsButton.Text = "Calculate conflicts";
            this.CalculateConflictsButton.UseVisualStyleBackColor = true;
            this.CalculateConflictsButton.Click += new System.EventHandler(this.CalculateConflictsButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(408, 256);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 1;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // VCFExportFileTextBox
            // 
            this.VCFExportFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VCFExportFileTextBox.Location = new System.Drawing.Point(12, 50);
            this.VCFExportFileTextBox.Name = "VCFExportFileTextBox";
            this.VCFExportFileTextBox.Size = new System.Drawing.Size(431, 20);
            this.VCFExportFileTextBox.TabIndex = 2;
            // 
            // OutputFolderTextBox
            // 
            this.OutputFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFolderTextBox.Location = new System.Drawing.Point(12, 108);
            this.OutputFolderTextBox.Name = "OutputFolderTextBox";
            this.OutputFolderTextBox.Size = new System.Drawing.Size(431, 20);
            this.OutputFolderTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "VCF export file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output folder:";
            // 
            // GetVCFFileButton
            // 
            this.GetVCFFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetVCFFileButton.Location = new System.Drawing.Point(449, 49);
            this.GetVCFFileButton.Name = "GetVCFFileButton";
            this.GetVCFFileButton.Size = new System.Drawing.Size(34, 20);
            this.GetVCFFileButton.TabIndex = 6;
            this.GetVCFFileButton.Text = "...";
            this.GetVCFFileButton.UseVisualStyleBackColor = true;
            this.GetVCFFileButton.Click += new System.EventHandler(this.GetVCFFileButton_Click);
            // 
            // OutputFolderButton
            // 
            this.OutputFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFolderButton.Location = new System.Drawing.Point(449, 108);
            this.OutputFolderButton.Name = "OutputFolderButton";
            this.OutputFolderButton.Size = new System.Drawing.Size(34, 20);
            this.OutputFolderButton.TabIndex = 7;
            this.OutputFolderButton.Text = "...";
            this.OutputFolderButton.UseVisualStyleBackColor = true;
            this.OutputFolderButton.Click += new System.EventHandler(this.OutputFolderButton_Click);
            // 
            // GetConflictsFromVCFExcportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(495, 291);
            this.Controls.Add(this.OutputFolderButton);
            this.Controls.Add(this.GetVCFFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputFolderTextBox);
            this.Controls.Add(this.VCFExportFileTextBox);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.CalculateConflictsButton);
            this.Name = "GetConflictsFromVCFExcportDialog";
            this.Text = "GetConflictsFromVCFExcportDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CalculateConflictsButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.TextBox VCFExportFileTextBox;
        private System.Windows.Forms.TextBox OutputFolderTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetVCFFileButton;
        private System.Windows.Forms.Button OutputFolderButton;
    }
}