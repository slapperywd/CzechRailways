using CZProjectFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class StationsPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@value='Display']")] private IWebElement displayButton;
        [FindsBy(How = How.Id, Using = "mainContent_StaniceTT")] private IWebElement enterStaionField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='mainContent_LabelTrate']/ul[1]/li[2]/a")]
        private IWebElement favoriteLineButton;

        [FindsBy(How = How.Id, Using = "mainContent_favorite")] private IWebElement favoriteStationButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='mainContent_LabelTrate']/ul[1]/li[2]")]
        private IWebElement lineName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/section/div[6]/ul/li[3]/a")]
        private IWebElement linesToolbar;

        [FindsBy(How = How.Id, Using = "mainContent_LabelStanice")] private IWebElement stationName;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-id-3']/a")] protected IWebElement stationToChoose;

        public StationsPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public StationsPage EnterStation()
        {
            //Go to “Stations” menu option
            enterStaionField.Click();

            //Choose a station from adrop-down station field
            Wait.Until(ExpectedConditions.ElementToBeClickable(stationToChoose));
            stationToChoose.Click();

            //Click “Display” button
            displayButton.Click();

            return new StationsPage();
        }

        public StationsPage AddStationToFavorite()
        {
            if (favoriteStationButton.GetAttribute("title") == "Add a favourite station")
            {
                favoriteStationButton.Click();
            }
            return new StationsPage();
        }

        public StationsPage AddFavoriteLine()
        {
            //Click "Lines" on toolbar
            linesToolbar.Click();

            //Click a star-shaped button below "The station is on lines"
            Wait.Until(ExpectedConditions.ElementToBeClickable(favoriteLineButton));
            favoriteLineButton.Click();

            return new StationsPage();

        }

        public string GetLineName()
        {
            return lineName.Text;
        }

        public string GetStationName()
        {
            return stationName.Text;
        }
    }
}