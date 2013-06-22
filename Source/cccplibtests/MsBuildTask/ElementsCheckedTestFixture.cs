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
    /// Tests that the correct elements (Class, Method, Property,
    /// Event or Field) are checked for code comments when
    /// the build task is executed.
    /// </summary>
    [TestFixture]
    public class ElementsCheckedTestFixture
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
        /// Check that methods are checked by default when creating
        /// the task using the default constructor.
        /// </summary>
        [Test]
        public void MethodsAreCheckedByDefault()
        {
            CheckCodeCommentsTask task = new CheckCodeCommentsTask();
            task.Sources = new ITaskItem[0];
            task.Execute();
            Assert.IsTrue(task.CheckMethods);
        }
        
        [Test]
        public void MethodsChecked()
        {
            task.CheckMethods = true;
            task.Execute();
            Assert.AreEqual(CodeCommentCheckingElements.Methods, task.CheckCodeComments.ElementsToCheck);
        }
        
        [Test]
        public void MethodsNotChecked()
        {
            task.CheckMethods = false;
            task.Execute();
            Assert.AreNotEqual(CodeCommentCheckingElements.Methods, task.CheckCodeComments.ElementsToCheck);
        }

        [Test]
        public void PropertiesNotCheckedByDefault()
        {
            CheckCodeCommentsTask task = new CheckCodeCommentsTask();
            task.Sources = new ITaskItem[0];
            task.Execute();
            Assert.IsFalse(task.CheckProperties);
        }
        
        [Test]
        public void PropertiesAreChecked()
        {
            task.CheckProperties = true;
            task.CheckMethods = false;
            task.Execute();
            Assert.AreEqual(CodeCommentCheckingElements.Properties, task.CheckCodeComments.ElementsToCheck);
        }    
        
        [Test]
        public void PropertiesAndMethodsAreChecked()
        {
            task.CheckProperties = true;
            task.CheckMethods = true;
            task.Execute();
            Assert.AreEqual(CodeCommentCheckingElements.Properties | CodeCommentCheckingElements.Methods, task.CheckCodeComments.ElementsToCheck);
        }    
        
        [Test]
        public void FieldsAreChecked()
        {
            task.CheckFields = true;
            task.CheckMethods = false;
            task.Execute();
            Assert.AreEqual(CodeCommentCheckingElements.Fields, task.CheckCodeComments.ElementsToCheck);
        }    
        
        [Test]
        public void FieldsNotCheckedByDefault()
        {
            CheckCodeCommentsTask task = new CheckCodeCommentsTask();
            task.Sources = new ITaskItem[0];
            task.Execute();
            Assert.IsFalse(task.CheckFields);
        }
        
        [Test]
        public void ClassesAreChecked()
        {
            task.CheckClasses = true;
            task.CheckMethods = false;
            task.Execute();
            Assert.AreEqual(CodeCommentCheckingElements.Class, task.CheckCodeComments.ElementsToCheck);
        }    
        
        [Test]
        public void ClassesNotCheckedByDefault()
        {
            CheckCodeCommentsTask task = new CheckCodeCommentsTask();
            task.Sources = new ITaskItem[0];
            task.Execute();
            Assert.IsFalse(task.CheckClasses);
        }
        
        [Test]
        public void EventsAreChecked()
        {
            task.CheckEvents = true;
            task.CheckMethods = false;
            task.Execute();
            Assert.AreEqual(CodeCommentCheckingElements.Events, task.CheckCodeComments.ElementsToCheck);
        }    
        
        [Test]
        public void EventsNotCheckedByDefault()
        {
            CheckCodeCommentsTask task = new CheckCodeCommentsTask();
            task.Sources = new ITaskItem[0];
            task.Execute();
            Assert.IsFalse(task.CheckEvents);
        }
        
    }
}
