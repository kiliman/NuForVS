using System.Linq;
using VSLangProj;

namespace NuForVS.Core
{
    class VSProjectWrapper : IProject
    {
        private VSLangProj.VSProject _vsproj;
        public VSProjectWrapper(VSLangProj.VSProject vsproj)
        {
            _vsproj = vsproj;
        }

        public string ProjectPath
        {
            get
            {
                return _vsproj.Project.FullName;
            }
        }

        public bool HasReference(string path)
        {
            return _vsproj.References.Cast<Reference>().Any(reference => string.Compare(reference.Path.ToString(), path, true) == 0);
        }

        public void AddReference(string path)
        {
            _vsproj.References.Add(path);
        }
    }
}
