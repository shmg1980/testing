using TgsARM.TestUtility.Configuration;
using UserInterface.Tests.TestConfig;

namespace UserInterface.Tests.Configuration
{

    internal static class TestConfiguration
    {
        private const string cardsTestCfgPath = @"TestConfig\cardstestcfg.json";
        private const string timerTestCfgPath = @"TestConfig\timertestcfg.json";

        private static CardsTestConfig cardsTestCfg;
        private static TimerTestConfig timerTestCfg;

        public static CardsTestConfig CardsTestCfg => GetConfig(ref cardsTestCfg, cardsTestCfgPath);

        public static TimerTestConfig TimerTestCfg => GetConfig(ref timerTestCfg, timerTestCfgPath);

        private static T GetConfig<T>(ref T cfgField, string path) where T : IConfigData
        {
            if (cfgField is null)
            {
                cfgField = ConfigManager.LoadConfig<T>(path);
            }

            return cfgField;
        }
    }

}
