using System;
using System.Configuration;
using System.Linq;
using CZProjectFramework;
using CZProjectFramework.Pages;
using CZProjectFramework.Utils;
using NUnit.Framework;

namespace CZTests
{
    [TestFixture]
    public class RegisterUserTest : BaseTest
    {
        private static User user = XmlReader.Read<User>("UserData.xml");
        protected NadaPage NadaPage => new NadaPage();
        protected NewPasswordPage NewPasswordPage => new NewPasswordPage();

        private readonly string _name = user.UserName;
        private readonly string _surname = user.UserSurName;

        private const string WrongPassword = "bad";
        private bool _clickContentButton = true;

        [Test]
        public void RegisterNewUser()
        {
            var homePage = RegisterWithPassword(user.Password)
                    .GotoUserProfilePage()
                    .GoToAddressCancellation()
                    .AcceptDeleteAccount()
                    .DeleteAccount()
                ;

            Assert.IsTrue(homePage.CheckIsDeleted());
        }

        [Test]
        public void RegisterWithIncorrectEmail()
        {
            // Fill “e-mail” field with incorrect e-mail 
            // (without @, low-level domain, like .com or .ru)
            var homePage = HomePage.SetLanguage(settings.Language);
            var registerPage = homePage.RegisterNewUser()
                .FillUserData(_clickContentButton, _name, _surname, WrongPassword);
            //Fill “name” and “surname” fields

            Assert.IsFalse(registerPage.EmailIsValid());
        }

        [Test]
        public void RegisterWithIncorrectPassword()
        {
            RegisterWithPassword(WrongPassword);

            Assert.IsTrue(NewPasswordPage.CheckPassword());
        }

        [Test]
        public void RegisterWithoutConsentCheckbox()
        {
            // Do not click consent checkbox
            _clickContentButton = false;
            //Click on button “Register”
            var registerPage = HomePage.SetLanguage(settings.Language).RegisterNewUser().
                // Do not fill all the fields or some of them
                FillUserData(_clickContentButton, _name, _surname, user.Password);


            Assert.IsFalse(registerPage.RegisterButtonEnabled());
        }

        [Test]
        public void RegisterWithoutFillingFields()
        {
            //Click on button “Register”
            var registerPage = HomePage.SetLanguage(settings.Language).RegisterNewUser().
                // Click consent checkbox
                FillUserData(_clickContentButton);

            Assert.IsFalse(registerPage.RegisterButtonEnabled());
        }

        private HomePage RegisterWithPassword(string password)
        {
            Random r = new Random();
            var myRegisteredEmail = r.Next(0, 100000).ToString();
            string emailDomen = settings.Domain;
            HomePage homePage = HomePage.SetLanguage(settings.Language);

            homePage.RegisterNewUser().FillUserData(_clickContentButton, _surname, myRegisteredEmail + emailDomen);

            //Add check We sent a verification e-mail to
            Browser.Goto(settings.NadaPage);
            var linkToActivate = NadaPage.CheckMail(myRegisteredEmail, emailDomen);
            Browser.Goto(linkToActivate);
            NewPasswordPage.SetNewPassword(password, true);
            return new HomePage();
        }
    }
}