using System;
using System.Collections.Generic;
using System.Text;

namespace CCCPLib.Extensibility
{
    public interface ICheckCodeCommentsPluginConfiguration
    {
        void Load(string serializedConfiguration);
        string Save();
        bool Edit();
    }
}
