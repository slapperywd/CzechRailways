using System;
using NUnit.Framework;
using CZProjectFramework;
using CZProjectFramework.Pages;
using CZProjectFramework.Utils;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.Extensions;
using Logger = CZProjectFramework.Utils.Logger;

namespace CZTests
{
    [TestFixture]
    public class BaseTest
    {
        protected HomePage HomePage => new HomePage();
        protected TestSettings settings;
        protected User user;

        [SetUp]
        public void SetUp()
        {
            settings = new TestSettings();
            BrowserInit(settings.BrowserName);
            user = XmlReader.Read<User>("UserData.xml");
            Logger.Info($"{TestContext.CurrentContext.Test.Name}" +
                        $"\r\nBrowser:{settings.BrowserName}" +
                        $"\r\nLanguage:{settings.Language}");
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                Logger.Info($"{AppDomain.CurrentDomain.BaseDirectory}{TestContext.CurrentContext.Test.Name}.jpg");
                Browser.WebDriver.TakeScreenshot().SaveAsFile($@"{AppDomain.CurrentDomain.BaseDirectory}{TestContext.CurrentContext.Test.Name}.jpg");
            }
            Browser.Close();
        }


        public void BrowserInit(string browserName)
        {
            Browser.Init(browserName);
            //Browser.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(settings.ImplicitTimeout);
            Browser.Goto(settings.BaseURL);
        }
    }
}