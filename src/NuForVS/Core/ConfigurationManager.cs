using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NuForVS.Core
{
    public class ConfigurationManager : IConfigurationManager
    {
        private string _configPath;
        private Configuration _config = new Configuration();

        public ConfigurationManager()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NuForVS");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            _configPath = Path.Combine(path, "config.ini");

            if (!File.Exists(_configPath))
            {
                // copy default config from resource
                using (var sr = new StreamReader(this.GetType().Assembly.GetManifestResourceStream("NuForVS.Resources.config.ini")))
                {
                    File.WriteAllText(_configPath, sr.ReadToEnd());
                }
            }

            loadConfig();
        }

        private void loadConfig()
        {
            var ini = new IniFile(_configPath);
            _config.GemCommand = ini.ReadValue("general", "gemCommand");
            _config.GemServer = ini.ReadValue("general", "gemServer");
            _config.AutoReferences.Clear();

            var references = ini.GetSection("auto-reference");
            foreach (var item in references)
            {
                var part = item.Split('=');
                var autoRef = new AutoReference {GemName = part[0]};
                var assemblies = part[1];
                foreach (var path in assemblies.Split(','))
                {
                    autoRef.Assemblies.Add(path);
                }
                _config.AutoReferences.Add(autoRef);
            }
        }

        public string ConfigurationAsText
        {
            get { return File.ReadAllText(_configPath); }
        }
        public Configuration GetConfig()
        {
            return _config;
        }
        
        public void SaveConfig(string configText)
        {
            File.WriteAllText(_configPath, configText);    
            loadConfig();
        }
    }
}
