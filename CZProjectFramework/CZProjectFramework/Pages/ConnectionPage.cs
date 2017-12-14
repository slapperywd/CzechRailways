using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CZProjectFramework.Pages
{
    public class ConnectionPage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div[2]/div/div[2]/p[2]/span[3]")]
        private IWebElement connectionArrivalName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div[2]/div/div[2]/p[2]/span[1]")]
        private IWebElement connectionDepartureName;

        [FindsBy(How = How.XPath, Using = "//a[@title='Add to favourite connections']")]
        private IWebElement favoriteButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='customnav']/a")]
        private IWebElement goBackButton;

        public void AddConnectionToFavorite()
        {
            favoriteButton.Click();
        }

        public string GetConnectionName()
        {
            return $"{connectionDepartureName.Text}\r\n{connectionArrivalName.Text}";
        }

        public void GoBack()
        {
            goBackButton.Click();
        }
    }
}