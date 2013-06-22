using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.NRefactory;
using ICSharpCode.SharpDevelop.Dom.NRefactoryResolver;

namespace CCCPLib.Extensibility
{
    public interface ICheckCodeCommentsPlugin
    {
        // Called exactly once when the plugin is loaded by the PluginManager
        void Initialize(ICheckCodeCommentsHost host);

        // Called when the parser has successfully parsed the file, before the first call to CheckClass
        void BeginCompilationUnitVerification(string sourceCode, IParser parser, NRefactoryASTConvertVisitor visitor);

        // Called after the last call to CheckClass, before the host returns evaluation results to the caller
        void EndCompilationUnitVerification();

        CheckCodeCommentsVerificationState VerifyClass(IClass c);
        CheckCodeCommentsVerificationState VerifyMethod(IMethod m);
        CheckCodeCommentsVerificationState VerifyField(IField f);
        CheckCodeCommentsVerificationState VerifyProperty(IProperty p);
        CheckCodeCommentsVerificationState VerifyEvent(IEvent e);
    }
}
