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
    /// Tests that the code comment task does not fail when the
    /// CheckCodeComments class has collected comment errors.
    /// </summary>
    [TestFixture]
    public class CodeCommentErrorsTestFixture
    {
        private TaskItem sourceTaskItem;
        private bool executeResult;
        private DerivedCheckCodeCommentsTask task;
        
        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            task = new DerivedCheckCodeCommentsTask();
            sourceTaskItem = new TaskItem("test.cs");
            task.Sources = new ITaskItem[] {sourceTaskItem};
            task.TreatParserErrorsAsPolicyViolation = true;
            task.CheckClasses = true;
            task.CheckEvents = true;
            task.CheckProtected = true;
            task.CheckPrivate = true;
            task.CheckPublic = false;
            task.CheckMethods = false;
            task.ReportFileName = "test.xml";
            task.Language = "C#";
            
            // Add dummy code comment errors.
            task.AddCodeCommentErrorDuringVerify(new CodeCommentError("test", "Stopped", 10));
            task.AddMissingCommentDuringVerify(new MissingCommentInfo(CodeCommentCheckingElements.Events, CodeCommentCheckingVisibility.Protected));
 
            executeResult = task.Execute();
        }
        
        [Test]
        public void ExecuteDoesNotFail()
        {
            Assert.IsTrue(executeResult);
        }
        
        [Test]
        public void ReportFileNameSet()
        {
            Assert.AreEqual("test.xml", task.ReportFileName);
        }
        
        [Test]
        public void LanguageSet()
        {
            Assert.AreEqual("C#", task.Language);
        }
        
        [Test]
        public void TreatParserErrorsAsViolationsSet()
        {
            Assert.AreEqual(true, task.TreatParserErrorsAsPolicyViolation);
        }
        
        [Test]
        public void ExpectedReportXml()
        {
            Assert.AreEqual(GetExpectedReportXml(), task.GetReportXml());
        }
        
        [Test]
        public void AccumulateStatistics()
        {
            Assert.IsTrue(task.CheckCodeComments.AccumulateStatistics);
        }
        
        [Test]
        public void TrackStatistics()
        {
            Assert.IsTrue(task.CheckCodeComments.TrackStatistics);
        }        
        
        string GetExpectedReportXml()
        {
            return "<report>\r\n" +
                "\t<configuration>\r\n" +
                "\t\t<elementsChecked classes=\"True\" methods=\"False\" properties=\"False\" events=\"True\" fields=\"False\" />\r\n" +
                "\t\t<visibilityChecked public=\"False\" protected=\"True\" private=\"True\" />\r\n" +
                "\t</configuration>\r\n" +
                "\t<reportDetails>\r\n" +
                "\t\t<file name=\"test.cs\" missingComments=\"1\">\r\n" +
                "\t\t\t<commentFailure class=\"test\" element=\"Stopped\" line=\"10\" />\r\n" +
                "\t\t</file>\r\n" +
                "\t</reportDetails>\r\n" +
                "\t<reportSummary>\r\n" +
                "\t\t<missing>\r\n" +
                "\t\t\t<events protected=\"1\" private=\"0\" />\r\n" +
                "\t\t\t<class protected=\"0\" private=\"0\" />\r\n" +
                "\t\t</missing>\r\n" +
                "\t</reportSummary>\r\n" +
                "</report>";    
        }        
    }
}
