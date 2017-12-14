using CZProjectFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CZProjectFramework.Pages
{
    public class FindConnectionsWithTheService
    {
        [FindsBy(How = How.XPath, Using = "//label[@for=\'serviceCarTrain\']/span")]
        private IWebElement automobileTrain;

        [FindsBy(How = How.XPath, Using = "//label[@for=\'serviceChildren\']/span")]
        private IWebElement childrenCompartment;

        [FindsBy(How = How.XPath, Using = "//label[@for=\'servicePowerSupply\']/span")]
        private IWebElement electricSockets;

        [FindsBy(How = How.XPath, Using = "//div[@class=\'btn-group\']/button[text()=\'Finished\']")]
        private IWebElement finishedButton;

        [FindsBy(How = How.XPath, Using = "//label[@for=\'serviceWheelChair\']/span")]
        private IWebElement forWheelchairUsers;

        [FindsBy(How = How.XPath, Using = "//label[@for=\'inSenior\']/span")] private IWebElement InSenior;

        [FindsBy(How = How.XPath, Using = "//label[@for=\'serviceLadiesComp\']/span")]
        private IWebElement ladiesCompartment;

        [FindsBy(How = How.XPath, Using = "//label[@for=\'serviceSilentComp\']/span")] private IWebElement quietSection;

        [FindsBy(How = How.XPath, Using = "//label[@for=\'serviceRefreshment\']/span")]
        private IWebElement refreshments;

        [FindsBy(How = How.XPath, Using = "//label[@for=\'serviceBike\']/span")] private IWebElement transportABicycle;

        [FindsBy(How = How.LinkText, Using = "Uncheck all")] private IWebElement uncheckAll;

        [FindsBy(How = How.XPath, Using = "//label[@for=\'serviceWiFi\']/span")] private IWebElement wiFi;

        public FindConnectionsWithTheService()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public FindConnectionsWithTheService ClickUncheckAll()
        {
            uncheckAll.Click();
            return new FindConnectionsWithTheService();
        }

        public ConnectionsAndTickets ClickFinishedButton()
        {
            finishedButton.Click();
            return new ConnectionsAndTickets();
        }

        public FindConnectionsWithTheService SelectWiFi()
        {
            wiFi.Click();
            return new FindConnectionsWithTheService();
        }

        public FindConnectionsWithTheService SelectElectricSockets()
        {
            electricSockets.Click();
            return new FindConnectionsWithTheService();
        }

        public FindConnectionsWithTheService SelectLadiesCompartment()
        {
            ladiesCompartment.Click();
            return new FindConnectionsWithTheService();
        }

        public FindConnectionsWithTheService SelectQuietSection()
        {
            quietSection.Click();
            return new FindConnectionsWithTheService();
        }

        public FindConnectionsWithTheService SelectAutomobileTrain()
        {
            automobileTrain.Click();
            return new FindConnectionsWithTheService();
        }

        public FindConnectionsWithTheService SelectRefreshments()
        {
            refreshments.Click();
            return new FindConnectionsWithTheService();
        }

        public FindConnectionsWithTheService SelectInSenior()
        {
            InSenior.Click();
            return new FindConnectionsWithTheService();
        }

        public FindConnectionsWithTheService SelectForWheelchairUsers()
        {
            forWheelchairUsers.Click();
            return new FindConnectionsWithTheService();
        }

        public FindConnectionsWithTheService SelectChildrenCompartment()
        {
            childrenCompartment.Click();
            return new FindConnectionsWithTheService();
        }

        public FindConnectionsWithTheService SelectTransportABicycle()
        {
            ClickUncheckAll();
            transportABicycle.Click();
            return new FindConnectionsWithTheService();
        }
    }
}