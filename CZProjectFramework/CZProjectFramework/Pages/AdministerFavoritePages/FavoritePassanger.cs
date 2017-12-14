using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages.AdministerFavoritePages
{
    public class FavoritePassanger
    {
        private string emptyMessage = "You have no favourite passengers";
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='removePassBtn']/button")]
        private IWebElement deleteFavoritePassenger;

        [FindsBy(How = How.XPath, Using = ".//li/a[@aria-label='Edit favourite passenger Test']")]
        private IWebElement editFavoritePassenger;

        [FindsBy(How = How.XPath, Using = ".//*[@id='passFav']/span")]
        private IWebElement emptySpanPassenger;

        [FindsBy(How = How.XPath, Using = ".//*[@id='passFav']/button")]
        private IWebElement addFavoritePassenger;

        [FindsBy(How = How.XPath, Using = "//*[@name='alias']")]
        private IWebElement aliasField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='pass5Modal']/div/div[2]/div[2]/div/button")]
        private IWebElement finishButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='passFav']/ul/li[2]/span")]
        private IWebElement favoritePassenger;

        public FavoritePassanger()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public FavoritePassanger AddFavoritePassenger(string testName)
        {
            //Click add in “Favorite passengers” option
            Wait.Until(ExpectedConditions.ElementToBeClickable(addFavoritePassenger));
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", addFavoritePassenger);
            //Enter "AnotherTestUser" into "Alias" field
            aliasField.Clear();
            aliasField.SendKeys(testName);

            //Click "Finished"
            finishButton.Click();
            return new FavoritePassanger();
        }

        public bool IsTheSamePassenger(string testName)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(favoritePassenger));
            return favoritePassenger.Text.Equals(testName);
        }

        public FavoritePassanger DeleteFavoritePassenger()
        {
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", editFavoritePassenger);
            js.ExecuteScript("arguments[0].click();", deleteFavoritePassenger);
            return new FavoritePassanger();
        }

        public bool IsFavoritePassengerEmpty()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(emptySpanPassenger));
            return emptySpanPassenger.Text.Equals(emptyMessage);
        }
    }
}
