using CZProjectFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps
{
    [Binding]
    public class PriceChangingSteps:BaseTest
    {

        private const string fromStation = "Praha hl.n.";
        private const string toStation = "Brno hl.n.";
        private const string timeHour = "12";
        private const string timeMinute = "00";
        private const double restrictCoeficient = 0.876;
        private const double restrictCoefficientWithDiscont = 1.333;
        private const double noneRestrictCoefficientWithDiscont = 1.224;
        private List<int> priceBefore;
        private List<int> priceAfter;

        [When(@"set directions")]
        public void WhenSetDirections()
        {
            HomePage
                .GetConnectionsAndTicketsAtHomePage()
                .SetDirections(fromStation, toStation);

        }
        
        [When(@"set day tomorrow")]
        public void WhenSetDayTomorrow()
        {
            new ConnectionsAndTicketsAtHomePage().SetDayTomorrow();
        }


         [When(@"set time (.*)")]
        public void WhenSetTime(string p0)
        {
            new ConnectionsAndTicketsAtHomePage()
                .GotoClockPage()
                .SetTestTime(timeHour, timeMinute)
                .GotoSelectTicketPage();
        }
        
        [When(@"get prices before adding")]
        public void WhenGetPricesBeforeAdding()
        {
         priceBefore=new SelectTicket().GetPrices();
        }
        
        [When(@"i add new defaulte passenger")]
        public void WhenIAddNewDefaultePassenger()
        {
            new SelectTicket()
                 .GoToConnectionAndTickets()
                 .GoToPassengerPage()
                 .FinishAddingPassenger()
                 .Search();
        }
        
        [When(@"get prices after adding")]
        public void WhenGetPricesAfterAdding()
        {
            priceAfter = new SelectTicket().GetPrices();
        }
        
        [Then(@"pricess after adding nore (.*)x or (.*)xrestrict coefficient then prices before adding")]
        public void ThenPricessAfterAddingNoreXOrXrestrictCoefficientThenPricesBeforeAdding(int p0, int p1)
        {
            Assert.IsTrue(new  SelectTicket().VerifyPriceChangingAsterAddingSecondDefaultePassenger(priceBefore,
            priceAfter, restrictCoeficient));
        }
    }
}
