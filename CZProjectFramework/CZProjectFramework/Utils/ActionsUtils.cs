using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CZProjectFramework.Utils
{
    public static class ActionsUtils
    {
        private static Actions actions;
        private static IJavaScriptExecutor js;
        static ActionsUtils()
        {
            actions = new Actions(Browser.WebDriver);
            js = Browser.WebDriver as IJavaScriptExecutor;
        }

        public static void MoveToElement(this IWebElement element)
        {
            actions.MoveToElement(element).Perform();
        }

        public static void MoveToElementJS(this IWebElement element)
        {
            js.ExecuteScript("arguments[0].scrollIntoView()", element);
        }

        public static void ClickElementJS(this IWebElement element)
        {
            js.ExecuteScript("arguments[0].click();", element);
        }
    }
}
