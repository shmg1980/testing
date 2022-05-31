using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterface.Tests.PageObjects
{

    internal class HomePage : Form
    {
        private ILink nextPageLink => ElementFactory.GetLink(By.XPath(@"//a[@class='start__link']"), "Next Page");

        public HomePage() : base(By.XPath(@"//button[@class='start__button']"), "Home Page")
        {
        }

        public void ClickNextPageLink()
        {
            nextPageLink.ClickAndWait();
        }
    }

}
