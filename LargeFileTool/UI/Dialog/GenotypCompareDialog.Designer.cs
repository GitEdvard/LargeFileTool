namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class GenotypCompareDialog
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
            this.GFile1TextBox = new System.Windows.Forms.TextBox();
            this.GFile2TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GetGFile1Button = new System.Windows.Forms.Button();
            this.GetGFile2Button = new System.Windows.Forms.Button();
            this.CompareButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SkipHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GFile1TextBox
            // 
            this.GFile1TextBox.Location = new System.Drawing.Point(36, 50);
            this.GFile1TextBox.Name = "GFile1TextBox";
            this.GFile1TextBox.Size = new System.Drawing.Size(321, 20);
            this.GFile1TextBox.TabIndex = 0;
            // 
            // GFile2TextBox
            // 
            this.GFile2TextBox.Location = new System.Drawing.Point(36, 115);
            this.GFile2TextBox.Name = "GFile2TextBox";
            this.GFile2TextBox.Size = new System.Drawing.Size(321, 20);
            this.GFile2TextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Genotype file 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Genotype file 2";
            // 
            // GetGFile1Button
            // 
            this.GetGFile1Button.Location = new System.Drawing.Point(363, 47);
            this.GetGFile1Button.Name = "GetGFile1Button";
            this.GetGFile1Button.Size = new System.Drawing.Size(35, 24);
            this.GetGFile1Button.TabIndex = 4;
            this.GetGFile1Button.Text = "...";
            this.GetGFile1Button.UseVisualStyleBackColor = true;
            this.GetGFile1Button.Click += new System.EventHandler(this.GetGFile1Button_Click);
            // 
            // GetGFile2Button
            // 
            this.GetGFile2Button.Location = new System.Drawing.Point(363, 115);
            this.GetGFile2Button.Name = "GetGFile2Button";
            this.GetGFile2Button.Size = new System.Drawing.Size(35, 20);
            this.GetGFile2Button.TabIndex = 5;
            this.GetGFile2Button.Text = "...";
            this.GetGFile2Button.UseVisualStyleBackColor = true;
            this.GetGFile2Button.Click += new System.EventHandler(this.GetGFile2Button_Click);
            // 
            // CompareButton
            // 
            this.CompareButton.Location = new System.Drawing.Point(36, 254);
            this.CompareButton.Name = "CompareButton";
            this.CompareButton.Size = new System.Drawing.Size(95, 33);
            this.CompareButton.TabIndex = 6;
            this.CompareButton.Text = "Compare";
            this.CompareButton.UseVisualStyleBackColor = true;
            this.CompareButton.Click += new System.EventHandler(this.CompareButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(254, 254);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(123, 33);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ResultTextBox);
            this.groupBox1.Location = new System.Drawing.Point(484, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 275);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(19, 44);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(295, 165);
            this.ResultTextBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "(Trimming each value before comparing)";
            // 
            // SkipHeaderCheckBox
            // 
            this.SkipHeaderCheckBox.AutoSize = true;
            this.SkipHeaderCheckBox.Location = new System.Drawing.Point(36, 151);
            this.SkipHeaderCheckBox.Name = "SkipHeaderCheckBox";
            this.SkipHeaderCheckBox.Size = new System.Drawing.Size(83, 17);
            this.SkipHeaderCheckBox.TabIndex = 10;
            this.SkipHeaderCheckBox.Text = "Skip header";
            this.SkipHeaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // GenotypCompareDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(863, 323);
            this.Controls.Add(this.SkipHeaderCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CompareButton);
            this.Controls.Add(this.GetGFile2Button);
            this.Controls.Add(this.GetGFile1Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GFile2TextBox);
            this.Controls.Add(this.GFile1TextBox);
            this.Name = "GenotypCompareDialog";
            this.Text = "GenotypCompareDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GFile1TextBox;
        private System.Windows.Forms.TextBox GFile2TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetGFile1Button;
        private System.Windows.Forms.Button GetGFile2Button;
        private System.Windows.Forms.Button CompareButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox SkipHeaderCheckBox;
    }
}