using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages.AdministerFavoritePages
{
    public class FavoriteConnection
    {
        private string emptyMessage = "You have no favourite connections";
       
        [FindsBy(How = How.Id, Using = "relationFavbtn")]
        private IWebElement favoriteConnectionMenu;

        [FindsBy(How = How.XPath, Using = "//*[@id='relationFavbtn']")]
        private IWebElement favoriteConnection;

        [FindsBy(How = How.XPath, Using = "//*[@id='relationFav']/ul/li[2]")]
        private IWebElement favoriteConnectionContent;
        //*[@id="relationFav"]/ul/li[2]

        [FindsBy(How = How.CssSelector, Using = "#relationFav > ul > li.l20 > a > img")]
        private IWebElement deleteFavoriteConnection;

        [FindsBy(How = How.XPath, Using = ".//*[@id='relationFav']/span")]
        private IWebElement emptySpanConnection;

        public FavoriteConnection()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public FavoriteConnection GoToFavoriteConnections()
        {
            Wait.Until(x => favoriteConnection.Displayed);
            //Actions act=new Actions(Browser.WebDriver);
            //act.DoubleClick(favoriteConnection).Build().Perform();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.WebDriver;
            js.ExecuteScript("arguments[0].click();", favoriteConnection);

            //  Wait.Until(x=>favoriteConnection.Displayed);
            // favoriteConnectionMenu.Click();
            return new FavoriteConnection();
        }

        public string GetConnectionName()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(favoriteConnectionContent));
            return favoriteConnectionContent.Text;
        }

        public FavoriteConnection DeleteFavoriteConnection()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.WebDriver;
            js.ExecuteScript("arguments[0].click();", deleteFavoriteConnection);
            return new FavoriteConnection();
        }

        public bool IsFavoriteConnectionEmpty()
        {
            Wait.Until(x => emptySpanConnection.Displayed);
            return emptySpanConnection.Text.Equals(emptyMessage);
        }
    }
}
