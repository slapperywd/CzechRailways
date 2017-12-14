using System;
using System.Configuration;
using System.IO;
using System.Linq;
using CZProjectFramework.Extensions;
using CZProjectFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CZProjectFramework.Pages
{
    public class NadaPage
    {
        [FindsBy(How = How.XPath, Using = "//span[.='Add More']")] private IWebElement addMoreButton;

        [FindsBy(How = How.XPath, Using = "//button[.='Add']")] private IWebElement addNewMailButton;

        [FindsBy(How = How.XPath, Using = "//li[1]/a/span[2]/span")] private IWebElement firstMail;

        [FindsBy(How = How.Id, Using = "idIframe")] private IWebElement iFrame;

        [FindsBy(How = How.XPath, Using = "html/body/span[1]")] private IWebElement linkToActivate;

        [FindsBy(How = How.XPath, Using = "//span[contains(., 'info@cd.cz')]")] private IWebElement mailFromCd;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='me']")] private IWebElement newMailName;

        [FindsBy(How = How.XPath, Using = "//li[2]/a/span[2]/span")] private IWebElement secondMail;

        [FindsBy(How = How.Id, Using = "soflow")] private IWebElement mailDomain;

        

        public NadaPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }

        public string CheckMail(string mail, string domain)
        {
            JsUtils js = new JsUtils();
            addMoreButton.Click();
            newMailName.SendKeys(mail);
            SelectElement selectDomain = new SelectElement(mailDomain);
            selectDomain.SelectByText(domain);
            addNewMailButton.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(mailFromCd));
            js.ClickJs(mailFromCd);
            Browser.SwitchToFrame(iFrame);
            Wait.Until(ExpectedConditions.ElementToBeClickable(linkToActivate));
            return linkToActivate.Text;
        }
    }
}