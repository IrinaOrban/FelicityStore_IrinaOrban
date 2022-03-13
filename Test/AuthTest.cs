using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using FelicityStore_IrinaOrban.Test;

namespace FelicityStore_IrinaOrban.Test
{
    class AuthTest: BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\LoginCredentials.csv");
            for (int i = 0; i <csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Test, Category("AuthTest"), TestCaseSource("GetCredentialsDataCsv")]
        public void BasicAuth(string username, string password, string usernameError, string passwordError, string loginError)
        {
            _driver.Navigate().GoToUrl(url + "/login");
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.AcceptCookies();
            Assert.AreEqual("Sunt deja client", loginPage.CheckAuthPage());
            var errors = loginPage.Login(username, password);
            Assert.AreEqual(usernameError, errors["usernameError"]);
            Assert.AreEqual(passwordError, errors["passwordError"]);
            Assert.AreEqual(loginError, errors["loginError"]);
           

        }
        private static IEnumerable<TestCaseData> GetUserDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\userCredential.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }
        [Test, Category("AuthTest"), TestCaseSource("GetUserDataCsv")]
        public void UserAuth(string username, string password)
        {
            _driver.Navigate().GoToUrl(url + "/login");
            LoginPage lp = new LoginPage(_driver);
            Assert.AreEqual("Sunt deja client", lp.CheckAuthPage());
            var login = lp.UserLogin(username, password);
           Assert.AreEqual("https://www.felicitystore.ro/contul-meu?login=1", login);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);

        }
    }
}
