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
    public class FavoriteTrain
    {
        private string emptyMessage = "You have no favourite trains";
       
        [FindsBy(How = How.Id, Using = "trainFavbtn")]
        private IWebElement favoriteTrainsMenu;

        [FindsBy(How = How.XPath, Using = ".//*[@id='trainFav']/ul/li[2]/span")]
        private IWebElement favoriteTrain;

        [FindsBy(How = How.XPath, Using = ".//*[@id='trainFav']/ul/li[3]/a")]
        private IWebElement deleteFavoriteTrain;

        [FindsBy(How = How.XPath, Using = ".//*[@id='trainFav']/span")]
        private IWebElement emptySpanTrain;


        public FavoriteTrain()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public FavoriteTrain GoToFavoriteTrains()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='passFav']/span")));
            favoriteTrainsMenu.Click();
            return new FavoriteTrain();
        }

        public string GetTrainName()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(favoriteTrain));
            return favoriteTrain.Text;
        }

        public FavoriteTrain DeleteFavoriteTrain()
        {
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", deleteFavoriteTrain);
            return new FavoriteTrain();
        }

        public bool IsFavoriteTrainEmpty()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(emptySpanTrain));
            return emptySpanTrain.Text.Equals(emptyMessage);
        }
    }
}
