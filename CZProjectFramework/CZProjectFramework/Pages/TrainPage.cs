using System;
using System.Threading;
using CZProjectFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class TrainPage
    {
        [FindsBy(How = How.Id, Using = "cmdSearch")] private IWebElement displayButton;

        [FindsBy(How = How.Id, Using = "trainName")] private IWebElement enterTrainField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[3]/div[1]/a")] private IWebElement favoriteButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='aspnetForm']/div[3]/div[1]/div[1]/h2")]
        private IWebElement trainName;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-id-3']/a")] protected IWebElement trainToChoose;

        [FindsBy(How = How.Id, Using = "trainName")]
        private IWebElement trainNameInput;

        [FindsBy(How = How.Id, Using = "cmdSearch")]
        private IWebElement displayBtn;

        [FindsBy(How = How.ClassName, Using = "inlinerror")]
        private IWebElement errorMessSelector;

        [FindsBy(How = How.PartialLinkText, Using = "facebook")]
        private IWebElement facebook;

        public T SearchTrainTimeTable<T>(string trainName) where T : new()
        {
            trainNameInput.SendKeys(trainName);
            displayBtn.Click();
            return new T();
        }

        public string ErrorMessage => errorMessSelector.Text;

        public TrainPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public TrainPage AddTrainToFavorite()
        {
            //Choose a train from drop-down train field
            Wait.Until(ExpectedConditions.ElementToBeClickable(enterTrainField));
            enterTrainField.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(trainToChoose));
            trainToChoose.Click();

            //Click “Display” button
            displayButton.Click();

            // Click a star-shaped button with “Add to favorites” tooltip
            favoriteButton.Click();
            return new TrainPage();
        }

        public string GetTrainName()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='aspnetForm']/div[3]/div[1]/div[1]/h2")));
            return trainName.Text;
        }
    }
}