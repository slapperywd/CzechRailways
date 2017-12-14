using CZProjectFramework.Pages.AdministerFavoritePages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CZProjectFramework.Pages
{
    public class MyTravelPage
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Administer')]")]
        private IWebElement administerButton;

        public MyTravelPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public void GoToAdministerFavorite()
        {
            administerButton.Click();
        }

        public FavoriteStation GoToAdministerFavoriteStation()
        {
            administerButton.Click();
            return new FavoriteStation();
        }

        public FavoriteTrain GoToAdministerFavoriteTrain()
        {
            administerButton.Click();
            return new FavoriteTrain();
        }

        public FavoriteConnection GoToAdministerFavoriteConnection()
        {
            administerButton.Click();
            return new FavoriteConnection();
        }

        public FavoriteLine GoToAdministerFavoriteLine()
        {
            administerButton.Click();
            return new FavoriteLine();
        }

        public FavoritePassanger GoToAdministerFavoritePassenger()
        {
            administerButton.Click();
            return new FavoritePassanger();
        }

    }
}