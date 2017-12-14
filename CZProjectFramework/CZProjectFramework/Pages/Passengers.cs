using CZProjectFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class Passengers
    {
        [FindsBy(How = How.XPath, Using = "//div[@id=\'passengersModal\']/div/div[2]/div/div/div[3]/div/div/span")]
        private IWebElement selectPassenger;

        [FindsBy(How = How.XPath, Using = "//ul[@id=\'ownsundefined\']/li")]
        private IWebElement child05Years;

        [FindsBy(How = How.XPath, Using = "//ul[@id=\'ownsundefined\']/li[2]")]
        private IWebElement child69Years;

        [FindsBy(How = How.XPath, Using = "//ul[@id=\'ownsundefined\']/li[3]")]
        private IWebElement child1014Years;

        [FindsBy(How = How.XPath, Using = "//ul[@id=\'ownsundefined\']/li[4]")]
        private IWebElement junior1525Years;

        [FindsBy(How = How.XPath, Using = "//ul[@id=\'ownsundefined\']/li[5]")]
        private IWebElement adult2669Years;

        [FindsBy(How = How.XPath, Using = "//ul[@id=\'ownsundefined\']/li[6]")]
        private IWebElement adult70YearsAndOlder;

        [FindsBy(How = How.XPath, Using = "//button[@title=\'Increase number of passengers\']")]
        private IWebElement addOneMorePassenger;

        [FindsBy(How = How.XPath, Using = "//button[@title=\'Decrease number of passengers\']")]
        private IWebElement minusOnePassenger;

        [FindsBy(How = How.Id, Using = "psgDropdownToggle7")]
        private IWebElement addDiscontCard;

        [FindsBy(How = How.XPath, Using = "//div[@id=\'psgDropdown10\']/ul/li/div/div/a")]
        private IWebElement czechRepublicCard;

        [FindsBy(How = How.XPath, Using = "//div[@id=\'psgDropdown10\']/ul/li/div/div/a[2]")]
        private IWebElement slovakiaCard;

        [FindsBy(How = How.XPath, Using = "//div[@id=\'psgDropdown10\']/ul/li/div/div/a[3]")]
        private IWebElement germanyCard;

        [FindsBy(How = How.XPath, Using = "//div[@id=\'psgDropdown10\']/ul/li/div/div/a[4]")]
        private IWebElement austriaCard;

        [FindsBy(How = How.Id, Using = "id=psg10cardid1")]
        private IWebElement in25CzechRepublic;

        [FindsBy(How = How.Id, Using = "id=psg10cardid2")]
        private IWebElement in50CzechRepublic;

        [FindsBy(How = How.Id, Using = "id=psg10cardid3")]
        private IWebElement in1002clCzechRepublic;

        [FindsBy(How = How.Id, Using = "id=psg10cardid4")]
        private IWebElement inBusinessCzechRepublic;

        [FindsBy(How = How.Id, Using = "id=psg10cardid101")]
        private IWebElement klasikRailPlusSlovakia;

        [FindsBy(How = How.Id, Using = "id=psg10cardid102")]
        private IWebElement maxiKlasikSlovakia;

        [FindsBy(How = How.Id, Using = "id=psg10cardid103")]
        private IWebElement seniorRailPlusSlovakia;

        [FindsBy(How = How.Id, Using = "id=psg10cardid104")]
        private IWebElement railCardSRSlovakia;

        [FindsBy(How = How.Id, Using = "id=psg10cardid201")]
        private IWebElement bahnCard25WithRailPlusGermany;

        [FindsBy(How = How.Id, Using = "id=psg10cardid202")]
        private IWebElement bahnCard50WithRailPlusGermany;

        [FindsBy(How = How.Id, Using = "id=psg10cardid203")]
        private IWebElement bahnCard100WithRailPlusGermany;

        [FindsBy(How = How.Id, Using = "id=psg10cardid301")]
        private IWebElement vorteilsCardAustria;

        [FindsBy(How = How.Id, Using = "id=psg10cardid302")]
        private IWebElement vorteilsCardWithRailPlusAustria;

        [FindsBy(How = How.CssSelector, Using = "div.btn-group.cd-right-top > button.cd-btn-blue")]
        private IWebElement finishAddingCards;

        [FindsBy(How = How.XPath, Using = "//div[@id=\'passengersModal\']/div/div[2]/div[2]/div/button[3]")]
        private IWebElement finishAddingPassengers;

        [FindsBy(How = How.XPath, Using = "//*[@id='psgDropdown2']/ul/li/div/div[2]/p[1]/label/span[1]")]
        private IWebElement firstDiscont25Percents;

        [FindsBy(How = How.Id, Using = "psgDropdownToggle2")]
        private IWebElement firstPassangerDiscount;

        [FindsBy(How = How.XPath, Using = "//*[@id='psgDropdown3']/ul/li/div/div[2]/p[1]/label/span[1]")]
        private IWebElement secondDiscont25Percents;

        [FindsBy(How = How.CssSelector, Using = "#psgDropdownToggle3")]
        private IWebElement secondPassangerDiscount;

        [FindsBy(How = How.XPath, Using = " //*[@id='psgDropdown2']/ul/li/div/div[4]/button")]
        private IWebElement buttonFinishFirstAddDiscont;

        [FindsBy(How = How.XPath, Using = " //*[@id='psgDropdown3']/ul/li/div/div[4]/button")]
        private IWebElement buttonFinishSecondAddDiscont;

        public Passengers()
        {
            PageFactory.InitElements(Browser.WebDriver,this);
        }

        public ConnectionsAndTickets FinishAddingPassenger()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(finishAddingPassengers));
            finishAddingPassengers.Click();
            return new ConnectionsAndTickets();
        }

        public Passengers FirstPassengerSetDiscont25()
        {
            firstPassangerDiscount.Click();
            firstDiscont25Percents.Click();
            buttonFinishFirstAddDiscont.Click();
            return this;
        }

        public Passengers SecondPassengerSetDiscont25()
        {
            secondPassangerDiscount.Click();
            secondDiscont25Percents.Click();
            buttonFinishSecondAddDiscont.Click();
            return this;
        }

        public ConnectionsAndTickets ClickFinishAddingPassengers()
        {
            Wait.Until(x => finishAddingPassengers.Displayed,2);
            finishAddingPassengers.Click();
            return new ConnectionsAndTickets();
        }


        public Passengers ClickSelectPassenger()
        {
            Wait.Until(x => selectPassenger.Displayed,2);
            selectPassenger.Click();
            return new Passengers();
        }

        public Passengers SelectChild05Years()
        {
            Wait.Until(x => child05Years.Displayed,2);
            child05Years.Click();
            return new Passengers();
        }

        public Passengers SelectChild69Years()
        {
            child69Years.Click();
            return new Passengers();
        }

        public Passengers SelectChild1014Years()
        {
            child1014Years.Click();
            return new Passengers();
        }

        public Passengers SelectJunior1525Years()
        {
            junior1525Years.Click();
            return new Passengers();
        }

        public Passengers SelectAdult2669Years()
        {
            adult2669Years.Click();
            return new Passengers();
        }

        public Passengers SelectAdult70YearsAndOlder()
        {
            adult70YearsAndOlder.Click();
            return new Passengers();
        }

        public void FinishEditingPassangers()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(finishAddingPassengers));
            finishAddingPassengers.Click();
        }

        public void SetDiscont25Percents()
        {
            firstPassangerDiscount.Click();
            firstDiscont25Percents.Click();
            buttonFinishFirstAddDiscont.Click();
            secondPassangerDiscount.Click();
            secondDiscont25Percents.Click();
            buttonFinishSecondAddDiscont.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(finishAddingPassengers));
            finishAddingPassengers.Click();
        }

    }
}
