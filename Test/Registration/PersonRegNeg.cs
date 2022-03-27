using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.Registration

{
    class PersonRegNeg: BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetPersonRegistrationDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\PersonRegistrationData.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Test,Category("Registration"), Category("Negative"), TestCaseSource("GetPersonRegistrationDataCsv")]
        public void PersonRegistrationNeg(string email, string emailErr, string password, string passwordErr, string confirmPassword, string confirmPasswordErr, string name, string nameErr, string phone, string phoneErr, string countyOptionIndex, string countyErr, string localityOptionIndex, string localityErr, string street, string streetErr,  string acceptTerms, string acceptTermsErr)
        {
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var registrationPage = new RegistrationPage(_driver);
            registrationPage.AcceptCookies();
            Assert.AreEqual("Creeaza Cont", registrationPage.CheckRegistrationPage());
            var errors = registrationPage.PersonRegistrationNeg(email, password, confirmPassword, name, phone, int.Parse(countyOptionIndex), int.Parse(localityOptionIndex), street,bool.Parse(acceptTerms));
            Assert.AreEqual(emailErr, errors["emailError"]);
            Assert.AreEqual(passwordErr, errors["passwordError"]);
            Assert.AreEqual(confirmPasswordErr, errors["confirmPasswordError"]);
            Assert.AreEqual(nameErr, errors["nameError"]);
            Assert.AreEqual(phoneErr, errors["phoneError"]);
            Assert.AreEqual(countyErr, errors["countyError"]);
            Assert.AreEqual(localityErr, errors["localityError"]);
            Assert.AreEqual(streetErr, errors["streetError"]);
            Assert.AreEqual(acceptTermsErr, errors["acceptTermsError"]);
            
        }
       


    }
}

