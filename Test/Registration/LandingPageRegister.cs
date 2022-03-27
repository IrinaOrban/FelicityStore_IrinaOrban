using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.Registration
{
    class LandingPageRegister:BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test, Category("Functionality"), Order(1)]
        public void LandingRegister()
        {
            _driver.Navigate().GoToUrl(url);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var landingPage = new LandingPage(_driver);
            landingPage.AcceptCookies();
            landingPage.MoveToContactPage();
            var registrationPage = new RegistrationPage(_driver);
            Assert.AreEqual("Creeaza Cont", registrationPage.CheckRegistrationPage());
        }


    }
}
