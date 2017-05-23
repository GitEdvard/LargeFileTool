namespace LargeFileTool.UI.Dialog
{
    partial class GetConflictsInPlusVCF_ManifestDialog
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
            this.ExportConflictsButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.ManifestFileTextBox = new System.Windows.Forms.TextBox();
            this.VCFFileTextBox = new System.Windows.Forms.TextBox();
            this.OutputFolderTextBox = new System.Windows.Forms.TextBox();
            this.SelectedMarkersTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectManifestButton = new System.Windows.Forms.Button();
            this.SelectVCFFileButton = new System.Windows.Forms.Button();
            this.SelectMarkersButton = new System.Windows.Forms.Button();
            this.OutputFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExportConflictsButton
            // 
            this.ExportConflictsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportConflictsButton.Location = new System.Drawing.Point(12, 260);
            this.ExportConflictsButton.Name = "ExportConflictsButton";
            this.ExportConflictsButton.Size = new System.Drawing.Size(94, 23);
            this.ExportConflictsButton.TabIndex = 0;
            this.ExportConflictsButton.Text = "Export conflicts";
            this.ExportConflictsButton.UseVisualStyleBackColor = true;
            this.ExportConflictsButton.Click += new System.EventHandler(this.ExportConflictsButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(338, 260);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 1;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // ManifestFileTextBox
            // 
            this.ManifestFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManifestFileTextBox.Location = new System.Drawing.Point(12, 47);
            this.ManifestFileTextBox.Name = "ManifestFileTextBox";
            this.ManifestFileTextBox.Size = new System.Drawing.Size(357, 20);
            this.ManifestFileTextBox.TabIndex = 2;
            // 
            // VCFFileTextBox
            // 
            this.VCFFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VCFFileTextBox.Location = new System.Drawing.Point(12, 92);
            this.VCFFileTextBox.Name = "VCFFileTextBox";
            this.VCFFileTextBox.Size = new System.Drawing.Size(357, 20);
            this.VCFFileTextBox.TabIndex = 3;
            // 
            // OutputFolderTextBox
            // 
            this.OutputFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFolderTextBox.Location = new System.Drawing.Point(12, 176);
            this.OutputFolderTextBox.Name = "OutputFolderTextBox";
            this.OutputFolderTextBox.Size = new System.Drawing.Size(357, 20);
            this.OutputFolderTextBox.TabIndex = 4;
            // 
            // SelectedMarkersTextBox
            // 
            this.SelectedMarkersTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedMarkersTextBox.Location = new System.Drawing.Point(12, 133);
            this.SelectedMarkersTextBox.Name = "SelectedMarkersTextBox";
            this.SelectedMarkersTextBox.Size = new System.Drawing.Size(357, 20);
            this.SelectedMarkersTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Manifest file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "VCF base reference file:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Marker list path (optional):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Output directory:";
            // 
            // SelectManifestButton
            // 
            this.SelectManifestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectManifestButton.Location = new System.Drawing.Point(375, 45);
            this.SelectManifestButton.Name = "SelectManifestButton";
            this.SelectManifestButton.Size = new System.Drawing.Size(38, 23);
            this.SelectManifestButton.TabIndex = 10;
            this.SelectManifestButton.Text = "...";
            this.SelectManifestButton.UseVisualStyleBackColor = true;
            this.SelectManifestButton.Click += new System.EventHandler(this.SelectManifestButton_Click);
            // 
            // SelectVCFFileButton
            // 
            this.SelectVCFFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectVCFFileButton.Location = new System.Drawing.Point(375, 90);
            this.SelectVCFFileButton.Name = "SelectVCFFileButton";
            this.SelectVCFFileButton.Size = new System.Drawing.Size(38, 23);
            this.SelectVCFFileButton.TabIndex = 11;
            this.SelectVCFFileButton.Text = "...";
            this.SelectVCFFileButton.UseVisualStyleBackColor = true;
            this.SelectVCFFileButton.Click += new System.EventHandler(this.SelectVCFFileButton_Click);
            // 
            // SelectMarkersButton
            // 
            this.SelectMarkersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectMarkersButton.Location = new System.Drawing.Point(375, 131);
            this.SelectMarkersButton.Name = "SelectMarkersButton";
            this.SelectMarkersButton.Size = new System.Drawing.Size(38, 23);
            this.SelectMarkersButton.TabIndex = 12;
            this.SelectMarkersButton.Text = "...";
            this.SelectMarkersButton.UseVisualStyleBackColor = true;
            this.SelectMarkersButton.Click += new System.EventHandler(this.SelectMarkersButton_Click);
            // 
            // OutputFolderButton
            // 
            this.OutputFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFolderButton.Location = new System.Drawing.Point(375, 174);
            this.OutputFolderButton.Name = "OutputFolderButton";
            this.OutputFolderButton.Size = new System.Drawing.Size(38, 23);
            this.OutputFolderButton.TabIndex = 13;
            this.OutputFolderButton.Text = "...";
            this.OutputFolderButton.UseVisualStyleBackColor = true;
            this.OutputFolderButton.Click += new System.EventHandler(this.OutputFolderButton_Click);
            // 
            // GetConflictsInPlusVCF_ManifestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(425, 295);
            this.Controls.Add(this.OutputFolderButton);
            this.Controls.Add(this.SelectMarkersButton);
            this.Controls.Add(this.SelectVCFFileButton);
            this.Controls.Add(this.SelectManifestButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedMarkersTextBox);
            this.Controls.Add(this.OutputFolderTextBox);
            this.Controls.Add(this.VCFFileTextBox);
            this.Controls.Add(this.ManifestFileTextBox);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.ExportConflictsButton);
            this.Name = "GetConflictsInPlusVCF_ManifestDialog";
            this.Text = "GetConflictsInPlusVCF_ManifestDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExportConflictsButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.TextBox ManifestFileTextBox;
        private System.Windows.Forms.TextBox VCFFileTextBox;
        private System.Windows.Forms.TextBox OutputFolderTextBox;
        private System.Windows.Forms.TextBox SelectedMarkersTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SelectManifestButton;
        private System.Windows.Forms.Button SelectVCFFileButton;
        private System.Windows.Forms.Button SelectMarkersButton;
        private System.Windows.Forms.Button OutputFolderButton;
    }
}