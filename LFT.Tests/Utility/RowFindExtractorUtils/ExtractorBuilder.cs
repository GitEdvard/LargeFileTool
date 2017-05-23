using System.Collections.Generic;
using System.ComponentModel;
using FlexibleStreamHandling;
using LargeFileTool.Data;

namespace LFT.Tests.Utility.RowFindExtractorUtils
{
    class ExtractorBuilder
    {
        private readonly string _contents;
        private readonly string _searchCriteria;
        private readonly StringReader _outputStream;

        public RowFindExtractor Extractor { get; private set; }

        public string ExtractedContent
        {
            get
            {
                var r = _outputStream.GetReader();
                return r.ReadToEnd();
            }
        }

        public ExtractorBuilder(string contents, string searchCriteria)
        {
            _contents = contents;
            _searchCriteria = searchCriteria;
            _outputStream = new StringReader("");
        }

        public void BuildExtractor()
        {
            var inputStream = new StringReader(_contents);
            var rowReader = new RowReader(inputStream, "", new List<ReadCriteria>(), true);
            var bgw = new BackgroundWorker();
            Extractor = new RowFindExtractor(bgw, rowReader, _outputStream, _searchCriteria, false);
        }
    }
}
