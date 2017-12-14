using System;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class ConnectionsAndTickets
    {
        [FindsBy(How = How.XPath, Using = "//button[@class=\'cd-btn-blue-xs-wb\']")]
        private IWebElement travelViaOrAlsoTravelVia;

        [FindsBy(How = How.XPath, Using = "(//input[@value=\'\'])[2]")]
        private IWebElement fromStationTown;

        [FindsBy(How = How.XPath, Using = "(//input[@value=\'\'])[4]")]
        private IWebElement toStationTown;

        [FindsBy(How = How.CssSelector, Using = "a.switch")]
        private IWebElement switchFromAndToStationButton;

        [FindsBy(How = How.XPath, Using = "//div[@class=\'con-right mtop\']/div[@class=\'onecolspace\']/button")]
        private IWebElement alsoTravelVia;

        [FindsBy(How = How.XPath, Using = "//div[@class=\'onecolspace\']/button")]
        private IWebElement travelVia;

        [FindsBy(How = How.XPath, Using = "//div[@class=\'btn-group cd-dropdown-left\']/button")]
        private IWebElement swithViaOrTranswer;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),\'TRANSFER\')]")]
        private IWebElement transferSelectInswithViaOrTranswer;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),\'VIA\')]")]
        private IWebElement viaSelectInswithViaOrTranswer;

        [FindsBy(How = How.XPath, Using = "//div[@id=\'vias\']/div/div/div/div/input")]
        private IWebElement viaOrTransverStationTown;

        [FindsBy(How = How.Id, Using = "class2")]
        private IWebElement services2ndClass;

        [FindsBy(How = How.Id, Using = "class1")]
        private IWebElement services1stClass;

        [FindsBy(How = How.Id, Using = "classBusiness")]
        private IWebElement servicesBusiness;

        [FindsBy(How = How.XPath, Using = "//div[@class=\'onecolspace\']/button[text()=\'Add another\']")]
        private IWebElement addAnotherServices;

        [FindsBy(How = How.CssSelector, Using = "a[title=\"Modify passengers\"]")]
        private IWebElement modifyPassengers;

        [FindsBy(How = How.XPath, Using = "//*[@id='connectionsearchbox']/div[14]/div/div[2]/button")]
        private IWebElement addAnotherPassenger;

        [FindsBy(How = How.XPath, Using = "//button[@title=\'Search\']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),\'Connection parameters\')]")]
        private IWebElement connectionParameters;

        [FindsBy(How = How.PartialLinkText, Using = "1x Child 0—5 years")]
        private IWebElement child05Years;

        [FindsBy(How = How.PartialLinkText, Using = "1x Child 6—9 years")]
        private IWebElement child69Years;

        [FindsBy(How = How.PartialLinkText, Using = "1x Child 10—14 years")]
        private IWebElement child1014Years;

        [FindsBy(How = How.PartialLinkText, Using = "1x Junior 15—25 years")]
        private IWebElement junior1525Years;

        [FindsBy(How = How.PartialLinkText, Using = "1x Adult 26—69 years")]
        private IWebElement adult2669Years;

        [FindsBy(How = How.PartialLinkText, Using = "1x Adult 70 years and older")]
        private IWebElement adult70YearsAndOlder;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'Transport a bicycle\']")]
        private IWebElement transportABicycle;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'Children’s compartment\']")]
        private IWebElement childrensCompartment;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'For wheelchair users\']")]
        private IWebElement forWheelchairUsers;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'IN Senior\']")]
        private IWebElement iNSenior;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'Refreshments\']")]
        private IWebElement refreshments;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'Automobile train\']")]
        private IWebElement automobileTrain;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'Quiet section\']")]
        private IWebElement quietSection;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'Ladies’ compartment\']")]
        private IWebElement ladiesCompartment;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'Electric sockets\']")]
        private IWebElement electricSockets;

        [FindsBy(How = How.XPath, Using = "//img[@alt=\'WiFi\']")]
        private IWebElement wiFi;

        [FindsBy(How = How.XPath, Using = ".//p[text()='Connections by ticket']")]
        private IWebElement connectionsByTicket;

        public ConnectionsAndTickets()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }


        public Passengers GoToPassengerPage()
        {
            Wait.Until(x => addAnotherPassenger.Displayed);
            addAnotherPassenger.Click();
            return new Passengers();
        }

        public string GetFromStationTown()
        {
            return fromStationTown.GetAttribute("value");
        }

        public string GetToStationTown()
        {
            return toStationTown.GetAttribute("value");
        }

        public ConnectionsAndTickets AddTravelVia()
        {
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", travelVia);
            return new ConnectionsAndTickets();
        }

        public ConnectionsAndTickets ClickSwitchFromAndToStationButton()
        {
            //IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            //js.ExecuteScript("arguments[0].click();", switchFromAndToStationButton);
            Wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            switchFromAndToStationButton.Click();
            //ActionsUtils.ClickElement(switchFromAndToStationButton);
            return new ConnectionsAndTickets();
        }

        public ConnectionsAndTickets Select2ndClass()
        {
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", services2ndClass);
            return new ConnectionsAndTickets();
        }

        public ConnectionsAndTickets Select1stClass()
        {
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", services1stClass);
            return new ConnectionsAndTickets();
        }

        public ConnectionsAndTickets SelectBusinessClass()
        {
            servicesBusiness.Click();
            return new ConnectionsAndTickets();
        }

        public Passengers ClickModifyPassengers()
        {
            Wait.Until(x=>modifyPassengers.Displayed,2);
            modifyPassengers.Click();
            return new Passengers();
        }

        public FindConnectionsWithTheService ClickAddAnotherServices()
        {
            addAnotherServices.Click();
            return new FindConnectionsWithTheService();
        }

        public ConnectionsAndTickets SetFromStationTown(string station)
        {
            fromStationTown.SendKeys(station);
            connectionsByTicket.Click();
            return new ConnectionsAndTickets();
        }

        public ConnectionsAndTickets SetToStationTown(string station)
        {
            toStationTown.SendKeys(station);
            connectionsByTicket.Click();
            return new ConnectionsAndTickets();
        }

        public ConnectionsAndTickets SetViaOrTransferStation(string station)
        {
            viaOrTransverStationTown.SendKeys(station);
            return new ConnectionsAndTickets();
        }

        public SelectTicket Search()
        {
            connectionsByTicket.Click();
            searchButton.Click();
            return new SelectTicket();
        }

        
        public bool Is2ndClassSelected => services2ndClass.Selected && !services1stClass.Selected && !servicesBusiness.Selected;

        public bool Is1stClassSelected => !services2ndClass.Selected && services1stClass.Selected && !servicesBusiness.Selected;

        public bool IsBusinessClassSelected => !services2ndClass.Selected && !services1stClass.Selected && servicesBusiness.Selected;

        public bool IsChild05YearsSelected => child05Years.Displayed;

        public bool IsChild69YearsSelected => child69Years.Displayed;

        public bool IsChild1014YearsSelected => child1014Years.Displayed;

        public bool IsJunior1525YearsSelected => junior1525Years.Displayed;

        public bool IsAdult2669YearsSelected => adult2669Years.Displayed;

        public bool IsAdult70YearsAndOlderSelected => adult70YearsAndOlder.Displayed;

        public bool IsTransportABicycleSelected => transportABicycle.Displayed;

        public bool IsINSeniorSelected => iNSenior.Displayed;

        public bool IsChildrensCompartmentSelected => childrensCompartment.Displayed;

        public bool IsForWheelchairUsersSelected => forWheelchairUsers.Displayed;

        public bool IsRefreshmentsSelected => refreshments.Displayed;

        public bool IsAutomobileTrainSelected => automobileTrain.Displayed;

        public bool IsQuietSectionSelected => quietSection.Displayed;

        public bool IsLadiesCompartmentSelected => ladiesCompartment.Displayed;

        public bool IsElectricSocketsSelected => electricSockets.Displayed;

        public bool IsWiFiSelected => wiFi.Displayed;

        public bool IsAlsoTravelViaVisible => alsoTravelVia.Displayed;

        public bool IsSwithViaOrTranswerVisible => swithViaOrTranswer.Displayed;

        public void AddNewDefaultePassanger()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(addAnotherPassenger));
            addAnotherPassenger.Click();
        }
    }
}