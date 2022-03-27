using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.Registration

{
    class RegistrationPositive: BaseTest
    {
        string url = FrameworkConstants.GetUrl();


        [Test, Category("Registration"), Category("Functionality")]
        public void PersonRegistration()
        {
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var registrationPage = new RegistrationPage(_driver);
            registrationPage.AcceptCookies();
            Assert.AreEqual("Creeaza Cont", registrationPage.CheckRegistrationPage());
            var password = MyUtils.GenerateRandomStringCount(10);
            var i = new Random();
            var errors = registrationPage.PersonRegistration(MyUtils.GenerateRandomStringCount(5) + "@yahoo.com", password, password, MyUtils.GenerateRandomStringCount(5), MyUtils.GenerateRandomStringOfNumbersCount(10), i.Next(7) + 1, i.Next(3), MyUtils.GenerateRandomStringCount(9), true);
            Assert.AreEqual("Felicitari", errors);
        }

           [Test,Category("Registration"), Category("Functionality")]
        public void Companyregistration()
        {
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var registrationPage = new RegistrationPage(_driver);
            registrationPage.AcceptCookies();
            Assert.AreEqual("Creeaza Cont", registrationPage.CheckRegistrationPage());
            var password = MyUtils.GenerateRandomStringCount(10);
            var i = new Random();
            var errors = registrationPage.CompanyRegistration(MyUtils.GenerateRandomStringCount(5) + "@yahoo.com", password, password, MyUtils.GenerateRandomStringCount(5), MyUtils.GenerateRandomStringOfNumbersCount(7), MyUtils.GenerateRandomStringOfNumbersCount(10), i.Next(7) + 1, i.Next(3), MyUtils.GenerateRandomStringCount(9), MyUtils.GenerateRandomStringCount(9), MyUtils.GenerateRandomStringOfNumbersCount(10), i.Next(7) + 1, i.Next(3),MyUtils.GenerateRandomStringCount(5),true);
            Assert.AreEqual("Felicitari", errors);
        }
    }
}

