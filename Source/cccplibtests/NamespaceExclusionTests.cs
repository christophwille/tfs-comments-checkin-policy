using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using CCCPLib;
using ICSharpCode.NRefactory;

namespace CCCPLibTests
{
    [TestFixture]
    public class NamespaceExclusionTests
    {
        [Test]
        public void SimpleExplicitNamespaceTest()
        {
            string testClass = @"namespace Hello.World { 
                                public class Test
                                {
                                    public void Some()
                                    { }
                                 }
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            ccc.ExcludedNamespaces.Add("Hello.World");
            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);
            Assert.IsTrue(result);
        }

        [Test]
        public void NestedNamespaceTest()
        {
            string testClass = @"namespace Hello{ namespace World { 
                                public class Test
                                {
                                    public void Some()
                                    { }
                                 }
                                } // namespace World
                                } // namespace Hello";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            ccc.ExcludedNamespaces.Add("Hello.World");
            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);
            Assert.IsTrue(result);
        }

        [Test]
        public void MixedNamespaceFailTest()
        {
            string testClass = @"namespace Hello.World { 
                                public class Test
                                {
                                    public void Some()
                                    { }
                                 }
                                }

                                namespace Hello.Chris { 
                                public class Test
                                {
                                    public void Some()
                                    { }
                                 }
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            ccc.ExcludedNamespaces.Add("Hello.World");
            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);
            Assert.IsFalse(result);
        }

        [Test]
        public void MixedNamespaceSucceedTest()
        {
            string testClass = @"namespace Hello.World { 
                                public class Test
                                {
                                    public void Some()
                                    { }
                                 }
                                }

                                namespace Hello.Chris { 
                                public class Test
                                {
                                    /// <summary>
                                    /// 
                                    /// </summary>                                      
                                    public void Some()
                                    { }
                                 }
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            ccc.ExcludedNamespaces.Add("Hello.World");
            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);
            Assert.IsTrue(result);
        }
    }
}
