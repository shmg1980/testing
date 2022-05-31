using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterface.Tests.Forms
{
    internal class HelpForm : Form
    {
        private IButton hideFormBtn = ElementFactory.GetButton(
            By.XPath("//button[contains(@class,'help-form__send-to-bottom-button')]"), "Hide Help Form");

        public HelpForm() : base(By.XPath("//h2[@class='help-form__title']"), "Help")
        {
        }

        public void Hide()
        {
            hideFormBtn.Click();
        }
    }
}
