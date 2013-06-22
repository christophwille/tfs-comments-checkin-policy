// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

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
    /// two files is checked.
    /// </summary>
    [TestFixture]
    public class CheckTwoFilesCodeCommentsTestFixture
    {
        private TaskItem sourceTaskItem1;
        private TaskItem sourceTaskItem2;
        private bool executeResult;
        private DerivedCheckCodeCommentsTask task;
        
        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            task = new DerivedCheckCodeCommentsTask();
            sourceTaskItem1 = new TaskItem("test1.vb");
            sourceTaskItem2 = new TaskItem("test2.vb");
            task.Language = "VB.NET";
            task.Sources = new ITaskItem[] {sourceTaskItem1, sourceTaskItem2};
            task.TreatParserErrorsAsPolicyViolation = true;
            executeResult = task.Execute();
        }
        
        [Test]
        public void TextReaderCreatedForFileName2()
        {
            Assert.AreEqual("test2.vb", task.FileNames[1]);
        }
        
        [Test]
        public void SupportedLanguages()
        {
            Assert.AreEqual(SupportedLanguage.VBNet, task.SupportedLanguages[1]);
        }
    }
}
