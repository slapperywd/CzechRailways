using System;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class UserProfilePage
    {
        [FindsBy(How = How.CssSelector, Using = ".adress")] private IWebElement contactAddressLink;

        [FindsBy(How = How.Id, Using = "city")] private IWebElement inputCity;

        [FindsBy(How = How.Id, Using = "country")] private IWebElement inputCountry;

        [FindsBy(How = How.Id, Using = "givenName")] private IWebElement inputName;

        [FindsBy(How = How.Id, Using = "street")] private IWebElement inputStreet;

        [FindsBy(How = How.Id, Using = "surName")] private IWebElement inputSurName;

        [FindsBy(How = How.PartialLinkText, Using = "Account cancellation")] private IWebElement accountCancellation;

        public UserProfilePage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public string GetUserProfileName()
        {
            return inputName.GetAttribute("value");
        }

        public string GetUserProfileSurname()
        {
            return inputSurName.GetAttribute("value");
        }

        public UserProfilePage GetAddressInfo()
        {
           Wait.Until(x => contactAddressLink.Exists());
          contactAddressLink.Click();
            return this;
        }

        public string GetUserCountry()
        {
            return inputCountry.GetAttribute("value");
        }

        public string GetUserCity()
        {
            return inputCity.GetAttribute("value");
        }

        public string GetUserStreet()
        {
            return inputStreet.GetAttribute("value");
        }

        public AccountCancellationPage GoToAddressCancellation()
        {
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", accountCancellation);
            return new AccountCancellationPage();
        }
    }
}