using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps
{
    [Binding]
    public class LogInRegisteredUserSteps:BaseTest
    {
        [When(@"I set language")]
        public void WhenISetLanguage()
        {
            HomePage.SetLanguage(settings.Language);
        }
        
        [When(@"input correct email, password and click log in button")]
        public void WhenInputCorrectEmailPasswordAndClickLogInButton()
        {
            HomePage.LogIn(user.Email, user.Password);
        }
        
        [Then(@"link log out and logged user's name are displayed")]
        public void ThenLinkLogOutAndLoggedUserSNameAreDisplayed()
        {
            Assert.IsTrue(HomePage.GetUserDisplayedName().Contains(user.UserName + " " + user.UserSurName.First() + "."), "Dysplayed names are not equal");     
            Assert.IsTrue(HomePage.LogOutIsAt());
            HomePage.LogOut();
        }
    }
}
