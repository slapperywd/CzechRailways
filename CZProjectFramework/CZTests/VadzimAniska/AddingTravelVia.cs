using CZProjectFramework.Utils;
using NUnit.Framework;

namespace CZTests.VadzimAniska
{
    [TestFixture]
    public class AddingTravelVia : BaseTest
    {
        [Test]
        public void TestAddingTravelVia()
        {
            var homePage = HomePage.SetLanguage(settings.Language);

            /*  
             *  1.Open “Connections and tickets”
             *  2.Insert dispatch station
             *  3.Insert station of arrival
             *  4.Click “Travel via”
             *  5.Insert via station
             *  6.Click Search button
             */

            var selectTicketPage = homePage.ClickConnectionTicket()
            .SetFromStationTown(Stations.FromStationTown)
            .SetToStationTown(Stations.ToStationTown)
            .AddTravelVia()
            .SetViaOrTransferStation(Stations.ViaStation)
            .Search();

            //Via station added to route
            Assert.IsTrue(selectTicketPage.GetTransverOrViaStation().Contains(Stations.ViaStation));
        }
    }
}