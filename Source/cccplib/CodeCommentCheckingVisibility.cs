using System;

namespace CCCPLib
{
    [Serializable, Flags]
    public enum CodeCommentCheckingVisibility
    {
        Public = 1,
        Protected = 2,
        Private = 4,
    }
}
