using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CZProjectFramework.Utils
{
    public class JsUtils
    {
        private static IJavaScriptExecutor js;

        public JsUtils()
        {
            js = Browser.WebDriver as IJavaScriptExecutor;
        }

        public void ClickJs(IWebElement element)
        {
            js.ExecuteScript("arguments[0].click()", element);
        }
    }
}
