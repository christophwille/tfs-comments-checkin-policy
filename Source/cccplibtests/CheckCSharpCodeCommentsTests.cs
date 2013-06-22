using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using CCCPLib;
using ICSharpCode.NRefactory;

namespace CCCPLibTests
{
    [TestFixture]
    public class CheckCSharpCodeCommentsTests
    {
        [Test]
        public void MethodWithCommentTest()
        {
            // Check that the verifier correctly finds a code comment
            string testClass = @"public class Test
                                {
                                    /// <summary>
                                    /// 
                                    /// </summary>
                                    public void Some()
                                    {
                                    }
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);
            Assert.IsTrue(result);
        }

        [Test]
        public void MethodMissingCommentTest()
        {
            // Check that the verifier correctly finds a code comment
            string testClass = @"public class Test
                                {
                                    public void Some()
                                    {
                                    }
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);
            Assert.IsFalse(result);
        }

        [Test]
        public void CommentedMethodTest()
        {
            // Check that the verifier doesn't mark commented out methods as missing xml comments
            string testClass = @"public class Test
                                {
                                    //public void Some()
                                    //{
                                    //}
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);
            Assert.IsTrue(result);
        }

        [Test]
        public void DontCheckOverridesTest()
        {
            // Check that the verifier correctly finds a code comment
            string testClass = @"public abstract class MyBaseClass
                                {
                                    /// <summary>
                                    /// 
                                    /// </summary>
                                    public abstract void SayHello();
                                }

                                public class MyDerivedClass : MyBaseClass
                                {
                                    public override void SayHello()
                                    {
                                    }
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            ccc.DoCheckOverrideElements = false;
            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverridesTest()
        {
            // Check that the verifier correctly finds a code comment
            string testClass = @"public abstract class MyBaseClass
                                {
                                    /// <summary>
                                    /// 
                                    /// </summary>
                                    public abstract void SayHello();
                                }

                                public class MyDerivedClass : MyBaseClass
                                {
                                    public override void SayHello()
                                    {
                                    }
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            ccc.DoCheckOverrideElements = true;
            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);
            Assert.IsFalse(result);
        }
    }
}
