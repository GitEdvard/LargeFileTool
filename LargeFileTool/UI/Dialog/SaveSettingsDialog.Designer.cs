namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class SaveSettingsDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.SettingNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ColumnDelimiterSourceFileLabel = new System.Windows.Forms.Label();
            this.ColumnDelimiterDestinationFileLabel = new System.Windows.Forms.Label();
            this.ColumnOrderLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter a name for this setting:";
            // 
            // SettingNameTextBox
            // 
            this.SettingNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingNameTextBox.Location = new System.Drawing.Point(12, 44);
            this.SettingNameTextBox.Name = "SettingNameTextBox";
            this.SettingNameTextBox.Size = new System.Drawing.Size(397, 20);
            this.SettingNameTextBox.TabIndex = 1;
            this.SettingNameTextBox.TextChanged += new System.EventHandler(this.SettingNameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Column delimiter (source file)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Column delimiter (destination file)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Included columns in destination file";
            // 
            // ColumnDelimiterSourceFileLabel
            // 
            this.ColumnDelimiterSourceFileLabel.AutoSize = true;
            this.ColumnDelimiterSourceFileLabel.Location = new System.Drawing.Point(207, 16);
            this.ColumnDelimiterSourceFileLabel.Name = "ColumnDelimiterSourceFileLabel";
            this.ColumnDelimiterSourceFileLabel.Size = new System.Drawing.Size(45, 13);
            this.ColumnDelimiterSourceFileLabel.TabIndex = 5;
            this.ColumnDelimiterSourceFileLabel.Text = "<value>";
            // 
            // ColumnDelimiterDestinationFileLabel
            // 
            this.ColumnDelimiterDestinationFileLabel.AutoSize = true;
            this.ColumnDelimiterDestinationFileLabel.Location = new System.Drawing.Point(207, 40);
            this.ColumnDelimiterDestinationFileLabel.Name = "ColumnDelimiterDestinationFileLabel";
            this.ColumnDelimiterDestinationFileLabel.Size = new System.Drawing.Size(45, 13);
            this.ColumnDelimiterDestinationFileLabel.TabIndex = 6;
            this.ColumnDelimiterDestinationFileLabel.Text = "<value>";
            // 
            // ColumnOrderLabel
            // 
            this.ColumnOrderLabel.AutoSize = true;
            this.ColumnOrderLabel.Location = new System.Drawing.Point(207, 64);
            this.ColumnOrderLabel.Name = "ColumnOrderLabel";
            this.ColumnOrderLabel.Size = new System.Drawing.Size(45, 13);
            this.ColumnOrderLabel.TabIndex = 7;
            this.ColumnOrderLabel.Text = "<value>";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.Location = new System.Drawing.Point(15, 196);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(334, 196);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 9;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ColumnOrderLabel);
            this.groupBox1.Controls.Add(this.ColumnDelimiterSourceFileLabel);
            this.groupBox1.Controls.Add(this.ColumnDelimiterDestinationFileLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 109);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // SaveSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(421, 231);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SettingNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "SaveSettingsDialog";
            this.Text = "SaveSettingsDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SettingNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ColumnDelimiterSourceFileLabel;
        private System.Windows.Forms.Label ColumnDelimiterDestinationFileLabel;
        private System.Windows.Forms.Label ColumnOrderLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}