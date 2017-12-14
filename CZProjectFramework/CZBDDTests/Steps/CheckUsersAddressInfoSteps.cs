using CZProjectFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps
{
    [Binding]
    public class CheckUsersAddressInfoSteps:BaseTest
    {
        [When(@"click user's addres info item")]
        public void WhenClickUserSAddresInfoItem()
        {
            new UserProfilePage().GetAddressInfo();
        }
        
        [Then(@"user country is TestCountry")]
        public void ThenUserCountryIsTestCountry()
        {
            Assert.AreEqual(user.Country, new UserProfilePage().GetUserCountry(), "Wrong country");
        }
        
        [Then(@"user city is TestCity")]
        public void ThenUserCityIsTestCity()
        {
            Assert.AreEqual(user.City, new UserProfilePage().GetUserCity(), "Wrong city");
        }
        
        [Then(@"user street is TestStreet")]
        public void ThenUserStreetIsTestStreet()
        {
            Assert.AreEqual(user.Street, new UserProfilePage().GetUserStreet(), "Wrong street");
        }
    }
}
