using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.ReturnProduct
{
    class ReturnProducts:BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetReturnProductsDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\ReturnProductsData.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Test, Category("ReturnProducts"), TestCaseSource("GetReturnProductsDataCsv")]
        public void ReturnProductsNeg(string orderNumber, string orderNumberErr, string hasOrderNumberValidationErr, string name, string nameErr, string returnTypeOptionIndex, string returnTypeErr, string productCode, string productCodeErr, string adress, string adressErr, string phone, string phoneErr, string email, string emailErr, string message, string messageErr)
        {
            _driver.Navigate().GoToUrl(url + returnProductsUrlPath);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var returnProductPage = new ReturnProductsPage(_driver);
            returnProductPage.AcceptCookies();
            Assert.AreEqual("Politica de retur Felicity Store", returnProductPage.CheckReturnProductsPage());
            var errors = returnProductPage.ReturnProducts(orderNumber,bool.Parse(hasOrderNumberValidationErr), name, int.Parse(returnTypeOptionIndex), productCode, adress, phone, email, message);
            Assert.AreEqual(orderNumberErr, errors["orderError"]);
            Assert.AreEqual(nameErr, errors["nameError"]);
            Assert.AreEqual(returnTypeErr, errors["returnTypeError"]);
            Assert.AreEqual(productCodeErr,errors["productError"]);
            Assert.AreEqual(adressErr, errors["adressError"]);
            Assert.AreEqual(phoneErr, errors["phoneError"]);
            Assert.AreEqual(emailErr, errors["emailError"]);
            Assert.AreEqual(messageErr, errors["messageError"]);
            
        }
    }
}
