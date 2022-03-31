using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.Wishlist

{
    class Wishlist:BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetUserDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\userCredential.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Test, Category("Wishlist"),Category("Functionality"), TestCaseSource("GetUserDataCsv")]
        public void WishlistHanling(string username, string password)
        {
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            _driver.Navigate().GoToUrl(url + productsUrlPath);
            var productsPage = new ProductsPage(_driver);
            productsPage.AcceptCookies();
            productsPage.ProductsPageUserLogin(username, password);
            var i = new Random().Next(5);
            Assert.AreEqual(i, productsPage.AddToWishlist(i));
            productsPage.GoToMyWishList();
            var wishlistPage = new MyWishlistPage(_driver);
            Assert.IsFalse(wishlistPage.HasDeletewhislistError());

        }

    }
}
