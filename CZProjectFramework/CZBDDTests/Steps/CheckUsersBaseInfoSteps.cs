using CZProjectFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps
{
    [Binding]
    public class CheckUsersBaseInfoSteps:BaseTest
    {
        [When(@"I get to user profile page")]
        public void WhenIGetToUserProfilePage()
        {
            HomePage.GotoUserProfilePage();
        }
        
        [Then(@"user's name and surname equals TestUser")]
        public void ThenUserSNameAndSurnameEqualsTestUser()
        {
            Assert.AreEqual(user.UserName,new UserProfilePage().GetUserProfileName(), "Wrong user1 name!");
            Assert.AreEqual(user.UserSurName, new UserProfilePage().GetUserProfileSurname(), "Wrong user1 name!");
        }
    }
}
