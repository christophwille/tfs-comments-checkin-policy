using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using CCCPLib.Extensibility;
using ICSharpCode.NRefactory;
using ICSharpCode.SharpDevelop.Dom.NRefactoryResolver;

namespace CCCPLibContrib.Test
{
    [CheckCodeCommentsPlugin("Test.Configurable", "This is test plugin can be configured")]
    public class ConfigurablePlugin : ICheckCodeCommentsPlugin, ICheckCodeCommentsPluginConfiguration
    {
        #region ICheckCodeCommentsPlugin Members

        public void Initialize(ICheckCodeCommentsHost host)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void BeginCompilationUnitVerification(string sourceCode, IParser parser, NRefactoryASTConvertVisitor visitor)
        {
        }

        public void EndCompilationUnitVerification()
        {
        }

        public CheckCodeCommentsVerificationState VerifyClass(ICSharpCode.SharpDevelop.Dom.IClass c)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CheckCodeCommentsVerificationState VerifyMethod(ICSharpCode.SharpDevelop.Dom.IMethod m)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CheckCodeCommentsVerificationState VerifyField(ICSharpCode.SharpDevelop.Dom.IField f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CheckCodeCommentsVerificationState VerifyProperty(ICSharpCode.SharpDevelop.Dom.IProperty p)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CheckCodeCommentsVerificationState VerifyEvent(ICSharpCode.SharpDevelop.Dom.IEvent e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region ICheckCodeCommentsPluginConfiguration Members

        private string config;

        public void Load(string serializedConfiguration)
        {
            config = serializedConfiguration;
        }

        public string Save()
        {
            return config;
        }

        public bool Edit()
        {
            ConfigurablePluginForm form = new ConfigurablePluginForm();
            form.TheValue = config;

            if (DialogResult.OK == form.ShowDialog())
            {
                config = form.TheValue;
                return true;
            }

            return false;
        }

        #endregion
    }
}
