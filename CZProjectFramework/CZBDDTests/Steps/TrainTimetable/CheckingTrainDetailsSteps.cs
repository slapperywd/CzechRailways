using CZProjectFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps.TrainTimetable
{
    [Binding]
    class CheckingTrainDetailsSteps:BaseTest
    {
        string trainName = "Ex 123 Fatra";

        [Given(@"I am on train details page looking for the train details")]
        public void GivenIAmOnTrainDetailsPageLookingForTheTrainDetails()
        {
            var stationDetailsPage = HomePage
                .GoToTrainPage()
                .SearchTrainTimeTable<TrainDetailsPage>(trainName)
                .OpenFirstLineStation();
        }

        [When(@"the page is loaded")]
        public void WhenThePageIsLoaded()
        {
            Assert.IsTrue(new StationDetailsPage().isStationDetailsPageLoaded, "Station details was not loaded");
        }

        [Then(@"train map should be shown")]
        public void ThenTrainMapShouldBeShown()
        {
            Assert.IsTrue(new StationDetailsPage().IsMapShown, "Map is not loaded");
        }

        [Then(@"at least one service should be displayed")]
        public void ThenAtLeastOneServiceIsDisplayed()
        {
            //Verify that at least one service is displayed;
            Assert.IsTrue(new StationDetailsPage().ServicesCount() > 0);
        }

        [Then(@"at least one accessibility station should be displayed")]
        public void ThenAtLeastOneAccessibilityStationIsDisplayed()
        {
            // Verify that at least one accessibility station is displayed;
            Assert.IsTrue(new StationDetailsPage().AccebilityStationsCount() > 0);
        }

        [Then(@"at least one line should be displayed")]
        public void ThenAtLeastOneLineIsDisplayed()
        {
            // Verify that at least one line is displayed.
            Assert.IsTrue(new StationDetailsPage().LinesCount() > 0);
        }

    }
}
