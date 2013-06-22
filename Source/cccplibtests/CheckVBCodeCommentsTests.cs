using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using CCCPLib;
using ICSharpCode.NRefactory;

namespace CCCPLibTests
{
    [TestFixture]
    public class CheckVBCodeCommentsTests
    {
        [Test]
        public void MethodWithCommentTest()
        {
            // Check that the verifier correctly finds a code comment
            string testClass = @"Public Class TheTestClass
                                    ''' <summary>
                                    ''' 
                                    ''' </summary>
                                    ''' <remarks></remarks>
                                    Public Sub MyMethod()

                                    End Sub
                                End Class";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            bool result = ccc.Verify(testClass, SupportedLanguage.VBNet);
            Assert.IsTrue(result);
        }

        [Test]
        public void MethodMissingCommentTest()
        {
            // Check that the verifier correctly finds a code comment
            string testClass = @"Public Class TheTestClass
                                    Public Sub MyMethod()

                                    End Sub
                                End Class";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            bool result = ccc.Verify(testClass, SupportedLanguage.VBNet);
            Assert.IsFalse(result);
        }

        [Test]
        public void CommentedMethodTest()
        {
            // Check that the verifier doesn't mark commented out methods as missing xml comments
            string testClass = @"Public Class TheTestClass
                                    'Public Sub MyMethod()

                                    'End Sub
                                End Class";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            bool result = ccc.Verify(testClass, SupportedLanguage.VBNet);
            Assert.IsTrue(result);
        }
    }
}
