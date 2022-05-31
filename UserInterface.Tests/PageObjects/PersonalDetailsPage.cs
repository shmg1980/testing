using OpenQA.Selenium;

namespace UserInterface.Tests.PageObjects
{

    internal class PersonalDetailsPage : GamePage
    {
        public PersonalDetailsPage() : base(By.XPath(@"//div[@class='personal-details__form']"), "Personal Details")
        {
        }
    }

}
