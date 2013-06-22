using System;
using System.Collections.Generic;
using System.Text;

namespace CCCPLib.Extensibility
{
    [Serializable]
    public class PluginInformation
    {
        public PluginInformation()
        {
            supportsConfiguration = false;
        }

        string assemblyFullName;

        public string AssemblyFullName
        {
            get { return assemblyFullName; }
            set { assemblyFullName = value; }
        }

        string typeFullName;

        public string TypeFullName
        {
            get { return typeFullName; }
            set { typeFullName = value; }
        }

        bool supportsConfiguration;

        public bool SupportsConfiguration
        {
            get { return supportsConfiguration; }
            set { supportsConfiguration = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // runtime properties
        bool enabled;

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        string configuration;

        public string Configuration
        {
            get { return configuration; }
            set { configuration = value; }
        }
    }
}
