using System;
using System.Collections.Generic;

using CCCPLib;
using CCCPMSBuildTask;
using ICSharpCode.NRefactory;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NUnit.Framework;

namespace CCCPMSBuildTaskTests
{
    /// <summary>
    /// Tests a successful execution of the CheckCodeCommentsTask when
    /// a single file is checked.
    /// </summary>
    [TestFixture]
    public class CheckSingleFileCodeCommentsTestFixture
    {
        private TaskItem sourceTaskItem;
        private bool executeResult;
        private DerivedCheckCodeCommentsTask task;
        private ITaskItem[] sourceItems;
        
        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            task = new DerivedCheckCodeCommentsTask();
            sourceTaskItem = new TaskItem("test.cs");
            sourceItems = new ITaskItem[] {sourceTaskItem};
            task.Sources = sourceItems;
            task.TreatParserErrorsAsPolicyViolation = true;
            task.CheckMethods = true;
            task.CheckPublic = true;
            task.Language = "C#";
            task.ReportFileName = @"C:\Projects\Test\CodeCommentReport.xml";
            executeResult = task.Execute();
        }
        
        [Test]
        public void TreatParserErrorsAsPolicyViolation()
        {
            Assert.IsTrue(task.CheckCodeComments.TreatParserErrorsAsPolicyViolation);
        }
        
        [Test]
        public void SourcesSet()
        {
            Assert.AreEqual(sourceItems, task.Sources);
        }
        
        [Test]
        public void ExecuteResult()
        {
            Assert.IsTrue(executeResult);
        }
        
        [Test]
        public void VerifyCalled()
        {
            Assert.IsTrue(task.IsVerifiedCalled);
        }
        
        [Test]
        public void TextReaderCreatedForFileName()
        {
            Assert.AreEqual("test.cs", task.FileNames[0]);
        }
        
        [Test]
        public void TextReaderPassedToVerifyMethod()
        {
            Assert.AreEqual(task.TextReadersCreated[0], task.TextReaders[0]);
        }
        
        [Test]
        public void SupportedLanguages()
        {
            Assert.AreEqual(SupportedLanguage.CSharp, task.SupportedLanguages[0]);
        }
        
        [Test]
        public void AccumulateErrors()
        {
            Assert.IsFalse(task.CheckCodeComments.AccumulateErrors);
        }
        
        [Test]
        public void ReportFileCreated()
        {
            Assert.AreEqual(@"C:\Projects\Test\CodeCommentReport.xml", task.XmlWriterFileName);
        }
        
        /// <summary>
        /// Do not get an ObjectDisposedException but an InvalidOperationException
        /// if the XmlWriter was closed or disposed.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ResultsFileWriterDisposed()
        {
            task.ResultsFileWriter.WriteComment("Test");
        }
        
        [Test]
        public void ExpectedReportXml()
        {
            Assert.AreEqual(GetExpectedReportXml(), task.GetReportXml());
        }
        
        string GetExpectedReportXml()
        {
            return "<report>\r\n" +
                "\t<configuration>\r\n" +
                "\t\t<elementsChecked classes=\"False\" methods=\"True\" properties=\"False\" events=\"False\" fields=\"False\" />\r\n" +
                "\t\t<visibilityChecked public=\"True\" protected=\"False\" private=\"False\" />\r\n" +
                "\t</configuration>\r\n" +
                "\t<reportDetails>\r\n" +
                "\t\t<file name=\"test.cs\" missingComments=\"0\" />\r\n" +
                "\t</reportDetails>\r\n" +
                "\t<reportSummary>\r\n" +
                "\t\t<missing>\r\n" +
                "\t\t\t<methods public=\"0\" />\r\n" +
                "\t\t</missing>\r\n" +
                "\t</reportSummary>\r\n" +
                "</report>";    
        }
    }
}
