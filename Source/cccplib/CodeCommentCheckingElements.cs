using System;

namespace CCCPLib
{
    [Serializable, Flags]
    public enum CodeCommentCheckingElements
    {
        Methods = 1,
        Properties = 2,
        Events = 4,
        Fields = 8,
        Class = 16,
    }
}
