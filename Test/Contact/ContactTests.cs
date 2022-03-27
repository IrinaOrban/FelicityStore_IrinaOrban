using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.Contact
{
    class ContactTests:BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        private static IEnumerable<TestCaseData> GetContactDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\ContactData.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Test, Category("Contact"), TestCaseSource("GetContactDataCsv")]

        public void Contact(string name, string nameErr,string email, string emailErr, string phone, string phoneErr, string message, string messageErr)
        {
            _driver.Navigate().GoToUrl(url + contactUrlPath);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var contactPage = new ContactPage(_driver);
            contactPage.AcceptCookies();
            Assert.AreEqual("Contact", contactPage.CheckAuthPage());
            var errors = contactPage.ContactForm(name,email,phone,message);
            Assert.AreEqual(nameErr, errors["nameError"]);
            Assert.AreEqual(emailErr, errors["emailError"]);
            Assert.AreEqual(phoneErr, errors["phoneError"]);
            Assert.AreEqual(messageErr, errors["messageError"]);
            

        }
    }
}
