using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuForVS.Core
{
    public class Configuration
    {
        public string Version { get; set; }
        public string GemCommand { get; set; }
        public string GemServer { get; set; }

        public string GemListCommand()
        {
            return GemCommand + " list" + (string.IsNullOrEmpty(GemServer) ? "" : " --source " + GemServer);
        }

        public string GemSearchCommand(string query)
        {
            return GemCommand + " query \"" + query + "\" --both" + (string.IsNullOrEmpty(GemServer) ? "" : " --source " + GemServer); 
        }

        public IList<AutoReference> AutoReferences { get; private set; }

        public Configuration()
        {
            AutoReferences = new List<AutoReference>();
        }
    }

    public class AutoReference
    {
        public string GemName { get; set; }
        public IList<string> Assemblies { get; private set; }

        public AutoReference()
        {
            Assemblies = new List<string>();
        }
    }
}
