using CZProjectFramework.Utils;
using NUnit.Framework;

namespace CZTests.VadzimAniska
{
    [TestFixture]
    public class SelectPassenger : BaseTest
    {
        [Test]
        public void TestSelectPassenger()
        {
            var homePage = HomePage.SetLanguage(settings.Language);

            /*  
             *  1.Open “Connections and tickets”
             *  2.Insert dispatch station
             *  3.Insert station of arrival
             *  4.Click “Modify passengers”
             *  5.Select Child 0-5 years
             *  6.Click Finished button
             *  7.Click Search button
             */

            var selectTicketPage = homePage.ClickConnectionTicket() 
                .SetFromStationTown(Stations.FromStationTown)
                .SetToStationTown(Stations.ToStationTown)
                .ClickModifyPassengers()
                .ClickSelectPassenger()
                .SelectChild05Years()
                .ClickFinishAddingPassengers()
                .Search();

            //Child 0-5 years is selected as a passenger
            Assert.IsTrue(selectTicketPage.GetPassenger().Contains(selectTicketPage.Child05YearsPassenger));
        }
    }
}
