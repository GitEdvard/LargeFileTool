namespace Molmed.LargeFileTool.UI.Dialog
{
    partial class GetUniqueItemsDialog
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
            this.InFileListView = new System.Windows.Forms.ListView();
            this.CloseButton = new System.Windows.Forms.Button();
            this.InputFilesButton = new System.Windows.Forms.Button();
            this.GetUniqueItemsButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InFileListView
            // 
            this.InFileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.InFileListView.FullRowSelect = true;
            this.InFileListView.GridLines = true;
            this.InFileListView.Location = new System.Drawing.Point(12, 94);
            this.InFileListView.Name = "InFileListView";
            this.InFileListView.Size = new System.Drawing.Size(569, 195);
            this.InFileListView.TabIndex = 0;
            this.InFileListView.UseCompatibleStateImageBehavior = false;
            this.InFileListView.View = System.Windows.Forms.View.Details;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(587, 295);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(80, 27);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // InputFilesButton
            // 
            this.InputFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFilesButton.Location = new System.Drawing.Point(587, 94);
            this.InputFilesButton.Name = "InputFilesButton";
            this.InputFilesButton.Size = new System.Drawing.Size(80, 27);
            this.InputFilesButton.TabIndex = 2;
            this.InputFilesButton.Text = "Add files";
            this.InputFilesButton.UseVisualStyleBackColor = true;
            this.InputFilesButton.Click += new System.EventHandler(this.InputFilesButton_Click);
            // 
            // GetUniqueItemsButton
            // 
            this.GetUniqueItemsButton.Location = new System.Drawing.Point(12, 295);
            this.GetUniqueItemsButton.Name = "GetUniqueItemsButton";
            this.GetUniqueItemsButton.Size = new System.Drawing.Size(107, 27);
            this.GetUniqueItemsButton.TabIndex = 3;
            this.GetUniqueItemsButton.Text = "Get unique items";
            this.GetUniqueItemsButton.UseVisualStyleBackColor = true;
            this.GetUniqueItemsButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(480, 59);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Enter one or more files to extract unique items from.\r\nEach row at the selected f" +
                "iles is counted as an item and \r\ncompared to other rows, in the same and the oth" +
                "er selected files.";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(587, 127);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(80, 27);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // GetUniqueItemsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(679, 330);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GetUniqueItemsButton);
            this.Controls.Add(this.InputFilesButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.InFileListView);
            this.Name = "GetUniqueItemsDialog";
            this.Text = "Get Unique Items";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView InFileListView;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button InputFilesButton;
        private System.Windows.Forms.Button GetUniqueItemsButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ClearButton;
    }
}