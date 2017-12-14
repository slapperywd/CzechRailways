using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps
{
    [Binding]
    public class LogInSteps:BaseTest
    {
        private const string WrongUserEmail = "user221";
        private const string WrongPassword = "123454";
        private const string WrongUserErrorMsg = "You entered an incorrect e-mail address or password.";

        [When(@"input incorrect email, password and click log in button")]
        public void WhenInputIncorrectEmailPasswordAndClickLogInButton()
        {
            HomePage.LogIn(WrongUserEmail, WrongUserEmail);
        }
        
        [Then(@"user is not logged in, error message is displayed")]
        public void ThenUserIsNotLoggedInErrorMessageIsDisplayed()
        {
            Assert.IsTrue(HomePage.GetErrorMsg().Contains(WrongUserErrorMsg));
        }
    }
}
