using CZProjectFramework.Utils;
using NUnit.Framework;

namespace CZTests.VadzimAniska
{
    [TestFixture]
    public class SelectConnectionsWithTheService : BaseTest
    {
        [Test]
        public void TestSelectConnectionsWithTheService()
        {
            var homePage = HomePage.SetLanguage(settings.Language);

            /*  
             *  1.Open “Connections and tickets”
             *  2.Insert dispatch station
             *  3.Insert station of arrival
             *  4.Click “add another services”
             *  5.Select Transport a bicycle
             *  6.Click finished button
             *  7.Click Search button
             */

            var selectTicketPage = homePage.ClickConnectionTicket()
                .SetFromStationTown(Stations.FromStationTown)
                .SetToStationTown(Stations.ToStationTown)
                .ClickAddAnotherServices()
                .SelectTransportABicycle()
                .ClickFinishedButton()
                .Search()
                .ShowDetails();

            //Transport a bicycle added to route services
            Assert.IsTrue(selectTicketPage.InspectServices(selectTicketPage.TransportABicycleService));
        }
    }
}