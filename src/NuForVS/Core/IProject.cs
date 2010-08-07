namespace NuForVS.Core
{
    public interface IProject
    {
        string ProjectPath { get; }
        bool HasReference(string path);
        void AddReference(string path);
    }
}
