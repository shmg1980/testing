using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Collections.Generic;
using TgsARM.TestUtility.Maths;
using TgsARM.TestUtility.Input;

namespace UserInterface.Tests.PageObjects
{

    internal class AvatarPage : GamePage
    {
        private static readonly By interestCheckboxLoc = By.XPath(@"//label[@class='checkbox__label'and(not(contains(@for,'selectall')))]");

        private ICheckBox unselectAllCheckBox = ElementFactory.GetCheckBox(By.XPath("//label[@for='interest_unselectall']"), "Unselect All");
        private IButton nextBtn = ElementFactory.GetButton(By.XPath(@"//button[text()='Next']"), "Next");
        private ILink uploadAvatarLink = ElementFactory.GetLink(By.XPath("//a[@class='avatar-and-interests__upload-button']"), "Upload Avatar");

        private IList<ICheckBox> GetInterestCheckBoxes()
        {
            var elementFactory = AqualityServices.Get<IElementFactory>();
            return elementFactory.FindElements<ICheckBox>(interestCheckboxLoc);
        }     

        public AvatarPage() : base(By.XPath(@"//div[@class='avatar-and-interests__form']"), "Avatar and Interests")
        {
        }  

        public void SelectRandomInterests(int count)
        {
            var interestCheckBoxes = GetInterestCheckBoxes();

            if (count > interestCheckBoxes.Count)
            {
                throw new ArgumentException("checkbox count is less than interests to select");
            }

            Logger.Info($"Unselecting all interests.");

            unselectAllCheckBox.Click();

            Logger.Info($"Selecting {count} random interests.");

            while (count-- > 0)
            {
                var index = RandomGenerator.NextInt(interestCheckBoxes.Count);

                interestCheckBoxes.ElementAt(index).Click();
                interestCheckBoxes.RemoveAt(index);
            }
        }

        public void UploadAvatar(string imgPath)
        {
            Logger.Info("Uploading avatar");

            uploadAvatarLink.Click();
            AutoInput.SimulateFileUpload(imgPath);
        }

        public void ClickNextBtn()
        {
            nextBtn.Click();
        }
    }

}
