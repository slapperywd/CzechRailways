using System;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class ConnectionsAndTicketsAtHomePage : ModalWindowClockPage
    {
        [FindsBy(How = How.CssSelector, Using = ".cd-btn-green.flr")] private IWebElement buttonSearch;

        [FindsBy(How = How.CssSelector, Using = ".cm.cd-icon-svg-calendar")] private IWebElement calendarIcon;

        [FindsBy(How = How.CssSelector, Using = ".cd-drop-sel.is-time-hour")]
        private IWebElement callSetTimeModalWindowItem;

        [FindsBy(How = How.Id, Using = "csbhp-from")] private IWebElement inputFrom;

        [FindsBy(How = How.Id, Using = "csbhp-to")] private IWebElement InputTo;

        [FindsBy(How = How.LinkText, Using = "More options")] private IWebElement linkMoreOptions;

        [FindsBy(How = How.CssSelector, Using = ".white-box.passengerbox")] private IWebElement passengerBoxItem;

        [FindsBy(How = How.XPath, Using = "//*[@id='connectionsearchbox-hp-o']/div/div[2]/div[1]/label[1]")]
        private IWebElement radioToday;

        [FindsBy(How = How.XPath, Using = "//*[@id='connectionsearchbox-hp-o']/div/div[2]/div[1]/label[2]")]
        private IWebElement radioTomorrow;

        public ConnectionsAndTicketsAtHomePage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public ConnectionsAndTicketsAtHomePage SetDirections(string fromStation, string toStation)
        {
            inputFrom.Clear();
            inputFrom.SendKeys(fromStation);
            InputTo.Clear();
            InputTo.SendKeys(toStation);
            InputTo.Click();
            // need to click twice 
            InputTo.Click();
            return this;
        }

        public ConnectionsAndTicketsAtHomePage SetDayTomorrow()
        {
            radioTomorrow.Click();
            return this;
        }

        public ModalWindowClockPage GotoClockPage()
        {
            callSetTimeModalWindowItem.Click();
            return new ModalWindowClockPage();
        }

        public SelectTicket GotoSelectTicketPage()
        {
            buttonSearch.Click();
            return new SelectTicket();
        }


    }
}
