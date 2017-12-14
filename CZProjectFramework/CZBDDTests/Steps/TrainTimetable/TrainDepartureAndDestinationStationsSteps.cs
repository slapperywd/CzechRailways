using CZProjectFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps.TrainTimetable
{
    [Binding]
    class TrainDepartureAndDestinationStationsSteps : BaseTest
    {
        string departure = "Lamprechtshausen";
        string destination = "Salzburg Lokalbahn";
        string trainName = "S 2";

        [Given(@"I am on train details page")]
        public void GivenIAmOnTrainDetailsPage()
        {
            var trainDetailsPage = HomePage
                .GoToTrainPage();
        }

        [When(@"I scroll to bottom of the page and click calendar popup link")]
        public void WhenIScrollToBottomOfThePageAndClickCalendarPopupLink()
        {
            new TrainPage()
                .SearchTrainTimeTable<TrainDetailsPage>(trainName)
                .OpenCalendarPopup();
        }

        [Then(@"destination and departure stations in the opened popup should be equals as on the train details page")]
        public void ThenDestinationAndDepartureStationsInTheOpenedPopupShouldBeEqualsAsOnTheTrainDetailsPage()
        {
            //verify departure and destination
//            Assert.AreEqual(new TrainDetailsPage().DepartureName, departure);
//            Assert.AreEqual(new TrainDetailsPage().DestinationName, destination);
        }
    }
}