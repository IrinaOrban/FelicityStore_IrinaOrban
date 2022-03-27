using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.POM
{
    public class LoginPage : BasePage
    {

        const string authPageTextSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_LoginRegisterForm1_PanelAroundControl > table > tbody > tr > td:nth-child(1) > h1"; // css
        const string usernameInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_LoginRegisterForm1_LoginFormGeneral1_Login1_UserName"; //id
        const string usernameErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_LoginRegisterForm1_LoginFormGeneral1_Login1_UserNameRequired"; // id
        const string passwordInputSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_LoginRegisterForm1_LoginFormGeneral1_Login1_Password"; // id
        const string passwordErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_LoginRegisterForm1_LoginFormGeneral1_Login1_PasswordRequired"; // id
        const string loginSubmitButtonSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_LoginRegisterForm1_LoginFormGeneral1_Login1_LoginButton"; // id
        const string loginErrorMessageSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_LoginRegisterForm1_LoginFormGeneral1_Login1 > tbody > tr > td > table > tbody > tr:nth-child(7) > td > div";//css
        const string forgotPasswordSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_LoginRegisterForm1_LoginFormGeneral1_Login1_HyperLinkRecoverPassword";//id

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public string CheckAuthPage()
        {
            var authPageEl = driver.FindElement(By.CssSelector(authPageTextSelector));
            return authPageEl.Text;
        }
        public Dictionary<string, string> Login(string user, string pass)
        {
            var usernameInputElement = driver.FindElement(By.Id(usernameInputSelector));
            usernameInputElement.Click();
            usernameInputElement.Clear();
            usernameInputElement.SendKeys(user);
            var passwordInputElement = driver.FindElement(By.Id(passwordInputSelector));
            usernameInputElement.Click();
            passwordInputElement.Clear();
            passwordInputElement.SendKeys(pass);
            var submitButtonElement = driver.FindElement(By.Id(loginSubmitButtonSelector));
            submitButtonElement.Submit();

            var usernameErrorElement = driver.FindElement(By.Id(usernameErrorSelector));
            var passwordErrorElement = driver.FindElement(By.Id(passwordErrorSelector));
            var loginErrorElement = driver.FindElement(By.CssSelector(loginErrorMessageSelector));

            return new Dictionary<string, string>() { { "usernameError", usernameErrorElement.Text }, { "passwordError", passwordErrorElement.Text }, { "loginError", loginErrorElement.Text } };
        }

        public void UserLogin(string user, string pass)
        {
            var usernameInputElement = driver.FindElement(By.Id(usernameInputSelector));
            usernameInputElement.Click();
            usernameInputElement.Clear();
            usernameInputElement.SendKeys(user);
            var passwordInputElement = driver.FindElement(By.Id(passwordInputSelector));
            passwordInputElement.Click();
            passwordInputElement.Clear();
            passwordInputElement.SendKeys(pass);
            var submitButtonElement = driver.FindElement(By.Id(loginSubmitButtonSelector));
            submitButtonElement.Submit();
        }

        public void MoveToForgotPassword()
        {
            MyUtils.WaitForElementClick(driver, 5, (By.Id(forgotPasswordSelector))).Click();

        }
    }
}
