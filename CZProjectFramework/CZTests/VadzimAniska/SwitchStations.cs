using CZProjectFramework.Utils;
using NUnit.Framework;

namespace CZTests.VadzimAniska
{
    [TestFixture]
    public class SwitchStations : BaseTest
    {
        [Test]
        public void TestSwitchStations()
        {
            var homePage = HomePage.SetLanguage(settings.Language);

            /*
             *  1.Open “Connections and tickets”
             *  2.Insert dispatch station
             *  3.Insert station of arrival
             *  4.Click switch button
             *  5.Click Search button
             */

            var selectTicketPage = homePage.ClickConnectionTicket()
                .SetFromStationTown(Stations.FromStationTown)
                .SetToStationTown(Stations.ToStationTown)
                .ClickSwitchFromAndToStationButton()
                .Search();

            //Station of arrival and dispatch station are switched places
            Assert.IsTrue(selectTicketPage.GetFromStationTown().Contains(Stations.ToStationTown));
            Assert.IsTrue(selectTicketPage.GetToStationStationTown().Contains(Stations.FromStationTown));
        }
    }
}