using System;

namespace CCCPLib.Extensibility
{
    public enum CheckCodeCommentsVerificationState
    {
        Pass,
        Fail,
        Forfeit // "pass up" on this test, don't vote on the outcome of the verification
                // eg when a plugin only adds value to method comment checking
    }
}