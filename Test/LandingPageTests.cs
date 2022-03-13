using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using FelicityStore_IrinaOrban.POM;

namespace FelicityStore_IrinaOrban.Test
{
    class LandingPageTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test, Category("StaticLinksNavigation"), Order(1)]
        public void LandingPage1()
        {
            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            Assert.IsFalse(landingPage.CheckHeaderLinks());
           
        }

        [Test, Category("StaticLinksNavigation"), Order(2)]
        public void LandingPage2()
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

        [Test, TestCaseSource("GetDynamicLinksDataCSV"), Category("DynamicLinks"), Order(3)]
        public void LandingPage3(string linkName)
        {
            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            LandingPage landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            Assert.IsFalse(landingPage.CheckDynamicLinks(linkName));
            

        }

        [Test, Category("DynamicLinks"), Order(3)]
        public void LandingPageCarusel()
        {
            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            LandingPage landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            Assert.IsFalse(landingPage.CheckCaruselBijuteriiRecomandate());
            

        }
    }
}
