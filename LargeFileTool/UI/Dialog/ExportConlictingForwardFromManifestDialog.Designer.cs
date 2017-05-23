namespace LargeFileTool.UI.Dialog
{
    partial class ExportConlictingForwardFromManifestDialog
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
            this.ManifestNameTextBox = new System.Windows.Forms.TextBox();
            this.ExportNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectManifestButton = new System.Windows.Forms.Button();
            this.ExportFileNameButton = new System.Windows.Forms.Button();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManifestNameTextBox
            // 
            this.ManifestNameTextBox.Location = new System.Drawing.Point(30, 46);
            this.ManifestNameTextBox.Name = "ManifestNameTextBox";
            this.ManifestNameTextBox.Size = new System.Drawing.Size(355, 20);
            this.ManifestNameTextBox.TabIndex = 0;
            // 
            // ExportNameTextBox
            // 
            this.ExportNameTextBox.Location = new System.Drawing.Point(30, 106);
            this.ExportNameTextBox.Name = "ExportNameTextBox";
            this.ExportNameTextBox.Size = new System.Drawing.Size(355, 20);
            this.ExportNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select manifest file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Export to file:";
            // 
            // SelectManifestButton
            // 
            this.SelectManifestButton.Location = new System.Drawing.Point(391, 43);
            this.SelectManifestButton.Name = "SelectManifestButton";
            this.SelectManifestButton.Size = new System.Drawing.Size(41, 25);
            this.SelectManifestButton.TabIndex = 4;
            this.SelectManifestButton.Text = "...";
            this.SelectManifestButton.UseVisualStyleBackColor = true;
            this.SelectManifestButton.Click += new System.EventHandler(this.SelectManifestButton_Click);
            // 
            // ExportFileNameButton
            // 
            this.ExportFileNameButton.Location = new System.Drawing.Point(391, 106);
            this.ExportFileNameButton.Name = "ExportFileNameButton";
            this.ExportFileNameButton.Size = new System.Drawing.Size(38, 20);
            this.ExportFileNameButton.TabIndex = 5;
            this.ExportFileNameButton.Text = "...";
            this.ExportFileNameButton.UseVisualStyleBackColor = true;
            this.ExportFileNameButton.Click += new System.EventHandler(this.ExportFileNameButton_Click);
            // 
            // ExtractButton
            // 
            this.ExtractButton.Location = new System.Drawing.Point(354, 164);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractButton.TabIndex = 6;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // ExportConlictingForwardFromManifest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 215);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.ExportFileNameButton);
            this.Controls.Add(this.SelectManifestButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportNameTextBox);
            this.Controls.Add(this.ManifestNameTextBox);
            this.Name = "ExportConlictingForwardFromManifest";
            this.Text = "ExportConlictingForwardFromManifest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ManifestNameTextBox;
        private System.Windows.Forms.TextBox ExportNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectManifestButton;
        private System.Windows.Forms.Button ExportFileNameButton;
        private System.Windows.Forms.Button ExtractButton;
    }
}