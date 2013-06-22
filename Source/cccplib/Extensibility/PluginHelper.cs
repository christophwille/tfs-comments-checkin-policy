using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using System.GACManagedAccess;

namespace CCCPLib.Extensibility
{
    public class PluginHelper
    {
        public static void ConfigurePlugin(PluginInformation pi)
        {
            ICheckCodeCommentsPluginConfiguration plugin = 
                (ICheckCodeCommentsPluginConfiguration)AppDomain.CurrentDomain.CreateInstanceAndUnwrap(pi.AssemblyFullName, pi.TypeFullName);

            plugin.Load(pi.Configuration);
            if (plugin.Edit())
                pi.Configuration = plugin.Save();
        }

        public static List<PluginInformation> GetPluginInformationFromAssembly(string fullName)
        {
            List<PluginInformation> availablePlugins = new List<PluginInformation>();

            Assembly asm = Assembly.LoadFrom(AssemblyCache.QueryAssemblyInfo(fullName));
            Type[] exportedTypes = asm.GetExportedTypes();
            int numberOfTypes = exportedTypes.Length;
            for (int i = 0; i < numberOfTypes; i++)
            {
                Type t = exportedTypes[i];
                if (t.IsClass)
                {
                    object[] attributes = t.GetCustomAttributes(typeof(CheckCodeCommentsPluginAttribute),false);

                    if (attributes.Length != 0)
                    {
                        CheckCodeCommentsPluginAttribute pa = (CheckCodeCommentsPluginAttribute)attributes[0];

                        PluginInformation pi = new PluginInformation();
                        pi.Name = pa.PluginName;
                        pi.Description = pa.PluginDescription;
                        pi.AssemblyFullName = fullName;
                        pi.TypeFullName = t.FullName;

                        if (null != t.GetInterface(typeof(ICheckCodeCommentsPluginConfiguration).ToString()))
                            pi.SupportsConfiguration = true;

                        availablePlugins.Add(pi);
                    }
                }
            }

            return availablePlugins;
        }

        public static SortedList<string, AssemblyDisplayInformation> EnumerateGAC()
        {
            AssemblyCacheEnum asmEnum = new AssemblyCacheEnum(null);
            SortedList<string, AssemblyDisplayInformation> sl = new SortedList<string, AssemblyDisplayInformation>();

            string currentAssembly = null;
            while (null != (currentAssembly = asmEnum.GetNextAssembly()))
            {
                // path in GAC: AssemblyCache.QueryAssemblyInfo(currentAssembly)
                string[] asmInfos = currentAssembly.Split(new char[] { ',' });
                if (asmInfos.Length >= 5)
                {
                    // only the full assembly name is unique, the short name isn't
                    sl.Add(currentAssembly, 
                        new AssemblyDisplayInformation(currentAssembly, 
                            asmInfos[0],                // short name
                            asmInfos[1].Substring(9),  // version information
                            asmInfos[2].Substring(9),  // culture
                            asmInfos[3].Substring(16),  // public key token
                            asmInfos[4].Substring(23)   // processor architecture
                            ));
                }
            }

            return sl;
        }
    }
}
