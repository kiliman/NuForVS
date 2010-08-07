using System.Collections.Generic;
using System.Diagnostics;

namespace NuForVS.Core
{
    public class CommandRunner : ICommandRunner
    {
        public IEnumerable<string> Run(string command, string args, string workingDirectory = null)
        {
            var psi = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory
            };

            var p = Process.Start(psi);
            while (!p.StandardOutput.EndOfStream)
            {
                yield return p.StandardOutput.ReadLine();
            }
            p.WaitForExit();
        }
    }
}
