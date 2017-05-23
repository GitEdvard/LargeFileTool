namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class GetCommonMarkersFromManifestsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.ParseFileButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ExcludeIntensityOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.SelectManifest2Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Manifest2TextBox = new System.Windows.Forms.TextBox();
            this.InlcudeOnlySNPVariationCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Manifest1TextBox
            // 
            this.Manifest1TextBox.Location = new System.Drawing.Point(33, 41);
            this.Manifest1TextBox.Name = "Manifest1TextBox";
            this.Manifest1TextBox.Size = new System.Drawing.Size(328, 20);
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
            this.SelectManifest1Button.Location = new System.Drawing.Point(367, 39);
            this.SelectManifest1Button.Name = "SelectManifest1Button";
            this.SelectManifest1Button.Size = new System.Drawing.Size(39, 23);
            this.SelectManifest1Button.TabIndex = 2;
            this.SelectManifest1Button.Text = "...";
            this.SelectManifest1Button.UseVisualStyleBackColor = true;
            this.SelectManifest1Button.Click += new System.EventHandler(this.SelectManifestButton_Click);
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
            this.ExcludeIntensityOnlyCheckBox.Location = new System.Drawing.Point(33, 114);
            this.ExcludeIntensityOnlyCheckBox.Name = "ExcludeIntensityOnlyCheckBox";
            this.ExcludeIntensityOnlyCheckBox.Size = new System.Drawing.Size(127, 17);
            this.ExcludeIntensityOnlyCheckBox.TabIndex = 5;
            this.ExcludeIntensityOnlyCheckBox.Text = "Exclude intensity only";
            this.ExcludeIntensityOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // SelectManifest2Button
            // 
            this.SelectManifest2Button.Location = new System.Drawing.Point(367, 86);
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
            this.Manifest2TextBox.Location = new System.Drawing.Point(33, 88);
            this.Manifest2TextBox.Name = "Manifest2TextBox";
            this.Manifest2TextBox.Size = new System.Drawing.Size(328, 20);
            this.Manifest2TextBox.TabIndex = 6;
            // 
            // InlcudeOnlySNPVariationCheckBox
            // 
            this.InlcudeOnlySNPVariationCheckBox.AutoSize = true;
            this.InlcudeOnlySNPVariationCheckBox.Location = new System.Drawing.Point(33, 137);
            this.InlcudeOnlySNPVariationCheckBox.Name = "InlcudeOnlySNPVariationCheckBox";
            this.InlcudeOnlySNPVariationCheckBox.Size = new System.Drawing.Size(173, 17);
            this.InlcudeOnlySNPVariationCheckBox.TabIndex = 9;
            this.InlcudeOnlySNPVariationCheckBox.Text = "Include only with SNP variation";
            this.InlcudeOnlySNPVariationCheckBox.UseVisualStyleBackColor = true;
            // 
            // GetCommonMarkersFromManifestsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(498, 220);
            this.Controls.Add(this.InlcudeOnlySNPVariationCheckBox);
            this.Controls.Add(this.SelectManifest2Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Manifest2TextBox);
            this.Controls.Add(this.ExcludeIntensityOnlyCheckBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ParseFileButton);
            this.Controls.Add(this.SelectManifest1Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Manifest1TextBox);
            this.Name = "GetCommonMarkersFromManifestsDialog";
            this.Text = "GetCommonMarkersDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Manifest1TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectManifest1Button;
        private System.Windows.Forms.Button ParseFileButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.CheckBox ExcludeIntensityOnlyCheckBox;
        private System.Windows.Forms.Button SelectManifest2Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Manifest2TextBox;
        private System.Windows.Forms.CheckBox InlcudeOnlySNPVariationCheckBox;
    }
}