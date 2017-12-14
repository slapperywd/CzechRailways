using System.Collections.Generic;
using System.Linq;
using CZProjectFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class SelectTicketPage
    {
        [FindsBy(How = How.CssSelector, Using = ".dropdown-toggle.is-btn.is-btn-white.is-btn-xs")]
        private IWebElement buttonModify;

        [FindsBy(How = How.LinkText, Using = "Details")] private IWebElement details;

        [FindsBy(How = How.LinkText, Using = "Go back one step")] private IWebElement goBackOneStep;

        [FindsBy(How = How.XPath, Using = "//p[@class=\'age\']")] private IWebElement passenger;


        [FindsBy(How = How.CssSelector, Using = ".buybut")] private IList<IWebElement> priceLabels;


        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[2]/div/div[1]/div/ul/li[1]/a/span")]
        private IWebElement selectJourneysAndPassangers;

        [FindsBy(How = How.XPath, Using = "//span[@class=\'train-icons\']/span")] private IList<IWebElement> services;

        [FindsBy(How = How.XPath, Using = "//a[@class=\'buybut green\']")] private IWebElement ticketPrice;

        [FindsBy(How = How.CssSelector, Using = "span.transfer")] private IWebElement transferVia;


        public List<int> GetPrices()
        {
            Wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@class=\'buybut green\']")));
            return priceLabels.Select(x => x.GetAttribute("title").ConvertToIntFormat()).ToList();
        }


        public void GoToConnectionAndTickets()
        {
            buttonModify.Click();
            selectJourneysAndPassangers.Click();
        }

        public bool VerifyPriceChangingAsterAddingSecondDefaultePassenger(List<int> priceBeforeAdding,
            List<int> priceAfterAdding)
        {
            // 0.876 is special coefficient when ticket type is RESTRICTIONS ON THE ROUTE
            for (var i = 0; i < priceBeforeAdding.Count; i++)
                if (priceBeforeAdding[i] * 2 == priceAfterAdding[i] ||
                    (int) (priceBeforeAdding[i] * 2 * 0.876) == priceAfterAdding[i])
                    continue;
                else
                    return false;
            return true;
        }

        public bool VerifyPriceChangedX2AndDiscont25Percent(List<int> priceBeforeAdding, List<int> priceAfterAdding)
        {
            for (var i = 0; i < priceBeforeAdding.Count; i++)
                if (priceBeforeAdding[i] * 2 == (int) (priceAfterAdding[i] * 1.224) ||
                    priceBeforeAdding[i] * 2 == (int) (priceAfterAdding[i] * 1.333))
                    continue;
                else
                    return false;
            return true;
        }
    }
}