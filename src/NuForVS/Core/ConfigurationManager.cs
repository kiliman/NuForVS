using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuForVS.Core
{
    public class ConfigurationManager : IConfigurationManager
    {
        public Configuration GetConfig()
        {
            return new Configuration();
        }
    }
}
