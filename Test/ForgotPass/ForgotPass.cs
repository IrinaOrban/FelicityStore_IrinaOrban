using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using FelicityStore_IrinaOrban.Test;

namespace FelicityStore_IrinaOrban.Test.ForgotPass

{
    class ForgotPass : BaseTest
    {

        string url = FrameworkConstants.GetUrl();


        [Test, Category("ForgotPass"),Category("Functionality"),Order(1)]
        public void UserPassRecovery()
        {
            _driver.Navigate().GoToUrl(url + forgotPasswordUrlPath);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var forgotPasswordPage = new ForgotPasswordPage(_driver);
            forgotPasswordPage.AcceptCookies();
            Assert.AreEqual("Ai uitat parola?", forgotPasswordPage.CheckFrogotPasswordPage());
            var hasRecoverPasswordErrors = forgotPasswordPage.HasUserRecoverPassworsErrors("test.elena@yahoo.com");
            Assert.IsFalse(hasRecoverPasswordErrors);
            if (!hasRecoverPasswordErrors)
            {
                var loginPage = new LoginPage(_driver);
                Assert.AreEqual("Sunt deja client", loginPage.CheckAuthPage());
            }
        }

        [Test, Category("ForgotPass"), Category("Negative"), Order(2)]

        public void ModalPassRecovery()
        {

            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            LandingPage landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            landingPage.MoveToForgotPassword();
            var forgotPasswordPage = new ForgotPasswordPage(_driver);
            Assert.AreEqual("Ai uitat parola?", forgotPasswordPage.CheckFrogotPasswordPage());
            
        }
        [Test, Category("ForgotPass"), Category("Negative"), Order(3)]
        public void NonUserPassRecovery()
        {
            _driver.Navigate().GoToUrl(url + forgotPasswordUrlPath);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var forgotPasswordPage = new ForgotPasswordPage(_driver);
            forgotPasswordPage.AcceptCookies();
            Assert.IsFalse(forgotPasswordPage.CheckForgotPassNonUser(MyUtils.GenerateRandomStringCount(10) + "@test.com"));

        }

      }
}
