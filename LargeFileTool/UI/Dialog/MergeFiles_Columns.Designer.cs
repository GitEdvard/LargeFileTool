namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class MergeFiles_Columns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeFiles_Columns));
            this.MergeButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FileADelimiterTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FileAHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.FileAFirstRowNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FileAKeyColumnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.BrowseFileAButton = new System.Windows.Forms.Button();
            this.FileAPathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FileBHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.FileBFirstRowNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FileBKeyColumnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BrowseFileBButton = new System.Windows.Forms.Button();
            this.FileBPathTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FileBDelimiterTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MergeFileColumnOrderTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.InstringOptionRadioButton = new System.Windows.Forms.RadioButton();
            this.ExactMatchOptionRadioButton = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.GetHeadersButton = new System.Windows.Forms.Button();
            this.MergeFileHeaderTextBox = new System.Windows.Forms.TextBox();
            this.includeHeaderCheckbox = new System.Windows.Forms.CheckBox();
            this.MergeFileColumnDelimiterTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ShowAllUnmatchedCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileAFirstRowNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileAKeyColumnNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileBFirstRowNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileBKeyColumnNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MergeButton
            // 
            this.MergeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MergeButton.Location = new System.Drawing.Point(12, 701);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(75, 23);
            this.MergeButton.TabIndex = 0;
            this.MergeButton.Text = "Merge";
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(649, 701);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 1;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(712, 119);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // FileADelimiterTextBox
            // 
            this.FileADelimiterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileADelimiterTextBox.Location = new System.Drawing.Point(180, 19);
            this.FileADelimiterTextBox.Name = "FileADelimiterTextBox";
            this.FileADelimiterTextBox.Size = new System.Drawing.Size(143, 20);
            this.FileADelimiterTextBox.TabIndex = 3;
            this.FileADelimiterTextBox.Text = ",";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Column delimiter  (\\t for tab)";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.FileAHeaderCheckBox);
            this.groupBox1.Controls.Add(this.FileAFirstRowNumericUpDown);
            this.groupBox1.Controls.Add(this.FileAKeyColumnNumericUpDown);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.BrowseFileAButton);
            this.groupBox1.Controls.Add(this.FileAPathTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FileADelimiterTextBox);
            this.groupBox1.Location = new System.Drawing.Point(23, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 147);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File A";
            // 
            // FileAHeaderCheckBox
            // 
            this.FileAHeaderCheckBox.AutoSize = true;
            this.FileAHeaderCheckBox.Checked = true;
            this.FileAHeaderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FileAHeaderCheckBox.Location = new System.Drawing.Point(366, 73);
            this.FileAHeaderCheckBox.Name = "FileAHeaderCheckBox";
            this.FileAHeaderCheckBox.Size = new System.Drawing.Size(110, 17);
            this.FileAHeaderCheckBox.TabIndex = 14;
            this.FileAHeaderCheckBox.Text = "First line is header";
            this.FileAHeaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // FileAFirstRowNumericUpDown
            // 
            this.FileAFirstRowNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileAFirstRowNumericUpDown.Location = new System.Drawing.Point(180, 72);
            this.FileAFirstRowNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.FileAFirstRowNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FileAFirstRowNumericUpDown.Name = "FileAFirstRowNumericUpDown";
            this.FileAFirstRowNumericUpDown.Size = new System.Drawing.Size(143, 20);
            this.FileAFirstRowNumericUpDown.TabIndex = 13;
            this.FileAFirstRowNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FileAKeyColumnNumericUpDown
            // 
            this.FileAKeyColumnNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileAKeyColumnNumericUpDown.Location = new System.Drawing.Point(180, 46);
            this.FileAKeyColumnNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.FileAKeyColumnNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FileAKeyColumnNumericUpDown.Name = "FileAKeyColumnNumericUpDown";
            this.FileAKeyColumnNumericUpDown.Size = new System.Drawing.Size(143, 20);
            this.FileAKeyColumnNumericUpDown.TabIndex = 12;
            this.FileAKeyColumnNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "First row to read from";
            // 
            // BrowseFileAButton
            // 
            this.BrowseFileAButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseFileAButton.Location = new System.Drawing.Point(620, 100);
            this.BrowseFileAButton.Name = "BrowseFileAButton";
            this.BrowseFileAButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseFileAButton.TabIndex = 9;
            this.BrowseFileAButton.Text = "Browse";
            this.BrowseFileAButton.UseVisualStyleBackColor = true;
            this.BrowseFileAButton.Click += new System.EventHandler(this.BrowseFileAButton_Click);
            // 
            // FileAPathTextBox
            // 
            this.FileAPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileAPathTextBox.Location = new System.Drawing.Point(48, 102);
            this.FileAPathTextBox.Name = "FileAPathTextBox";
            this.FileAPathTextBox.Size = new System.Drawing.Size(566, 20);
            this.FileAPathTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Key column (first column = 1)";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.FileBHeaderCheckBox);
            this.groupBox2.Controls.Add(this.FileBFirstRowNumericUpDown);
            this.groupBox2.Controls.Add(this.FileBKeyColumnNumericUpDown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.BrowseFileBButton);
            this.groupBox2.Controls.Add(this.FileBPathTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.FileBDelimiterTextBox);
            this.groupBox2.Location = new System.Drawing.Point(23, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 138);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File B";
            // 
            // FileBHeaderCheckBox
            // 
            this.FileBHeaderCheckBox.AutoSize = true;
            this.FileBHeaderCheckBox.Checked = true;
            this.FileBHeaderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FileBHeaderCheckBox.Location = new System.Drawing.Point(366, 77);
            this.FileBHeaderCheckBox.Name = "FileBHeaderCheckBox";
            this.FileBHeaderCheckBox.Size = new System.Drawing.Size(110, 17);
            this.FileBHeaderCheckBox.TabIndex = 18;
            this.FileBHeaderCheckBox.Text = "First line is header";
            this.FileBHeaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // FileBFirstRowNumericUpDown
            // 
            this.FileBFirstRowNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileBFirstRowNumericUpDown.Location = new System.Drawing.Point(180, 74);
            this.FileBFirstRowNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.FileBFirstRowNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FileBFirstRowNumericUpDown.Name = "FileBFirstRowNumericUpDown";
            this.FileBFirstRowNumericUpDown.Size = new System.Drawing.Size(143, 20);
            this.FileBFirstRowNumericUpDown.TabIndex = 17;
            this.FileBFirstRowNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FileBKeyColumnNumericUpDown
            // 
            this.FileBKeyColumnNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileBKeyColumnNumericUpDown.Location = new System.Drawing.Point(180, 48);
            this.FileBKeyColumnNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.FileBKeyColumnNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FileBKeyColumnNumericUpDown.Name = "FileBKeyColumnNumericUpDown";
            this.FileBKeyColumnNumericUpDown.Size = new System.Drawing.Size(143, 20);
            this.FileBKeyColumnNumericUpDown.TabIndex = 16;
            this.FileBKeyColumnNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "First row to read from";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Key column (first column = 1)";
            // 
            // BrowseFileBButton
            // 
            this.BrowseFileBButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseFileBButton.Location = new System.Drawing.Point(620, 98);
            this.BrowseFileBButton.Name = "BrowseFileBButton";
            this.BrowseFileBButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseFileBButton.TabIndex = 13;
            this.BrowseFileBButton.Text = "Browse";
            this.BrowseFileBButton.UseVisualStyleBackColor = true;
            this.BrowseFileBButton.Click += new System.EventHandler(this.BrowseFileBButton_Click);
            // 
            // FileBPathTextBox
            // 
            this.FileBPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileBPathTextBox.Location = new System.Drawing.Point(48, 100);
            this.FileBPathTextBox.Name = "FileBPathTextBox";
            this.FileBPathTextBox.Size = new System.Drawing.Size(566, 20);
            this.FileBPathTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "File B:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Column delimiter  (\\t for tab)";
            // 
            // FileBDelimiterTextBox
            // 
            this.FileBDelimiterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileBDelimiterTextBox.Location = new System.Drawing.Point(180, 22);
            this.FileBDelimiterTextBox.Name = "FileBDelimiterTextBox";
            this.FileBDelimiterTextBox.Size = new System.Drawing.Size(143, 20);
            this.FileBDelimiterTextBox.TabIndex = 7;
            this.FileBDelimiterTextBox.Text = ",";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 78);
            this.label7.TabIndex = 7;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // MergeFileColumnOrderTextBox
            // 
            this.MergeFileColumnOrderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MergeFileColumnOrderTextBox.Location = new System.Drawing.Point(273, 30);
            this.MergeFileColumnOrderTextBox.Name = "MergeFileColumnOrderTextBox";
            this.MergeFileColumnOrderTextBox.Size = new System.Drawing.Size(416, 20);
            this.MergeFileColumnOrderTextBox.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ShowAllUnmatchedCheckBox);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.GetHeadersButton);
            this.groupBox3.Controls.Add(this.MergeFileHeaderTextBox);
            this.groupBox3.Controls.Add(this.includeHeaderCheckbox);
            this.groupBox3.Controls.Add(this.MergeFileColumnDelimiterTextBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.MergeFileColumnOrderTextBox);
            this.groupBox3.Location = new System.Drawing.Point(23, 444);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(695, 238);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Merge file";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.InstringOptionRadioButton);
            this.groupBox4.Controls.Add(this.ExactMatchOptionRadioButton);
            this.groupBox4.Location = new System.Drawing.Point(9, 129);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 72);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Key column options";
            // 
            // InstringOptionRadioButton
            // 
            this.InstringOptionRadioButton.AutoSize = true;
            this.InstringOptionRadioButton.Location = new System.Drawing.Point(6, 42);
            this.InstringOptionRadioButton.Name = "InstringOptionRadioButton";
            this.InstringOptionRadioButton.Size = new System.Drawing.Size(146, 17);
            this.InstringOptionRadioButton.TabIndex = 1;
            this.InstringOptionRadioButton.TabStop = true;
            this.InstringOptionRadioButton.Text = "Instring comparison (slow)";
            this.InstringOptionRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExactMatchOptionRadioButton
            // 
            this.ExactMatchOptionRadioButton.AutoSize = true;
            this.ExactMatchOptionRadioButton.Checked = true;
            this.ExactMatchOptionRadioButton.Location = new System.Drawing.Point(6, 19);
            this.ExactMatchOptionRadioButton.Name = "ExactMatchOptionRadioButton";
            this.ExactMatchOptionRadioButton.Size = new System.Drawing.Size(110, 17);
            this.ExactMatchOptionRadioButton.TabIndex = 0;
            this.ExactMatchOptionRadioButton.TabStop = true;
            this.ExactMatchOptionRadioButton.Text = "Exact match (fast)";
            this.ExactMatchOptionRadioButton.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(408, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Get header from input files:";
            // 
            // GetHeadersButton
            // 
            this.GetHeadersButton.Location = new System.Drawing.Point(614, 149);
            this.GetHeadersButton.Name = "GetHeadersButton";
            this.GetHeadersButton.Size = new System.Drawing.Size(75, 23);
            this.GetHeadersButton.TabIndex = 13;
            this.GetHeadersButton.Text = "Get headers";
            this.GetHeadersButton.UseVisualStyleBackColor = true;
            this.GetHeadersButton.Click += new System.EventHandler(this.GetHeadersButton_Click);
            // 
            // MergeFileHeaderTextBox
            // 
            this.MergeFileHeaderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MergeFileHeaderTextBox.Location = new System.Drawing.Point(411, 89);
            this.MergeFileHeaderTextBox.Multiline = true;
            this.MergeFileHeaderTextBox.Name = "MergeFileHeaderTextBox";
            this.MergeFileHeaderTextBox.Size = new System.Drawing.Size(278, 54);
            this.MergeFileHeaderTextBox.TabIndex = 12;
            // 
            // includeHeaderCheckbox
            // 
            this.includeHeaderCheckbox.AutoSize = true;
            this.includeHeaderCheckbox.Location = new System.Drawing.Point(273, 89);
            this.includeHeaderCheckbox.Name = "includeHeaderCheckbox";
            this.includeHeaderCheckbox.Size = new System.Drawing.Size(132, 30);
            this.includeHeaderCheckbox.TabIndex = 11;
            this.includeHeaderCheckbox.Text = "Include header\r\n(Separated by comma)";
            this.includeHeaderCheckbox.UseVisualStyleBackColor = true;
            // 
            // MergeFileColumnDelimiterTextBox
            // 
            this.MergeFileColumnDelimiterTextBox.Location = new System.Drawing.Point(411, 61);
            this.MergeFileColumnDelimiterTextBox.Name = "MergeFileColumnDelimiterTextBox";
            this.MergeFileColumnDelimiterTextBox.Size = new System.Drawing.Size(100, 20);
            this.MergeFileColumnDelimiterTextBox.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Column delimiter";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ShowAllUnmatchedCheckBox
            // 
            this.ShowAllUnmatchedCheckBox.AutoSize = true;
            this.ShowAllUnmatchedCheckBox.Checked = true;
            this.ShowAllUnmatchedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowAllUnmatchedCheckBox.Location = new System.Drawing.Point(9, 207);
            this.ShowAllUnmatchedCheckBox.Name = "ShowAllUnmatchedCheckBox";
            this.ShowAllUnmatchedCheckBox.Size = new System.Drawing.Size(308, 17);
            this.ShowAllUnmatchedCheckBox.TabIndex = 16;
            this.ShowAllUnmatchedCheckBox.Text = "Show unmatched keys from both files (may take longer time)";
            this.ShowAllUnmatchedCheckBox.UseVisualStyleBackColor = true;
            // 
            // MergeFiles_Columns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(736, 736);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.MergeButton);
            this.Name = "MergeFiles_Columns";
            this.Text = "Merge files column-wise";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileAFirstRowNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileAKeyColumnNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileBFirstRowNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileBKeyColumnNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox FileADelimiterTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BrowseFileAButton;
        private System.Windows.Forms.TextBox FileAPathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BrowseFileBButton;
        private System.Windows.Forms.TextBox FileBPathTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FileBDelimiterTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MergeFileColumnOrderTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown FileAFirstRowNumericUpDown;
        private System.Windows.Forms.NumericUpDown FileAKeyColumnNumericUpDown;
        private System.Windows.Forms.NumericUpDown FileBFirstRowNumericUpDown;
        private System.Windows.Forms.NumericUpDown FileBKeyColumnNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox FileAHeaderCheckBox;
        private System.Windows.Forms.CheckBox FileBHeaderCheckBox;
        private System.Windows.Forms.TextBox MergeFileColumnDelimiterTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox MergeFileHeaderTextBox;
        private System.Windows.Forms.CheckBox includeHeaderCheckbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button GetHeadersButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton InstringOptionRadioButton;
        private System.Windows.Forms.RadioButton ExactMatchOptionRadioButton;
        private System.Windows.Forms.CheckBox ShowAllUnmatchedCheckBox;
    }
}