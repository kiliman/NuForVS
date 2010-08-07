using System.Collections.Generic;

namespace NuForVS.Core
{
    public interface ICommandRunner
    {
        IEnumerable<string> Run(string command, string args, string workingDirectory = null);
    }
}
