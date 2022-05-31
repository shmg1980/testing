using Aquality.Selenium.Core.Forms;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterface.Tests.Forms
{
    internal class CookieForm : Form
    {
        private IButton acceptBtn = ElementFactory.GetButton(By.XPath("//button[text()='Not really, no']"), "Accept Cookies");

        public CookieForm() : base(By.XPath("//div[@class='cookies']"), "Cookies")
        {
        }

        public void Accept()
        {
            State.WaitForDisplayed();
            acceptBtn.Click();
        }
    }
}
