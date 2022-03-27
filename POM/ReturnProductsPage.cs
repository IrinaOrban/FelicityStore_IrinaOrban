using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace FelicityStore_IrinaOrban.POM
{
    class ReturnProductsPage : BasePage
    {
        public ReturnProductsPage(IWebDriver driver) : base(driver)
        {
        }

        const string returnProductPageTextSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_LiteralDescBottom > div > span > strong"; // css
        const string orderNumberInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_txtOrderNr";//id
        const string requiredOrderNumberErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_valRequireName";//id
        const string validationOrderNumberErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_valImportanceType";//id
        const string nameInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_txtName";//id
        const string nameErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_RequiredFieldValidator2";//id
        const string returnTypeDropdownSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_ddlReturType";//id
        const string returnTypeErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_RequiredFieldValidator1";//id
        const string productCodeInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_txtOldProductID";//id
        const string productCodeErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_CompareValidator1";//id
        const string adressInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_txtAddress";//id
        const string adressErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_RequiredFieldValidator3";//id
        const string phoneInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_txtPhone";//id
        const string requiredPhoneErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_RequiredFieldValidator4";//id
        const string validPhoneErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_RegularExpressionValidator1";//id
        const string emailInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_txtEmail";//id
        const string requiredEmailErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_valRequireEmail";//id
        const string validEmailErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_valEmailPattern";//id

        const string messaageInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_txtMesaj";//id
        const string submitReturSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ReturControl1_btnSendRetur";//id


       
        public string CheckReturnProductsPage()
        {
            var authPageEl = driver.FindElement(By.CssSelector(returnProductPageTextSelector));
            return authPageEl.Text;
        }
        public Dictionary<string, string> ReturnProducts(string orderNumber,bool hasOrderNumberValidationError, string name, int returnTypeOptionIndex, string productCode, string adress, string phone, string email, string message)
        {
            var errorsDictionary = new Dictionary<string, string>();
            var messageError = "";
            var orderNumberInput = driver.FindElement(By.Id(orderNumberInputSelector));
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            var retunTypeDropdown = new SelectElement(driver.FindElement(By.Id(returnTypeDropdownSelector)));
            var productCodeInput = driver.FindElement(By.Id(productCodeInputSelector));
            var adressInput = driver.FindElement(By.Id(adressInputSelector));
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            var messageInput = driver.FindElement(By.Id(messaageInputSelector));
            
            var submitRetur = driver.FindElement(By.Id(submitReturSelector));
            
            orderNumberInput.Click();
            orderNumberInput.Clear();
            orderNumberInput.SendKeys(orderNumber);

            nameInput.Click();
            nameInput.Clear();
            nameInput.SendKeys(name);

            if (returnTypeOptionIndex > 0)
            {
                retunTypeDropdown.SelectByIndex(returnTypeOptionIndex);
            }

            productCodeInput.Click();
            productCodeInput.Clear();
            productCodeInput.SendKeys(productCode);
           
            adressInput.Click();
            adressInput.Clear();
            adressInput.SendKeys(adress);
         
            phoneInput.Click();
            phoneInput.Clear();
            phoneInput.SendKeys(phone);
         
            emailInput.Click();
            emailInput.Clear();
            emailInput.SendKeys(email);

            messageInput.Clear();
            messageInput.SendKeys(message);
            
            submitRetur.Submit();

            if (message.Length > 160)
            {
                messageError = "The was to long but no error was displayed";
            }
            if (hasOrderNumberValidationError)
            {
                var orderNumberError = driver.FindElement(By.Id(validationOrderNumberErrorSelector));
                errorsDictionary.Add("orderError", orderNumberError.Text);
            }
            else
            {
                var orderNumberError = driver.FindElement(By.Id(requiredOrderNumberErrorSelector));
                errorsDictionary.Add("orderError", orderNumberError.Text);
            }

            if(phone=="")
            {
                var phoneError = driver.FindElement(By.Id(requiredPhoneErrorSelector));
                errorsDictionary.Add("phoneError", phoneError.Text);
            }
            else
            {
                var phoneError = driver.FindElement(By.Id(validPhoneErrorSelector));
                errorsDictionary.Add("phoneError", phoneError.Text);

            }

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
            var nameError = driver.FindElement(By.Id(nameErrorSelector));
            errorsDictionary.Add("nameError", nameError.Text);

            var returnTypeError = driver.FindElement(By.Id(returnTypeErrorSelector));
            errorsDictionary.Add("returnTypeError", returnTypeError.Text);

            var productCodeError = driver.FindElement(By.Id(productCodeErrorSelector));
            errorsDictionary.Add("productError", productCodeError.Text);

            var adressError = driver.FindElement(By.Id(adressErrorSelector));
            errorsDictionary.Add("adressError", adressError.Text);

            errorsDictionary.Add("messageError", messageError);
            return errorsDictionary;
        }

    }
}
