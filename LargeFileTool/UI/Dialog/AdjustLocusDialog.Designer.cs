namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class AdjustLocusDialog
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
            this.OutputFileButton = new System.Windows.Forms.Button();
            this.InputFileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ExtractToFileTextBox = new System.Windows.Forms.TextBox();
            this.LocusFileTextBox = new System.Windows.Forms.TextBox();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.IncludeCallScoreCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OutputFileButton
            // 
            this.OutputFileButton.Location = new System.Drawing.Point(572, 93);
            this.OutputFileButton.Name = "OutputFileButton";
            this.OutputFileButton.Size = new System.Drawing.Size(37, 23);
            this.OutputFileButton.TabIndex = 11;
            this.OutputFileButton.Text = "...";
            this.OutputFileButton.UseVisualStyleBackColor = true;
            this.OutputFileButton.Click += new System.EventHandler(this.OutputFileButton_Click);
            // 
            // InputFileButton
            // 
            this.InputFileButton.Location = new System.Drawing.Point(572, 35);
            this.InputFileButton.Name = "InputFileButton";
            this.InputFileButton.Size = new System.Drawing.Size(37, 24);
            this.InputFileButton.TabIndex = 10;
            this.InputFileButton.Text = "...";
            this.InputFileButton.UseVisualStyleBackColor = true;
            this.InputFileButton.Click += new System.EventHandler(this.InputFileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Extract to file:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select Locus-file:";
            // 
            // ExtractToFileTextBox
            // 
            this.ExtractToFileTextBox.Location = new System.Drawing.Point(12, 96);
            this.ExtractToFileTextBox.Name = "ExtractToFileTextBox";
            this.ExtractToFileTextBox.Size = new System.Drawing.Size(554, 20);
            this.ExtractToFileTextBox.TabIndex = 7;
            // 
            // LocusFileTextBox
            // 
            this.LocusFileTextBox.Location = new System.Drawing.Point(12, 38);
            this.LocusFileTextBox.Name = "LocusFileTextBox";
            this.LocusFileTextBox.Size = new System.Drawing.Size(554, 20);
            this.LocusFileTextBox.TabIndex = 6;
            // 
            // ExtractButton
            // 
            this.ExtractButton.Location = new System.Drawing.Point(12, 186);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(96, 27);
            this.ExtractButton.TabIndex = 13;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(594, 188);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 12;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // IncludeCallScoreCheckBox
            // 
            this.IncludeCallScoreCheckBox.AutoSize = true;
            this.IncludeCallScoreCheckBox.Location = new System.Drawing.Point(12, 122);
            this.IncludeCallScoreCheckBox.Name = "IncludeCallScoreCheckBox";
            this.IncludeCallScoreCheckBox.Size = new System.Drawing.Size(134, 17);
            this.IncludeCallScoreCheckBox.TabIndex = 14;
            this.IncludeCallScoreCheckBox.Text = "Include call score rows";
            this.IncludeCallScoreCheckBox.UseVisualStyleBackColor = true;
            // 
            // AdjustLocusDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(681, 225);
            this.Controls.Add(this.IncludeCallScoreCheckBox);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OutputFileButton);
            this.Controls.Add(this.InputFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExtractToFileTextBox);
            this.Controls.Add(this.LocusFileTextBox);
            this.Name = "AdjustLocusDialog";
            this.Text = "AdjustLocusDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OutputFileButton;
        private System.Windows.Forms.Button InputFileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ExtractToFileTextBox;
        private System.Windows.Forms.TextBox LocusFileTextBox;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.CheckBox IncludeCallScoreCheckBox;
    }
}