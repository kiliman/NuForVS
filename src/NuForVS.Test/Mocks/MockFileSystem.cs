using System.Collections.Generic;
using System.Linq;
using NuForVS.Core;

namespace NuForVS.Test.Mocks
{
    public class MockFileSystem : IFileSystem
    {
        private string[] _paths;

        public MockFileSystem(string[] paths)
        {
            _paths = paths;
        }
        
        public bool FolderExists(string path)
        {
            if (!path.EndsWith(@"\")) path += @"\";
            return _paths.Any(p => p.StartsWith(path));
        }

        public bool FileExists(string path)
        {
            return _paths.Any(p => string.Compare(p, path, true) == 0);
        }

        public IEnumerable<string> GetFolders(string path)
        {
            if (!path.EndsWith(@"\")) path += @"\";

            IList<string> folders = new List<string>();

            foreach (var p in _paths)
            {
                if (p.StartsWith(path))
                {
                    var n = p.IndexOf('\\', path.Length + 1);
                    if (n >= 0)
                    {
                        var folder = p.Substring(0, n);
                        if (!folders.Contains(folder))
                        {
                            folders.Add(folder);
                        }
                    }
                }
            }
            return folders;
        }

        public IEnumerable<string> GetFiles(string path)
        {
            if (!path.EndsWith(@"\")) path += @"\";

            IList<string> files = new List<string>();

            for (int index = 0; index < _paths.Length; index++)
            {
                var p = _paths[index];
                if (p.StartsWith(path))
                {
                    var n = p.IndexOf('\\', path.Length + 1);
                    if (n == -1)
                    {
                        if (!files.Contains(p))
                        {
                            files.Add(p);
                        }
                    }
                }
            }
            return files;
        }
    }
}
