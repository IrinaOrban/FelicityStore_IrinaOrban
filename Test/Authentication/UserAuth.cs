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
    class UserAuth: BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetUserDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\UserCredential.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }
        [Test, Category("AuthTest"), Category("Functionality"), Category("Smoke"),TestCaseSource("GetUserDataCsv"), Order(1)]
        public void UserLoginLogoutBack(string username, string password)
        {
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            _driver.Navigate().GoToUrl(url + loginUrlPath);
           var loginPage = new LoginPage(_driver);
           Assert.AreEqual("Sunt deja client", loginPage.CheckAuthPage());
           loginPage.AcceptCookies();
           loginPage.UserLogin(username, password);
           var userPage = new MyAccountPage(_driver);
           Assert.AreEqual(username, userPage.CheckAccount());
           userPage.Logout();
           Assert.AreEqual("Sunt deja client", loginPage.CheckAuthPage());
            _driver.Navigate().Back();
            Assert.AreEqual("Sunt deja client", loginPage.CheckAuthPage());
        }
        [Test, Category("AuthTest"), Category("Functionality"), Category("Smoke"), TestCaseSource("GetUserDataCsv"), Order(2)]
        public void ModalUserLoginLogoutBack(string username, string password)
        {
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            _driver.Navigate().GoToUrl(url);
            var landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            landingPage.LandingPageUserLogin(username, password);
            var userPage = new MyAccountPage(_driver);
            Assert.AreEqual(username, userPage.CheckAccount());
            userPage.Logout();
            Assert.AreEqual("Autentificare | Login", landingPage.CheckAccount());
            _driver.Navigate().Back();
            Assert.AreEqual("Autentificare | Login", landingPage.CheckAccount());

        }
    }
}
