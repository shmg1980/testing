using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using NUnit.Framework;
using TgsARM.TestUtility.Configuration;

namespace TgsARM.TestUtility.Tests
{

    [TestFixture]
    public abstract class BaseTest
    {
        protected Browser Browser
        {
            get;
            private set;
        }

        protected MainConfig MainConfig
        {
            get;
            private set;
        }

        protected Logger Logger
        {
            get;
            private set;
        }

        [SetUp]
        public void SetUp()
        {
            Logger.Instance.Info($"Starting tests in {GetType().Name}.");

            Browser = AqualityServices.Browser;
            MainConfig = ConfigManager.MainConfig;
            Logger = Logger.Instance;
        }


        [TearDown]
        public void CleanUp()
        {
            Logger.Instance.Info($"End of tests in {GetType().Name}.");

            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }

}
