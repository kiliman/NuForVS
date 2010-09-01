using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace NuForVS.Core
{
    public class PackageManager
    {
        private string _solutionPath;
        private string _rootPath;
        private string _libPath;
        private int _targetFramework;
        private IProject _project;
        private ICommandRunner _runner;
        private IFileSystem _fs;
        private IConfigurationManager _configManager;
        private Configuration _config;
        private Regex _targetRegex = new Regex("(net)[ -]?(\\d)[.]?(\\d*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public PackageManager(string solutionPath, int targetFramework, IProject project, ICommandRunner runner, IFileSystem fs, IConfigurationManager configManager)
        {
            _solutionPath = solutionPath;

            // lib will be in solution folder
            _rootPath = Path.GetDirectoryName(_solutionPath);

            // if parent of solution is src folder, then use solution parent
            // lib should be sibling of src
            if (string.Compare(Path.GetFileName(_rootPath), "src", true) == 0)
            {
                _rootPath = Path.GetDirectoryName(_rootPath);
            }
            _libPath = Path.Combine(_rootPath, "lib");
            _targetFramework = targetFramework == 0 ? 0x00020000 : targetFramework; // default to 2.0
            _project = project;
            _runner = runner;
            _fs = fs;
            _configManager = configManager;
            _config = _configManager.GetConfig();
        }

        public string RootPath
        {
            get { return _rootPath; }
        }
        public string LibPath
        {
            get { return _libPath;  }
        }
        public IProject Project
        {
            get { return _project;  }
        }
        public IEnumerable<Gem> ListGems()
        {
            var gems = new List<Gem>();

            foreach (var line in _runner.Run("cmd.exe", "/c " + _config.GemListCommand()))
            {
                // parse line
                var m = Regex.Match(line, "(.+?)\\s\\((.+?)\\)");
                if (!m.Success) continue;
                var gem = new Gem
                              {
                                  Name = m.Groups[1].Value,
                                  Version = m.Groups[2].Value
                              };
                getAssemblies(gem, Path.Combine(_libPath, gem.Name));
                gems.Add(gem);

                if (gem.Assemblies.Count == 0) continue;

                // count how many assemblies of this gem are currently referenced in project
                var refCount = gem.Assemblies.Count(filename => _project.HasReference(filename));

                // if assembly count equals ref count then gem is referenced
                if (gem.Assemblies.Count == refCount)
                {
                    gem.IsReferenced = true;
                }
            }
            return gems;
        }

        public IEnumerable<Gem> SearchGems(string query, Action<string> output)
        {
            var gems = new List<Gem>();

            output("> " + _config.GemSearchCommand(query));
            var remoteGems = false;
            foreach (var line in _runner.Run("cmd.exe", "/c " + _config.GemSearchCommand(query)))
            {
                output(line);
                if (line == "*** REMOTE GEMS ***")
                {
                    remoteGems = true;
                    continue;
                }
                // parse line
                var m = Regex.Match(line, "(.+?)\\s\\((.+?)\\)");
                if (!m.Success) continue;
                var gem = new Gem
                              {
                                  Name = m.Groups[1].Value,
                                  Version = m.Groups[2].Value,
                                  IsRemote = remoteGems
                              };
                if (!gems.Contains(gem))
                {
                    gems.Add(gem);
                }
            }
            return gems;
        }

        public IList<Gem> InstallGem(string gemname, Action<string> output)
        {
            IList<Gem> gems = new List<Gem>();

            // build list of gems and assemblies installed by nu in _root/lib
            output("> nu install " + gemname);
            foreach (var line in _runner.Run("cmd.exe", "/c nu install " + gemname + " --verbose", _rootPath))
            {
                output(line);
                if (line.StartsWith("Copy To:"))
                {
                    var installPath = Path.GetFullPath(line.Substring(9).Replace("/", "\\"));
                    var name = Path.GetFileName(installPath);

                    var gem = new Gem { Name = name };
                    if (!gems.Contains(gem))
                    {
                        gems.Add(gem);
                        getAssemblies(gem, installPath);
                    }
                }
            }

            // for each gem, auto reference gems with 1 assembly (or configured auto-ref)
            // return rest to prompt user
            foreach (var gem in gems)
            {
                // if only 1 assembly in this gem, auto reference it
                if (gem.Assemblies.Count == 1 || gem.IsAutoReferenced)
                {
                    foreach (var assembly in gem.Assemblies)
                    {
                        output("Adding Reference: " + assembly);
                        _project.AddReference(assembly);
                        gem.IsReferenced = true;
                    }
                }
            }

            return gems;
        }


        private void getAssemblies(Gem gem, string installPath)
        {
            if (!_fs.FolderExists(installPath)) return;

            var currentFrameworkVersion = 0;

            // check for framework folders
            foreach (var folder in _fs.GetFolders(installPath))
            {
                var version = GetTargetFrameworkVersion(Path.GetFileName(folder));
                if (version != 0 && version > currentFrameworkVersion && version <= _targetFramework)
                {
                    currentFrameworkVersion = version;
                    installPath = folder;
                }
            }

            // look for auto-ref
            var autoref = _config.AutoReferences.FirstOrDefault(a => a.GemName == gem.Name);
            if (autoref != null)
            {
                gem.IsAutoReferenced = true;
                foreach (var path in autoref.Assemblies)
                {
                    var filePath = path.Replace("/", "\\");
                    // strip leading /
                    if (filePath.StartsWith("\\")) filePath = filePath.Substring(1);
                    // if ends with * then add all in path
                    if (filePath.EndsWith("*"))
                    {
                        foreach (var filename in _fs.GetFiles(Path.Combine(installPath, Path.GetDirectoryName(filePath))))
                        {
                            if (filename.EndsWith(".dll"))
                            {
                                gem.Assemblies.Add(filename);
                            }
                        }
                    }
                    else
                    {
                        gem.Assemblies.Add(Path.Combine(installPath, filePath));
                    }
                }
            }
            else
            {


                foreach (var filename in _fs.GetFiles(installPath))
                {
                    if (filename.EndsWith(".dll"))
                    {
                        gem.Assemblies.Add(filename);
                    }
                }
            }
        }

        public int GetTargetFrameworkVersion(string folder)
        {
            var m = _targetRegex.Match(folder);
            if (!m.Success) return 0;

            var platform = m.Groups[1].Value;
            var platformMajorVersion = Convert.ToInt32(m.Groups[2].Value);
            var platformMinorVersion = 0;
            if (m.Groups[3].Value != "") platformMinorVersion = Convert.ToInt32(m.Groups[3].Value);

            return platformMajorVersion << 16 | platformMinorVersion;

        }
    }

}
