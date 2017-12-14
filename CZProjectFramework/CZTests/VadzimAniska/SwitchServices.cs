using CZProjectFramework.Utils;
using NUnit.Framework;

namespace CZTests.VadzimAniska
{
    [TestFixture]
    public class SwitchServices:BaseTest
    {
        [Test]
        public void TestSwitchServices()
        {
            var homePage = HomePage.SetLanguage(settings.Language);

            /*  
             *  1.Open “Connections and tickets”
             *  2.Insert dispatch station
             *  3.Insert station of arrival
             *  4.Select 2nd class
             *  5.Click Search button
             */

            var selectTicketPage = homePage.ClickConnectionTicket()
                .SetFromStationTown(Stations.FromStationTown)
                .SetToStationTown(Stations.ToStationTown)
                .Select2ndClass()
                .Search();
            var prise2NdClass = selectTicketPage.GetTicketPrice();

            /*
             *  6.Click "Go back one step" button
             *  7.Select 1st class
             *  8.Click Search button
             */

            selectTicketPage = selectTicketPage.ClickGoBackOneStep()
                .Select1stClass()
                .Search();
            var prise1StClass = selectTicketPage.GetTicketPrice();

            //The cost of the 1st class ticket is more than the cost of the second class ticket
            Assert.IsFalse(prise1StClass.Equals(prise2NdClass));
        }
    }
}
