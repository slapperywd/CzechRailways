using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class IdentityVerificationPage
    {
        [FindsBy(How = How.Id, Using = "password")] private IWebElement passwordInput;
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")] private IWebElement confirmDelete;
        User user = XmlReader.Read<User>("UserData.xml");
        public IdentityVerificationPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public HomePage DeleteAccount()
        {
            passwordInput.SendKeys(user.Password);
            Wait.Until(ExpectedConditions.ElementToBeClickable(confirmDelete));
            confirmDelete.Click();
            return new HomePage();
        }

        public void InsertPassword()
        {
            passwordInput.SendKeys(user.Password);
        }

        public HomePage ConfirmDelete()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(confirmDelete));
            confirmDelete.Click();
            return new HomePage();
        }

    }
}