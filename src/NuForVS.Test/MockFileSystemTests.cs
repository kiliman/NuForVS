using System.Linq;
using NuForVS.Test.Mocks;
using NUnit.Framework;

namespace NuForVS.Test
{
    [TestFixture]
    public class MockFileSystemTests
    {
        private MockFileSystem _mock;

        public MockFileSystemTests()
        {
            _mock = new MockFileSystem(new string[] { 
                @"C:\root\sub1\file1.txt", 
                @"C:\root\sub1\file2.txt", 
                @"C:\root\sub2\file3.txt", 
                @"C:\root\sub2\file4.txt"
            });
        }

        [Test]
        public void RootFolderShouldHave2SubFolders()
        {
            var folders = _mock.GetFolders(@"C:\root").ToList();
            Assert.AreEqual(2, folders.Count);
            Assert.AreEqual(@"C:\root\sub1", folders[0]);
            Assert.AreEqual(@"C:\root\sub2", folders[1]);
        }

        [Test]
        public void SubFolder1ShouldExist()
        {
            var exists = _mock.FolderExists(@"C:\root\sub1");
            Assert.AreEqual(true, exists);
        }
        [Test]
        public void SubFolder2ShouldNotExist()
        {
            var exists = _mock.FolderExists(@"C:\root\sub3");
            Assert.AreEqual(false, exists);
        }

        [Test]
        public void File1ShouldExist()
        {
            var exists = _mock.FileExists(@"C:\root\sub1\file1.txt");
            Assert.AreEqual(true, exists);
        }
        [Test]
        public void File5ShouldNotExist()
        {
            var exists = _mock.FileExists(@"C:\root\sub1\file5.txt");
            Assert.AreEqual(false, exists);
        }

        [Test]
        public void SubFolder1ShouldHave2Files()
        {
            var files = _mock.GetFiles(@"C:\root\sub1").ToList();
            Assert.AreEqual(2, files.Count);
            Assert.AreEqual(@"C:\root\sub1\file1.txt", files[0]);
            Assert.AreEqual(@"C:\root\sub1\file2.txt", files[1]);
        }


    }
}
