using System.Collections.Generic;
using NuForVS.Core;

namespace NuForVS.Test.Mocks
{
    public class MockProject : IProject
    {
        private string _projectPath;
        private IList<string> _references = new List<string>();

        public MockProject(string projectPath)
        {
            _projectPath = projectPath;
        }

        public string ProjectPath { get { return _projectPath; } }

        public bool HasReference(string path)
        {
            return _references.Contains(path);
        }

        public void AddReference(string path)
        {
            _references.Add(path);
        }

    }
}
