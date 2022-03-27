using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FelicityStore_IrinaOrban.POM
{
    class RegistrationPage : BasePage
    {

        const string registrationPageTextSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1 > tbody > tr:nth-child(1) > td > table > tbody > tr > td > h2"; // css
        const string emailInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_UserName";//id
        const string requiredEmailErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_UserNameRequired";//id
        const string validEmailErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_valEmailPattern";//id
        const string passwordInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_Password";//id
        const string passwordErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_PasswordRequired";//id
        const string confirmPasswordInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_ConfirmPassword";//id
        const string requiredConfirmPasswordErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_ConfirmPasswordRequired";//id
        const string matchPasswordErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_PasswordCompare";//id
        const string personCheckSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_UpdatePanel1 > table:nth-child(1) > tbody > tr > td:nth-child(1) > label";//css
        const string companyCheckSelector = "//*[@id='ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_UpdatePanel1']/table[1]/tbody/tr/td[3]/label";//xpath
        const string nameInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_TextBoxFirstName";//id
        const string nameErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator1";//id
        const string phoneInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_TextBoxPhone";//id
        const string requiredPhoneErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator3";//id
        const string validPhoneErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RegularExpressionValidator1";//id
        const string countyDropdownSelector = "dropdownCounty";//id
        const string countyErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1_CreateUserStepContainer_RequiredFieldValidator12";//id
        const string localityDropdownSelector = "dropdownLocality";//id
        const string localityDataSelector = "ShippingLocalityIDDataList";//id
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
        const string accountCreatedConfirmationSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_RegisterForm1_CreateUserWizard1 > tbody > tr > td > table > tbody > tr > td > center > table > tbody > tr:nth-child(1) > td > h1";//css

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public string CheckRegistrationPage()
        {
            var authPageEl = driver.FindElement(By.CssSelector(registrationPageTextSelector));
            return authPageEl.Text;
        }

        public Dictionary<string, string> PersonRegistrationNeg(string email, string password, string confirmPassword, string name, string phone, int countyOptionIndex, int localityOptionIndex, string street, bool acceptTerms)
        {
            var errorsDictionary = new Dictionary<string, string>();
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            var confirmPasswordInput = driver.FindElement(By.Id(confirmPasswordInputSelector));
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            var countyInput = driver.FindElement(By.Id(countyDropdownSelector));
            var streetInput = driver.FindElement(By.Id(streetInputSelector));
            var submitRegistration = driver.FindElement(By.Id(submitRegistrationSelector));

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

            if (countyOptionIndex > 0)
            {
                countyInput.Click();
                var countyOptions = countyInput.FindElements(By.ClassName("item"));
                countyOptions[countyOptionIndex].Click();
            }
            if (localityOptionIndex > 0)
            {

                var firstLocalotyOption = MyUtils.WaitForElementClick(driver, 5, By.ClassName("item"));
                if (firstLocalotyOption != null)
                {

                    var localityInput = MyUtils.WaitForElementClick(driver, 10, By.Id(localityDropdownSelector));
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(localityInput).Click().Build().Perform();
                    var option = localityOptionIndex + 1;
                    var localityOption = MyUtils.WaitForElementClick(driver, 10, By.XPath("//*[@id='ShippingLocalityIDDataList']/div[" + option + "]"));
                    localityOption.Click();

                }
            }
            streetInput.Clear();
            streetInput.SendKeys(street);
            if (acceptTerms)
            {
                var acceptTermsInput = MyUtils.WaitForElementClick(driver, 5, (By.XPath(acceptTermsCheckboxSelector)));
                acceptTermsInput.Click();
                errorsDictionary.Add("acceptTermsError", "");

            }
            else
            {
                var acceptTermsError = driver.FindElement(By.CssSelector(acceptTermsErrorSelector));
                errorsDictionary.Add("acceptTermsError", acceptTermsError.Text);
            }
            submitRegistration.Submit();

            if (email == "")
            {
                var emailError = driver.FindElement(By.Id(requiredEmailErrorSelector));
                errorsDictionary.Add("emailError", emailError.Text);
            }
            else
            {
                var emailError = driver.FindElement(By.Id(validEmailErrorSelector));
                errorsDictionary.Add("emailError", emailError.Text);

            }
            var passwordError = driver.FindElement(By.Id(passwordErrorSelector));
            errorsDictionary.Add("passwordError", passwordError.Text);

            if (password == confirmPassword)
            {
                var confirmPasswordError = driver.FindElement(By.Id(requiredConfirmPasswordErrorSelector));
                errorsDictionary.Add("confirmPasswordError", confirmPasswordError.Text);
            }
            else
            {
                var confirmPasswordError = driver.FindElement(By.Id(matchPasswordErrorSelector));
                errorsDictionary.Add("confirmPasswordError", confirmPasswordError.Text);
            }
            var nameError = driver.FindElement(By.Id(nameErrorSelector));
            errorsDictionary.Add("nameError", nameError.Text);

            if (phone == "")
            {
                var phoneError = driver.FindElement(By.Id(requiredPhoneErrorSelector));
                errorsDictionary.Add("phoneError", phoneError.Text);
            }
            else
            {
                var phoneError = driver.FindElement(By.Id(validPhoneErrorSelector));
                errorsDictionary.Add("phoneError", phoneError.Text);
            }
            var countyError = driver.FindElement(By.Id(countyErrorSelector));
            errorsDictionary.Add("countyError", countyError.Text);

            var localityError = driver.FindElement(By.Id(localityErrorSelector));
            Console.WriteLine(localityError.GetCssValue("display"));
            errorsDictionary.Add("localityError", localityError.Text);

            var streetError = driver.FindElement(By.Id(streetErrorSelector));
            errorsDictionary.Add("streetError", streetError.Text);
            return errorsDictionary;
        }
        public string PersonRegistration(string email, string password, string confirmPassword, string name, string phone, int countyOptionIndex, int localityOptionIndex, string street, bool acceptTerms)
        {
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            var confirmPasswordInput = driver.FindElement(By.Id(confirmPasswordInputSelector));
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            var countyInput = driver.FindElement(By.Id(countyDropdownSelector));
            var streetInput = driver.FindElement(By.Id(streetInputSelector));
            var submitRegistration = driver.FindElement(By.Id(submitRegistrationSelector));
            var acceptTermsInput = MyUtils.WaitForElementClick(driver, 5, (By.XPath(acceptTermsCheckboxSelector)));

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
            countyInput.Click();
            var countyOptions = countyInput.FindElements(By.ClassName("item"));
            countyOptions[countyOptionIndex].Click();
            var firstLocalotyOption = MyUtils.WaitForElementClick(driver, 5, By.ClassName("item"));
            if (firstLocalotyOption != null)
            {
                var localityInput = MyUtils.WaitForElementClick(driver, 10, By.Id(localityDropdownSelector));
                Actions actions = new Actions(driver);
                actions.MoveToElement(localityInput).Click().Build().Perform();
                var option = localityOptionIndex + 1;
                var localityOption = MyUtils.WaitForElementClick(driver, 10, By.XPath("//*[@id='ShippingLocalityIDDataList']/div[" + option + "]"));
                localityOption.Click();
            }

            streetInput.Clear();
            streetInput.SendKeys(street);
            acceptTermsInput.Click();
            submitRegistration.Submit();
            var accountCreatedConfirmation = driver.FindElement(By.CssSelector(accountCreatedConfirmationSelector));
            return accountCreatedConfirmation.Text;
        }
        public Dictionary<string, string> CompanyRegistrationNeg(string email, string password, string confirmPassword, string companyName, string companyCui, string companyRegistrationCode, int companyCountyOptionIndex, int companyLocalityOptionsIndex, string companyStreet, string name, string phone, int countyOptionIndex, int localityOptionIndex, string street, bool acceptTerms)
        {
            var errorsDictionary = new Dictionary<string, string>();
            var companyCheckboxInput = driver.FindElement(By.XPath(companyCheckSelector));
            companyCheckboxInput.Click();

            var hasServerErr = false;
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            var confirmPasswordInput = driver.FindElement(By.Id(confirmPasswordInputSelector));
            var companyNameInput = MyUtils.WaitForElementClick(driver, 5, By.Id(companyNameInputSelector));
            var companyCuiInput = driver.FindElement(By.Id(companyCuiInputSelector));
            var companyRegistrationCodeInput = driver.FindElement(By.Id(companyRegistrationCodeInputSelector));
            var companyCountyInput = driver.FindElement(By.Id(companyCountyDropdownSelector));
            var companyStreetInput = driver.FindElement(By.Id(companyStreetInputSelector));
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            var countyInput = driver.FindElement(By.Id(countyDropdownSelector));
            var streetInput = driver.FindElement(By.Id(streetInputSelector));
            var submitRegistration = driver.FindElement(By.Id(submitRegistrationSelector));

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
            if (companyCountyOptionIndex > 0)
            {
                companyCountyInput.Click();
                var companyCountyOptions = companyCountyInput.FindElements(By.ClassName("item"));
                if (MyUtils.TryClick(companyCountyOptions[companyCountyOptionIndex]))
                {
                    companyCountyOptions[companyCountyOptionIndex].Click();
                }
                else
                {
                    Console.WriteLine("County dropdown doesnt work, HAS ERRORS!!");
                    hasServerErr = true;
                }
            }
            if (companyLocalityOptionsIndex > 0 && !hasServerErr)
            {
                var firstLocalityOption = MyUtils.WaitForElementClick(driver, 5, By.ClassName("item"));
                if (firstLocalityOption != null)
                {
                    var companyLocalityInput = MyUtils.WaitForElementClick(driver, 10, By.Id(companyLocalityDropdownSelector));
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(companyLocalityInput).Click().Build().Perform();
                    var option = companyLocalityOptionsIndex + 1;
                    var companyLocalityOption = MyUtils.WaitForElementClick(driver, 10, By.XPath("//*[@id='ShippingLocalityIDDataList']/div[" + option + "]"));
                    companyLocalityOption.Click();
                }
            }
            companyStreetInput.Clear();
            companyStreetInput.SendKeys(companyStreet);
            nameInput.Clear();
            nameInput.SendKeys(name);
            phoneInput.Clear();
            phoneInput.SendKeys(phone);
            if (countyOptionIndex > 0 && !hasServerErr)
            {
                countyInput.Click();
                var countyOptions = countyInput.FindElements(By.ClassName("item"));
                countyOptions[countyOptionIndex].Click();
            }
            if (localityOptionIndex > 0 && !hasServerErr)
            {

                var firstLocalotyOption = MyUtils.WaitForElementClick(driver, 5, By.ClassName("item"));
                if (firstLocalotyOption != null)
                {
                    var localityInput = MyUtils.WaitForElementClick(driver, 10, By.Id(localityDropdownSelector));
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(localityInput).Click().Build().Perform();
                    var option = localityOptionIndex + 1;
                    var localityOption = MyUtils.WaitForElementClick(driver, 10, By.XPath("//*[@id='ShippingLocalityIDDataList']/div[" + option + "]"));
                    localityOption.Click();
                }
            }
            streetInput.Clear();
            streetInput.SendKeys(street);
            if (acceptTerms)
            {
                var acceptTermsInput = MyUtils.WaitForElementClick(driver, 5, (By.XPath(acceptTermsCheckboxSelector)));
                acceptTermsInput.Click();
                errorsDictionary.Add("acceptTermsError", "");
            }
            else
            {
                var acceptTermsError = driver.FindElement(By.CssSelector(acceptTermsErrorSelector));
                errorsDictionary.Add("acceptTermsError", acceptTermsError.Text);
            }
            submitRegistration.Submit();

            if (email == "")
            {
                var emailError = driver.FindElement(By.Id(requiredEmailErrorSelector));
                errorsDictionary.Add("emailError", emailError.Text);
            }
            else
            {
                var emailError = driver.FindElement(By.Id(validEmailErrorSelector));
                errorsDictionary.Add("emailError", emailError.Text);

            }
            var passwordError = driver.FindElement(By.Id(passwordErrorSelector));
            errorsDictionary.Add("passwordError", passwordError.Text);

            if (password == confirmPassword)
            {
                var confirmPasswordError = driver.FindElement(By.Id(requiredConfirmPasswordErrorSelector));
                errorsDictionary.Add("confirmPasswordError", confirmPasswordError.Text);
            }
            else
            {
                var confirmPasswordError = driver.FindElement(By.Id(matchPasswordErrorSelector));
                errorsDictionary.Add("confirmPasswordError", confirmPasswordError.Text);
            }
            var companyNameError = driver.FindElement(By.Id(companyNameErrorSelector));
            errorsDictionary.Add("companyNameError", companyNameError.Text);

            var companyCuiError = driver.FindElement(By.Id(companyCuiErrorSelector));
            errorsDictionary.Add("companyCuiError", companyCuiError.Text);

            var companyRegistrationCodeError = driver.FindElement(By.Id(companyRegistrationCodeErrorSelector));
            errorsDictionary.Add("companyRegistrationCodeError", companyRegistrationCodeError.Text);

            var companyCountyError = driver.FindElement(By.Id(companyCountyErroSelector));
            errorsDictionary.Add("companyCountyError", companyCountyError.Text);

            var companyLocalityError = driver.FindElement(By.Id(companyLocalityErrorSelector));
            errorsDictionary.Add("companyLocalityError", companyLocalityError.Text);

            var companyStreetError = driver.FindElement(By.Id(companyStreetErrorSelector));
            errorsDictionary.Add("companyStreetError", companyStreetError.Text);

            var nameError = driver.FindElement(By.Id(nameErrorSelector));
            errorsDictionary.Add("nameError", nameError.Text);

            if (phone == "")
            {
                var phoneError = driver.FindElement(By.Id(requiredPhoneErrorSelector));
                errorsDictionary.Add("phoneError", phoneError.Text);
            }
            else
            {
                var phoneError = driver.FindElement(By.Id(validPhoneErrorSelector));
                errorsDictionary.Add("phoneError", phoneError.Text);
            }
            var countyError = driver.FindElement(By.Id(countyErrorSelector));
            errorsDictionary.Add("countyError", countyError.Text);

            var localityError = driver.FindElement(By.Id(localityErrorSelector));
            errorsDictionary.Add("localityError", localityError.Text);

            var streetError = driver.FindElement(By.Id(streetErrorSelector));
            errorsDictionary.Add("streetError", streetError.Text);
            return errorsDictionary;
        }

        public string CompanyRegistration(string email, string password, string confirmPassword, string companyName, string companyCui, string companyRegistrationCode, int companyCountyOptionIndex, int companyLocalityOptionsIndex, string companyStreet, string name, string phone, int countyOptionIndex, int localityOptionIndex, string street, bool acceptTerms)
        {
            var accountCreatedConfirmation = "";
            var companyCheckboxInput = driver.FindElement(By.XPath(companyCheckSelector));
            companyCheckboxInput.Click();

            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            var confirmPasswordInput = driver.FindElement(By.Id(confirmPasswordInputSelector));
            var companyNameInput = MyUtils.WaitForElementClick(driver, 5, By.Id(companyNameInputSelector));
            var companyCuiInput = driver.FindElement(By.Id(companyCuiInputSelector));
            var companyRegistrationCodeInput = driver.FindElement(By.Id(companyRegistrationCodeInputSelector));
            var companyCountyInput = driver.FindElement(By.Id(companyCountyDropdownSelector));
            var companyStreetInput = driver.FindElement(By.Id(companyStreetInputSelector));
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            var countyInput = driver.FindElement(By.Id(countyDropdownSelector));
            var streetInput = driver.FindElement(By.Id(streetInputSelector));
            var submitRegistration = driver.FindElement(By.Id(submitRegistrationSelector));

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
            companyCountyInput.Click();
            var companyCountyOptions = companyCountyInput.FindElements(By.ClassName("item"));

            if (MyUtils.TryClick(companyCountyOptions[companyCountyOptionIndex]))
            {

                companyCountyOptions[companyCountyOptionIndex].Click();
                var firstLocalityOption = MyUtils.WaitForElementClick(driver, 5, By.ClassName("item"));

                if (firstLocalityOption != null)
                {

                    var companyLocalityInput = MyUtils.WaitForElementClick(driver, 10, By.Id(companyLocalityDropdownSelector));
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(companyLocalityInput).Click().Build().Perform();
                    var option = companyLocalityOptionsIndex + 1;
                    var companyLocalityOption = MyUtils.WaitForElementClick(driver, 10, By.XPath("//*[@id='ShippingLocalityIDDataList']/div[" + option + "]"));
                    companyLocalityOption.Click();
                }
                companyStreetInput.Clear();
                companyStreetInput.SendKeys(companyStreet);
                nameInput.Clear();
                nameInput.SendKeys(name);
                phoneInput.Clear();
                phoneInput.SendKeys(phone);
                countyInput.Click();
                var countyOptions = countyInput.FindElements(By.ClassName("item"));
                countyOptions[countyOptionIndex].Click();
                var firstLocalotyOption = MyUtils.WaitForElementClick(driver, 5, By.ClassName("item"));
                if (firstLocalotyOption != null)
                {
                    var localityInput = MyUtils.WaitForElementClick(driver, 10, By.Id(localityDropdownSelector));
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(localityInput).Click().Build().Perform();
                    var option = localityOptionIndex + 1;
                    var localityOption = MyUtils.WaitForElementClick(driver, 10, By.XPath("//*[@id='ShippingLocalityIDDataList']/div[" + option + "]"));
                    localityOption.Click();
                }
                streetInput.SendKeys(street);
                var acceptTermsInput = MyUtils.WaitForElementClick(driver, 5, (By.XPath(acceptTermsCheckboxSelector)));
                acceptTermsInput.Click();

                submitRegistration.Submit();
                accountCreatedConfirmation = driver.FindElement(By.CssSelector(accountCreatedConfirmationSelector)).Text;
            }
            else
            {
                accountCreatedConfirmation = "Cannot complete registration,county cannot be selected,has errors";
            }
            
            return accountCreatedConfirmation;
        }
    }
}
