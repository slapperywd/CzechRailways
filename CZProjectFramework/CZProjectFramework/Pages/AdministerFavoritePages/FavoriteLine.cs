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

namespace CZProjectFramework.Pages.AdministerFavoritePages
{
    public class FavoriteLine
    {

        private string emptyMessage = "You have no favourite lines";
        
        [FindsBy(How = How.Id, Using = "trackFavbtn")]
        private IWebElement favoriteLinesMenu;

        [FindsBy(How = How.XPath, Using = ".//*[@id='trackFav']/ul/li[2]")]
        private IWebElement favoriteLine;

        [FindsBy(How = How.XPath, Using = ".//*[@id='trackFav']/ul/li[3]/a")]
        private IWebElement deleteFavoriteLine;

        [FindsBy(How = How.XPath, Using = ".//*[@id='trackFav']/span")]
        private IWebElement emptySpanLine;

        public FavoriteLine()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }


        public FavoriteLine GoToFavoriteLine()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='passFav']/span")));
            favoriteLinesMenu.Click();
            return new FavoriteLine();
        }

        public string GetLineName()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(favoriteLine));
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            string text = (string)js.ExecuteScript("return arguments[0].textContent", favoriteLine);
            return text.Replace('-', '–');
        }

        public FavoriteLine DeleteFavoriteLine()
        {
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", deleteFavoriteLine);
            return new FavoriteLine();
        }

        public bool IsFavoriteLineEmpty()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(emptySpanLine));
            return emptySpanLine.Text.Equals(emptyMessage);
        }
    }
}
