using NuForVS.Core;
using NUnit.Framework;

namespace NuForVS.Test
{
    [TestFixture]
    public class ConfigurationTests
    {
        [TestCase("gem", "", "gem list")]
        [TestCase("gem", "myserver", "gem list")]
        [TestCase("igem", "", "igem list")]
        [TestCase("igem", "myserver", "igem list")]
        public void VerifyListGemCommand(string gemCommand, string gemServer, string expectedResult)
        {
            var config = new Configuration {GemCommand = gemCommand, GemServer = gemServer};
            var command = config.GemListCommand();
            Assert.AreEqual(expectedResult, command);
        }

        [TestCase("gem", "", "myquery", "gem query -n \"myquery\" --both")]
        [TestCase("gem", "myserver", "myquery", "gem query -n \"myquery\" --both --source myserver")]
        [TestCase("igem", "", "myquery", "igem query -n \"myquery\" --both")]
        [TestCase("igem", "myserver", "myquery", "igem query -n \"myquery\" --both --source myserver")]
        public void VerifySearchGemCommand(string gemCommand, string gemServer, string query, string expectedResult)
        {
            var config = new Configuration { GemCommand = gemCommand, GemServer = gemServer };
            var command = config.GemSearchCommand(query);
            Assert.AreEqual(expectedResult, command);
        }
    }
}
