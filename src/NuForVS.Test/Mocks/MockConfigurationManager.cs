using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NuForVS.Core;

namespace NuForVS.Test.Mocks
{
    public class MockConfigurationManager : IConfigurationManager
    {
        private Configuration _config;

        public MockConfigurationManager(Configuration config)
        {
            _config = config;
        }

        public string ConfigurationAsText
        {
            get { throw new NotImplementedException(); }
        }

        public Configuration GetConfig()
        {
            return _config;
        }

        public void SaveConfig(string configText)
        {
            throw new NotImplementedException();
        }
    }
}
