namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class ExtractRowsFromFilesDialog
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
            this.ExtractButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.KeyListFileTextBox = new System.Windows.Forms.TextBox();
            this.File1PathTextBox = new System.Windows.Forms.TextBox();
            this.File2PathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.File2Button = new System.Windows.Forms.Button();
            this.KeyFileButton = new System.Windows.Forms.Button();
            this.File1Button = new System.Windows.Forms.Button();
            this.File1DelimiterTextBox = new System.Windows.Forms.TextBox();
            this.File1SearchColumnIndexTextBox = new System.Windows.Forms.TextBox();
            this.File2SearchColumnIndexTextBox = new System.Windows.Forms.TextBox();
            this.File2DelimiterTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.OutputFolderTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.OutputFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExtractButton
            // 
            this.ExtractButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExtractButton.Location = new System.Drawing.Point(12, 393);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractButton.TabIndex = 0;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(350, 393);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 1;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // KeyListFileTextBox
            // 
            this.KeyListFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyListFileTextBox.Location = new System.Drawing.Point(12, 44);
            this.KeyListFileTextBox.Name = "KeyListFileTextBox";
            this.KeyListFileTextBox.Size = new System.Drawing.Size(372, 20);
            this.KeyListFileTextBox.TabIndex = 2;
            // 
            // File1PathTextBox
            // 
            this.File1PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.File1PathTextBox.Location = new System.Drawing.Point(12, 99);
            this.File1PathTextBox.Name = "File1PathTextBox";
            this.File1PathTextBox.Size = new System.Drawing.Size(372, 20);
            this.File1PathTextBox.TabIndex = 3;
            // 
            // File2PathTextBox
            // 
            this.File2PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.File2PathTextBox.Location = new System.Drawing.Point(12, 198);
            this.File2PathTextBox.Name = "File2PathTextBox";
            this.File2PathTextBox.Size = new System.Drawing.Size(372, 20);
            this.File2PathTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key list file (rows matching this list will be extracted):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "File 1 path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File 2 path (optional):";
            // 
            // File2Button
            // 
            this.File2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.File2Button.Location = new System.Drawing.Point(390, 199);
            this.File2Button.Name = "File2Button";
            this.File2Button.Size = new System.Drawing.Size(35, 19);
            this.File2Button.TabIndex = 10;
            this.File2Button.Text = "...";
            this.File2Button.UseVisualStyleBackColor = true;
            this.File2Button.Click += new System.EventHandler(this.File2Button_Click);
            // 
            // KeyFileButton
            // 
            this.KeyFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyFileButton.Location = new System.Drawing.Point(390, 44);
            this.KeyFileButton.Name = "KeyFileButton";
            this.KeyFileButton.Size = new System.Drawing.Size(35, 19);
            this.KeyFileButton.TabIndex = 11;
            this.KeyFileButton.Text = "...";
            this.KeyFileButton.UseVisualStyleBackColor = true;
            this.KeyFileButton.Click += new System.EventHandler(this.KeyFileButton_Click);
            // 
            // File1Button
            // 
            this.File1Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.File1Button.Location = new System.Drawing.Point(390, 99);
            this.File1Button.Name = "File1Button";
            this.File1Button.Size = new System.Drawing.Size(35, 19);
            this.File1Button.TabIndex = 12;
            this.File1Button.Text = "...";
            this.File1Button.UseVisualStyleBackColor = true;
            this.File1Button.Click += new System.EventHandler(this.File1Button_Click);
            // 
            // File1DelimiterTextBox
            // 
            this.File1DelimiterTextBox.Location = new System.Drawing.Point(12, 138);
            this.File1DelimiterTextBox.Name = "File1DelimiterTextBox";
            this.File1DelimiterTextBox.Size = new System.Drawing.Size(119, 20);
            this.File1DelimiterTextBox.TabIndex = 13;
            // 
            // File1SearchColumnIndexTextBox
            // 
            this.File1SearchColumnIndexTextBox.Location = new System.Drawing.Point(178, 138);
            this.File1SearchColumnIndexTextBox.Name = "File1SearchColumnIndexTextBox";
            this.File1SearchColumnIndexTextBox.Size = new System.Drawing.Size(135, 20);
            this.File1SearchColumnIndexTextBox.TabIndex = 14;
            // 
            // File2SearchColumnIndexTextBox
            // 
            this.File2SearchColumnIndexTextBox.Location = new System.Drawing.Point(134, 243);
            this.File2SearchColumnIndexTextBox.Name = "File2SearchColumnIndexTextBox";
            this.File2SearchColumnIndexTextBox.Size = new System.Drawing.Size(138, 20);
            this.File2SearchColumnIndexTextBox.TabIndex = 15;
            // 
            // File2DelimiterTextBox
            // 
            this.File2DelimiterTextBox.Location = new System.Drawing.Point(9, 243);
            this.File2DelimiterTextBox.Name = "File2DelimiterTextBox";
            this.File2DelimiterTextBox.Size = new System.Drawing.Size(119, 20);
            this.File2DelimiterTextBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "File 1 delimiter (\'\\t\' for tab):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "File 1 search column index (0-based):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "File 2 search column index (0-based):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "File 2 delimiter:";
            // 
            // OutputFolderTextBox
            // 
            this.OutputFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFolderTextBox.Location = new System.Drawing.Point(9, 314);
            this.OutputFolderTextBox.Name = "OutputFolderTextBox";
            this.OutputFolderTextBox.Size = new System.Drawing.Size(375, 20);
            this.OutputFolderTextBox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Output folder:";
            // 
            // OutputFolderButton
            // 
            this.OutputFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFolderButton.Location = new System.Drawing.Point(390, 315);
            this.OutputFolderButton.Name = "OutputFolderButton";
            this.OutputFolderButton.Size = new System.Drawing.Size(35, 19);
            this.OutputFolderButton.TabIndex = 23;
            this.OutputFolderButton.Text = "...";
            this.OutputFolderButton.UseVisualStyleBackColor = true;
            this.OutputFolderButton.Click += new System.EventHandler(this.OutputFolderButton_Click);
            // 
            // ExtractRowsFromFilesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(437, 428);
            this.Controls.Add(this.OutputFolderButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OutputFolderTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.File2DelimiterTextBox);
            this.Controls.Add(this.File2SearchColumnIndexTextBox);
            this.Controls.Add(this.File1SearchColumnIndexTextBox);
            this.Controls.Add(this.File1DelimiterTextBox);
            this.Controls.Add(this.File1Button);
            this.Controls.Add(this.KeyFileButton);
            this.Controls.Add(this.File2Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.File2PathTextBox);
            this.Controls.Add(this.File1PathTextBox);
            this.Controls.Add(this.KeyListFileTextBox);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.ExtractButton);
            this.Name = "ExtractRowsFromFilesDialog";
            this.Text = "ExtractRowsFromFilesDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.TextBox KeyListFileTextBox;
        private System.Windows.Forms.TextBox File1PathTextBox;
        private System.Windows.Forms.TextBox File2PathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button File2Button;
        private System.Windows.Forms.Button KeyFileButton;
        private System.Windows.Forms.Button File1Button;
        private System.Windows.Forms.TextBox File1DelimiterTextBox;
        private System.Windows.Forms.TextBox File1SearchColumnIndexTextBox;
        private System.Windows.Forms.TextBox File2SearchColumnIndexTextBox;
        private System.Windows.Forms.TextBox File2DelimiterTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox OutputFolderTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button OutputFolderButton;
    }
}