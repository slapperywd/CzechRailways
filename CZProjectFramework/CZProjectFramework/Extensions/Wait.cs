using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Extensions
{
    public static class Wait
    {
        private static WebDriverWait wait;
        private const int defaultTimeout = 60;

        public static IWebElement Until(Func<IWebDriver, IWebElement> condition, int timeout = defaultTimeout)
        {
            wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(timeout));
            return wait.Until(condition);
        }

        public static bool Until(Func<IWebDriver, bool> condition, int timeout = defaultTimeout)
        {
            wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(timeout));
            return wait.Until(condition);
        }
    }
}
