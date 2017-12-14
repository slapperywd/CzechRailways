using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class NewPasswordPage
    {
        [FindsBy(How = How.Id, Using = "regfinishsubmit")] private IWebElement completeRegistration;

        [FindsBy(How = How.XPath, Using = "//span[.='The minimum number of characters is 8.']")]
        private IWebElement incorrectPasswordFrame;

        [FindsBy(How = How.Id, Using = "password")] private IWebElement newPassword;

        [FindsBy(How = How.XPath, Using = "//div[2]/div/label/span[1]")] private IWebElement receiveInformation;

        [FindsBy(How = How.Id, Using = "pwdCheck")] private IWebElement repeatPassword;

        public NewPasswordPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public void SetNewPassword(string password, bool receiveInformationBool)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(newPassword));
            newPassword.SendKeys(password);
            Wait.Until(ExpectedConditions.ElementToBeClickable(repeatPassword));
            repeatPassword.SendKeys(password);
            if (receiveInformationBool)
                receiveInformation.Click();
            completeRegistration.Click();
        }

        public void InputNewPassword(string password)
        {
            newPassword.SendKeys(password);
        }

        public void InputRepeatPassword(string password)
        {
            repeatPassword.SendKeys(password);
        }

        public void ClickReceiveInformation(bool receiveInformationBool)
        {
            if (receiveInformationBool)
                receiveInformation.Click();
        }

        public void CompleteRegistration()
        {
            completeRegistration.Click();
        }

        public bool CheckPassword()
        {
            return incorrectPasswordFrame.Text.Equals("The minimum number of characters is 8.");
        }
    }
}