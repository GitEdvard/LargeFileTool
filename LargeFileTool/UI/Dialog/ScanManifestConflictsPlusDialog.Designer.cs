namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class ScanManifestConflictsPlusDialog
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
            this.ManifestDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectManifestDirectoryButton = new System.Windows.Forms.Button();
            this.ExportConflictsButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SelectOutputDirectoryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.MarkerListFileTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MarkerListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManifestDirectoryTextBox
            // 
            this.ManifestDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManifestDirectoryTextBox.Location = new System.Drawing.Point(33, 41);
            this.ManifestDirectoryTextBox.Name = "ManifestDirectoryTextBox";
            this.ManifestDirectoryTextBox.Size = new System.Drawing.Size(368, 20);
            this.ManifestDirectoryTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Directory containing manifest files:";
            // 
            // SelectManifestDirectoryButton
            // 
            this.SelectManifestDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectManifestDirectoryButton.Location = new System.Drawing.Point(407, 39);
            this.SelectManifestDirectoryButton.Name = "SelectManifestDirectoryButton";
            this.SelectManifestDirectoryButton.Size = new System.Drawing.Size(39, 23);
            this.SelectManifestDirectoryButton.TabIndex = 2;
            this.SelectManifestDirectoryButton.Text = "...";
            this.SelectManifestDirectoryButton.UseVisualStyleBackColor = true;
            this.SelectManifestDirectoryButton.Click += new System.EventHandler(this.SelectManifestDirectoryButton_Click);
            // 
            // ExportConflictsButton
            // 
            this.ExportConflictsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportConflictsButton.Location = new System.Drawing.Point(21, 235);
            this.ExportConflictsButton.Name = "ExportConflictsButton";
            this.ExportConflictsButton.Size = new System.Drawing.Size(102, 26);
            this.ExportConflictsButton.TabIndex = 3;
            this.ExportConflictsButton.Text = "Export conflicts";
            this.ExportConflictsButton.UseVisualStyleBackColor = true;
            this.ExportConflictsButton.Click += new System.EventHandler(this.ExportConflictsButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(383, 237);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // SelectOutputDirectoryButton
            // 
            this.SelectOutputDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectOutputDirectoryButton.Location = new System.Drawing.Point(407, 86);
            this.SelectOutputDirectoryButton.Name = "SelectOutputDirectoryButton";
            this.SelectOutputDirectoryButton.Size = new System.Drawing.Size(39, 23);
            this.SelectOutputDirectoryButton.TabIndex = 8;
            this.SelectOutputDirectoryButton.Text = "...";
            this.SelectOutputDirectoryButton.UseVisualStyleBackColor = true;
            this.SelectOutputDirectoryButton.Click += new System.EventHandler(this.SelectOutputDirectoryButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Output directory:";
            // 
            // OutputDirectoryTextBox
            // 
            this.OutputDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputDirectoryTextBox.Location = new System.Drawing.Point(33, 88);
            this.OutputDirectoryTextBox.Name = "OutputDirectoryTextBox";
            this.OutputDirectoryTextBox.Size = new System.Drawing.Size(368, 20);
            this.OutputDirectoryTextBox.TabIndex = 6;
            // 
            // MarkerListFileTextBox
            // 
            this.MarkerListFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MarkerListFileTextBox.Location = new System.Drawing.Point(33, 137);
            this.MarkerListFileTextBox.Name = "MarkerListFileTextBox";
            this.MarkerListFileTextBox.Size = new System.Drawing.Size(368, 20);
            this.MarkerListFileTextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Marker list (only check markers from this file, optional)";
            // 
            // MarkerListButton
            // 
            this.MarkerListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MarkerListButton.Location = new System.Drawing.Point(407, 135);
            this.MarkerListButton.Name = "MarkerListButton";
            this.MarkerListButton.Size = new System.Drawing.Size(39, 23);
            this.MarkerListButton.TabIndex = 13;
            this.MarkerListButton.Text = "...";
            this.MarkerListButton.UseVisualStyleBackColor = true;
            this.MarkerListButton.Click += new System.EventHandler(this.MarkerListButton_Click);
            // 
            // ScanManifestConflictsPlusDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(475, 282);
            this.Controls.Add(this.MarkerListButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MarkerListFileTextBox);
            this.Controls.Add(this.SelectOutputDirectoryButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OutputDirectoryTextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ExportConflictsButton);
            this.Controls.Add(this.SelectManifestDirectoryButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ManifestDirectoryTextBox);
            this.Name = "ScanManifestConflictsPlusDialog";
            this.Text = "Scan manifests for  plus strand conflicts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ManifestDirectoryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectManifestDirectoryButton;
        private System.Windows.Forms.Button ExportConflictsButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button SelectOutputDirectoryButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OutputDirectoryTextBox;
        private System.Windows.Forms.TextBox MarkerListFileTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button MarkerListButton;
    }
}