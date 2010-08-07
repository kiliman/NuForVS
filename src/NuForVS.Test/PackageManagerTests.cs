using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NuForVS.Core;
using NuForVS.Test.Mocks;
using NUnit.Framework;

namespace NuForVS.Tests
{
    [TestFixture]
    public class PackageManagerTests
    {
        [TestCase("net-3.5", true)]
        [TestCase("NET40", true)]
        [TestCase("silverlight-2.0", true)]
        [TestCase("abc123", false)]
        [TestCase("123xyz", false)]
        public void IsTargetFramework(string path, bool expectedResult)
        {
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0;
            var pm = new PackageManager(solutionPath, targetFramework, null, null, null);

            Assert.AreEqual(expectedResult, pm.IsTargetFramework(path, targetFramework));
        }

        [Test]
        public void ListGemsShouldReturnCorrectGemCount()
        {
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0;
            var project = new MockProject(@"C:\Projects\Test\Test.csproj");

            var runner = new MockCommandRunner(new string[] {
                    "log4net (1.2.10)",
                    "nu (0.1.17)",
                    "thor (0.14.0)"
            });
            var fs = new MockFileSystem(new string[] {
                    @"C:\Projects\Test\lib\log4net\LICENSE.txt",
                    @"C:\Projects\Test\lib\log4net\log4net.dll",
                    @"C:\Projects\Test\lib\log4net\log4net.xml",
                    @"C:\Projects\Test\lib\log4net\NOTICE.txt",
                    @"C:\Projects\Test\lib\log4net\README.txt"
            });
            var pm = new PackageManager(solutionPath, targetFramework, project, runner, fs);
            var gems = pm.ListGems().ToList();

            Assert.AreEqual(3, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual("nu", gems[1].Name);
            Assert.AreEqual("thor", gems[2].Name);
        }

        [Test]
        public void InstallGemShouldReturn1Reference()
        {
            // mock project
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0;
            var project = new MockProject(@"C:\Projects\Test\Test.csproj");

            // mock command: nu install log4net
            var runner = new MockCommandRunner(new string[] {
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/log4net-1.2.10.0/lib",
                    "Copy To: C:/Projects/Test/lib/log4net"
            });

            // mock fs: contents of gem
            var gemname = "log4net";
            var fs = new MockFileSystem(new string[] {
                    @"C:\Projects\Test\lib\log4net\LICENSE.txt",
                    @"C:\Projects\Test\lib\log4net\log4net.dll",
                    @"C:\Projects\Test\lib\log4net\log4net.xml",
                    @"C:\Projects\Test\lib\log4net\NOTICE.txt",
                    @"C:\Projects\Test\lib\log4net\README.txt"
            });
            

            var pm = new PackageManager(solutionPath, targetFramework, project, runner, fs);
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(1, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.AreEqual(true, gems[0].IsReferenced);
            Assert.AreEqual(true, project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));
        }

        [Test]
        public void InstallGemShouldReturn1GemAnd2AssembliesNotReferenced()
        {
            // mock project
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0;
            var project = new MockProject(@"C:\Projects\Test\Test.csproj");

            // mock command: nu install log4net
            var runner = new MockCommandRunner(new string[] {
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/log4net-1.2.10.0/lib",
                    "Copy To: C:/Projects/Test/lib/log4net"
            });

            // mock fs: contents of gem (2 assemblies)
            var gemname = "log4net";
            var fs = new MockFileSystem(new string[] {
                    @"C:\Projects\Test\lib\log4net\LICENSE.txt",
                    @"C:\Projects\Test\lib\log4net\log4net.dll",
                    @"C:\Projects\Test\lib\log4net\log4net2.dll",
                    @"C:\Projects\Test\lib\log4net\log4net.xml",
                    @"C:\Projects\Test\lib\log4net\NOTICE.txt",
                    @"C:\Projects\Test\lib\log4net\README.txt"
            });


            var pm = new PackageManager(solutionPath, targetFramework, project, runner, fs);
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(1, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(2, gems[0].Assemblies.Count);
            Assert.AreEqual(false, gems[0].IsReferenced);
            Assert.AreEqual(false, project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));
        }

        [Test]
        public void InstallGemShouldReturn2GemsBothAutoReferenced()
        {
            // mock project
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0;
            var project = new MockProject(@"C:\Projects\Test\Test.csproj");

            // mock command: nu install log4net (dependency on nunit)
            var runner = new MockCommandRunner(new string[] {
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/log4net-1.2.10.0/lib",
                    "Copy To: C:/Projects/Test/lib/log4net",
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/nunit-2.5.7.10213/lib",
                    "Copy To: C:/Projects/Test/lib/nunit"
            });

            // mock fs: contents of 2 gem
            var gemname = "log4net";
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


            var pm = new PackageManager(solutionPath, targetFramework, project, runner, fs);
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(2, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.AreEqual(true, gems[0].IsReferenced);
            Assert.AreEqual(true, project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));

            Assert.AreEqual("nunit", gems[1].Name);
            Assert.AreEqual(1, gems[1].Assemblies.Count);
            Assert.AreEqual(true, gems[1].IsReferenced);
            Assert.AreEqual(true, project.HasReference(@"C:\Projects\Test\lib\nunit\nunit.dll"));
        }

        [Test]
        public void InstallGemShouldReturn2GemsBothAutoReferencedWithTargetFramework()
        {
            // mock project
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0x00030005;
            var project = new MockProject(@"C:\Projects\Test\Test.csproj");

            // mock command: nu install log4net (dependency on nunit)
            var runner = new MockCommandRunner(new string[] {
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/castle.dynamicproxy2-2.1.0.0/lib",
                    "Copy To: C:/Projects/Test/lib/castle.dynamicproxy2",
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/castle.core-1.1.0.0/lib",
                    "Copy To: C:/Projects/Test/lib/castle.core"
            });

            // mock fs: contents of 2 gem
            var gemname = "castle.dynamicproxy2";
            var fs = new MockFileSystem(new string[] {
                    @"C:\Projects\Test\lib\castle.dynamicproxy2\net-2.0\Castle.DynamicProxy2.dll",
                    @"C:\Projects\Test\lib\castle.dynamicproxy2\net-2.0\Castle.DynamicProxy2.xml",
                    @"C:\Projects\Test\lib\castle.dynamicproxy2\net-3.5\Castle.DynamicProxy2.dll",
                    @"C:\Projects\Test\lib\castle.dynamicproxy2\net-3.5\Castle.DynamicProxy2.xml",

                    @"C:\Projects\Test\lib\castle.core\Castle.Core.dll",
                    @"C:\Projects\Test\lib\castle.core\Castle.Core.xml",
            });


            var pm = new PackageManager(solutionPath, targetFramework, project, runner, fs);
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(2, gems.Count);
            Assert.AreEqual("castle.dynamicproxy2", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.AreEqual(true, gems[0].IsReferenced);
            Assert.AreEqual(true, project.HasReference(@"C:\Projects\Test\lib\castle.dynamicproxy2\net-3.5\Castle.DynamicProxy2.dll"));

            Assert.AreEqual("castle.core", gems[1].Name);
            Assert.AreEqual(1, gems[1].Assemblies.Count);
            Assert.AreEqual(true, gems[1].IsReferenced);
            Assert.AreEqual(true, project.HasReference(@"C:\Projects\Test\lib\castle.core\Castle.Core.dll"));
        }

        [Test]
        public void InstallGemShouldReturn2GemsOnly1AutoReferenced()
        {
            // mock project
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0;
            var project = new MockProject(@"C:\Projects\Test\Test.csproj");

            // mock command: nu install log4net (dependency on nunit)
            var runner = new MockCommandRunner(new string[] {
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/log4net-1.2.10.0/lib",
                    "Copy To: C:/Projects/Test/lib/log4net",
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/nunit-2.5.7.10213/lib",
                    "Copy To: C:/Projects/Test/lib/nunit"
            });

            // mock fs: contents of 2 gem (nunit has 2 assemblies)
            var gemname = "log4net";
            var fs = new MockFileSystem(new string[] {
                    @"C:\Projects\Test\lib\log4net\LICENSE.txt",
                    @"C:\Projects\Test\lib\log4net\log4net.dll",
                    @"C:\Projects\Test\lib\log4net\log4net.xml",
                    @"C:\Projects\Test\lib\log4net\NOTICE.txt",
                    @"C:\Projects\Test\lib\log4net\README.txt",

                    @"C:\Projects\Test\lib\nunit\LICENSE.txt",
                    @"C:\Projects\Test\lib\nunit\nunit.dll",
                    @"C:\Projects\Test\lib\nunit\nunit2.dll",
                    @"C:\Projects\Test\lib\nunit\nunit.xml",
                    @"C:\Projects\Test\lib\nunit\NOTICE.txt",
                    @"C:\Projects\Test\lib\nunit\README.txt",
            });


            var pm = new PackageManager(solutionPath, targetFramework, project, runner, fs);
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(2, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.AreEqual(true, gems[0].IsReferenced);
            Assert.AreEqual(true, project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));

            Assert.AreEqual("nunit", gems[1].Name);
            Assert.AreEqual(2, gems[1].Assemblies.Count);
            Assert.AreEqual(false, gems[1].IsReferenced);
            Assert.AreEqual(false, project.HasReference(@"C:\Projects\Test\lib\nunit\nunit.dll"));
        }

        [Test]
        public void ListGemShouldReturn2Gems1ThatIsReferenced()
        {
            // mock project
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0;
            var project = new MockProject(@"C:\Projects\Test\Test.csproj");
            project.AddReference(@"C:\Projects\Test\lib\log4net\log4net.dll");

            // mock command: gem list
            var runner = new MockCommandRunner(new string[] {
                    "log4net (1.2.10)",
                    "nunit (2.5.7.10213)",
            });

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


            var pm = new PackageManager(solutionPath, targetFramework, project, runner, fs);
            var gems = pm.ListGems().ToList();

            Assert.AreEqual(2, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.AreEqual(true, gems[0].IsReferenced);
            Assert.AreEqual(true, project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));

            Assert.AreEqual("nunit", gems[1].Name);
            Assert.AreEqual(1, gems[1].Assemblies.Count);
            Assert.AreEqual(false, gems[1].IsReferenced);
            Assert.AreEqual(false, project.HasReference(@"C:\Projects\Test\lib\nunit\nunit.dll"));
        }

        [Test]
        public void LibPathShouldBeInSolutionPath()
        {
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var targetFramework = 0;
            var pm = new PackageManager(solutionPath, targetFramework, null, null, null);

            Assert.AreEqual(@"C:\Projects\Test\lib", pm.LibPath);
        }

        [Test]
        public void LibPathShouldBeSiblingOfSrcPath()
        {
            var solutionPath = @"C:\Projects\Test\src\Solution.sln";
            var targetFramework = 0;
            var pm = new PackageManager(solutionPath, targetFramework, null, null, null);

            Assert.AreEqual(@"C:\Projects\Test\lib", pm.LibPath);
        }



        private void noOutput(string line)
        {
        }
    }
}
