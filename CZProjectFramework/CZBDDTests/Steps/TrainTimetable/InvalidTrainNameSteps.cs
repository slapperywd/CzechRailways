using CZProjectFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps.TrainTimetable
{
    [Binding]
    class InvalidTrainNameSteps:BaseTest
    {
        string invalidTrainName = "blablablablabla";

        [Given(@"I am on train page searching a train")]
        public void GivenIAmOnTrainPageSearchingATrain()
        {
            var trainInformationPage = HomePage
                .GoToTrainPage();
        }

        [When(@"I type train name which is not exist")]
        public void WhenITypeTrainNameWhichIsNotExist()
        {
            new TrainPage()
                .SearchTrainTimeTable<TrainPage>(invalidTrainName);
        }

        [Then(@"error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed()
        {
            Assert.IsTrue(new TrainPage().ErrorMessage.Contains("Vlak nebyl nalezen.") ||
                          new TrainPage().ErrorMessage.Contains("The train was not found."), "Error message is not displayed");
        }

    }
}
