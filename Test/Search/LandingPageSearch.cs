using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.Search
{
    class LandingPageSearch:BaseTest

    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetSearchData()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\SearchData.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Test, TestCaseSource("GetSearchData"), Category("Functionality"), Order(3)]

        public void MainSearch(string searchedText)
        {
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            _driver.Navigate().GoToUrl(url);
            var landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            landingPage.SubmitSearchText(searchedText);
            var searchPage = new SearchResultPage(_driver);
           Assert.AreEqual("Rezultate cautare:", searchPage.CheckSearchPage());
            Assert.IsFalse(searchPage.HasSearchErrors());
        }

    }
}
