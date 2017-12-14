using System;
using System.Collections.Generic;
using System.Linq;
using CZProjectFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using CZProjectFramework.Utils;
using OpenQA.Selenium.Interactions;

namespace CZProjectFramework.Pages
{
    public class SelectTicket
    {
        [FindsBy(How = How.CssSelector, Using = "span.transfer")]
        private IWebElement transferVia;

        [FindsBy(How = How.LinkText, Using = "Details")]
        private IWebElement details;

        [FindsBy(How = How.XPath, Using = "//p[@class=\'age\']")]
        private IWebElement passenger;

        [FindsBy(How = How.XPath, Using = "//span[@class=\'train-icons\']/span")]
        private IList<IWebElement> services;

        [FindsBy(How = How.LinkText, Using = "Go back one step")]
        private IWebElement goBackOneStep;

        [FindsBy(How = How.XPath, Using = "//a[@class=\'buybut green\']")]
        private IWebElement ticketPrice;

        [FindsBy(How = How.XPath, Using = "//span[@class=\'res-cityname\']/a")]
        private IWebElement fromStationTown;

        [FindsBy(How = How.XPath, Using = "//p[@class=\'res-city res-bottom\']/span/a")]
        private IWebElement toStationStationTown;

        [FindsBy(How = How.XPath, Using = ".//*[@id='connectionlistanchor']/div[1]/a[3]")]
        private IWebElement favoriteButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div[2]/div/div[2]/p[2]/span[1]")]
        private IWebElement connectionDepartureName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div[2]/div/div[2]/p[2]/span[3]")]
        private IWebElement connectionArrivalName;

        [FindsBy(How = How.CssSelector, Using = ".buybut")] private IList<IWebElement> ticketPrices;

        [FindsBy(How = How.CssSelector, Using = ".dropdown-toggle.is-btn.is-btn-white.is-btn-xs")]
        private IWebElement buttonModify;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[2]/div/div[1]/div/ul/li[1]/a/span")]
        private IWebElement selectJourneysAndPassangers;

        [FindsBy(How = How.XPath, Using = "//div[@id='connectionlistanchor']/div[11]/div/div/div/a[1]")]
        private IWebElement lastPrice;



        public List<int> GetPrices()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(lastPrice));
         
            return ticketPrices.Select(x => x.GetAttribute("title").ConvertToIntFormat()).ToList();
        }

        public ConnectionsAndTickets GoToConnectionAndTickets()
        {
            buttonModify.Click();
            selectJourneysAndPassangers.Click();
            return new ConnectionsAndTickets();
        }


        public SelectTicket()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public string GetToStationStationTown()
        {
            Wait.Until(x => toStationStationTown.Exists());
            return toStationStationTown.Text;
        }

        public string GetFromStationTown()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(buttonModify));
         //   Wait.Until(x => fromStationTown.Exists());
            return fromStationTown.Text;
        }


        public int GetTicketPrice()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(lastPrice));
            var priceStr = ticketPrice.Text.Where(x => Char.IsDigit(x)).ToArray();
            return Convert.ToInt32(new string(priceStr));
        }

        public string GetPassenger()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(lastPrice));
            return passenger.Text.ToLower();
        }

        public ConnectionsAndTickets ClickGoBackOneStep()
        {
            goBackOneStep.Click();
            return new ConnectionsAndTickets();
        }

        public bool InspectServices(string service)
        {
            var servicesNames = services.Select(x => x.GetAttribute("title").ToLower()).ToList();
            var isServiceThere = servicesNames.Select(x => x.Contains(service)).Where(x => x).ToList();
            if (isServiceThere.Count > 0)
                return true;

            return false;
        }

        public SelectTicket ShowDetails()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(details));
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", details);
            return new SelectTicket();
        }

        public string GetTransverOrViaStation()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(transferVia));
            return transferVia.Text;
        }

        public bool VerifyPriceChangedX2AndDiscont25Percent(List<int> priceBeforeAdding, List<int> priceAfterAdding,
            double coefficient1, double coefficient2)
        {
            Logger.Info($"VerifyPriceChangedX2AndDiscont25Percent");
            for (var i = 0; i < priceBeforeAdding.Count; i++)
                if (priceBeforeAdding[i] * 2 == (int)(priceAfterAdding[i] * coefficient1))
                {
                    Logger.Info($"priceBeforeAdding({priceBeforeAdding[i]})*2=priceAfterAdding={priceAfterAdding[i]}*{coefficient1}");
                    continue;
                }
                else if (priceBeforeAdding[i] * 2 == (int)(priceAfterAdding[i] * coefficient2))
                {
                    Logger.Info($"priceBeforeAdding({priceBeforeAdding[i]})*2=priceAfterAdding={priceAfterAdding[i]}*{coefficient2}");
                    continue;
                }
                else
                {
                    Logger.Error($"priceBeforeAdding={priceBeforeAdding[i]},{coefficient1},{coefficient2}:priceAfterAdding={priceAfterAdding[i]}");
                    return false;
                }
            return true;
        }

        public bool VerifyPriceChangingAsterAddingSecondDefaultePassenger(List<int> priceBeforeAdding,
            List<int> priceAfterAdding, double coefficient)
        {
            // 0.876 is special coefficient when ticket type is RESTRICTIONS ON THE ROUTE
            Logger.Info($"VerifyPriceChangingAsterAddingSecondDefaultePassenger");
            for (var i = 0; i < priceBeforeAdding.Count; i++)
                if (priceBeforeAdding[i] * 2 == priceAfterAdding[i])
                {
                    Logger.Info($"priceBeforeAdding({priceBeforeAdding[i]})*2=priceAfterAdding={priceAfterAdding[i]}");
                    continue;
                }
                else if ((int)(priceBeforeAdding[i] * 2 * coefficient) == priceAfterAdding[i])

                {
                    Logger.Info($"priceBeforeAdding({priceBeforeAdding[i]})*2*{coefficient}=priceAfterAdding={priceAfterAdding[i]}");
                    continue;
                }
                else
                {
                    Logger.Error($"priceBeforeAdding{priceBeforeAdding[i]},{coefficient}:priceAfterAdding={priceAfterAdding[i]}");
                    return false;
                }
            return true;
        }

        public SelectTicket AddConnectionToFavorite()
        {
            Wait.Until(x=>favoriteButton.Displayed);
          Actions act=new Actions(Browser.WebDriver);
            act.Click(favoriteButton).Build().Perform();
          //  favoriteButton.Click();
            var a = 0;
            return new SelectTicket();
        }

        public string GetConnectionName()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath(".//*[@id='main']/div[2]/div/div[2]/p[2]/span[1]")));
          return  $"{connectionDepartureName.Text}\r\n{connectionArrivalName.Text}";
        }

        //Services
        public string AutomobileTrainService => "";
        public string ChildrenCompartmentService => "children";
        public string ElectricSocketsService => "230";
        public string ForWheelchairUsersService => "wheelchair";
        public string InSeniorService => "sitting";
        public string LadiesCompartmentService => "ladies compartment";
        public string QuietSectionService => "silence";
        public string RefreshmentsService => "bar";
        public string TransportABicycleService => "bicycle";
        public string WiFiService => "internet";
        //Passengers
        public string Adult2669YearsPassenger => "adult 26—69 years";
        public string Adult70YearsAndOlderPassenger => "adult 70 years and older";
        public string Child05YearsPassenger => "child 0—5 years";
        public string Child1014YearsPassenger => "child 10—14 years";
        public string Child69YearsPassenger => "child 6—9 years";
        public string Junior1525YearsPassenger => "junior 15—25 years";
    }
}
