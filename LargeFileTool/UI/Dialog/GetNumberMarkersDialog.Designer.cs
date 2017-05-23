namespace LargeFileTool.UI.Dialog
{
    partial class GetNumberMarkersDialog
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
            this.ManifestTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectManifestButton = new System.Windows.Forms.Button();
            this.ParseFileButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ExcludeIntensityOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.OnlyAlleleCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ManifestTextBox
            // 
            this.ManifestTextBox.Location = new System.Drawing.Point(35, 86);
            this.ManifestTextBox.Name = "ManifestTextBox";
            this.ManifestTextBox.Size = new System.Drawing.Size(328, 20);
            this.ManifestTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manifest:";
            // 
            // SelectManifestButton
            // 
            this.SelectManifestButton.Location = new System.Drawing.Point(369, 84);
            this.SelectManifestButton.Name = "SelectManifestButton";
            this.SelectManifestButton.Size = new System.Drawing.Size(39, 23);
            this.SelectManifestButton.TabIndex = 2;
            this.SelectManifestButton.Text = "...";
            this.SelectManifestButton.UseVisualStyleBackColor = true;
            this.SelectManifestButton.Click += new System.EventHandler(this.SelectManifestButton_Click);
            // 
            // ParseFileButton
            // 
            this.ParseFileButton.Location = new System.Drawing.Point(21, 173);
            this.ParseFileButton.Name = "ParseFileButton";
            this.ParseFileButton.Size = new System.Drawing.Size(79, 26);
            this.ParseFileButton.TabIndex = 3;
            this.ParseFileButton.Text = "Parse file";
            this.ParseFileButton.UseVisualStyleBackColor = true;
            this.ParseFileButton.Click += new System.EventHandler(this.ParseFileButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(406, 175);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // ExcludeIntensityOnlyCheckBox
            // 
            this.ExcludeIntensityOnlyCheckBox.AutoSize = true;
            this.ExcludeIntensityOnlyCheckBox.Location = new System.Drawing.Point(35, 112);
            this.ExcludeIntensityOnlyCheckBox.Name = "ExcludeIntensityOnlyCheckBox";
            this.ExcludeIntensityOnlyCheckBox.Size = new System.Drawing.Size(127, 17);
            this.ExcludeIntensityOnlyCheckBox.TabIndex = 5;
            this.ExcludeIntensityOnlyCheckBox.Text = "Exclude intensity only";
            this.ExcludeIntensityOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // OnlyAlleleCheckBox
            // 
            this.OnlyAlleleCheckBox.AutoSize = true;
            this.OnlyAlleleCheckBox.Location = new System.Drawing.Point(35, 135);
            this.OnlyAlleleCheckBox.Name = "OnlyAlleleCheckBox";
            this.OnlyAlleleCheckBox.Size = new System.Drawing.Size(168, 17);
            this.OnlyAlleleCheckBox.TabIndex = 6;
            this.OnlyAlleleCheckBox.Text = "Count only with allele variation";
            this.OnlyAlleleCheckBox.UseVisualStyleBackColor = true;
            // 
            // GetNumberMarkersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(498, 220);
            this.Controls.Add(this.OnlyAlleleCheckBox);
            this.Controls.Add(this.ExcludeIntensityOnlyCheckBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ParseFileButton);
            this.Controls.Add(this.SelectManifestButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ManifestTextBox);
            this.Name = "GetNumberMarkersDialog";
            this.Text = "GetNumberMarkersDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ManifestTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectManifestButton;
        private System.Windows.Forms.Button ParseFileButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.CheckBox ExcludeIntensityOnlyCheckBox;
        private System.Windows.Forms.CheckBox OnlyAlleleCheckBox;
    }
}