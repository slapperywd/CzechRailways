using System;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Extensions
{
    public static class WebElementExtension
    {
        public static bool Exists(this IWebElement element)
        {
            try
            {
                var text = element.Text;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}