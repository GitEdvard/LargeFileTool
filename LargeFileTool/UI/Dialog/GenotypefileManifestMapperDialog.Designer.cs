namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class GenotypefileManifestMapperDialog
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
            this.GenotypeFileTextBox = new System.Windows.Forms.TextBox();
            this.ManifestFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FindButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.GetGenotypeFileButton = new System.Windows.Forms.Button();
            this.GetManifestFileButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ExportMarkersButton = new System.Windows.Forms.Button();
            this.ConflictMarkerFileTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ConflictMarkerFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenotypeFileTextBox
            // 
            this.GenotypeFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GenotypeFileTextBox.Location = new System.Drawing.Point(12, 58);
            this.GenotypeFileTextBox.Name = "GenotypeFileTextBox";
            this.GenotypeFileTextBox.Size = new System.Drawing.Size(446, 20);
            this.GenotypeFileTextBox.TabIndex = 0;
            // 
            // ManifestFileTextBox
            // 
            this.ManifestFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManifestFileTextBox.Location = new System.Drawing.Point(12, 115);
            this.ManifestFileTextBox.Name = "ManifestFileTextBox";
            this.ManifestFileTextBox.Size = new System.Drawing.Size(446, 20);
            this.ManifestFileTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Genotypefile:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Manifest file:";
            // 
            // FindButton
            // 
            this.FindButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FindButton.Location = new System.Drawing.Point(12, 336);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(67, 27);
            this.FindButton.TabIndex = 4;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(441, 336);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(67, 27);
            this.MyCancelButton.TabIndex = 5;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // GetGenotypeFileButton
            // 
            this.GetGenotypeFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetGenotypeFileButton.Location = new System.Drawing.Point(464, 58);
            this.GetGenotypeFileButton.Name = "GetGenotypeFileButton";
            this.GetGenotypeFileButton.Size = new System.Drawing.Size(44, 20);
            this.GetGenotypeFileButton.TabIndex = 6;
            this.GetGenotypeFileButton.Text = "...";
            this.GetGenotypeFileButton.UseVisualStyleBackColor = true;
            this.GetGenotypeFileButton.Click += new System.EventHandler(this.GetGenotypeFileButton_Click);
            // 
            // GetManifestFileButton
            // 
            this.GetManifestFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetManifestFileButton.Location = new System.Drawing.Point(464, 115);
            this.GetManifestFileButton.Name = "GetManifestFileButton";
            this.GetManifestFileButton.Size = new System.Drawing.Size(44, 20);
            this.GetManifestFileButton.TabIndex = 7;
            this.GetManifestFileButton.Text = "...";
            this.GetManifestFileButton.UseVisualStyleBackColor = true;
            this.GetManifestFileButton.Click += new System.EventHandler(this.GetManifestFileButton_Click);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTextBox.Location = new System.Drawing.Point(12, 244);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(496, 86);
            this.ResultTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Result:";
            // 
            // ExportMarkersButton
            // 
            this.ExportMarkersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportMarkersButton.Location = new System.Drawing.Point(396, 215);
            this.ExportMarkersButton.Name = "ExportMarkersButton";
            this.ExportMarkersButton.Size = new System.Drawing.Size(112, 23);
            this.ExportMarkersButton.TabIndex = 10;
            this.ExportMarkersButton.Text = "Export markers ...";
            this.ExportMarkersButton.UseVisualStyleBackColor = true;
            this.ExportMarkersButton.Click += new System.EventHandler(this.ExportMarkersButton_Click);
            // 
            // ConflictMarkerFileTextBox
            // 
            this.ConflictMarkerFileTextBox.Location = new System.Drawing.Point(12, 165);
            this.ConflictMarkerFileTextBox.Name = "ConflictMarkerFileTextBox";
            this.ConflictMarkerFileTextBox.Size = new System.Drawing.Size(446, 20);
            this.ConflictMarkerFileTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Export conflicting markers to file (optional):";
            // 
            // ConflictMarkerFileButton
            // 
            this.ConflictMarkerFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConflictMarkerFileButton.Location = new System.Drawing.Point(464, 165);
            this.ConflictMarkerFileButton.Name = "ConflictMarkerFileButton";
            this.ConflictMarkerFileButton.Size = new System.Drawing.Size(44, 20);
            this.ConflictMarkerFileButton.TabIndex = 13;
            this.ConflictMarkerFileButton.Text = "...";
            this.ConflictMarkerFileButton.UseVisualStyleBackColor = true;
            this.ConflictMarkerFileButton.Click += new System.EventHandler(this.ConflictMarkerFileButton_Click);
            // 
            // GenotypefileManifestMapperDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(520, 375);
            this.Controls.Add(this.ConflictMarkerFileButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ConflictMarkerFileTextBox);
            this.Controls.Add(this.ExportMarkersButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.GetManifestFileButton);
            this.Controls.Add(this.GetGenotypeFileButton);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ManifestFileTextBox);
            this.Controls.Add(this.GenotypeFileTextBox);
            this.Name = "GenotypefileManifestMapperDialog";
            this.Text = "GenotypefileManifestMapperDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GenotypeFileTextBox;
        private System.Windows.Forms.TextBox ManifestFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button GetGenotypeFileButton;
        private System.Windows.Forms.Button GetManifestFileButton;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ExportMarkersButton;
        private System.Windows.Forms.TextBox ConflictMarkerFileTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ConflictMarkerFileButton;
    }
}