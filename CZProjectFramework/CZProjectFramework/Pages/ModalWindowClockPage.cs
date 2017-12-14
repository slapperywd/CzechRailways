using System;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class ModalWindowClockPage
    {
        [FindsBy(How = How.CssSelector, Using = ".is-time-modal-done")] private IWebElement buttonFinish;

        [FindsBy(How = How.CssSelector, Using = ".is-time-modal-now")] private IWebElement buttonNow;
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "hour-input-id")] private IWebElement inputHour;

        [FindsBy(How = How.Id, Using = "min-input-id")] private IWebElement inputMinute;


        public ModalWindowClockPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public ConnectionsAndTicketsAtHomePage SetTestTime(string timeHour, string timeMinutes)
        {
            inputHour.Clear();
            inputHour.SendKeys(timeHour);
            inputMinute.Clear();
            inputMinute.SendKeys(timeMinutes);
            buttonFinish.Click();
            return new ConnectionsAndTicketsAtHomePage();
        }
    }
}
