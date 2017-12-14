using CZProjectFramework;
using CZProjectFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps
{
    [Binding]
    public class TrainTimetableVisibilitySteps : BaseTest
    {
        string trainName = "Ex 123 Fatra";
        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage() { }
        
        [When(@"I click on Train page link")]
        public void WhenIClickOnTrainPageLink()
        {
            HomePage.GoToTrainPage();
        }
        
        [When(@"I enter train name into the Search input")]
        public void WhenIEnterTrainNameIntoTheSearchInput()
        {
            new TrainPage().SearchTrainTimeTable<TrainDetailsPage>(trainName);
        }
        
        [When(@"I click Search button")]
        public void WhenIClickSeachButton()
        {
            //Check if train timetable is found 
            Assert.IsTrue(Browser.WebDriver.Title.Contains("Detail vlaku"));
        }
        
        [Then(@"train timetable should be found and be the same as on the search page")]
        public void ThenTrainTimetableShouldBeFoundAndBeTheSameAsOnTheSearchPage()
        {
            //Verify that train name is the same as on information page
            Assert.AreEqual(trainName, new TrainDetailsPage().TrainName);
        }
    }
}
