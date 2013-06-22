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
    /// Tests that the correct visibility of classes, methods and 
    /// properties are checked for code comments when
    /// the build task is executed.
    /// </summary>
    [TestFixture]
    public class VisibilityCheckedTestFixture
    {
        private TaskItem sourceTaskItem;
        private DerivedCheckCodeCommentsTask task;
        
        [SetUp]
        public void SetUp()
        {
            task = new DerivedCheckCodeCommentsTask();
            sourceTaskItem = new TaskItem("test.cs");
            task.Sources = new ITaskItem[] {sourceTaskItem};
        }
        
        /// <summary>
        /// Check that public items are checked by default when creating
        /// the task using the default constructor.
        /// </summary>
        [Test]
        public void PublicItemsCheckedByDefault()
        {
            CheckCodeCommentsTask task = new CheckCodeCommentsTask();
            task.Sources = new ITaskItem[0];
            task.Execute();
            Assert.IsTrue(task.CheckPublic);
        }
        
        /// <summary>
        /// Check that private items are not checked by default when creating
        /// the task using the default constructor.
        /// </summary>
        [Test]
        public void PrivateItemsNotCheckedByDefault()
        {
            CheckCodeCommentsTask task = new CheckCodeCommentsTask();
            task.Sources = new ITaskItem[0];
            task.Execute();
            Assert.IsFalse(task.CheckPrivate);
        }
        
        /// <summary>
        /// Check that protected items are not checked by default when creating
        /// the task using the default constructor.
        /// </summary>
        [Test]
        public void ProtectedItemsNotCheckedByDefault()
        {
            CheckCodeCommentsTask task = new CheckCodeCommentsTask();
            task.Sources = new ITaskItem[0];
            task.Execute();
            Assert.IsFalse(task.CheckProtected);
        }        
        
        [Test]
        public void ProtectedAreChecked()
        {
            task.CheckPublic = false;
            task.CheckPrivate = false;
            task.CheckProtected = true;
            task.Execute();
            Assert.AreEqual(CodeCommentCheckingVisibility.Protected, task.CheckCodeComments.VisibilityToCheck);
        }        
        
        [Test]
        public void PrivateAreChecked()
        {
            task.CheckPublic = false;
            task.CheckPrivate = true;
            task.CheckProtected = false;
            task.Execute();
            Assert.AreEqual(CodeCommentCheckingVisibility.Private, task.CheckCodeComments.VisibilityToCheck);
        }            
    }
}
