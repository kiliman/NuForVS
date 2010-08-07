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
            var targetFramework = 0;
            var project = new MockProject(@"C:\Projects\Test\Test.csproj");
            project.AddReference(@"C:\Projects\Test\lib\log4net\log4net.dll");

            var runner = new CommandRunner();
            // mock fs: contents of 2 gem
            var fs = new MockFileSystem(new string[] {
                    @"C:\Projects\Test\lib\log4net\LICENSE.txt",
                    @"C:\Projects\Test\lib\log4net\log4net.dll",
                    @"C:\Projects\Test\lib\log4net\log4net.xml",
                    @"C:\Projects\Test\lib\log4net\NOTICE.txt",
                    @"C:\Projects\Test\lib\log4net\README.txt",

                    @"C:\Projects\Test\lib\nunit\LICENSE.txt",
                    @"C:\Projects\Test\lib\nunit\nunit.dll",
                    @"C:\Projects\Test\lib\nunit\nunit.xml",
                    @"C:\Projects\Test\lib\nunit\NOTICE.txt",
                    @"C:\Projects\Test\lib\nunit\README.txt",
            });
            Application.Run(new AddReferenceForm(solutionPath, targetFramework, project, runner, fs));
        }
    }
}
