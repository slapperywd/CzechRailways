using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class FavoriteStation
    {
        private string emptyMessage = "You have no favourite stations";
       
        [FindsBy(How = How.XPath, Using = "//button[@id='staniceFavbtn']")]
        private IWebElement favoriteStationsMenu;

        [FindsBy(How = How.XPath, Using = ".//*[@id='relationFav']/ul/li[4]/span")]
        private IWebElement favoriteStation;
    
        [FindsBy(How = How.XPath, Using = "//*[@id='staniceFav']/ul/li[2]/span")]
        private IWebElement favoriteStationContent;

        [FindsBy(How = How.CssSelector, Using = "#staniceFav > ul > li.l20 > a > img")]
        private IWebElement deleteFavoriteStation;

        [FindsBy(How = How.XPath, Using = ".//*[@id='staniceFav']/span")]
        private IWebElement emptySpanStation;

        public FavoriteStation()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public FavoriteStation GoToFavoriteStations()
        {
    
            Actions act=new Actions(Browser.WebDriver);
            act.DoubleClick(favoriteStationsMenu).Build().Perform();

            return new FavoriteStation();
        }

        public string GetStationName()
        {
            Wait.Until(x => favoriteStationContent.Displayed);
            return favoriteStationContent.Text;
        }

        public FavoriteStation DeleteFavoriteStation()
        {
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", deleteFavoriteStation);
            return new FavoriteStation();
        }

        public bool IsFavoriteStationEmpty()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(emptySpanStation));
            return emptySpanStation.Text.Equals(emptyMessage);
        }
        
    }
}
