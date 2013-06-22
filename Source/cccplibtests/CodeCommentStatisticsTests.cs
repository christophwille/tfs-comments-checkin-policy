using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using CCCPLib;
using ICSharpCode.NRefactory;

namespace CCCPLibTests
{
    [TestFixture]
    public class CodeCommentStatisticsTest
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
            ccc.TrackStatistics = true; // we get away w/out accumulation

            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);

            Assert.AreEqual(ccc.CommentStatistics.GetCommentCount(ccc.ElementsToCheck, ccc.VisibilityToCheck), 1);
            Assert.AreEqual(ccc.CommentStatistics.GetMissingCommentCount(ccc.ElementsToCheck, ccc.VisibilityToCheck), 0);
            Assert.AreEqual(ccc.CommentStatistics.CommentsCount.Count, 1);
            Assert.AreEqual(ccc.CommentStatistics.MissingCommentsCount.Count, 1);
            Assert.AreEqual(ccc.CommentStatistics.CommentsCount[ccc.ElementsToCheck].Count, 1);
            Assert.AreEqual(ccc.CommentStatistics.MissingCommentsCount[ccc.ElementsToCheck].Count, 1);
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
            ccc.TrackStatistics = true;

            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);

            Assert.AreEqual(ccc.CommentStatistics.GetCommentCount(ccc.ElementsToCheck, ccc.VisibilityToCheck), 0);
            Assert.AreEqual(ccc.CommentStatistics.GetMissingCommentCount(ccc.ElementsToCheck, ccc.VisibilityToCheck), 1);
            Assert.AreEqual(ccc.CommentStatistics.CommentsCount.Count, 1);
            Assert.AreEqual(ccc.CommentStatistics.MissingCommentsCount.Count, 1);
            Assert.AreEqual(ccc.CommentStatistics.CommentsCount[ccc.ElementsToCheck].Count, 1);
            Assert.AreEqual(ccc.CommentStatistics.MissingCommentsCount[ccc.ElementsToCheck].Count, 1);
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
            ccc.TrackStatistics = true;

            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);

            Assert.AreEqual(ccc.CommentStatistics.GetCommentCount(ccc.ElementsToCheck, ccc.VisibilityToCheck), 0);
            Assert.AreEqual(ccc.CommentStatistics.GetMissingCommentCount(ccc.ElementsToCheck, ccc.VisibilityToCheck), 0);
            Assert.AreEqual(ccc.CommentStatistics.CommentsCount.Count, 1);
            Assert.AreEqual(ccc.CommentStatistics.MissingCommentsCount.Count, 1);
            Assert.AreEqual(ccc.CommentStatistics.CommentsCount[ccc.ElementsToCheck].Count, 1);
            Assert.AreEqual(ccc.CommentStatistics.MissingCommentsCount[ccc.ElementsToCheck].Count, 1);
        }

        [Test]
        public void FlagAndDictionaryTest()
        {
            string testClass = @"public class Test
                                {
                                    //public void Some()
                                    //{
                                    //}
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance(
                CodeCommentCheckingElements.Methods | CodeCommentCheckingElements.Class,
                CodeCommentCheckingVisibility.Public | CodeCommentCheckingVisibility.Private | CodeCommentCheckingVisibility.Protected);
            ccc.TrackStatistics = true;

            bool result = ccc.Verify(testClass, SupportedLanguage.CSharp);

            Assert.AreEqual(ccc.CommentStatistics.GetCommentCount(CodeCommentCheckingElements.Methods, CodeCommentCheckingVisibility.Public), 0);
            Assert.AreEqual(ccc.CommentStatistics.GetMissingCommentCount(CodeCommentCheckingElements.Class, CodeCommentCheckingVisibility.Public), 1);
            Assert.AreEqual(2, ccc.CommentStatistics.CommentsCount.Count); // two elements
            Assert.AreEqual(2, ccc.CommentStatistics.MissingCommentsCount.Count);
            Assert.AreEqual(3, ccc.CommentStatistics.CommentsCount[CodeCommentCheckingElements.Class].Count); // three visibilities
            Assert.AreEqual(3, ccc.CommentStatistics.MissingCommentsCount[CodeCommentCheckingElements.Methods].Count);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullTestOnDisablingStatistics()
        {
            string testClass = @"public class Test
                                {
                                }";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance();
            ccc.TrackStatistics = true;
            ccc.Verify(testClass, SupportedLanguage.CSharp);
            ccc.TrackStatistics = false;

            ccc.CommentStatistics.GetCommentCount(CodeCommentCheckingElements.Methods, CodeCommentCheckingVisibility.Public);
        }
    }
}
