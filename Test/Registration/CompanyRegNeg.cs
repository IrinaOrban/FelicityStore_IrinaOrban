using FelicityStore_IrinaOrban.POM;
using FelicityStore_IrinaOrban.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Test.Registration
{
    class CompanyRegNeg: BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        
        private static IEnumerable<TestCaseData> GetCompanyRegistrationDataCsv()
        {
            var csvData = MyUtils.GetDataTableFromCsv("TestData\\CompanyRegistrationData.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }

        [Test, Category("Registration"), Category("Negative"),TestCaseSource("GetCompanyRegistrationDataCsv")]
        public void CompanyRegistrationNeg(string email, string emailErr, string password, string passwordErr, string confirmPassword, string confirmPasswordErr, string companyName, string companyNameErr, string companyCui, string companyCuiErr, string companyRegistrationCode,string companyRegistrationCodeErr,string companyCountyOptionIndex,  string companyCountyErr, string companyLocalityOptionsIndex, string companyLocalityErr, string companyStreet,string companyStreetErr, string name, string nameErr, string phone, string phoneErr, string countyOptionIndex, string countyErr, string localityOptionIndex, string localityErr, string street, string streetErr, string acceptTerms, string acceptTermsErr)
        {
            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            String contextName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(contextName);
            var registrationPage = new RegistrationPage(_driver);
            registrationPage.AcceptCookies();
            Assert.AreEqual("Creeaza Cont", registrationPage.CheckRegistrationPage());
            var errors = registrationPage.CompanyRegistrationNeg(email, password, confirmPassword,companyName,companyCui,companyRegistrationCode,int.Parse(companyCountyOptionIndex),int.Parse(companyLocalityOptionsIndex),companyStreet, name, phone, int.Parse(countyOptionIndex), int.Parse(localityOptionIndex), street, bool.Parse(acceptTerms));
            Assert.AreEqual(emailErr, errors["emailError"]);
            Assert.AreEqual(passwordErr, errors["passwordError"]);
            Assert.AreEqual(confirmPasswordErr, errors["confirmPasswordError"]);
            Assert.AreEqual(companyNameErr, errors["companyNameError"]);
            Assert.AreEqual(companyCuiErr, errors["companyCuiError"]);
            Assert.AreEqual(companyRegistrationCodeErr, errors["companyRegistrationCodeError"]);
            Assert.AreEqual(companyCountyErr, errors["companyCountyError"]);
            Assert.AreEqual(companyLocalityErr, errors["companyLocalityError"]);
            Assert.AreEqual(companyStreetErr, errors["companyStreetError"]);
            Assert.AreEqual(nameErr, errors["nameError"]);
            Assert.AreEqual(phoneErr, errors["phoneError"]);
            Assert.AreEqual(countyErr, errors["countyError"]);
            Assert.AreEqual(localityErr, errors["localityError"]);
            Assert.AreEqual(streetErr, errors["streetError"]);
            Assert.AreEqual(acceptTermsErr, errors["acceptTermsError"]);
           
        }
    }
}

