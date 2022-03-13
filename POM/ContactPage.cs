using OpenQA.Selenium;
using System.Collections.Generic;

namespace FelicityStore_IrinaOrban.POM
{
    class ContactPage : BasePage
    {
        const string acceptcookiesSelector = "//*[@id='ctl00_divBody']/div[1]/div/a[1]";//xpath
        const string contactPageTextSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductDescription > div > h1"; // css
        const string nameInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_txtName"; // id
        const string nameErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_valRequireName";//id
        const string emailInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_txtEmail";//id
        const string emalErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_valRequireEmail";//id
        const string phoneInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_TextBoxTel";//id
        const string phoneErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_RegularExpressionValidator1";//id
        const string messageInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_txtMesaj";//id
        const string messageErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_RequiredFieldValidator1";//id
        const string sendMessageButtonSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ContactFormMVC1_Button1";//id


        public ContactPage(IWebDriver driver) : base(driver)
        {
        }
        public void AcceptCookies()
        {
            var acceptButton = MyUtils.WaitForElement(driver, 5, By.XPath(acceptcookiesSelector));
            acceptButton.Click();
        }
        public string CheckAuthPage()
        {
            var authPageEl = driver.FindElement(By.CssSelector(contactPageTextSelector));
            return authPageEl.Text;
        }
        public Dictionary<string,string> ContactForm(string name, string email, string phone, string message)
        {
            var errorsDictionary = new Dictionary<string, string>();
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            var phoneInput = driver.FindElement(By.Id(phoneInputSelector));
            var messageInput = driver.FindElement(By.Id(messageInputSelector));
            var nameError = driver.FindElement(By.Id(nameErrorSelector));
            var emailError = driver.FindElement(By.Id(emalErrorSelector));
            var phoneError = driver.FindElement(By.Id(phoneErrorSelector));
            var messageError = driver.FindElement(By.Id(messageErrorSelector));
            var sendMessageButton = driver.FindElement(By.Id(sendMessageButtonSelector));

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
            sendMessageButton.Submit();

            errorsDictionary.Add("nameError", nameError.Text);
            errorsDictionary.Add("emailError", emailError.Text);
            errorsDictionary.Add("phoneError", phoneError.Text);
            errorsDictionary.Add("messageError", messageError.Text);

            return errorsDictionary;
        }

    }
}
