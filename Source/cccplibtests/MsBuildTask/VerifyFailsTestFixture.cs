using System;
using System.Collections.Generic;
using System.IO;

using CCCPLib;
using CCCPMSBuildTask;
using ICSharpCode.NRefactory;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NUnit.Framework;

namespace CCCPMSBuildTaskTests
{
    /// <summary>
    /// Tests the CheckCodeComments Verify method is called when
    /// the CheckCodeCommentsTask is executed.
    /// </summary>
    [TestFixture]
    public class VerifyFailsTestFixture
    {
        bool verify;
        DerivedCheckCodeCommentsTask task;
        
        [TestFixtureSetUp]
        public void SetUpFixture()
        {
           task = new DerivedCheckCodeCommentsTask();
           task.Sources = new ITaskItem[0];
           task.TreatParserErrorsAsPolicyViolation = true;
            
           // Call execute to ensure that the CheckCodeComments class is
           // created by the build task.
           task.Execute();
           
           verify = task.CallVerify(new StringReader("["), SupportedLanguage.CSharp);
        }
        
        [Test]
        public void VerifyFails()
        {
            Assert.IsFalse(verify);
        }
        
        [Test]
        public void OneCodeCommentError()
        {
            Assert.AreEqual(1, task.CheckCodeComments.CodeCommentErrors.Count);
        }
        
        [Test]
        public void CodeCommentError()
        {
            Assert.AreEqual("Failed parsing file", task.CheckCodeComments.CodeCommentErrors[0].ToString());
        }
    }
}
