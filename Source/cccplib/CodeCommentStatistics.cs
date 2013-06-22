using System;
using System.Collections.Generic;
using System.Text;

namespace CCCPLib
{
    public class VisibilityCommentCountDictionary : Dictionary<CodeCommentCheckingVisibility, int>
    {
    }

    public class CommentCountDictionary : Dictionary<CodeCommentCheckingElements, VisibilityCommentCountDictionary>
    {
    }

    public class CodeCommentStatistics
    {
        private CommentCountDictionary commentsCount;

        public CommentCountDictionary CommentsCount
        {
            get { return commentsCount; }
        }
        private CommentCountDictionary missingCommentsCount;

        public CommentCountDictionary MissingCommentsCount
        {
            get { return missingCommentsCount; }
        }

        private CodeCommentStatistics()
        {
            commentsCount = new CommentCountDictionary();
            missingCommentsCount = new CommentCountDictionary();
        }

        public static CodeCommentStatistics CreateInstance(CodeCommentCheckingElements elementFlags, CodeCommentCheckingVisibility visibilityFlags)
        {
            CodeCommentStatistics ccs = new CodeCommentStatistics();

            Array elementValues = Enum.GetValues(typeof(CodeCommentCheckingElements));
            for (int i = 0; i < elementValues.Length; i++)
            {
                // flag set? if so, we need to add it to the dictionary
                CodeCommentCheckingElements currentElement = ((CodeCommentCheckingElements)elementValues.GetValue(i));
                if ((currentElement & elementFlags) == currentElement)
                {
                    VisibilityCommentCountDictionary cc = new VisibilityCommentCountDictionary();
                    ccs.commentsCount.Add(currentElement, cc);

                    VisibilityCommentCountDictionary mcc = new VisibilityCommentCountDictionary();
                    ccs.missingCommentsCount.Add(currentElement, mcc);

                    Array visibilityValues = Enum.GetValues(typeof(CodeCommentCheckingVisibility));
                    for (int j = 0; j < visibilityValues.Length; j++)
                    {
                        CodeCommentCheckingVisibility currentVisibility = ((CodeCommentCheckingVisibility)visibilityValues.GetValue(j));
                        if ((currentVisibility & visibilityFlags) == currentVisibility)
                        {
                            cc.Add(currentVisibility, 0);
                            mcc.Add(currentVisibility, 0);
                        }
                    }
                }
            }

            return ccs;
        }

        public void Clear()
        {
            foreach (VisibilityCommentCountDictionary vccd in commentsCount.Values)
            {
                foreach (CodeCommentCheckingVisibility vi in vccd.Keys)
                {
                    vccd[vi] = 0;
                }
            }

            foreach (VisibilityCommentCountDictionary vccd in missingCommentsCount.Values)
            {
                foreach (CodeCommentCheckingVisibility vi in vccd.Keys)
                {
                    vccd[vi] = 0;
                }
            }
        }

        public void IncCommentCount(CodeCommentCheckingElements element, CodeCommentCheckingVisibility visibility)
        {
            commentsCount[element][visibility] = commentsCount[element][visibility] + 1;
        }

        public void IncMissingCommentCount(CodeCommentCheckingElements element, CodeCommentCheckingVisibility visibility)
        {
            missingCommentsCount[element][visibility] = missingCommentsCount[element][visibility] + 1;
        }

        public int GetCommentCount(CodeCommentCheckingElements element, CodeCommentCheckingVisibility visibility)
        {
            return commentsCount[element][visibility];
        }

        public int GetMissingCommentCount(CodeCommentCheckingElements element, CodeCommentCheckingVisibility visibility)
        {
            return missingCommentsCount[element][visibility];
        }
    }
}
