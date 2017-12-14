using System;
using System.Linq;
using CZProjectFramework;
using CZProjectFramework.Pages;
using CZProjectFramework.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.Extensions;

namespace CZTests
{
    [TestFixture]
    internal class LoginUserTests : BaseTest
    {

        private const string WrongUserEmail = "user21";
        private const string WrongPassword = "123454";

        private const string WrongUserErrorMsg = "You entered an incorrect e-mail address or password.";
        // "Due to too many failed logins, the account has been locked for 60 minutes.";
      
        [Test]
        // [Ignore("")]
        public void LoginRegisteredUserTest()
        {
            HomePage.
                SetLanguage(settings.Language)
                .LogIn(user.Email, user.Password);
            Assert.IsTrue(HomePage.GetUserDisplayedName().Contains(user.UserName + " " + user.UserSurName.First() + "."), "Dysplayed names are not equal");
            //Assert.AreEqual(user1.UserName + " " + user1.UserSurName.First() + ".", HomePage.GetUserDisplayedName(), "Dysplayed names are not equal");
            Assert.IsTrue(HomePage.LogOutIsAt());
            HomePage.LogOut();
        }

        [Test]
        // [Ignore("")]
        public void LoginUnregisteredUserTest()
        {
            HomePage.
                SetLanguage(settings.Language)
                .LogIn(WrongUserEmail, WrongPassword);
            Assert.IsTrue(HomePage.GetErrorMsg().Contains(WrongUserErrorMsg));
            //Assert.AreEqual(WrongUserErrorMsg, HomePage.GetErrorMsg());
        }

        [Test]
        //   [Ignore("")]
        public void UserProfileInfoTest()
        {
            var userProfilePage = HomePage
                    .SetLanguage(settings.Language)
                    .LogIn(user.Email, user.Password)
              .GotoUserProfilePage();
            Assert.AreEqual(user.UserName, userProfilePage.GetUserProfileName(), "Wrong user1 name!");
            Assert.AreEqual(user.UserSurName, userProfilePage.GetUserProfileSurname(), "Wrong user1 name!");


        }

        [Test]
        //  [Ignore("")]
        public void UserProfileContactAndAddressInfoTest()
        {
            var userProfile = HomePage
             .SetLanguage(settings.Language)
             .LogIn(user.Email, user.Password)
            .GotoUserProfilePage().GetAddressInfo();
            Assert.AreEqual(user.City, userProfile.GetUserCity(), "Wrong city");
            Assert.AreEqual(user.Country, userProfile.GetUserCountry(), "Wrong country");
            Assert.AreEqual(user.Street, userProfile.GetUserStreet(), "Wrong street");
        }
    }
}
