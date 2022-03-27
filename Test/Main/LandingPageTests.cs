using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using FelicityStore_IrinaOrban.POM;

namespace FelicityStore_IrinaOrban.Test.Main
{
    class LandingPageTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test, Category("Main"), Category("Functionality"), Order(1)]
        public void LandingPageHeadderLinks()
        {
            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            Assert.IsFalse(landingPage.CheckHeaderLinks());
           
        }
        [Test, Category("Main"), Category("Usability"), Order(2)]
        public void LandingPageFooterLinks()
        {
            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            LandingPage landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            Assert.IsFalse(landingPage.CheckFooterLinks());
        }
        private static IEnumerable<TestCaseData> GetDynamicLinksDataCSV()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\LandingPageDynamicLinksData.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Test, Category("Main"), Category("Usability"), TestCaseSource("GetDynamicLinksDataCSV"),  Order(3)]
        public void LandingPageProductsLinks(string linkName)
        {
            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            LandingPage landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            Assert.IsFalse(landingPage.CheckDynamicLinks(linkName));

        }

        [Test, Category("Main"),Category("Usability"), Order(4)]
        public void LandingPageCarusel()
        {
            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            LandingPage landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            Assert.IsFalse(landingPage.CheckCaruselBijuteriiRecomandate());
            

        }

        [Test, Category("Main"),Category("Usability"), Order(5)]
        public void LandingPageCaruselProducts()
        {
            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            LandingPage landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            var i = new Random();
            Assert.IsFalse(landingPage.CheckCaruselProductLinks(i.Next(6)));
            
        }
    }
}
