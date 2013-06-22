using System;
using System.Collections.Generic;
using System.Text;

namespace CCCPLib.Extensibility
{
    public class AssemblyDisplayInformation
    {
        string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        string shortName;

        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }
        string versionString;

        public string VersionString
        {
            get { return versionString; }
            set { versionString = value; }
        }

        string culture;

        public string Culture
        {
            get { return culture; }
            set { culture = value; }
        }
        string publicKeyToken;

        public string PublicKeyToken
        {
            get { return publicKeyToken; }
            set { publicKeyToken = value; }
        }
        string processorArchitecture;

        public string ProcessorArchitecture
        {
            get { return processorArchitecture; }
            set { processorArchitecture = value; }
        }

        public AssemblyDisplayInformation(string f, string s, string v, string c, string pkt, string pa)
        {
            fullName = f;
            shortName = s;
            versionString = v;
            culture = c;
            publicKeyToken = pkt;
            processorArchitecture = pa;
        }
    }
}
