namespace LargeFileTool.UI.Dialog
{
    partial class CopyPasteColumns
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TransferButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnDelimiterSourceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstRowSourceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SourceFilePathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseSourceFileButton = new System.Windows.Forms.Button();
            this.ColumnDelimiterDestinationTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TransferColumnsTextBox = new System.Windows.Forms.TextBox();
            this.GetHeaderButton = new System.Windows.Forms.Button();
            this.HeaderTextBox = new System.Windows.Forms.TextBox();
            this.SkipHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveGetSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentTransferSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getTransferSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.TestButton = new System.Windows.Forms.Button();
            this.DelimiterListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AddDelimiterButton = new System.Windows.Forms.Button();
            this.ClearDelimiersButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ColumnValueTextBox = new System.Windows.Forms.TextBox();
            this.AddColumnButton = new System.Windows.Forms.Button();
            this.ExtraColumnsListView = new System.Windows.Forms.ListView();
            this.ClearColumnsButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ForceUppercaseTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstRowSourceNumericUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ClearDelimiersButton);
            this.groupBox1.Controls.Add(this.AddDelimiterButton);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.DelimiterListBox);
            this.groupBox1.Controls.Add(this.BrowseSourceFileButton);
            this.groupBox1.Controls.Add(this.SourceFilePathTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FirstRowSourceNumericUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ColumnDelimiterSourceTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source file";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.ForceUppercaseTextBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TransferColumnsTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ColumnDelimiterDestinationTextBox);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(644, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 367);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transfer options";
            // 
            // TransferButton
            // 
            this.TransferButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TransferButton.Location = new System.Drawing.Point(1114, 497);
            this.TransferButton.Name = "TransferButton";
            this.TransferButton.Size = new System.Drawing.Size(75, 23);
            this.TransferButton.TabIndex = 2;
            this.TransferButton.Text = "Transfer";
            this.TransferButton.UseVisualStyleBackColor = true;
            this.TransferButton.Click += new System.EventHandler(this.TransferButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(1195, 497);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 3;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(345, 64);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(608, 35);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "This function transfer selected columns from one file to another at a given order" +
                ". ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Column delimiter (\\t for tab)";
            // 
            // ColumnDelimiterSourceTextBox
            // 
            this.ColumnDelimiterSourceTextBox.Location = new System.Drawing.Point(145, 29);
            this.ColumnDelimiterSourceTextBox.Name = "ColumnDelimiterSourceTextBox";
            this.ColumnDelimiterSourceTextBox.Size = new System.Drawing.Size(120, 20);
            this.ColumnDelimiterSourceTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "First row to read from";
            // 
            // FirstRowSourceNumericUpDown
            // 
            this.FirstRowSourceNumericUpDown.Location = new System.Drawing.Point(145, 89);
            this.FirstRowSourceNumericUpDown.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.FirstRowSourceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FirstRowSourceNumericUpDown.Name = "FirstRowSourceNumericUpDown";
            this.FirstRowSourceNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.FirstRowSourceNumericUpDown.TabIndex = 3;
            this.FirstRowSourceNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "File:";
            // 
            // SourceFilePathTextBox
            // 
            this.SourceFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceFilePathTextBox.Location = new System.Drawing.Point(38, 115);
            this.SourceFilePathTextBox.Name = "SourceFilePathTextBox";
            this.SourceFilePathTextBox.Size = new System.Drawing.Size(501, 20);
            this.SourceFilePathTextBox.TabIndex = 5;
            // 
            // BrowseSourceFileButton
            // 
            this.BrowseSourceFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseSourceFileButton.Location = new System.Drawing.Point(545, 113);
            this.BrowseSourceFileButton.Name = "BrowseSourceFileButton";
            this.BrowseSourceFileButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseSourceFileButton.TabIndex = 6;
            this.BrowseSourceFileButton.Text = "Browse";
            this.BrowseSourceFileButton.UseVisualStyleBackColor = true;
            this.BrowseSourceFileButton.Click += new System.EventHandler(this.BrowseSourceFileButton_Click);
            // 
            // ColumnDelimiterDestinationTextBox
            // 
            this.ColumnDelimiterDestinationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ColumnDelimiterDestinationTextBox.Location = new System.Drawing.Point(223, 282);
            this.ColumnDelimiterDestinationTextBox.Name = "ColumnDelimiterDestinationTextBox";
            this.ColumnDelimiterDestinationTextBox.Size = new System.Drawing.Size(397, 20);
            this.ColumnDelimiterDestinationTextBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Column delimiter in destination file(\\t for tab)";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(223, 214);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(387, 65);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "\"3,1,6\" means \r\n\"Copy columns 3, 1 and 6 from the source file to the destination " +
                "file in the given order\" Columns are separated by comma. Extra columns (see abov" +
                "e) are refered by their names.";
            // 
            // TransferColumnsTextBox
            // 
            this.TransferColumnsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TransferColumnsTextBox.Location = new System.Drawing.Point(223, 188);
            this.TransferColumnsTextBox.Name = "TransferColumnsTextBox";
            this.TransferColumnsTextBox.Size = new System.Drawing.Size(397, 20);
            this.TransferColumnsTextBox.TabIndex = 10;
            // 
            // GetHeaderButton
            // 
            this.GetHeaderButton.Location = new System.Drawing.Point(18, 336);
            this.GetHeaderButton.Name = "GetHeaderButton";
            this.GetHeaderButton.Size = new System.Drawing.Size(75, 23);
            this.GetHeaderButton.TabIndex = 11;
            this.GetHeaderButton.Text = "Get header";
            this.GetHeaderButton.UseVisualStyleBackColor = true;
            this.GetHeaderButton.Click += new System.EventHandler(this.GetHeaderButton_Click);
            // 
            // HeaderTextBox
            // 
            this.HeaderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.HeaderTextBox.Location = new System.Drawing.Point(102, 338);
            this.HeaderTextBox.Multiline = true;
            this.HeaderTextBox.Name = "HeaderTextBox";
            this.HeaderTextBox.Size = new System.Drawing.Size(530, 63);
            this.HeaderTextBox.TabIndex = 12;
            // 
            // SkipHeaderCheckBox
            // 
            this.SkipHeaderCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SkipHeaderCheckBox.AutoSize = true;
            this.SkipHeaderCheckBox.Checked = true;
            this.SkipHeaderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SkipHeaderCheckBox.Location = new System.Drawing.Point(102, 407);
            this.SkipHeaderCheckBox.Name = "SkipHeaderCheckBox";
            this.SkipHeaderCheckBox.Size = new System.Drawing.Size(164, 17);
            this.SkipHeaderCheckBox.TabIndex = 13;
            this.SkipHeaderCheckBox.Text = "Skip header in destination file";
            this.SkipHeaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Included columns in destination file:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Textfiles (*.txt)|*.txt|Csv-files (*.csv)|*.csv|All files |*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Textfiles (*.txt)|*.txt|Csv-files (*.csv)|*.csv|All files |*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGetSettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1282, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveGetSettingToolStripMenuItem
            // 
            this.saveGetSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCurrentTransferSettingToolStripMenuItem,
            this.getTransferSettingToolStripMenuItem});
            this.saveGetSettingToolStripMenuItem.Name = "saveGetSettingToolStripMenuItem";
            this.saveGetSettingToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.saveGetSettingToolStripMenuItem.Text = "Save/Get Setting";
            // 
            // saveCurrentTransferSettingToolStripMenuItem
            // 
            this.saveCurrentTransferSettingToolStripMenuItem.Name = "saveCurrentTransferSettingToolStripMenuItem";
            this.saveCurrentTransferSettingToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.saveCurrentTransferSettingToolStripMenuItem.Text = "Save current transfer setting";
            this.saveCurrentTransferSettingToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentTransferSettingToolStripMenuItem_Click);
            // 
            // getTransferSettingToolStripMenuItem
            // 
            this.getTransferSettingToolStripMenuItem.Name = "getTransferSettingToolStripMenuItem";
            this.getTransferSettingToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.getTransferSettingToolStripMenuItem.Text = "Get transfer setting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(327, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Header in destination file can be manually updated in the field below";
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(447, 27);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(132, 31);
            this.TestButton.TabIndex = 6;
            this.TestButton.Text = "SampleFile";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // DelimiterListBox
            // 
            this.DelimiterListBox.FormattingEnabled = true;
            this.DelimiterListBox.Location = new System.Drawing.Point(318, 32);
            this.DelimiterListBox.Name = "DelimiterListBox";
            this.DelimiterListBox.Size = new System.Drawing.Size(180, 69);
            this.DelimiterListBox.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Multiple delimiters can be selected:";
            // 
            // AddDelimiterButton
            // 
            this.AddDelimiterButton.Location = new System.Drawing.Point(271, 27);
            this.AddDelimiterButton.Name = "AddDelimiterButton";
            this.AddDelimiterButton.Size = new System.Drawing.Size(38, 23);
            this.AddDelimiterButton.TabIndex = 9;
            this.AddDelimiterButton.Text = "-->";
            this.AddDelimiterButton.UseVisualStyleBackColor = true;
            this.AddDelimiterButton.Click += new System.EventHandler(this.AddDelimiterButton_Click);
            // 
            // ClearDelimiersButton
            // 
            this.ClearDelimiersButton.Location = new System.Drawing.Point(504, 29);
            this.ClearDelimiersButton.Name = "ClearDelimiersButton";
            this.ClearDelimiersButton.Size = new System.Drawing.Size(49, 23);
            this.ClearDelimiersButton.TabIndex = 10;
            this.ClearDelimiersButton.Text = "Clear";
            this.ClearDelimiersButton.UseVisualStyleBackColor = true;
            this.ClearDelimiersButton.Click += new System.EventHandler(this.ClearDelimiersButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.ClearColumnsButton);
            this.groupBox3.Controls.Add(this.ExtraColumnsListView);
            this.groupBox3.Controls.Add(this.AddColumnButton);
            this.groupBox3.Controls.Add(this.ColumnValueTextBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.ColumnNameTextBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(9, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(601, 147);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Insert extra columns in destination file (optional)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Column name";
            // 
            // ColumnNameTextBox
            // 
            this.ColumnNameTextBox.Location = new System.Drawing.Point(6, 37);
            this.ColumnNameTextBox.Name = "ColumnNameTextBox";
            this.ColumnNameTextBox.Size = new System.Drawing.Size(231, 20);
            this.ColumnNameTextBox.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Value (inserted at each row)";
            // 
            // ColumnValueTextBox
            // 
            this.ColumnValueTextBox.Location = new System.Drawing.Point(6, 76);
            this.ColumnValueTextBox.Name = "ColumnValueTextBox";
            this.ColumnValueTextBox.Size = new System.Drawing.Size(231, 20);
            this.ColumnValueTextBox.TabIndex = 3;
            // 
            // AddColumnButton
            // 
            this.AddColumnButton.Location = new System.Drawing.Point(243, 35);
            this.AddColumnButton.Name = "AddColumnButton";
            this.AddColumnButton.Size = new System.Drawing.Size(57, 23);
            this.AddColumnButton.TabIndex = 4;
            this.AddColumnButton.Text = "Add -->";
            this.AddColumnButton.UseVisualStyleBackColor = true;
            this.AddColumnButton.Click += new System.EventHandler(this.AddColumnButton_Click);
            // 
            // ExtraColumnsListView
            // 
            this.ExtraColumnsListView.FullRowSelect = true;
            this.ExtraColumnsListView.GridLines = true;
            this.ExtraColumnsListView.Location = new System.Drawing.Point(309, 19);
            this.ExtraColumnsListView.Name = "ExtraColumnsListView";
            this.ExtraColumnsListView.Size = new System.Drawing.Size(286, 122);
            this.ExtraColumnsListView.TabIndex = 5;
            this.ExtraColumnsListView.UseCompatibleStateImageBehavior = false;
            this.ExtraColumnsListView.View = System.Windows.Forms.View.Details;
            // 
            // ClearColumnsButton
            // 
            this.ClearColumnsButton.Location = new System.Drawing.Point(243, 65);
            this.ClearColumnsButton.Name = "ClearColumnsButton";
            this.ClearColumnsButton.Size = new System.Drawing.Size(57, 23);
            this.ClearColumnsButton.TabIndex = 6;
            this.ClearColumnsButton.Text = "Clear";
            this.ClearColumnsButton.UseVisualStyleBackColor = true;
            this.ClearColumnsButton.Click += new System.EventHandler(this.ClearColumnsButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(276, 39);
            this.label10.TabIndex = 7;
            this.label10.Text = "To include other columns into the added \r\nextra column, refer to a column number " +
                "\r\nand embrace it by double brackets, e.g. \"[[5]]  some text\"";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Columns to force UPPERCASE";
            // 
            // ForceUppercaseTextBox
            // 
            this.ForceUppercaseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ForceUppercaseTextBox.Location = new System.Drawing.Point(223, 308);
            this.ForceUppercaseTextBox.Name = "ForceUppercaseTextBox";
            this.ForceUppercaseTextBox.Size = new System.Drawing.Size(397, 20);
            this.ForceUppercaseTextBox.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 331);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "(Columns separated by comma)";
            // 
            // CopyPasteColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(1282, 532);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SkipHeaderCheckBox);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.HeaderTextBox);
            this.Controls.Add(this.TransferButton);
            this.Controls.Add(this.GetHeaderButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CopyPasteColumns";
            this.Text = "Transfer columns between files";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstRowSourceNumericUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button TransferButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown FirstRowSourceNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ColumnDelimiterSourceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseSourceFileButton;
        private System.Windows.Forms.TextBox SourceFilePathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ColumnDelimiterDestinationTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox TransferColumnsTextBox;
        private System.Windows.Forms.TextBox HeaderTextBox;
        private System.Windows.Forms.Button GetHeaderButton;
        private System.Windows.Forms.CheckBox SkipHeaderCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveGetSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentTransferSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getTransferSettingToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.ListBox DelimiterListBox;
        private System.Windows.Forms.Button AddDelimiterButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ClearDelimiersButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox ColumnValueTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ColumnNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ClearColumnsButton;
        private System.Windows.Forms.ListView ExtraColumnsListView;
        private System.Windows.Forms.Button AddColumnButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ForceUppercaseTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}