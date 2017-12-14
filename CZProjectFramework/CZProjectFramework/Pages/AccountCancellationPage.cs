using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class AccountCancellationPage
    {
        [FindsBy(How = How.Id, Using = "archiveAccountSubmit")] private IWebElement cancelButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'unchecked ')]")]
        private IWebElement clickWantToCancel;

        public AccountCancellationPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public IdentityVerificationPage AcceptDeleteAccount()
        {
            clickWantToCancel.Click();
            cancelButton.Click();
            return new IdentityVerificationPage();
        }

        public void ClickWantToCancel()
        {
            clickWantToCancel.Click();
        }

        public IdentityVerificationPage ClickCancelButton()
        {
            cancelButton.Click();
            return new IdentityVerificationPage();
        }

    }
}