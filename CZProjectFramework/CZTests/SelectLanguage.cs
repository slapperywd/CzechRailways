using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZProjectFramework.Pages;
using NUnit.Framework;

namespace CZTests
{
    [TestFixture]
    [Parallelizable
        (ParallelScope.Children)
        ]
    class TestClass : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BaseTest), nameof(BrowserToRunWith))]
        public void VerifySettingEnglishLanguage(string browserName)
        {
            SetUp(browserName);
            Assert.IsTrue(Page.Home.VerifyHomePageLoad());
            Assert.IsTrue(Page.Home.VerifySettingEnglishLanguage());
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), nameof(BrowserToRunWith))]
        public void VerifySettingDeutchLanguage(string browserName)
        {
            SetUp(browserName);
            Assert.IsTrue(Page.Home.VerifyHomePageLoad());
            Assert.IsTrue(Page.Home.VerifySettingDeutchLanguage());
        }


    }
}
