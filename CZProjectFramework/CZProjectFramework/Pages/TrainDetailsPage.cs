using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;

namespace CZProjectFramework.Pages
{
    public class TrainDetailsPage
    {
        [FindsBy(How = How.CssSelector, Using = "div.train-name h2")]
        private IWebElement trainName;

        [FindsBy(How = How.CssSelector, Using = "p.addcalendarlink a")]
        private IWebElement calendarLink;

        [FindsBy(How = How.CssSelector, Using = "div#ogDateLimitsCalModal div.cd-modal-content")]
        private IWebElement modalCalendar;

        [FindsBy(How = How.CssSelector, Using = "div.cal-info-in div:nth-child(3)")]
        private IWebElement departureFrom;

        [FindsBy(How = How.CssSelector, Using = "div.cal-info-in div:nth-child(5)")]
        private IWebElement destinationTo;

        [FindsBy(How = How.CssSelector, Using = "footer.web")]
        private IWebElement pageFooter;

        [FindsBy(How = How.CssSelector, Using = "div[role='list'] div[role='listitem']")]
        private IList<IWebElement> lineStations;

        [FindsBy(How = How.CssSelector, Using = "div.ico-share-box a[data-toggle='dropdown']")]
        private IWebElement shareBtn;

        [FindsBy(How = How.CssSelector, Using = "div.ico-share-box ul li:nth-child(2) a")]
        private IWebElement saveAsPdfOption;

        [FindsBy(How = How.CssSelector, Using = "div.modal-body div.is-loader")]
        private IWebElement loadFileModal;

        public TrainDetailsPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public string DepartureName()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(departureFrom));
            return departureFrom.Text;
        }

        public string DestinationName()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(destinationTo));
            return destinationTo.Text;
        }

        public string TrainName => trainName.Text; 

        public IList<IWebElement> LineStations => lineStations;

        public bool isCalendarPopupOpened => calendarLink.Displayed;

        public TrainDetailsPage OpenCalendarPopup()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(calendarLink));
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", calendarLink);
            return this;
        }

        public StationDetailsPage OpenFirstLineStation()
        {
            Wait.Until(x=>LineStations[0].Displayed);
            LineStations[0].Click();
            return new StationDetailsPage();
        }

        public bool SaveTimeTableAsPDF(string savedFileName)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads\" + savedFileName;

            //click share icon
            Wait.Until(ExpectedConditions.ElementToBeClickable(shareBtn));
            shareBtn.Click();
            //choose "Save as PDF" option from dropdown
            saveAsPdfOption.Click();

            //wait until file is fully downloaded otherwise this step will be not passed
            Wait.Until(el => File.Exists(path));
            File.Delete(path);
            return true;
        }
    }
}
