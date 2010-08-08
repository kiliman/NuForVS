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

        public PackageManager(string solutionPath, int targetFramework, IProject project, ICommandRunner runner, IFileSystem fs)
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
            _targetFramework = targetFramework;
            _project = project;
            _runner = runner;
            _fs = fs;
        }

        public string RootPath
        {
            get { return _rootPath; }
        }
        public string LibPath
        {
            get { return _libPath;  }
        }

        public IEnumerable<Gem> ListGems()
        {
            var gems = new List<Gem>();

            foreach (var line in _runner.Run("cmd.exe", "/c gem list"))
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

            output("> gem query -b -n \"" + query + "\"");
            var remoteGems = false;
            foreach (var line in _runner.Run("cmd.exe", "/c gem query -b -n \"" + query + "\""))
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
            foreach (var line in _runner.Run("cmd.exe", "/c nu install " + gemname, _rootPath))
            {
                output(line);
                if (line.StartsWith("Copy To:"))
                {
                    var installPath = line.Substring(9).Replace("/", "\\");
                    var name = Path.GetFileName(installPath);

                    var gem = new Gem { Name = name };
                    if (!gems.Contains(gem))
                    {
                        gems.Add(gem);
                        getAssemblies(gem, installPath);
                    }
                }
            }

            // for each gem, auto reference gems with 1 assembly
            // return rest to prompt user
            foreach (var gem in gems)
            {
                // if only 1 assembly in this gem, auto reference it
                if (gem.Assemblies.Count == 1)
                {
                    output("Adding Reference: " + gem.Assemblies[0]);
                    _project.AddReference(gem.Assemblies[0]);
                    gem.IsReferenced = true;
                }
            }

            return gems;
        }


        private void getAssemblies(Gem gem, string installPath)
        {
            if (!_fs.FolderExists(installPath)) return;

            // check for framework folders
            foreach (var folder in _fs.GetFolders(installPath))
            {
                if (IsTargetFramework(Path.GetFileName(folder), _targetFramework))
                {
                    installPath = folder;
                }
            }

            foreach (var filename in _fs.GetFiles(installPath))
            {
                if (filename.EndsWith(".dll"))
                {
                    gem.Assemblies.Add(filename);
                }
            }
        }

        public bool IsTargetFramework(string folder, int targetFramework)
        {
            var majorVersion = targetFramework >> 16;
            var minorVersion = targetFramework & 0xFFFF;

            var re = new Regex("(net|mono|sl|silverlight)[ -]?(\\d+)[.]?(\\d*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var m = re.Match(folder);
            if (!m.Success) return false;

            var platform = m.Groups[1].Value;
            var platformMajorVersion = Convert.ToInt32(m.Groups[2].Value);
            var platformMinorVersion = 0;
            if (m.Groups[3].Value != "") platformMinorVersion = Convert.ToInt32(m.Groups[3].Value);

            return m.Success;

        }
    }

}
