using System.Collections.Generic;
using NuForVS.Core;

namespace NuForVS.Test.Mocks
{
    public class MockCommandRunner : ICommandRunner
    {
        private string[] _lines;
        
        public MockCommandRunner(string[] lines)
        {
            _lines = lines;
        }
        public IEnumerable<string> Run(string command, string args, string workingDirectory = null)
        {
            foreach (var line in _lines)
            {
                yield return line;
            }
        }

    }
}
