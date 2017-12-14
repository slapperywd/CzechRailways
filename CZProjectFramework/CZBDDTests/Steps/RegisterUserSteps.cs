using System;
using CZProjectFramework;
using CZProjectFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CZBDDTests.Steps
{
    [Binding]
    public class RegisterUserSteps : BaseTest
    {
        private AccountCancellationPage _accountCancellationPage;
        private HomePage _homePage;
        private string _linkToActivate;

        private string _myRegisteredEmail;
        private RegisterPage _registerPage;
        private UserProfilePage _userProfilePage;
        private IdentityVerificationPage _verificationPage;
        protected NadaPage NadaPage => new NadaPage();
        protected NewPasswordPage NewPasswordPage => new NewPasswordPage();

        [Given(@"Home Page")]
        public void GivenHomePage()
        {
            _registerPage = HomePage.SetLanguage(settings.Language).RegisterNewUser();
        }

        [Given(@"insert ""(.*)"" into a field")]
        public void GivenInsertIntoAField(string p0)
        {
            switch (p0)
            {
                case "name":
                    _registerPage.InsertName(user.UserName);
                    break;
                case "surname":
                    _registerPage.InsertSurname(user.UserSurName);
                    break;
                case "e-mail":
                    var r = new Random();
                    _myRegisteredEmail = r.Next(0, 100000).ToString();
                    _registerPage.InsertEmail(_myRegisteredEmail + settings.Domain);
                    break;
                case "New Password":
                    NewPasswordPage.InputNewPassword(user.Password);
                    break;
                case "password":
                    NewPasswordPage.InputRepeatPassword(user.Password);
                    break;
                case "Password":
                    _verificationPage.InsertPassword();
                    break;
            }
        }

        [When(@"click ""(.*)""")]
        [Given(@"click ""(.*)""")]
        public void Click(string p0)
        {
            switch (p0)
            {
                case "consent checkbox":
                    _registerPage.ClickConsentButton();
                    break;
                case "Register button":
                    _registerPage.ClickRegisterButton();
                    break;
                case "radio button":
                    NewPasswordPage.ClickReceiveInformation(true);
                    break;
                case "confirmation button":
                    NewPasswordPage.CompleteRegistration();
                    break;
                case "triangle right to the name":
                    HomePage.ClickOnTriangle();
                    break;
                case "User profile button":
                    _userProfilePage = HomePage.ClickOnUserProfileLink();
                    break;
                case "Account cancellation button":
                    _accountCancellationPage = _userProfilePage.GoToAddressCancellation();
                    break;
                case "confirmation of cancellation":
                    _accountCancellationPage.ClickWantToCancel();
                    break;
                case "Cancel button":
                    _verificationPage = _accountCancellationPage.ClickCancelButton();
                    break;
                case "Save changes button":
                    _homePage = _verificationPage.ConfirmDelete();
                    break;
            }
        }

        [Given(@"check entered mail")]
        public void GivenCheckEnteredMail()
        {
            Browser.Goto(settings.NadaPage);
            _linkToActivate = NadaPage.CheckMail(_myRegisteredEmail, settings.Domain);
        }

        [Given(@"activate your account")]
        public void GivenActivateYourAccount()
        {
            Browser.Goto(_linkToActivate);
        }

        [Then(@"the ""(.*)"" appears on the right side")]
        public void ThenTheAppearsOnTheRightSide(string p0)
        {
            Assert.IsTrue(_homePage.CheckIsDeleted());
        }
    }
}