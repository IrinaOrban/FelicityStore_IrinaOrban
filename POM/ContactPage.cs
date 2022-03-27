using OpenQA.Selenium;
using System.Collections.Generic;

namespace FelicityStore_IrinaOrban.POM
{
    class ContactPage : BasePage
    {
        const string contactPageTextSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductDescription > div > h1"; // css
        const string nameInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_txtName"; // id
        const string nameErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_valRequireName";//id
        const string emailInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_txtEmail";//id
        const string requiredEmailErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_valRequireEmail";//id
        const string validEmailErrorSelector ="ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_valEmailPattern";//id
        const string phoneInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_TextBoxTel";//id
        const string phoneErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_RegularExpressionValidator1";//id
        const string messageInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_txtMesaj";//id
        const string messageErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_RequiredFieldValidator1";//id
        const string sendMessageButtonSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_Button1";//id


        public ContactPage(IWebDriver driver) : base(driver)
        {
        }
       
        public string CheckAuthPage()
        {
            var authPageEl = driver.FindElement(By.CssSelector(contactPageTextSelector));
            return authPageEl.Text;
        }
        public Dictionary<string,string> ContactForm(string name, string email, string phone, string message)
        {
            var messageError = "";
            var errorsDictionary = new Dictionary<string, string>();
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            var messageInput = driver.FindElement(By.Id(messageInputSelector));
            var sendMessage = driver.FindElement(By.Id(sendMessageButtonSelector));

            nameInput.Click();
            nameInput.Clear();
            nameInput.SendKeys(name);

            emailInput.Click();
            emailInput.Clear();
            emailInput.SendKeys(email);

            phoneInput.Click();
            phoneInput.Clear();
            phoneInput.SendKeys(phone);

            messageInput.Clear();
            messageInput.SendKeys(message);
            sendMessage.Submit();

            var nameError = driver.FindElement(By.Id(nameErrorSelector));
            errorsDictionary.Add("nameError", nameError.Text);

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
            var phoneError = driver.FindElement(By.Id(phoneErrorSelector));
            errorsDictionary.Add("phoneError", phoneError.Text);


            if (message.Length>160)
            {
                messageError = "The message is too long but no message was displayed";
            }
            else
            {
                 messageError = driver.FindElement(By.Id(messageErrorSelector)).Text;

            }

            errorsDictionary.Add("messageError", messageError);

            return errorsDictionary;
        }

    }
}
