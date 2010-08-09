using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuForVS.Core
{
    public interface IConfigurationManager
    {
        string ConfigurationAsText { get; }
        Configuration GetConfig();
        void SaveConfig(string configText);
    }
}
