using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NuForVS.Core;
using NuForVS.Test.Mocks;

namespace NuForVS.Test
{
    public class ObjectMother
    {
        public static PackageManager CreatePackageManager(string solutionPath = @"C:\Projects\Test\Solution.sln",
                                                    int targetFramework = 0, 
                                                    string projectPath = @"C:\Projects\Test\Test.csproj",
                                                    string[] references = null,
                                                    string[] commandLines = null,
                                                    string[] paths = null,
                                                    Configuration config = null
                                    )
        {
            var project = new MockProject(projectPath);
            if (references != null)
            {
                foreach (var reference in references)
                {
                    project.AddReference(reference);
                }
            }


            if (commandLines == null)
            {
                commandLines = new string[]
                                   {
                                       "log4net (1.2.10)",
                                       "nu (0.1.17)",
                                       "thor (0.14.0)"
                                   };
            }
            if (paths == null)
            {
                paths = new string[]
                            {
                                @"C:\Projects\Test\lib\log4net\LICENSE.txt",
                                @"C:\Projects\Test\lib\log4net\log4net.dll",
                                @"C:\Projects\Test\lib\log4net\log4net.xml",
                                @"C:\Projects\Test\lib\log4net\NOTICE.txt",
                                @"C:\Projects\Test\lib\log4net\README.txt"
                            };
            }

            if (config == null)
            {
                config = new Configuration
                             {
                                 GemCommand = "gem"
                             };
            }
            return new PackageManager(solutionPath, targetFramework, project, new MockCommandRunner(commandLines), new MockFileSystem(paths), new MockConfigurationManager(config));
        }
    }

}
