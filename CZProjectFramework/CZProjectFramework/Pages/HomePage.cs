using System;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class HomePage
    {
        [FindsBy(How = How.Id, Using = "csbhp-to")] protected IWebElement arrivalField;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-id-3']/li[2]/a")] protected IWebElement arrivalStationToChoose;

        [FindsBy(How = How.CssSelector, Using = ".is-iconcollapsing.collapsed")]
        private IWebElement changeLanguageArrow;

        [FindsBy(How = How.XPath, Using = "//a[@href='/spojeni-a-jizdenka/']")]
        protected IWebElement connectionMenuSection;

        [FindsBy(How = How.XPath, Using = ("//*[@id='user']/span[2]/button"))] private IWebElement logInDropItem;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),\'Connection & Ticket\')]")]
        private IWebElement connectionTicket;

        [FindsBy(How = How.Id, Using = "csbhp-from")] protected IWebElement departureField;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-id-2']/li[1]/a")] protected IWebElement departureStationToChoose;

        [FindsBy(How = How.XPath, Using = "//*[@id='layout']/header/div[1]/div[1]/div[1]/ul/li[2]/a")]
        private IWebElement deutchLanguageSelector;

        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='use']/span[2]")] private IWebElement dropDownProfile;

        [FindsBy(How = How.Id, Using = "emailInput")] private IWebElement emaiInput;

        [FindsBy(How = How.Id, Using = "emailInput")] private IWebElement emailInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='layout']/header/div[1]/div[1]/div[1]/ul/li[1]/a/span[2]")]
        private IWebElement englishLanguageSelector;

        [FindsBy(How = How.ClassName, Using = "name")] protected IWebElement userEntered;

        [FindsBy(How = How.XPath, Using = "//*[@id='quicklgnfrm']/div/form/span")]
        private IWebElement errorMessageUregisterUser;

        [FindsBy(How = How.XPath, Using = "//*[@id='use']/span[2]/img")] private IWebElement imageArrow;

        [FindsBy(How = How.XPath, Using = "//*[@id='use']/span[2]")] private IWebElement loginUserName;
        [FindsBy(How = How.CssSelector, Using = ".cd-btn-blue.cdis_login_button")] private IWebElement loginButton;

        public HomePage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Log out")] private IWebElement logOutLink;

        [FindsBy(How = How.XPath, Using = "//a[@href='/moje-cestovani/']")] protected IWebElement myTravelMenuSection;

        [FindsBy(How = How.Id, Using = "pswdInput")] private IWebElement passswordInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='user']/span[2]/span/a")] private IWebElement registerButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Search')]")] protected IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='/stanice/']")] protected IWebElement stationMenuSection;

        [FindsBy(How = How.XPath, Using = "//a[@href='/vlak/']")] protected IWebElement trainMenuSection;

        [FindsBy(How = How.LinkText, Using = "User profile")] private IWebElement userProfileLink;

        public RegisterPage RegisterNewUser()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(registerButton));
            registerButton.Click();
            return new RegisterPage();
        }

        public HomePage SetLanguage(string language)
        {
            changeLanguageArrow.Click();
            switch (language)
            {
                case "English":
                    englishLanguageSelector.Click();
                    break;
                case "Deutch":
                    deutchLanguageSelector.Click();
                    break;
                default:
                    throw new Exception("Unknown language!");
            }
            return this;
        }

        public bool CheckIsLoggedIn()
        {
          //  WebDriverWait wait =new WebDriverWait(Browser.WebDriver,new TimeSpan(5).Seconds);
            dropDownProfile.Click();
            return logOutLink.Exists();
        }

        public ConnectionsAndTickets ClickConnectionTicket()
        {
            connectionTicket.Click();
            return new ConnectionsAndTickets();
        }

        public void SetDeutchLanguage()
        {
        //    WebDriverWait wait=new WebDriverWait(Browser.WebDriver,TimeSpan.FromSeconds(10));
          
            changeLanguageArrow.Click();
            deutchLanguageSelector.Click();
        }


        public string GetErrorMsg()
        {
            Wait.Until(x => errorMessageUregisterUser.Displayed);
            return errorMessageUregisterUser.Text;
        }

        public ConnectionsAndTicketsAtHomePage GetConnectionsAndTicketsAtHomePage()
        {
            return new ConnectionsAndTicketsAtHomePage();
        }


        public HomePage LogIn(string email, string password)
        {
            Wait.Until(x => logInDropItem.Displayed);
            logInDropItem.Click();
            emailInput.Clear();
            Actions action=new Actions(Browser.WebDriver);
            //need to use action because without it firefox is not working
            action.SendKeys(emaiInput,email).SendKeys(passswordInput,password).Click(loginButton).Perform();  
            return this;
        }

        public string GetUserDisplayedName()
        {
            //Wait.Until(ExpectedConditions.ElementToBeClickable(imageArrow));
            Wait.Until(x => imageArrow.Displayed);
            imageArrow.Click();
            return loginUserName.Text;
        }

        public void GotoUserProfilePage(string correctEmail, string correctPassword)
        {
            LogIn(correctEmail, correctPassword);
            Wait.Until(ExpectedConditions.ElementToBeClickable(imageArrow));
            imageArrow.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(userProfileLink));
            userProfileLink.Click();
        }
        public StationsPage GoToStation()
        {
            Wait.Until(x => userEntered.Displayed);
            stationMenuSection.Click();
            return new StationsPage();
        }

        public MyTravelPage GoToMyTravel()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(userEntered));
            myTravelMenuSection.Click();
            return new MyTravelPage();
        }

        public TrainPage GoToTrain()
        {
            Wait.Until(x => userEntered.Displayed);
            trainMenuSection.Click();
            return new TrainPage();
        }

        public bool LogOutIsAt()
        {
            return logOutLink.Exists();
        }

        public HomePage LogOut()
        {
            logOutLink.Click();
            return this;
        }

        public TrainPage GoToTrainPage()
        {
            trainMenuSection.Click();
            return new TrainPage();
        }

        public ConnectionsAndTickets GoToConnection()
        {
            Wait.Until(x => userEntered.Displayed);
            connectionMenuSection.Click();
            return new ConnectionsAndTickets();
        }

        public UserProfilePage GotoUserProfilePage()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(imageArrow));
            IJavaScriptExecutor js = Browser.WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", imageArrow);
            Wait.Until(x => userProfileLink.Exists());
            userProfileLink.Click();
            return new UserProfilePage();
        }

        public void ClickOnTriangle()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(imageArrow));
            imageArrow.Click();
        }

        public UserProfilePage ClickOnUserProfileLink()
        {
            Wait.Until(x => userProfileLink.Exists());
            userProfileLink.Click();
            return new UserProfilePage();
        }

        public bool CheckIsDeleted()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(registerButton));
            return registerButton.Displayed;
        }
    }
}
