using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.Search
{
    class BasicSearch:BaseTest

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

        public void BasicPositiveSearch(string searchedText)
        {
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            _driver.Navigate().GoToUrl(url+searchProductsUrlPath);
            var searchResultPage = new SearchResultPage(_driver);
            searchResultPage.AcceptCookies();
            Assert.AreEqual("Rezultate cautare:", searchResultPage.CheckSearchPage());
            searchResultPage.SubmitSearchText(searchedText);
            Assert.IsFalse(searchResultPage.HasSearchErrors());
        }

        [Test, Category("Functionality"), Order(3)]

        public void BasicNegativeSearch()
        {
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            _driver.Navigate().GoToUrl(url + searchProductsUrlPath);
            var searchResultPage = new SearchResultPage(_driver);
            searchResultPage.AcceptCookies();
            Assert.AreEqual("Rezultate cautare:", searchResultPage.CheckSearchPage());
            searchResultPage.SubmitSearchText(MyUtils.GenerateRandomStringCount(10));
            Assert.IsTrue(searchResultPage.HasSearchErrors());
        }
    }
}
