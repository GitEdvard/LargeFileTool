namespace LargeFileTool.UI.Dialog
{
    partial class FindLocusWithManifestDialog
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
            this.FindLocusButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ManifestNameTextBox = new System.Windows.Forms.TextBox();
            this.RootDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.LocusListView = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FindLocusButton
            // 
            this.FindLocusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FindLocusButton.Location = new System.Drawing.Point(12, 412);
            this.FindLocusButton.Name = "FindLocusButton";
            this.FindLocusButton.Size = new System.Drawing.Size(75, 23);
            this.FindLocusButton.TabIndex = 0;
            this.FindLocusButton.Text = "Find Locus";
            this.FindLocusButton.UseVisualStyleBackColor = true;
            this.FindLocusButton.Click += new System.EventHandler(this.FindLocusButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(368, 412);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 1;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manifest name, or part of manifest file name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Root directory:";
            // 
            // ManifestNameTextBox
            // 
            this.ManifestNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManifestNameTextBox.Location = new System.Drawing.Point(12, 58);
            this.ManifestNameTextBox.Name = "ManifestNameTextBox";
            this.ManifestNameTextBox.Size = new System.Drawing.Size(418, 20);
            this.ManifestNameTextBox.TabIndex = 4;
            this.ManifestNameTextBox.TextChanged += new System.EventHandler(this.ManifestNameTextBox_TextChanged);
            // 
            // RootDirectoryTextBox
            // 
            this.RootDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RootDirectoryTextBox.Location = new System.Drawing.Point(12, 113);
            this.RootDirectoryTextBox.Multiline = true;
            this.RootDirectoryTextBox.Name = "RootDirectoryTextBox";
            this.RootDirectoryTextBox.Size = new System.Drawing.Size(418, 109);
            this.RootDirectoryTextBox.TabIndex = 5;
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFolderButton.Location = new System.Drawing.Point(392, 87);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(38, 23);
            this.SelectFolderButton.TabIndex = 6;
            this.SelectFolderButton.Text = "...";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // LocusListView
            // 
            this.LocusListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LocusListView.FullRowSelect = true;
            this.LocusListView.GridLines = true;
            this.LocusListView.Location = new System.Drawing.Point(12, 254);
            this.LocusListView.Name = "LocusListView";
            this.LocusListView.Size = new System.Drawing.Size(418, 141);
            this.LocusListView.TabIndex = 7;
            this.LocusListView.UseCompatibleStateImageBehavior = false;
            this.LocusListView.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Locus files refering to entered manifest:";
            // 
            // FindLocusWithManifestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(455, 447);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LocusListView);
            this.Controls.Add(this.SelectFolderButton);
            this.Controls.Add(this.RootDirectoryTextBox);
            this.Controls.Add(this.ManifestNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.FindLocusButton);
            this.Name = "FindLocusWithManifestDialog";
            this.Text = "Find Locus Files By Manifest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FindLocusButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ManifestNameTextBox;
        private System.Windows.Forms.TextBox RootDirectoryTextBox;
        private System.Windows.Forms.Button SelectFolderButton;
        private System.Windows.Forms.ListView LocusListView;
        private System.Windows.Forms.Label label3;
    }
}