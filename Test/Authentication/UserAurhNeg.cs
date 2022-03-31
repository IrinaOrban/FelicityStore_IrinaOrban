using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using FelicityStore_IrinaOrban.Test;

namespace FelicityStore_IrinaOrban.Test.Authentication
{
    class UserAuthNeg: BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetUserNegDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\UserCredentialNegative.csv");
            for (int i = 0; i <csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Test, Category("AuthTest"), Category("Negative"),Category("Functionality"),TestCaseSource("GetUserNegDataCsv"), Order(3)]
        public void UserLoginNegative(string username, string password, string usernameError, string passwordError, string loginError)
        {
            _driver.Navigate().GoToUrl(url + loginUrlPath);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var loginPage = new LoginPage(_driver);
            loginPage.AcceptCookies();
            Assert.AreEqual("Sunt deja client", loginPage.CheckAuthPage());
            var errors = loginPage.Login(username, password);
            Assert.AreEqual(usernameError, errors["usernameError"]);
            Assert.AreEqual(passwordError, errors["passwordError"]);
            Assert.AreEqual(loginError, errors["loginError"]);

        }
        private static IEnumerable<TestCaseData> GetModalNegUserDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\UserCredentialNegativeModal.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }
        [Test, Category("AuthTest"), Category("Negative"),Category("Functionality"), TestCaseSource("GetModalNegUserDataCsv"),Order(4)]
        public void ModalUserLoginNegative(string username, string password)
        {
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            _driver.Navigate().GoToUrl(url);
            var landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            var errors = landingPage.LandingPageLogin(username,password);
            Assert.AreEqual("Incercati din nou!", errors);
        }
    }
}
