using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.POM
{
    class ForgotPasswordPage : BasePage
    {
        const string forgotPageTextSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_PasswordRecoveryCustomised1_PanelRecover > table > tbody > tr:nth-child(1) > td > h1";//Css
        const string emailInputselector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_PasswordRecoveryCustomised1_TextBoxEmail";//id
        const string emailErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_PasswordRecoveryCustomised1_UserNameRequired";//id
        const string generalErrorMessageSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_PasswordRecoveryCustomised1_LabelFailureText";//id
        const string sendPasswordSubmitButtonSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_PasswordRecoveryCustomised1_ButtonSubmit";//id
        const string backToLoginButtonSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_PasswordRecoveryCustomised1_HyperLinkLogIN";//id
        const string newPasswordWasSubmittedMessageSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_PasswordRecoveryCustomised1_PanelPasswordChanged > div";//css

        public ForgotPasswordPage(IWebDriver driver) : base(driver)
        {
        }
       
        public string CheckFrogotPasswordPage()
        {
            var authPageEl = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(forgotPageTextSelector));
            return authPageEl.Text;
        }
        public bool  HasUserRecoverPassworsErrors(string email)
        {
            bool HasUserRecoverPassworsErrors = false;
            var emailInput = driver.FindElement(By.Id(emailInputselector));
            var sendPasswordSubmitButton = driver.FindElement(By.Id(sendPasswordSubmitButtonSelector));
            var generalErrorMessage = driver.FindElement(By.Id(generalErrorMessageSelector));

            emailInput.Clear();
            emailInput.SendKeys(email);
            sendPasswordSubmitButton.Click();
            var jsExecutor = (IJavaScriptExecutor)driver;
            var hasServerErrors = (Boolean)jsExecutor.ExecuteScript("return !!(document.getElementById('ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_PasswordRecoveryCustomised1_LabelFailureText'))");
            if (!hasServerErrors)
            {
                var newPasswordWasSubmittedMessage = MyUtils.WaitForElementClick(driver, 10, By.CssSelector(newPasswordWasSubmittedMessageSelector)).Text;
                Console.WriteLine(newPasswordWasSubmittedMessage);
                var backToLoginButton = MyUtils.WaitForElementClick(driver,10,By.Id(backToLoginButtonSelector));
                backToLoginButton.Click();
                HasUserRecoverPassworsErrors = false;
            }
            else
            {
                var emailErrors = driver.FindElement(By.Id(generalErrorMessageSelector)).Text;
                HasUserRecoverPassworsErrors = true;
                Console.WriteLine(emailErrors);

            }
            return HasUserRecoverPassworsErrors;
        }
        public bool CheckForgotPassNonUser(string email)
        {
            var CheckForgotPassNonUser = false;
            var emailInput = driver.FindElement(By.Id(emailInputselector));
            var sendPasswordSubmitButton = driver.FindElement(By.Id(sendPasswordSubmitButtonSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            sendPasswordSubmitButton.Click();
            var generalErrorMessage = MyUtils.WaitForElementClick(driver, 10, By.Id(generalErrorMessageSelector)).Text;

            if (generalErrorMessage.Length==0)
            {
                CheckForgotPassNonUser = true;
                Console.WriteLine("Non user email  but no message was displayed");
            }
            else
            {
                CheckForgotPassNonUser = false;
                Console.WriteLine(generalErrorMessage);
            }
            return CheckForgotPassNonUser;
        }

    }
}
