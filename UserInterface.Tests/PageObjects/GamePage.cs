using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using UserInterface.Tests.Forms;

namespace UserInterface.Tests.PageObjects
{
    internal abstract class GamePage : Form
    {
        public HelpForm HelpForm { get; }

        public CookieForm CookieForm { get; }

        protected GamePage(By locator, string name) : base(locator, name)
        {
            HelpForm = new HelpForm();
            CookieForm = new CookieForm();
        }
    }
}
