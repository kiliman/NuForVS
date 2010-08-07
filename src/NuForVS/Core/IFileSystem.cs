using System.Collections.Generic;

namespace NuForVS.Core
{
    public interface IFileSystem
    {
        bool FolderExists(string path);
        bool FileExists(string path);
        IEnumerable<string> GetFolders(string path);
        IEnumerable<string> GetFiles(string path);
    }
}
