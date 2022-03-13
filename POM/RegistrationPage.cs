using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.POM
{
    class RegistrationPage : BasePage
    {

        const string acceptcookiesSelector = "//*[@id='ctl00_divBody']/div[1]/div/a[1]";//xpath
        const string registrationPageTextSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1 > tbody > tr:nth-child(1) > td > table > tbody > tr > td > h2"; // css
        const string emailInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_UserName";//id
        const string emailErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_UserNameRequired";//id
        const string passwordInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_Password";//id
        const string passwordErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_PasswordRequired";//id
        const string confirmPasswordInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_ConfirmPassword";//id
        const string confirmPasswordErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_ConfirmPasswordRequired";//id
        const string personCheckSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_UpdatePanel1 > table:nth-child(1) > tbody > tr > td:nth-child(1) > label";//css
        const string companyCheckSelector = "//*[@id='ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_UpdatePanel1']/table[1]/tbody/tr/td[3]/label";//xpath
        const string nameInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_TextBoxFirstName";//id
        const string nameErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator1";//id
        const string phoneInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_TextBoxPhone";//id
        const string phoneErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator3";//id
        const string countyDropdownSelector = "dropdownCounty";//id
        const string countyErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator12";//id
        const string localityDropdownSelector = "dropdownLocality";//id
        const string localityErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator13";//id
        const string streetInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_TextBoxStreet";
        const string streetErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator4";//id
        const string companyNameInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_TextBoxCompanyName";//id
        const string companyNameErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator16";//id
        const string companyCuiInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_TextBoxCUI";//id
        const string companyCuiErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator15";//id
        const string companyRegistrationCodeInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_TextBoxRegCode";//id
        const string companyRegistrationCodeErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator14";//id
        const string companyCountyDropdownSelector = "dropdownCounty";//id
        const string companyCountyErroSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator5";//id
        const string companyLocalityDropdownSelector = "dropdownCompanyLocality";//id
        const string companyLocalityErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator6";//id
        const string companyStreetInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_TextBoxCompanyStreet";//id
        const string companyStreetErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator10";
        const string acceptTermsCheckboxSelector = "//*[@id='ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_UpdatePanel1']/table[3]/tbody/tr[2]/td[3]/label";//xpath
        const string acceptTermsErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_LiteralErrorTermsAndConditions";//css
        const string newsletterCheckboxSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_trNewsletter > td:nth-child(3) > label";//css
        const string submitRegistrationSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1___CustomNav0_StepNextButtonButton";//id

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }
        public void AcceptCookies()
        {
            var acceptButton = MyUtils.WaitForElement(driver, 5, By.XPath(acceptcookiesSelector));
            acceptButton.Click();
        }
        public string CheckRegistrationPage()
        {
            var authPageEl = driver.FindElement(By.CssSelector(registrationPageTextSelector));
            return authPageEl.Text;
        }

        public Dictionary<string, string> PersonRegistration(string email, string password, string confirmPassword, string name, string phone, int countyOptionIndex, int localityOptionIndex, string street, bool acceptTerms)
        {
            var errorsDictionary = new Dictionary<string, string>();
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            var confirmPasswordInput = driver.FindElement(By.Id(confirmPasswordInputSelector));
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            var countyInput = driver.FindElement(By.Id(countyDropdownSelector));
            var localityInput = driver.FindElement(By.Id(localityDropdownSelector));
            var streetInput= driver.FindElement(By.Id(streetInputSelector));
            var submitRegistration = driver.FindElement(By.Id(submitRegistrationSelector));
            var emailError = driver.FindElement(By.Id(emailErrorSelector));
            var passwordError = driver.FindElement(By.Id(passwordErrorSelector));
            var confirmPasswordError = driver.FindElement(By.Id(confirmPasswordErrorSelector));
            var nameError = driver.FindElement(By.Id(nameErrorSelector));
            var phoneError = driver.FindElement(By.Id(phoneErrorSelector));
            var countyError = driver.FindElement(By.Id(countyErrorSelector));
            var localityError = driver.FindElement(By.Id(localityErrorSelector));
            var streetError = driver.FindElement(By.Id(streetErrorSelector));
           
            emailInput.Clear();
            emailInput.SendKeys(email);
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            confirmPasswordInput.Clear();
            confirmPasswordInput.SendKeys(confirmPassword);
            nameInput.Clear();
            nameInput.SendKeys(name);
            phoneInput.Clear();
            phoneInput.SendKeys(phone);
            if (countyOptionIndex>0)
            {
                countyInput.Click();
                var countyOptions = countyInput.FindElements(By.ClassName("item"));
                countyOptions[countyOptionIndex].Click();

            }
            if (localityOptionIndex > 0)
            {
                localityInput.Click();
                var localityOptions = localityInput.FindElements(By.ClassName("item"));
                localityOptions[localityOptionIndex].Click();

            }
            streetInput.Clear();
            streetInput.SendKeys(street);
            if (acceptTerms)
            {
                var acceptTermsInput = MyUtils.WaitForElement(driver, 5,(By.XPath(acceptTermsCheckboxSelector)));
                acceptTermsInput.Click();
                errorsDictionary.Add("acceptTermsError","");

            }
            else
            {
                var acceptTermsError = driver.FindElement(By.CssSelector(acceptTermsErrorSelector));
                errorsDictionary.Add("acceptTermsError", acceptTermsError.Text);
            }
            submitRegistration.Submit();

            errorsDictionary.Add("emailError", emailError.Text);
            errorsDictionary.Add("passwordError", passwordError.Text);
            errorsDictionary.Add("confirmPasswordError", confirmPasswordError.Text);
            errorsDictionary.Add("nameError", nameError.Text);
            errorsDictionary.Add("phoneError", phoneError.Text);
            errorsDictionary.Add("countyError", countyError.Text);
            errorsDictionary.Add("localityError", localityError.Text);
            errorsDictionary.Add("streetError", streetError.Text);
            return errorsDictionary;
        }

        public Dictionary<string, string> CompanyRegistration(string email, string password, string confirmPassword, string companyName, string companyCui, string companyRegistrationCode, int companyCountyOptionIndex, int companyLocalityOptionsIndex, string companyStreet, string name, string phone, int countyOptionIndex, int localityOptionIndex, string street, bool acceptTerms)
        {
            var errorsDictionary = new Dictionary<string, string>();
            var companyCheckboxInput = driver.FindElement(By.XPath(companyCheckSelector));
            companyCheckboxInput.Click();

            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            var confirmPasswordInput = driver.FindElement(By.Id(confirmPasswordInputSelector));
            var companyNameInput = MyUtils.WaitForElement(driver, 5,By.Id(companyNameInputSelector));
            var companyCuiInput= driver.FindElement(By.Id(companyCuiInputSelector));
            var companyRegistrationCodeInput = driver.FindElement(By.Id(companyRegistrationCodeInputSelector));
            var companyCountyInput = driver.FindElement(By.Id(companyCountyDropdownSelector));
            var companyLocalityInput = driver.FindElement(By.Id(companyLocalityDropdownSelector));
            var companyStreetInput = driver.FindElement(By.Id(companyStreetInputSelector));
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            var countyInput = driver.FindElement(By.Id(countyDropdownSelector));
            var localityInput = driver.FindElement(By.Id(localityDropdownSelector));
            var streetInput = driver.FindElement(By.Id(streetInputSelector));
            var submitRegistration = driver.FindElement(By.Id(submitRegistrationSelector));
           
            var emailError = driver.FindElement(By.Id(emailErrorSelector));
            var passwordError = driver.FindElement(By.Id(passwordErrorSelector));
            var confirmPasswordError = driver.FindElement(By.Id(confirmPasswordErrorSelector));
            var companyNameError = driver.FindElement(By.Id(companyNameErrorSelector));
            var companyCuiError = driver.FindElement(By.Id(companyCuiErrorSelector));
            var companyRegistrationCodeError = driver.FindElement(By.Id(companyRegistrationCodeErrorSelector));
            var companyCountyError = driver.FindElement(By.Id(companyCountyErroSelector));
            var companyLocalityError = driver.FindElement(By.Id(companyLocalityErrorSelector));
            var companyStreetError = driver.FindElement(By.Id(companyStreetErrorSelector));
            var nameError = driver.FindElement(By.Id(nameErrorSelector));
            var phoneError = driver.FindElement(By.Id(phoneErrorSelector));
            var countyError = driver.FindElement(By.Id(countyErrorSelector));
            var localityError = driver.FindElement(By.Id(localityErrorSelector));
            var streetError = driver.FindElement(By.Id(streetErrorSelector));

            emailInput.Clear();
            emailInput.SendKeys(email);
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            confirmPasswordInput.Clear();
            confirmPasswordInput.SendKeys(confirmPassword);
            companyNameInput.Clear();
            companyNameInput.SendKeys(companyName);
            companyCuiInput.Clear();
            companyCuiInput.SendKeys(companyCui);
            companyRegistrationCodeInput.Clear();
            companyRegistrationCodeInput.SendKeys(companyRegistrationCode);
            if(companyCountyOptionIndex > 0)
            {
                companyCountyInput.Click();
                var companyCountyOptions = companyCountyInput.FindElements(By.ClassName("item"));
                companyCountyOptions[companyCountyOptionIndex].Click();

            }
            if (companyLocalityOptionsIndex > 0)
            {
                companyLocalityInput.Click();
                var companyLocalityOptions = companyLocalityInput.FindElements(By.ClassName("item"));
                companyLocalityOptions[companyLocalityOptionsIndex].Click();

            }
            companyStreetInput.Clear();
            companyStreetInput.SendKeys(companyStreet);
            nameInput.Clear();
            nameInput.SendKeys(name);
            phoneInput.Clear();
            phoneInput.SendKeys(phone);
            if (countyOptionIndex > 0)
            {
                countyInput.Click();
                var countyOptions = countyInput.FindElements(By.ClassName("item"));
                countyOptions[countyOptionIndex].Click();

            }
            if (localityOptionIndex > 0)
            {
                localityInput.Click();
                var localityOptions = localityInput.FindElements(By.ClassName("item"));
                localityOptions[localityOptionIndex].Click();

            }
            streetInput.Clear();
            streetInput.SendKeys(street);
            if (acceptTerms)
            {
                var acceptTermsInput = MyUtils.WaitForElement(driver, 5, (By.XPath(acceptTermsCheckboxSelector)));
                acceptTermsInput.Click();
                errorsDictionary.Add("acceptTermsError", "");

            }
            else
            {
                var acceptTermsError = driver.FindElement(By.CssSelector(acceptTermsErrorSelector));
                errorsDictionary.Add("acceptTermsError", acceptTermsError.Text);
            }

            submitRegistration.Submit();

            errorsDictionary.Add("emailError", emailError.Text);
            errorsDictionary.Add("passwordError", passwordError.Text);
            errorsDictionary.Add("confirmPasswordError", confirmPasswordError.Text);
            errorsDictionary.Add("companyNameError", companyNameError.Text);
            errorsDictionary.Add("companyCuiError", companyCuiError.Text);
            errorsDictionary.Add("companyRegistrationCodeError", companyRegistrationCodeError.Text);
            errorsDictionary.Add("companyCountyError", companyCountyError.Text);
            errorsDictionary.Add("companyLocalityError", companyLocalityError.Text);
            errorsDictionary.Add("companyStreetError", companyStreetError.Text);
            errorsDictionary.Add("nameError", nameError.Text);
            errorsDictionary.Add("phoneError", phoneError.Text);
            errorsDictionary.Add("countyError", countyError.Text);
            errorsDictionary.Add("localityError", localityError.Text);
            errorsDictionary.Add("streetError", streetError.Text);
          return errorsDictionary;
        }
    }
}
