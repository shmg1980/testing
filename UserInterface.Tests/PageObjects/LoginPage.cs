using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using TgsARM.TestUtility.StringHelpers;
using UserInterface.Tests.Extensions;

namespace UserInterface.Tests.PageObjects
{

    internal class LoginPage : GamePage
    {
        public static StringRequirements PasswordFormat { get; } =  
            StringRequirements.ContainNumeric | StringRequirements.ContainCyrillic | StringRequirements.ContainUpperCase;

        private ITextBox passwordInput = ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Choose Password']"), "Password");
        private ITextBox emailInput = ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Your email']"), "Email");
        private ITextBox emailDomainInput = ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Domain']"), "Email Domain");
        private IComboBox domainComboBox = ElementFactory.GetCardComboBox(By.XPath("//div[contains(@class,'dropdown--gray')]"), "Domain");
        private ICheckBox termsCheckbox = ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox__box']"), "Terms");       

        private IButton nextPageBtn = ElementFactory.GetButton(By.XPath("//a[text()='Next']"), "Next");

        private ILabel timerLabel = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'timer')]"), "Timer");

        public LoginPage() : base(By.XPath("//div[@class='login-form']"), "Login Page")
        {
        }     

        public void EnterPassword(string value)
        {
            passwordInput.ClearAndType(value);
        }

        public void EnterEmail(string value)
        {
            emailInput.ClearAndType(value);
        }

        public void EnterEmailDomain(string value)
        {
            emailDomainInput.ClearAndType(value);
        }

        public void EnterDomain(string value)
        {
            domainComboBox.SelectByText(value);
        }

        public void UncheckTermsCheckbox()
        {
            termsCheckbox.Click();
        }

        public void ClickNextButton()
        {
            nextPageBtn.Click();    
        }

        public string GetTimerValue() => timerLabel.Text;
    }

}
