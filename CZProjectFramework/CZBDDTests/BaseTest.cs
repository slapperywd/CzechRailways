using System;
using CZProjectFramework;
using CZProjectFramework.Pages;
using CZProjectFramework.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using Logger = CZProjectFramework.Utils.Logger;

namespace CZBDDTests
{
    [Binding]
    public class BaseTest
    {
        protected HomePage HomePage => new HomePage();
        protected static TestSettings settings;
        protected static User user;

        [BeforeScenario]
        public static void SetUp()
        {
            settings = new TestSettings();
            BrowserInit(settings.BrowserName);
            user = XmlReader.Read<User>("UserData.xml");
            Logger.Info($"{TestContext.CurrentContext.Test.Name}" +
                        $"\r\nBrowser:{settings.BrowserName}" +
                        $"\r\nLanguage:{settings.Language}");
        }

        [AfterScenario]
        public static void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                Logger.Info($"{AppDomain.CurrentDomain.BaseDirectory}{TestContext.CurrentContext.Test.Name}.jpg");
                Browser.WebDriver.TakeScreenshot().SaveAsFile($@"{AppDomain.CurrentDomain.BaseDirectory}{TestContext.CurrentContext.Test.Name}.jpg");
            }
            Browser.Close();
        }


        public static void BrowserInit(string browserName)
        {
            Browser.Init(browserName);
            //Browser.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(settings.ImplicitTimeout);
            Browser.Goto(settings.BaseURL);
        }
    }
}