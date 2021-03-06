using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.Shopping
{
    class Shopping:BaseTest
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

        [Test, Category("Shopping"),Category("Functionality"), Category("Smoke"),TestCaseSource("GetUserDataCsv")]
        public void UserShopping(string username, string password)
        {
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            _driver.Navigate().GoToUrl(url + productsUrlPath);
            var productsPage = new ProductsPage(_driver);
            productsPage.AcceptCookies();
            productsPage.ProductsPageUserLogin(username, password);
            var i = new Random().Next(5);
            Assert.AreEqual(2,productsPage.AddToBasket(2));
            productsPage.GoToMyBasket();
            var basketPage = new MyBasketPage(_driver);
            Assert.AreEqual(basketPage.NumberOfProductsInBasket()+1, basketPage.IncreaseProductsToBasket());
            Assert.IsTrue(basketPage.HasDeleteProductsErrors());
            Assert.AreEqual("Selectati metoda de plata!", basketPage.CheckOutNegative());
            var myAccount = new MyAccountPage(_driver);
            myAccount.Logout();
        }

    }
}
