using System;
using System.IO;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework
{
    public class Browser
    {
        [ThreadStatic] private static IWebDriver webDriver;

        public static IWebDriver WebDriver => webDriver;

        public static void Init(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "IE":
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    ieOptions.EnsureCleanSession = true;
                    webDriver = new InternetExplorerDriver(ieOptions);
                    break;
                case "Firefox":
                    //set firefox profile to be able to perform TrainTimetableTests.cs SaveTimeTableInPDFformat test
                    //in order to prevent download popup appearance
                    var pathToProfile = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    var fp = new FirefoxProfile($@"{pathToProfile}\FirefoxProfile\mpeoqubn.default-1511355350572\");
                    webDriver = new FirefoxDriver(fp);
                    break;
                case "EDGE":
                    webDriver = new EdgeDriver($"{AppDomain.CurrentDomain.BaseDirectory}");
                    break;
                default: throw new Exception("Unknown Browser!");
            }
            webDriver.Manage().Window.Maximize();
        }

        public static void Goto(string url)
        {
            webDriver.Url = url;
        }

        public static void Close()
        {
            webDriver.Close();
            webDriver.Quit();
        }

        public static IWebDriver SwitchToFrame(IWebElement element)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return webDriver.SwitchTo().Frame(element);
        }
    }
}