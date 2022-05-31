using NUnit.Framework;
using TgsARM.TestUtility.Maths;
using UserInterface.Tests.PageObjects;
using TgsARM.TestUtility.Extensions;
using TgsARM.TestUtility.Configuration;
using System;
using TgsARM.TestUtility.FileUtility;
using Aquality.Selenium.Core.Logging;
using UserInterface.Tests.Configuration;
using TgsARM.TestUtility.Tests;

namespace UserInterface.Tests.TestCases
{

    internal class FormTests : BaseTest
    {
        [Test]
        public void TestCards()
        {
            Logger.Info("Beginning cards test.");

            var testCfg = TestConfiguration.CardsTestCfg;

            Logger.Info("Step #1: Navigating to home page.");

            Browser.GoTo(MainConfig.HomePageUrl);
            var homePage = new HomePage();
            Logger.Info("Step #1: Asserting that home page is open.");
            Assert.IsTrue(homePage.State.WaitForDisplayed(), "Welcome page is not open.");

            Logger.Info("Step #2: Navigating to next page.");

            homePage.ClickNextPageLink();  
            var loginPage = new LoginPage();
            Logger.Info("Step #2: Asserting that first card is open.");
            Assert.IsTrue(loginPage.State.WaitForDisplayed(), "First card is not open.");

            Logger.Info("Step #3: Filling login form.");

            var maxPasswordLength = Math.Max(testCfg.MinPasswordLength, MainConfig.RandomStringMaxLength);
            Logger.Info("Step #3: Generating random email.");
            var email = RandomGenerator.NextEmail(MainConfig.RandomStringMinLength, MainConfig.RandomStringMaxLength);
            Logger.Info("Step #3: Generating random password.");
            var password = RandomGenerator.NextStringWithMinReqs(testCfg.MinPasswordLength, maxPasswordLength, LoginPage.PasswordFormat, 
                email.RandomElement());
            Logger.Info("Step #3: Generating random email domain.");
            var emailDomain = RandomGenerator.NextDomain(MainConfig.RandomStringMinLength, MainConfig.RandomStringMaxLength);              
            loginPage.EnterEmail(email);
            loginPage.EnterPassword(password);
            loginPage.EnterEmailDomain(emailDomain);
            loginPage.EnterDomain(testCfg.Domain);
            loginPage.UncheckTermsCheckbox();
            Logger.Info("Step #3: Submitting login form.");
            loginPage.ClickNextButton();
            var avatarPage = new AvatarPage();
            Logger.Info("Step #3: Asserting that second card is open.");
            Assert.IsTrue(avatarPage.State.WaitForDisplayed(), "Second card is not open.");

            Logger.Info("Step #4: Picking interests and uploading image.");

            avatarPage.SelectRandomInterests(testCfg.InterestsToSelect);
            avatarPage.UploadAvatar(PathUtility.GetResourcePath(testCfg.AvatarImgPath));
            Logger.Info("Step #4: Submitting avatar and interests form.");
            avatarPage.ClickNextBtn();
            var personalDetailsPage = new PersonalDetailsPage();
            Logger.Info("Step #4: Asserting that third card is open.");
            Assert.IsTrue(personalDetailsPage.State.WaitForDisplayed(), "Third card is not open.");
        }

        [Test]
        public void TestFormTimer()
        {
            Logger.Info("Beginning help form test.");

            var testCfg = TestConfiguration.TimerTestCfg;

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
            Logger.Info("Step #1: Asserting that timer starts at zero.");
            Assert.AreEqual(loginPage.GetTimerValue(), testCfg.ExpectedTimerValue, 
                $"Timer is not equal to expected value {testCfg.ExpectedTimerValue}.");
        }
    }

}