using Aquality.Selenium.Core.Logging;
using TgsARM.TestUtility.Json;

namespace TgsARM.TestUtility.Configuration
{

    public static class ConfigManager
    {
        private const string mainCfgPath = "mainconfig.json";

        private static MainConfig mainConfig;

        public static MainConfig MainConfig
        {
            get
            {
                if (mainConfig is null)
                {
                    mainConfig = LoadConfig<MainConfig>(mainCfgPath);
                }

                return mainConfig;
            }
        }

        public static T LoadConfig<T>(string path) where T : IConfigData
        {
            Logger.Instance.Info($"Loading config file of type {typeof(T).Name}.");

            return JsonUtility.Deserialize<T>(path);
        }
    }

}
