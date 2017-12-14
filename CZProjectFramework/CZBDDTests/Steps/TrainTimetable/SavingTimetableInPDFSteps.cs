using CZProjectFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps.TrainTimetable
{
    [Binding]
    class SavingTimetableInPDFSteps:BaseTest
    {
        string trainName = "Ex 123 Fatra";

        [Given(@"I am on Train page trying to save my timetable in PDF")]
        public void GivenIAmOnTrainPageTryingToSaveMyTimetableInPDF()
        {
            var trainDetailsPage = HomePage
                .GoToTrainPage()
                .SearchTrainTimeTable<TrainDetailsPage>(trainName);
        }

        [When(@"I click Save as PDF button")]
        public void WhenIClickSaveAsPDF(){}

        [Then(@"PDF timetable should be downloaded")]
        public void ThenPDFTimetableShouldBeDownloaded()
        {
            Assert.IsTrue(new TrainDetailsPage().SaveTimeTableAsPDF("Detail_vlaku_Ex123_Fatra.pdf"));
        }
    }
}
