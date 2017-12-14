using CZProjectFramework;
using CZProjectFramework.Pages;
using NUnit.Framework;

namespace CZTests
{
    [TestFixture]
    class TrainTimetableTests : BaseTest
    {
        [Test(Description = "Checking train timetable visibility")]
        public void VerifyTrainTimetableVisibility()
        {
            string trainName = "Ex 123 Fatra";

            var trainDetailsPage = HomePage
                .GoToTrainPage()
                .SearchTrainTimeTable<TrainDetailsPage>(trainName);

            //Check if train timetable is found 
            Assert.IsTrue(Browser.WebDriver.Title.Contains("Detail vlaku"));
            //Verify that train name is the same as on information page
            Assert.AreEqual(trainName, trainDetailsPage.TrainName);
        }

        [Test(Description = "Verifying train departure and destination stations")]
        public void VerifyTrainDepartureAndDestinationDtations()
        {
            string departure = "Lamprechtshausen";
            string destination = "Salzburg Lokalbahn";
            string trainName = "S 2";

            var trainDetailsPage = HomePage
                .GoToTrainPage()
                .SearchTrainTimeTable<TrainDetailsPage>(trainName)
                .OpenCalendarPopup();

            //verify departure and destination
            Assert.AreEqual(trainDetailsPage.DepartureName(), departure);
            Assert.AreEqual(trainDetailsPage.DestinationName(), destination);
        }

        [Test(Description = "Checking train timetable with invalid values input")]
        public void SearchTrainTimetableWithInvalidTrainNameInput()
        {
            string invalidTrainName = "blablablablabla";

            var trainInformationPage = HomePage
                .GoToTrainPage()
                .SearchTrainTimeTable<TrainPage>(invalidTrainName);
            Assert.IsTrue(trainInformationPage.ErrorMessage.Contains("Vlak nebyl nalezen.")||
                          trainInformationPage.ErrorMessage.Contains("The train was not found."), "Error message is not displayed");
            //Assert.AreEqual("Vlak nebyl nalezen.", trainInformationPage.ErrorMessage, "Error message is not displayed");
        }

        [Test(Description = "Checking visibility of all train timetable details")]
        public void CheckTrainTimetableDetails()
        {
            string trainName = "Ex 123 Fatra";
            var stationDetailsPage = HomePage
                .GoToTrainPage()
                .SearchTrainTimeTable<TrainDetailsPage>(trainName)
                .OpenFirstLineStation();
            //check if station details page is loaded and map is shown
            Assert.IsTrue(stationDetailsPage.isStationDetailsPageLoaded, "Station details was not loaded");
            Assert.IsTrue(stationDetailsPage.IsMapShown, "Map is not loaded");

            //Verify that at least one service is displayed;
            Assert.IsTrue(stationDetailsPage.ServicesCount() > 0);
            // Verify that at least one accessibility station is displayed;
            Assert.IsTrue(stationDetailsPage.AccebilityStationsCount() > 0);
            // Verify that at least one line is displayed.
            Assert.IsTrue(stationDetailsPage.LinesCount() > 0);
        }

        [Test(Description = "Save timetable in PDF")]
        public void SaveTimeTableInPDFformat()
        {
            string trainName = "Ex 123 Fatra";

            var trainDetailsPage = HomePage
                .GoToTrainPage()
                .SearchTrainTimeTable<TrainDetailsPage>(trainName);

            Assert.IsTrue(trainDetailsPage.SaveTimeTableAsPDF("Detail_vlaku_Ex123_Fatra.pdf"));
        }
    }
}
