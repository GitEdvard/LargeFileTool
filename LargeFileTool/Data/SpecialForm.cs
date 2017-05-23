using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Molmed.LargeFileTool.Data
{
    public partial class SpecialForm : Form
    {
        private string MyWorkingFolder;
        public SpecialForm()
        {
            InitializeComponent();
            MyWorkingFolder = "";
        }

        private void SplitInternalReportButton_Click(object sender, EventArgs e)
        {
            string internalRerpotFIlename, filename_withoutSuffix;
            string textLine;
            StreamReader sr = null;
            StreamWriter sw = null;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.Trim().Length == 0)
            {
                return;
            }
            MyWorkingFolder = openFileDialog1.InitialDirectory;
            internalRerpotFIlename = openFileDialog1.FileName;
            filename_withoutSuffix = internalRerpotFIlename.Substring(0, internalRerpotFIlename.IndexOf(".crp"));
            try
            {
                sr = new StreamReader(internalRerpotFIlename);
                sw = new StreamWriter(filename_withoutSuffix + "_items.crp");
                while (!sr.EndOfStream)
                {
                    textLine = sr.ReadLine();
                    if (textLine.Contains("[markers]"))
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                        sw = new StreamWriter(filename_withoutSuffix + "_markers.crp");
                    }
                    if (textLine.Contains("[results]"))
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                        sw = new StreamWriter(filename_withoutSuffix + "_genotypes.crp");
                    }
                    sw.WriteLine(textLine);
                }
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }

        }

        private void MergeInternalReportButton_Click(object sender, EventArgs e)
        {
            string selectedPath;
            string[] IR_files;
            string textLine;
            string fileName_withoutSuffix;
            StreamReader sr = null;
            StreamWriter sw = null;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath.Trim().Length == 0)
            {
                return;
            }
            selectedPath = folderBrowserDialog1.SelectedPath;
            //selectedPath = "C:/Småjobb/Augusti2010/Klistra_internrapport/Working";
            IR_files = Directory.GetFiles(selectedPath, "*.crp");
            try
            {
                foreach (string file in IR_files)
                {
                    if (file.Contains("_items"))
                    {
                        fileName_withoutSuffix = file.Substring(0, file.IndexOf("_items"));
                        sw = new StreamWriter(fileName_withoutSuffix + "_merged.crp");
                        sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            textLine = sr.ReadLine();
                            sw.WriteLine(textLine);
                        }
                        sr.Close();
                        break;
                    }
                }
                foreach (string file in IR_files)
                {
                    if (file.Contains("_markers"))
                    {
                        sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            textLine = sr.ReadLine();
                            sw.WriteLine(textLine);
                        }
                        sr.Close();
                        break;
                    }
                }
                foreach (string file in IR_files)
                {
                    if (file.Contains("_genotypes"))
                    {
                        sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            textLine = sr.ReadLine();
                            sw.WriteLine(textLine);
                        }
                        sr.Close();
                        break;
                    }
                }
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }            
            }
        }
    }
}
