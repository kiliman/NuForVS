using System.Collections.Generic;
using System.IO;

namespace NuForVS.Core
{
    public class FileSystem : IFileSystem
    {
        public bool FolderExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
        
        public IEnumerable<string> GetFolders(string path)
        {
            return Directory.GetDirectories(path);
        }

        public IEnumerable<string> GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}
