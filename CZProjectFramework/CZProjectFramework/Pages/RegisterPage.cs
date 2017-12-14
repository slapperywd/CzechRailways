using CZProjectFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CZProjectFramework.Pages
{
    public class RegisterPage
    {
        [FindsBy(How = How.Id, Using = "rulesagreecheck")] private IWebElement consentButton;

        [FindsBy(How = How.Id, Using = "email")] private IWebElement emailElement;

        [FindsBy(How = How.Id, Using = "regsubmit")] private IWebElement registerButton;

        [FindsBy(How = How.XPath, Using = "//div[1]/span[.='Required field.']")]
        private IWebElement requiredFieldForName;

        [FindsBy(How = How.XPath, Using = "//div[2]/span[.='Required field.']")]
        private IWebElement requiredFieldForSurname;

        [FindsBy(How = How.Id, Using = "surName")] private IWebElement surnameElement;

        [FindsBy(How = How.Id, Using = "givenName")] private IWebElement userNameElement;

        [FindsBy(How = How.XPath, Using = "//span[.='Please enter a valid e-mail address.']")]
        private IWebElement validMailMessage;


        public RegisterPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public RegisterPage FillUserData(bool clickConsentButton = true, string name = "", string surname = "", string email = "")
        {
            userNameElement.SendKeys(name);
            surnameElement.SendKeys(surname);
            emailElement.SendKeys(email);

            if (clickConsentButton)
                consentButton.Click();

            if (RegisterButtonEnabled())
                registerButton.Click();
            return this;
        }

        public RegisterPage InsertName(string name = "")
        {
            userNameElement.SendKeys(name);
            return this;
        }

        public RegisterPage InsertSurname(string surname = "")
        {
            surnameElement.SendKeys(surname);
            return this;
        }

        public RegisterPage InsertEmail(string email = "")
        {
            emailElement.SendKeys(email);
            return this;
        }

        public RegisterPage ClickConsentButton(bool clickConsentButton = true)
        {
            if (clickConsentButton)
                consentButton.Click();
            return this;
        }

        public RegisterPage ClickRegisterButton()
        {
            if (RegisterButtonEnabled())
                registerButton.Click();
            return this;
        }

        public bool EmailIsValid()
        {
            return !validMailMessage.Exists();
        }

        public bool RegisterButtonEnabled()
        {
            return registerButton.Enabled;
        }

        public bool RequiredNameAlert()
        {
            return requiredFieldForName.Exists();
        }

        public bool RequiredSurnameAlert()
        {
            return requiredFieldForSurname.Exists();
        }
    }
}