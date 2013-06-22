using System;
using System.Collections.Generic;
using System.Text;

namespace CCCPLib.Extensibility
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CheckCodeCommentsPluginAttribute : Attribute
    {
        private string pluginName;
        private string pluginDescription;

        public string PluginDescription
        {
            get { return pluginDescription; }
            set { pluginDescription = value; }
        }

        public string PluginName
        {
            get { return pluginName; }
            set { pluginName = value; }
        }

        public CheckCodeCommentsPluginAttribute(string pn, string pd)
        {
            pluginName = pn;
            pluginDescription = pd;
        }
    }
}
