using NUnit.Framework;
using UserInterface.Tests.PageObjects;
using Aquality.Selenium.Core.Logging;
using TgsARM.TestUtility.Tests;

namespace UserInterface.Tests.TestCases
{

    internal class PromptTests : BaseTest
    {
        [Test]
        public void TestHelpForm()
        {
            Logger.Info("Beginning help form test.");

            Logger.Info("Step #1: Navigating to home page.");

            Browser.GoTo(MainConfig.HomePageUrl);
            var homePage = new HomePage();
            Logger.Info("Step #1: Asserting that home page is open.");
            Assert.IsTrue(homePage.State.WaitForDisplayed(), "Welcome page is not open.");
            Logger.Info("Step #1: Navigating to next page.");
            homePage.ClickNextPageLink();
            var loginPage = new LoginPage();
            Logger.Info("Step #1: Asserting that game page is open.");
            Assert.IsTrue(loginPage.State.WaitForDisplayed(), "Game page is not open.");

            Logger.Info("Step #2: Hiding help form.");

            loginPage.HelpForm.Hide();
            Logger.Info("Step #2: Asserting that help form is not displayed.");
            Assert.IsTrue(loginPage.HelpForm.State.WaitForNotDisplayed(), "Help form is displayed on page.");
        }

        [Test]
        public void TestCookiesPrompt()
        {
            Logger.Info("Beginning cookies prompt test.");

            Logger.Info("Step #1: Navigating to home page.");

            Browser.GoTo(MainConfig.HomePageUrl);
            var homePage = new HomePage();
            Logger.Info("Step #1: Asserting that home page is open.");
            Assert.IsTrue(homePage.State.WaitForDisplayed(), "Welcome page is not open.");
            Logger.Info("Step #1: Navigating to next page.");
            homePage.ClickNextPageLink();
            var loginPage = new LoginPage();
            Logger.Info("Step #1: Asserting that game page is open.");
            Assert.IsTrue(loginPage.State.WaitForDisplayed(), "Game page is not open.");

            Logger.Info("Step #2: Accepting cookies.");

            loginPage.CookieForm.Accept();
            Logger.Info("Step #2: Asserting that cookie form is not displayed.");
            Assert.IsTrue(loginPage.CookieForm.State.WaitForNotDisplayed(), "Cookie form is displayed on page.");
        }
    }

}
