using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace Molmed.LargeFileTool.Data
{
    public class LocusFileSearcher
    {
        private const int READ_LENGTH = 1000;
        private string MyManifestName;
        private string MyRootDirectory;
        private BackgroundWorker MyBackgroundWorker;
        List<LocusFileInfo> MyMatchingFiles;
        StringCollection MyWhiteCharacters;

        public LocusFileSearcher(string manifestName, string rootDirectory, BackgroundWorker bgw)
        {
            MyManifestName = manifestName.ToLower();
            if (MyManifestName.Contains(".csv"))
            {
                MyManifestName = MyManifestName.Substring(0, MyManifestName.Length - 4);
            }
            MyRootDirectory = rootDirectory;
            MyBackgroundWorker = bgw;
            MyMatchingFiles = new List<LocusFileInfo>();
            InitWhiteCharacters();
            MyBackgroundWorker.DoWork += FindLocus;
        }

        private void InitWhiteCharacters()
        {
            MyWhiteCharacters = new StringCollection();
            MyWhiteCharacters.Add(" ");
            MyWhiteCharacters.Add(",");
            MyWhiteCharacters.Add(Environment.NewLine);
            MyWhiteCharacters.Add("\t");
            MyWhiteCharacters.Add(";");
        }

        private void FindLocus(object sender, EventArgs e)
        {
            SearchLocus_Rec(MyRootDirectory, ref MyMatchingFiles);
        }

        private void SearchLocus_Rec(string rootDir, ref List<LocusFileInfo> matchingFiles)
        {
            string[] dirs;
            SearchLocusInCatalog(rootDir, ref matchingFiles);
            MyBackgroundWorker.ReportProgress(0, "Searching directory:\n" + rootDir);
            if (MyBackgroundWorker.CancellationPending)
            {
                return;
            }

            dirs = Directory.GetDirectories(rootDir);
            foreach (string dir in dirs)
            {
                SearchLocus_Rec(dir, ref matchingFiles);
            }
        }

        private void SearchLocusInCatalog(string catalogPath, ref List<LocusFileInfo> matchingFiles)
        {
            FileInfo fileInfo;
            string[] files;
            string headerString;
            char[] buffer;
            string manifestName;
            files = Directory.GetFiles(catalogPath, "*.csv");
            StreamReader sr = null;

            try
            {
                foreach (string file in files)
                {
                    if (!file.ToLower().Contains("samplesheet"))
                    {
                        buffer = new char[READ_LENGTH];
                        sr = new StreamReader(file);
                        sr.Read(buffer, 0, READ_LENGTH);
                        headerString = new string(buffer);
                        headerString = headerString.ToLower();
                        if (headerString.Contains(MyManifestName))
                        {
                            fileInfo = new FileInfo(file);
                            manifestName = ExtractManifestName(headerString, MyManifestName);
                            matchingFiles.Add(new LocusFileInfo(fileInfo, manifestName));
                        }
                        sr.Close();
                        
                    }
                }

            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        private string ExtractManifestName(string headerBuffer, string manifestSearchStr)
        { 
            // If search string is part a manifest file name
            int hitInd,startInd, endInd;
            string manifestName = "???";
            hitInd = headerBuffer.IndexOf(manifestSearchStr);
            startInd = FindStartIndexForWord(headerBuffer, hitInd);
            endInd = FindEndIndexForWord(headerBuffer, hitInd);

            if (startInd != -1 && endInd != -1)
            {
                manifestName = headerBuffer.Substring(startInd, endInd - startInd + 1);
                
            } 
            return manifestName;
        }

        private int FindStartIndexForWord(string searchStr, int index)
        {
            int closestIndex = -1, ind;
            searchStr = searchStr.Substring(0, index);
            foreach (string whiteStr in MyWhiteCharacters)
            {
                ind = searchStr.LastIndexOf(whiteStr);
                ind += whiteStr.Length;
                if (ind > closestIndex)
                {
                    closestIndex = ind;
                }
            }

            return closestIndex;
        }

        private int FindEndIndexForWord(string searchStr, int index)
        {
            int closestIndex = int.MaxValue, ind;
            searchStr = searchStr.Substring(index);
            foreach (string whiteStr in MyWhiteCharacters)
            {
                ind = searchStr.IndexOf(whiteStr) - 1;
                if (ind > 0 && ind < closestIndex)
                {
                    closestIndex = ind;
                }
            }
            if (closestIndex == int.MaxValue)
            {
                closestIndex = -1;
            }
            return closestIndex + index;
        }

        public List<LocusFileInfo> GetMatchingFiles()
        {
            return MyMatchingFiles;
        }

    }

    public class LocusFileInfo
    {
        private FileInfo MyFileInfo;
        private string MyManifestFileName;

        public LocusFileInfo(FileInfo fileInfo, string manifestName)
        {
            MyFileInfo = fileInfo;
            MyManifestFileName = manifestName;
        }

        public FileInfo FileInfo
        {
            get
            {
                return MyFileInfo;
            }
        }

        public string ManifestFile
        {
            get
            {
                return MyManifestFileName;
            }
        }
    }
}
