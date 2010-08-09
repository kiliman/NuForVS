using System;
using System.Windows.Forms;
using NuForVS.Test.Mocks;
using NuForVS.UI;
using NuForVS.Core;

namespace NuForVS.TestUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()

        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0x00030005;
            var project = new MockProject(@"C:\Projects\Test\Test.csproj");
            project.AddReference(@"C:\Projects\Test\lib\log4net\log4net.dll");

            var runner = new CommandRunner();
            var fs = new FileSystem();
            var configManager = new ConfigurationManager();

            Application.Run(new AddReferenceForm(solutionPath, targetFramework, project, runner, fs, configManager));
        }
    }
}
