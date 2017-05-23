namespace LargeFileTool.UI.Dialog
{
    partial class GetConflictMarkersDialog
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
            this.Manifest1TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectManifest1Button = new System.Windows.Forms.Button();
            this.ExportConflictsButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SelectManifest2Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Manifest2TextBox = new System.Windows.Forms.TextBox();
            this.MarkerListFileTextBox = new System.Windows.Forms.TextBox();
            this.ConflictReportFileTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MarkerListButton = new System.Windows.Forms.Button();
            this.ConflictReportFileButton = new System.Windows.Forms.Button();
            this.SummaryFileButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SummaryFileTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Manifest1TextBox
            // 
            this.Manifest1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manifest1TextBox.Location = new System.Drawing.Point(33, 41);
            this.Manifest1TextBox.Name = "Manifest1TextBox";
            this.Manifest1TextBox.Size = new System.Drawing.Size(368, 20);
            this.Manifest1TextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manifest 1:";
            // 
            // SelectManifest1Button
            // 
            this.SelectManifest1Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectManifest1Button.Location = new System.Drawing.Point(407, 39);
            this.SelectManifest1Button.Name = "SelectManifest1Button";
            this.SelectManifest1Button.Size = new System.Drawing.Size(39, 23);
            this.SelectManifest1Button.TabIndex = 2;
            this.SelectManifest1Button.Text = "...";
            this.SelectManifest1Button.UseVisualStyleBackColor = true;
            this.SelectManifest1Button.Click += new System.EventHandler(this.SelectManifestButton_Click);
            // 
            // ExportConflictsButton
            // 
            this.ExportConflictsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportConflictsButton.Location = new System.Drawing.Point(21, 334);
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
            this.CloseButton.Location = new System.Drawing.Point(383, 336);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // SelectManifest2Button
            // 
            this.SelectManifest2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectManifest2Button.Location = new System.Drawing.Point(407, 86);
            this.SelectManifest2Button.Name = "SelectManifest2Button";
            this.SelectManifest2Button.Size = new System.Drawing.Size(39, 23);
            this.SelectManifest2Button.TabIndex = 8;
            this.SelectManifest2Button.Text = "...";
            this.SelectManifest2Button.UseVisualStyleBackColor = true;
            this.SelectManifest2Button.Click += new System.EventHandler(this.SelectManifest2Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Manifest 2:";
            // 
            // Manifest2TextBox
            // 
            this.Manifest2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manifest2TextBox.Location = new System.Drawing.Point(33, 88);
            this.Manifest2TextBox.Name = "Manifest2TextBox";
            this.Manifest2TextBox.Size = new System.Drawing.Size(368, 20);
            this.Manifest2TextBox.TabIndex = 6;
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
            // ConflictReportFileTextBox
            // 
            this.ConflictReportFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConflictReportFileTextBox.Location = new System.Drawing.Point(33, 188);
            this.ConflictReportFileTextBox.Name = "ConflictReportFileTextBox";
            this.ConflictReportFileTextBox.Size = new System.Drawing.Size(368, 20);
            this.ConflictReportFileTextBox.TabIndex = 10;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Conflict Report file";
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
            // ConflictReportFileButton
            // 
            this.ConflictReportFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConflictReportFileButton.Location = new System.Drawing.Point(407, 186);
            this.ConflictReportFileButton.Name = "ConflictReportFileButton";
            this.ConflictReportFileButton.Size = new System.Drawing.Size(39, 23);
            this.ConflictReportFileButton.TabIndex = 14;
            this.ConflictReportFileButton.Text = "...";
            this.ConflictReportFileButton.UseVisualStyleBackColor = true;
            this.ConflictReportFileButton.Click += new System.EventHandler(this.ConflictReportFileButton_Click);
            // 
            // SummaryFileButton
            // 
            this.SummaryFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SummaryFileButton.Location = new System.Drawing.Point(407, 235);
            this.SummaryFileButton.Name = "SummaryFileButton";
            this.SummaryFileButton.Size = new System.Drawing.Size(39, 23);
            this.SummaryFileButton.TabIndex = 17;
            this.SummaryFileButton.Text = "...";
            this.SummaryFileButton.UseVisualStyleBackColor = true;
            this.SummaryFileButton.Click += new System.EventHandler(this.SummaryFileButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Summary file:";
            // 
            // SummaryFileTextBox
            // 
            this.SummaryFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SummaryFileTextBox.Location = new System.Drawing.Point(33, 237);
            this.SummaryFileTextBox.Name = "SummaryFileTextBox";
            this.SummaryFileTextBox.Size = new System.Drawing.Size(368, 20);
            this.SummaryFileTextBox.TabIndex = 15;
            // 
            // GetConflictMarkersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(475, 381);
            this.Controls.Add(this.SummaryFileButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SummaryFileTextBox);
            this.Controls.Add(this.ConflictReportFileButton);
            this.Controls.Add(this.MarkerListButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConflictReportFileTextBox);
            this.Controls.Add(this.MarkerListFileTextBox);
            this.Controls.Add(this.SelectManifest2Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Manifest2TextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ExportConflictsButton);
            this.Controls.Add(this.SelectManifest1Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Manifest1TextBox);
            this.Name = "GetConflictMarkersDialog";
            this.Text = "Export plus strand conflicts in manifests ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Manifest1TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectManifest1Button;
        private System.Windows.Forms.Button ExportConflictsButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button SelectManifest2Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Manifest2TextBox;
        private System.Windows.Forms.TextBox MarkerListFileTextBox;
        private System.Windows.Forms.TextBox ConflictReportFileTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button MarkerListButton;
        private System.Windows.Forms.Button ConflictReportFileButton;
        private System.Windows.Forms.Button SummaryFileButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SummaryFileTextBox;
    }
}