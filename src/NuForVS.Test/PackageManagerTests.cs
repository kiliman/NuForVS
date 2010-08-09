using System.Linq;
using NuForVS.Core;
using NuForVS.Test.Mocks;
using NUnit.Framework;

namespace NuForVS.Test
{
    [TestFixture]
    public class PackageManagerTests
    {
        [TestCase("net-3.5", 0x00030005)]
        [TestCase("NET40", 0x00040000)]
        [TestCase("silverlight-2.0", 0)]
        [TestCase("abc123", 0)]
        [TestCase("123xyz", 0)]
        public void GetTargetFrameworkVersion(string path, int expectedResult)
        {
            var pm = ObjectMother.CreatePackageManager();

            Assert.AreEqual(expectedResult, pm.GetTargetFrameworkVersion(path));
        }

        [Test]
        public void ListGemsShouldReturnCorrectGemCount()
        {
            var commandLines = new string[]
            {
                "log4net (1.2.10)",
                "nu (0.1.17)",
                "thor (0.14.0)"
            };

            var pm = ObjectMother.CreatePackageManager(commandLines: commandLines);
            var gems = pm.ListGems().ToList();

            Assert.AreEqual(3, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual("nu", gems[1].Name);
            Assert.AreEqual("thor", gems[2].Name);
        }

        [Test]
        public void SearchGemsShouldReturnCorrectGemCount()
        {
            var commandLines = new string[]
            {
                    "*** LOCAL GEMS ***",
                    "",
                    "castle.core (1.2.0.0)",
                    "",
                    "*** REMOTE GEMS ***",
                    "",
                    "bouncy-castle-java (1.5.0145.2)",
                    "castle (0.0.3)",
                    "castle.core (1.2.0.0)",
                    "castle.dynamicproxy2 (2.2.0.0)",
                    "castle.windsor (2.1.0.0)"
            };

            var pm = ObjectMother.CreatePackageManager(commandLines: commandLines);
            var gems = pm.SearchGems("castle", noOutput).ToList();

            Assert.AreEqual(5, gems.Count);
            Assert.AreEqual("castle.core", gems[0].Name);
            Assert.IsFalse(gems[0].IsRemote);
            Assert.AreEqual("castle.dynamicproxy2", gems[3].Name);
            Assert.IsTrue(gems[3].IsRemote);
        }

        [Test]
        public void InstallGemShouldReturn1Reference()
        {
            var commandLines = new string[]
            {
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/log4net-1.2.10.0/lib",
                    "Copy To: C:/Projects/Test/lib/log4net"
            };

            var pm = ObjectMother.CreatePackageManager(commandLines: commandLines);
            
            // mock fs: contents of gem
            var gemname = "log4net";
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(1, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.IsTrue(gems[0].IsReferenced);
            Assert.IsTrue(pm.Project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));
        }

        [Test]
        public void InstallGemShouldReturn1GemAnd2AssembliesNotReferenced()
        {
            var commandLines = new string[]
            {
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/log4net-1.2.10.0/lib",
                    "Copy To: C:/Projects/Test/lib/log4net"
            };

            var paths = new string[]
                            {
                                @"C:\Projects\Test\lib\log4net\LICENSE.txt",
                                @"C:\Projects\Test\lib\log4net\log4net.dll",
                                @"C:\Projects\Test\lib\log4net\log4net2.dll",
                                @"C:\Projects\Test\lib\log4net\log4net.xml",
                                @"C:\Projects\Test\lib\log4net\NOTICE.txt",
                                @"C:\Projects\Test\lib\log4net\README.txt"

                            };

            var pm = ObjectMother.CreatePackageManager(commandLines: commandLines, paths: paths);

            // mock fs: contents of gem (2 assemblies)
            var gemname = "log4net";
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(1, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(2, gems[0].Assemblies.Count);
            Assert.IsFalse(gems[0].IsReferenced);
            Assert.IsFalse(pm.Project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));
        }

        [TestCase(0x00020000, @"C:\Projects\Test\lib\log4net\net-2.0\log4net.dll")]
        [TestCase(0x00030005, @"C:\Projects\Test\lib\log4net\net-3.5\log4net.dll")]
        [TestCase(0x00040000, @"C:\Projects\Test\lib\log4net\net-4.0\log4net.dll")]
        public void InstallGemShouldReturnCorrectTargetFramework(int targetFramework, string expectedResults)
        {
            var commandLines = new string[]
            {
                    "Found Gem",
                    "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/log4net-1.2.10.0/lib",
                    "Copy To: C:/Projects/Test/lib/log4net"
            };

            var paths = new string[]
                            {
                                @"C:\Projects\Test\lib\log4net\net-2.0\log4net.dll",
                                @"C:\Projects\Test\lib\log4net\net-3.5\log4net.dll",
                                @"C:\Projects\Test\lib\log4net\net-4.0\log4net.dll",
                            };

            var pm = ObjectMother.CreatePackageManager(targetFramework: targetFramework, commandLines: commandLines, paths: paths);

            // mock fs: contents of gem (2 assemblies)
            var gemname = "log4net";
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.IsTrue(pm.Project.HasReference(expectedResults));
        }

        [Test]
        public void InstallGemShouldReturn2GemsBothAutoReferenced()
        {
            // mock command: nu install log4net (dependency on nunit)
            var commandLines = new string[]
                            {
                                "Found Gem",
                                "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/log4net-1.2.10.0/lib",
                                "Copy To: C:/Projects/Test/lib/log4net",
                                "Found Gem",
                                "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/nunit-2.5.7.10213/lib",
                                "Copy To: C:/Projects/Test/lib/nunit"
                            };

            // mock fs: contents of 2 gem
            var paths = new string[]
                            {
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
                            };

            var pm = ObjectMother.CreatePackageManager(commandLines: commandLines, paths: paths);
            var gemname = "log4net";
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(2, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.IsTrue(gems[0].IsReferenced);
            Assert.IsTrue(pm.Project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));

            Assert.AreEqual("nunit", gems[1].Name);
            Assert.AreEqual(1, gems[1].Assemblies.Count);
            Assert.IsTrue(gems[1].IsReferenced);
            Assert.IsTrue(pm.Project.HasReference(@"C:\Projects\Test\lib\nunit\nunit.dll"));
        }

        [Test]
        public void InstallGemShouldReturn2GemsBothAutoReferencedWithTargetFramework()
        {
            // mock command: nu install log4net (dependency on nunit)
            var commandLines = new string[]
                                   {
                                       "Found Gem",
                                       "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/castle.dynamicproxy2-2.1.0.0/lib"
                                       ,
                                       "Copy To: C:/Projects/Test/lib/castle.dynamicproxy2",
                                       "Found Gem",
                                       "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/castle.core-1.1.0.0/lib",
                                       "Copy To: C:/Projects/Test/lib/castle.core"
                                   };

            // mock fs: contents of 2 gem
            var paths = new string[]
                            {
                                @"C:\Projects\Test\lib\castle.dynamicproxy2\net-2.0\Castle.DynamicProxy2.dll",
                                @"C:\Projects\Test\lib\castle.dynamicproxy2\net-2.0\Castle.DynamicProxy2.xml",
                                @"C:\Projects\Test\lib\castle.dynamicproxy2\net-3.5\Castle.DynamicProxy2.dll",
                                @"C:\Projects\Test\lib\castle.dynamicproxy2\net-3.5\Castle.DynamicProxy2.xml",

                                @"C:\Projects\Test\lib\castle.core\Castle.Core.dll",
                                @"C:\Projects\Test\lib\castle.core\Castle.Core.xml",
                            };

            var pm = ObjectMother.CreatePackageManager(commandLines: commandLines, paths: paths);
            var gemname = "castle.dynamicproxy2";
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(2, gems.Count);
            Assert.AreEqual("castle.dynamicproxy2", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.IsTrue(gems[0].IsReferenced);
            Assert.IsTrue(pm.Project.HasReference(@"C:\Projects\Test\lib\castle.dynamicproxy2\net-3.5\Castle.DynamicProxy2.dll"));

            Assert.AreEqual("castle.core", gems[1].Name);
            Assert.AreEqual(1, gems[1].Assemblies.Count);
            Assert.IsTrue(gems[1].IsReferenced);
            Assert.IsTrue(pm.Project.HasReference(@"C:\Projects\Test\lib\castle.core\Castle.Core.dll"));
        }

        [Test]
        public void InstallGemShouldReturn2GemsOnly1AutoReferenced()
        {
            // mock command: nu install log4net (dependency on nunit)
            var commandLines = new string[]
                                   {
                                       "Found Gem",
                                       "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/log4net-1.2.10.0/lib",
                                       "Copy To: C:/Projects/Test/lib/log4net",
                                       "Found Gem",
                                       "Copy From: C:/Tools/Ruby191/lib/ruby/gems/1.9.1/gems/nunit-2.5.7.10213/lib",
                                       "Copy To: C:/Projects/Test/lib/nunit"
                                   };
            // mock fs: contents of 2 gem (nunit has 2 assemblies)
            var paths = new string[]
                            {
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
                            };

            var pm = ObjectMother.CreatePackageManager(commandLines: commandLines, paths: paths);
            var gemname = "log4net";
            var gems = pm.InstallGem(gemname, noOutput);

            Assert.AreEqual(2, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.IsTrue(gems[0].IsReferenced);
            Assert.IsTrue(pm.Project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));

            Assert.AreEqual("nunit", gems[1].Name);
            Assert.AreEqual(2, gems[1].Assemblies.Count);
            Assert.IsFalse(gems[1].IsReferenced);
            Assert.IsFalse(pm.Project.HasReference(@"C:\Projects\Test\lib\nunit\nunit.dll"));
        }

        [Test]
        public void ListGemShouldReturn2Gems1ThatIsReferenced()
        {
            // mock command: gem list
            var commandLines = new string[]
                                   {
                                       "log4net (1.2.10)",
                                       "nunit (2.5.7.10213)",
                                   };

            // mock fs: contents of 2 gem
            var paths = new string[]
                            {
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
                            };

            var references = new string[]
                                {
                                    @"C:\Projects\Test\lib\log4net\log4net.dll",
                                };

            var pm = ObjectMother.CreatePackageManager(commandLines: commandLines, paths: paths, references: references);
            var gems = pm.ListGems().ToList();

            Assert.AreEqual(2, gems.Count);
            Assert.AreEqual("log4net", gems[0].Name);
            Assert.AreEqual(1, gems[0].Assemblies.Count);
            Assert.IsTrue(gems[0].IsReferenced);
            Assert.IsTrue(pm.Project.HasReference(@"C:\Projects\Test\lib\log4net\log4net.dll"));

            Assert.AreEqual("nunit", gems[1].Name);
            Assert.AreEqual(1, gems[1].Assemblies.Count);
            Assert.IsFalse(gems[1].IsReferenced);
            Assert.IsFalse(pm.Project.HasReference(@"C:\Projects\Test\lib\nunit\nunit.dll"));
        }

        [Test]
        public void LibPathShouldBeInSolutionPath()
        {
            var solutionPath = @"C:\Projects\Test\Solution.sln";
            var pm = ObjectMother.CreatePackageManager(solutionPath: solutionPath);

            Assert.AreEqual(@"C:\Projects\Test\lib", pm.LibPath);
        }

        [Test]
        public void LibPathShouldBeSiblingOfSrcPath()
        {
            var solutionPath = @"C:\Projects\Test\src\Solution.sln";
            var pm = ObjectMother.CreatePackageManager(solutionPath: solutionPath);

            Assert.AreEqual(@"C:\Projects\Test\lib", pm.LibPath);
        }



        private void noOutput(string line)
        {
        }
    }
}
