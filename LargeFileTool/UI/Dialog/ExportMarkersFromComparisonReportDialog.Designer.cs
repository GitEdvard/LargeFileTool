namespace LargeFileTool.UI.Dialog
{
    partial class ExportMarkersFromComparisonReportDialog
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
            this.ExportButton = new System.Windows.Forms.Button();
            this.MyCloseButton = new System.Windows.Forms.Button();
            this.Manifest1NameTextBox = new System.Windows.Forms.TextBox();
            this.ManifestFile2TextBox = new System.Windows.Forms.TextBox();
            this.ComparisonFileFolderTextBox = new System.Windows.Forms.TextBox();
            this.OutputFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Manifest1NameButton = new System.Windows.Forms.Button();
            this.Manifest2NameButton = new System.Windows.Forms.Button();
            this.ComparisonFileFolderButton = new System.Windows.Forms.Button();
            this.OutputFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportButton.Location = new System.Drawing.Point(12, 350);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 0;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // MyCloseButton
            // 
            this.MyCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCloseButton.Location = new System.Drawing.Point(464, 350);
            this.MyCloseButton.Name = "MyCloseButton";
            this.MyCloseButton.Size = new System.Drawing.Size(75, 23);
            this.MyCloseButton.TabIndex = 1;
            this.MyCloseButton.Text = "Close";
            this.MyCloseButton.UseVisualStyleBackColor = true;
            this.MyCloseButton.Click += new System.EventHandler(this.MyCloseButton_Click);
            // 
            // Manifest1NameTextBox
            // 
            this.Manifest1NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manifest1NameTextBox.Location = new System.Drawing.Point(12, 45);
            this.Manifest1NameTextBox.Name = "Manifest1NameTextBox";
            this.Manifest1NameTextBox.Size = new System.Drawing.Size(481, 20);
            this.Manifest1NameTextBox.TabIndex = 2;
            // 
            // ManifestFile2TextBox
            // 
            this.ManifestFile2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManifestFile2TextBox.Location = new System.Drawing.Point(12, 98);
            this.ManifestFile2TextBox.Name = "ManifestFile2TextBox";
            this.ManifestFile2TextBox.Size = new System.Drawing.Size(481, 20);
            this.ManifestFile2TextBox.TabIndex = 3;
            // 
            // ComparisonFileFolderTextBox
            // 
            this.ComparisonFileFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComparisonFileFolderTextBox.Location = new System.Drawing.Point(12, 147);
            this.ComparisonFileFolderTextBox.Name = "ComparisonFileFolderTextBox";
            this.ComparisonFileFolderTextBox.Size = new System.Drawing.Size(481, 20);
            this.ComparisonFileFolderTextBox.TabIndex = 4;
            // 
            // OutputFileTextBox
            // 
            this.OutputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFileTextBox.Location = new System.Drawing.Point(12, 201);
            this.OutputFileTextBox.Name = "OutputFileTextBox";
            this.OutputFileTextBox.Size = new System.Drawing.Size(481, 20);
            this.OutputFileTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Manifest 1 name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Manifest 2 name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Comparison file folder:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Output file:";
            // 
            // Manifest1NameButton
            // 
            this.Manifest1NameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Manifest1NameButton.Location = new System.Drawing.Point(499, 45);
            this.Manifest1NameButton.Name = "Manifest1NameButton";
            this.Manifest1NameButton.Size = new System.Drawing.Size(40, 20);
            this.Manifest1NameButton.TabIndex = 10;
            this.Manifest1NameButton.Text = "...";
            this.Manifest1NameButton.UseVisualStyleBackColor = true;
            this.Manifest1NameButton.Click += new System.EventHandler(this.Manifest1NameButton_Click);
            // 
            // Manifest2NameButton
            // 
            this.Manifest2NameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Manifest2NameButton.Location = new System.Drawing.Point(499, 98);
            this.Manifest2NameButton.Name = "Manifest2NameButton";
            this.Manifest2NameButton.Size = new System.Drawing.Size(40, 20);
            this.Manifest2NameButton.TabIndex = 11;
            this.Manifest2NameButton.Text = "...";
            this.Manifest2NameButton.UseVisualStyleBackColor = true;
            this.Manifest2NameButton.Click += new System.EventHandler(this.Manifest2NameButton_Click);
            // 
            // ComparisonFileFolderButton
            // 
            this.ComparisonFileFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComparisonFileFolderButton.Location = new System.Drawing.Point(499, 147);
            this.ComparisonFileFolderButton.Name = "ComparisonFileFolderButton";
            this.ComparisonFileFolderButton.Size = new System.Drawing.Size(40, 20);
            this.ComparisonFileFolderButton.TabIndex = 12;
            this.ComparisonFileFolderButton.Text = "...";
            this.ComparisonFileFolderButton.UseVisualStyleBackColor = true;
            this.ComparisonFileFolderButton.Click += new System.EventHandler(this.ComparisonFileFolderButton_Click);
            // 
            // OutputFileButton
            // 
            this.OutputFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFileButton.Location = new System.Drawing.Point(499, 201);
            this.OutputFileButton.Name = "OutputFileButton";
            this.OutputFileButton.Size = new System.Drawing.Size(40, 20);
            this.OutputFileButton.TabIndex = 13;
            this.OutputFileButton.Text = "...";
            this.OutputFileButton.UseVisualStyleBackColor = true;
            this.OutputFileButton.Click += new System.EventHandler(this.OutputFileButton_Click);
            // 
            // ExportMarkersFromComparisonReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCloseButton;
            this.ClientSize = new System.Drawing.Size(551, 385);
            this.Controls.Add(this.OutputFileButton);
            this.Controls.Add(this.ComparisonFileFolderButton);
            this.Controls.Add(this.Manifest2NameButton);
            this.Controls.Add(this.Manifest1NameButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputFileTextBox);
            this.Controls.Add(this.ComparisonFileFolderTextBox);
            this.Controls.Add(this.ManifestFile2TextBox);
            this.Controls.Add(this.Manifest1NameTextBox);
            this.Controls.Add(this.MyCloseButton);
            this.Controls.Add(this.ExportButton);
            this.Name = "ExportMarkersFromComparisonReportDialog";
            this.Text = "ExportMarkersFromComparisonReportDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button MyCloseButton;
        private System.Windows.Forms.TextBox Manifest1NameTextBox;
        private System.Windows.Forms.TextBox ManifestFile2TextBox;
        private System.Windows.Forms.TextBox ComparisonFileFolderTextBox;
        private System.Windows.Forms.TextBox OutputFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Manifest1NameButton;
        private System.Windows.Forms.Button Manifest2NameButton;
        private System.Windows.Forms.Button ComparisonFileFolderButton;
        private System.Windows.Forms.Button OutputFileButton;
    }
}