using System;
using CZProjectFramework;
using CZProjectFramework.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.Extensions;

namespace CZTests
{
    [TestFixture]
    internal class PriceChangesTests : BaseTest
    {
        private const string fromStation = "Praha hl.n.";
        private const string toStation = "Brno hl.n.";
        private const string timeHour = "12";
        private const string timeMinute = "00";
        private const double restrictCoeficient = 0.876;
        private const double restrictCoefficientWithDiscont = 1.333;
        private const double noneRestrictCoefficientWithDiscont = 1.224;

        [Test]
        // [Ignore("")]
        public void VerifyPriceChangingAfterAddingDefaultePassengerAndDiscontX25Test()
        {
            var selectTicket = HomePage
                .SetLanguage(settings.Language)
                .GetConnectionsAndTicketsAtHomePage()
                .SetDirections(fromStation, toStation)
                .SetDayTomorrow()
                .GotoClockPage()
                .SetTestTime(timeHour, timeMinute)
                .GotoSelectTicketPage();
            var pricesBeforeAdding = selectTicket.GetPrices();
            var pricesAfterAdding = selectTicket
                .GoToConnectionAndTickets()
                .GoToPassengerPage()
                .FirstPassengerSetDiscont25()
                .SecondPassengerSetDiscont25()
                .FinishAddingPassenger()
                .Search()
                .GetPrices();
            Assert.IsTrue(selectTicket.VerifyPriceChangedX2AndDiscont25Percent(pricesBeforeAdding, pricesAfterAdding,
                restrictCoefficientWithDiscont, noneRestrictCoefficientWithDiscont));
        }

        [Test]
        //   [Ignore("")]
        public void VeryfiPriceChangingAfterAddingDafaultePassengerTest()
        {
            var selectTicket = HomePage
                .SetLanguage(settings.Language)
                .GetConnectionsAndTicketsAtHomePage()
                .SetDirections(fromStation, toStation)
                .SetDayTomorrow()
                .GotoClockPage()
                .SetTestTime(timeHour, timeMinute)
                .GotoSelectTicketPage();
            var pricesBeforeAdding = selectTicket.GetPrices();
            var pricesAfterAdding = selectTicket
                .GoToConnectionAndTickets()
                .GoToPassengerPage()
                .FinishAddingPassenger()
                .Search()
                .GetPrices();
            Assert.IsTrue(selectTicket.VerifyPriceChangingAsterAddingSecondDefaultePassenger(pricesBeforeAdding,
                pricesAfterAdding, restrictCoeficient));
        }
    }
}
