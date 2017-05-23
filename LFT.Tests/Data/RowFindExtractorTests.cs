using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FlexibleStreamHandling;
using LargeFileTool.Data;
using LFT.Tests.Utility.RowFindExtractorUtils;
using NUnit.Framework;


namespace LFT.Tests.Data
{
    [TestFixture]
    class RowFindExtractorTests
    {
        [Test]
        public void Extract_TwoRowsInput_HitOnOneRow()
        {
            //Arrange
            var input = new StringBuilder();
            input.AppendLine("line 1");
            input.AppendLine("line 2");
            var builder = new ExtractorBuilder(input.ToString(), searchCriteria: "2");
            builder.BuildExtractor();
            var e = new DoWorkEventArgs(null);

            //Act
            builder.Extractor.Extract(null, e);

            //Assert
            Assert.AreEqual("line 2", builder.ExtractedContent.Trim());
        }

        [Test]
        public void Extract_KeyStringHasATab_ExtractionWorks()
        {
            //Arrange
            var input = new StringBuilder();
            input.AppendLine("1\tline 1");
            input.AppendLine("2\tline 2");
            var builder = new ExtractorBuilder(input.ToString(), searchCriteria: "2\\t");
            builder.BuildExtractor();
            var e = new DoWorkEventArgs(null);

            //Act
            builder.Extractor.Extract(null, e);

            //Assert
            Assert.AreEqual("2\tline 2", builder.ExtractedContent.Trim());
        }
    }
}
