using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using CZProjectFramework.Extensions;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class StationDetailsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "MapaImagediv")]
        private IWebElement map;

        [FindsBy(How = How.Id, Using = "mainContent_LabelStanice")]
        private IWebElement stationName;

        [FindsBy(How = How.CssSelector, Using = "ul.cd-tabs li a[href='#home1']")]
        private IWebElement servicesTab;

        [FindsBy(How = How.CssSelector, Using = "ul.cd-tabs li a[href='#menu1']")]
        private IWebElement stationAccebilityTab;

        [FindsBy(How = How.CssSelector, Using = "ul.cd-tabs li a[href='#menu2']")]
        private IWebElement linesTab;

        [FindsBy(How = How.CssSelector, Using = "div#home1 ul.tab-service")]
        private IList<IWebElement> services;

        [FindsBy(How = How.CssSelector, Using = "div#menu1 ul.tab-service")]
        private IList<IWebElement> accebilityStations;

        [FindsBy(How = How.CssSelector, Using = "div#menu2 ul.tab-service")]
        private IList<IWebElement> lines;

        public bool isStationDetailsPageLoaded 
            => Wait.Until(x => driver.Title.Contains("Vše o stanici"));

        public bool IsMapShown => map.Displayed;

        public StationDetailsPage()
        {
            driver = Browser.WebDriver;
            PageFactory.InitElements(Browser.WebDriver, this);
            Wait.Until(ExpectedConditions.ElementToBeClickable(map));
        }

        public int LinesCount()
        {
            linesTab.Click();
            Console.Out.WriteLine($"Lines count {lines.Count}");
            return lines.Count;
        }

        public int ServicesCount()
        {
            servicesTab.Click();
            Console.Out.WriteLine($"Services count {services.Count}");
            return services.Count;
        }

        public int AccebilityStationsCount()
        {
            stationAccebilityTab.Click();
            Console.Out.WriteLine($"Services count {accebilityStations.Count}");
            return accebilityStations.Count;
        }
    }
}
