using System;
using System.Collections.Generic;
using System.Text;

using CCCPLib.Extensibility;
using ICSharpCode.NRefactory;
using ICSharpCode.SharpDevelop.Dom.NRefactoryResolver;

namespace CCCPLibContrib.Test
{
    [CheckCodeCommentsPlugin("Test.Simple", "This is a simple test code checking plugin without configuration")]
    public class SimplePlugin : ICheckCodeCommentsPlugin
    {
        private ICheckCodeCommentsHost theHost = null;

        public void Initialize(ICheckCodeCommentsHost host)
        {
            theHost = host;
        }

        public void BeginCompilationUnitVerification(string sourceCode, IParser parser, NRefactoryASTConvertVisitor visitor)
        {
        }

        public void EndCompilationUnitVerification()
        {
        }

        public CheckCodeCommentsVerificationState VerifyClass(ICSharpCode.SharpDevelop.Dom.IClass c)
        {
            return CheckCodeCommentsVerificationState.Forfeit;
        }

        public CheckCodeCommentsVerificationState VerifyMethod(ICSharpCode.SharpDevelop.Dom.IMethod m)
        {
            return CheckCodeCommentsVerificationState.Forfeit;
        }

        public CheckCodeCommentsVerificationState VerifyField(ICSharpCode.SharpDevelop.Dom.IField f)
        {
            return CheckCodeCommentsVerificationState.Forfeit;
        }

        public CheckCodeCommentsVerificationState VerifyProperty(ICSharpCode.SharpDevelop.Dom.IProperty p)
        {
            return CheckCodeCommentsVerificationState.Forfeit;
        }

        public CheckCodeCommentsVerificationState VerifyEvent(ICSharpCode.SharpDevelop.Dom.IEvent e)
        {
            return CheckCodeCommentsVerificationState.Forfeit;
        }
    }
}
