namespace LargeFileTool.UI.Dialog
{
    partial class ExtractFromLocusDialog
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
            this.LocusFileTextBox = new System.Windows.Forms.TextBox();
            this.ExtractToFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InputFileButton = new System.Windows.Forms.Button();
            this.OutputFileButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.SampleFilterTextBox = new System.Windows.Forms.TextBox();
            this.SelectMarkersTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MarkerNumberSelectionPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StartAtMarkerTextBox = new System.Windows.Forms.TextBox();
            this.MarkersToIncludeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MarkerFileTextBox = new System.Windows.Forms.TextBox();
            this.MarkerFileSelectionButton = new System.Windows.Forms.Button();
            this.SampleFilterButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.MarkerNumberSelectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LocusFileTextBox
            // 
            this.LocusFileTextBox.Location = new System.Drawing.Point(21, 41);
            this.LocusFileTextBox.Name = "LocusFileTextBox";
            this.LocusFileTextBox.Size = new System.Drawing.Size(554, 20);
            this.LocusFileTextBox.TabIndex = 0;
            // 
            // ExtractToFileTextBox
            // 
            this.ExtractToFileTextBox.Location = new System.Drawing.Point(21, 84);
            this.ExtractToFileTextBox.Name = "ExtractToFileTextBox";
            this.ExtractToFileTextBox.Size = new System.Drawing.Size(554, 20);
            this.ExtractToFileTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Locus-file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Extract to file:";
            // 
            // InputFileButton
            // 
            this.InputFileButton.Location = new System.Drawing.Point(581, 38);
            this.InputFileButton.Name = "InputFileButton";
            this.InputFileButton.Size = new System.Drawing.Size(37, 24);
            this.InputFileButton.TabIndex = 4;
            this.InputFileButton.Text = "...";
            this.InputFileButton.UseVisualStyleBackColor = true;
            this.InputFileButton.Click += new System.EventHandler(this.InputFileButton_Click);
            // 
            // OutputFileButton
            // 
            this.OutputFileButton.Location = new System.Drawing.Point(581, 81);
            this.OutputFileButton.Name = "OutputFileButton";
            this.OutputFileButton.Size = new System.Drawing.Size(37, 23);
            this.OutputFileButton.TabIndex = 5;
            this.OutputFileButton.Text = "...";
            this.OutputFileButton.UseVisualStyleBackColor = true;
            this.OutputFileButton.Click += new System.EventHandler(this.OutputFileButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(553, 458);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ExtractButton
            // 
            this.ExtractButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExtractButton.Location = new System.Drawing.Point(12, 456);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(96, 27);
            this.ExtractButton.TabIndex = 7;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // SampleFilterTextBox
            // 
            this.SampleFilterTextBox.Location = new System.Drawing.Point(21, 177);
            this.SampleFilterTextBox.Name = "SampleFilterTextBox";
            this.SampleFilterTextBox.Size = new System.Drawing.Size(554, 20);
            this.SampleFilterTextBox.TabIndex = 8;
            // 
            // SelectMarkersTextbox
            // 
            this.SelectMarkersTextbox.Location = new System.Drawing.Point(25, 30);
            this.SelectMarkersTextbox.Multiline = true;
            this.SelectMarkersTextbox.Name = "SelectMarkersTextbox";
            this.SelectMarkersTextbox.Size = new System.Drawing.Size(584, 72);
            this.SelectMarkersTextbox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sample filter:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Select markers, separated by comma:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MarkerNumberSelectionPanel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SelectMarkersTextbox);
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 234);
            this.panel1.TabIndex = 12;
            // 
            // MarkerNumberSelectionPanel
            // 
            this.MarkerNumberSelectionPanel.Controls.Add(this.label6);
            this.MarkerNumberSelectionPanel.Controls.Add(this.label5);
            this.MarkerNumberSelectionPanel.Controls.Add(this.StartAtMarkerTextBox);
            this.MarkerNumberSelectionPanel.Controls.Add(this.MarkersToIncludeTextBox);
            this.MarkerNumberSelectionPanel.Location = new System.Drawing.Point(25, 108);
            this.MarkerNumberSelectionPanel.Name = "MarkerNumberSelectionPanel";
            this.MarkerNumberSelectionPanel.Size = new System.Drawing.Size(584, 54);
            this.MarkerNumberSelectionPanel.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Start at marker:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Select number of markers to include:";
            // 
            // StartAtMarkerTextBox
            // 
            this.StartAtMarkerTextBox.Location = new System.Drawing.Point(243, 26);
            this.StartAtMarkerTextBox.Name = "StartAtMarkerTextBox";
            this.StartAtMarkerTextBox.Size = new System.Drawing.Size(185, 20);
            this.StartAtMarkerTextBox.TabIndex = 1;
            // 
            // MarkersToIncludeTextBox
            // 
            this.MarkersToIncludeTextBox.Location = new System.Drawing.Point(0, 26);
            this.MarkersToIncludeTextBox.Name = "MarkersToIncludeTextBox";
            this.MarkersToIncludeTextBox.Size = new System.Drawing.Size(197, 20);
            this.MarkersToIncludeTextBox.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Extract markers to file (optional):";
            // 
            // MarkerFileTextBox
            // 
            this.MarkerFileTextBox.Location = new System.Drawing.Point(21, 128);
            this.MarkerFileTextBox.Name = "MarkerFileTextBox";
            this.MarkerFileTextBox.Size = new System.Drawing.Size(554, 20);
            this.MarkerFileTextBox.TabIndex = 14;
            // 
            // MarkerFileSelectionButton
            // 
            this.MarkerFileSelectionButton.Location = new System.Drawing.Point(581, 126);
            this.MarkerFileSelectionButton.Name = "MarkerFileSelectionButton";
            this.MarkerFileSelectionButton.Size = new System.Drawing.Size(37, 23);
            this.MarkerFileSelectionButton.TabIndex = 15;
            this.MarkerFileSelectionButton.Text = "...";
            this.MarkerFileSelectionButton.UseVisualStyleBackColor = true;
            this.MarkerFileSelectionButton.Click += new System.EventHandler(this.MarkerFileSelectionButton_Click);
            // 
            // SampleFilterButton
            // 
            this.SampleFilterButton.Location = new System.Drawing.Point(581, 175);
            this.SampleFilterButton.Name = "SampleFilterButton";
            this.SampleFilterButton.Size = new System.Drawing.Size(37, 23);
            this.SampleFilterButton.TabIndex = 16;
            this.SampleFilterButton.Text = "...";
            this.SampleFilterButton.UseVisualStyleBackColor = true;
            this.SampleFilterButton.Click += new System.EventHandler(this.SampleFilterButton_Click);
            // 
            // ExtractFromLocusDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(640, 495);
            this.Controls.Add(this.SampleFilterButton);
            this.Controls.Add(this.MarkerFileSelectionButton);
            this.Controls.Add(this.MarkerFileTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SampleFilterTextBox);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OutputFileButton);
            this.Controls.Add(this.InputFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExtractToFileTextBox);
            this.Controls.Add(this.LocusFileTextBox);
            this.Name = "ExtractFromLocusDialog";
            this.Text = "ExtractFromLocusDialog";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MarkerNumberSelectionPanel.ResumeLayout(false);
            this.MarkerNumberSelectionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LocusFileTextBox;
        private System.Windows.Forms.TextBox ExtractToFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button InputFileButton;
        private System.Windows.Forms.Button OutputFileButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.TextBox SampleFilterTextBox;
        private System.Windows.Forms.TextBox SelectMarkersTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MarkerNumberSelectionPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StartAtMarkerTextBox;
        private System.Windows.Forms.TextBox MarkersToIncludeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MarkerFileTextBox;
        private System.Windows.Forms.Button MarkerFileSelectionButton;
        private System.Windows.Forms.Button SampleFilterButton;
    }
}