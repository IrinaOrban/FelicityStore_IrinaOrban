using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.POM
{
    class MyAccountPage : BasePage
    {

        const string accountNameSelector = "ctl00_LoginViewMasterPage1_LoginView1_LoginName1";//id
        const string lougoutSelector = "ctl00_LoginViewMasterPage1_LoginView1_LoginStatus1";//id
        const string myAccountSelector = "ctl00_LoginViewMasterPage1_LoginView1_HyperLinkMyaccount";//id
        const string wishListselector = "ctl00_LabelWishList";//id
        const string cosulMeuIconSelector = "ctl00_HyperLinkShoppingCartBox2";//id
        const string cosulMeuSelector = "ctl00_HyperLinkShoppingCartBox";//id

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }
        public string CheckAccount()
        {
           return driver.FindElement(By.Id(accountNameSelector)).Text;
        }
        public void Logout()

        {
            var logoutButton = driver.FindElement(By.Id(lougoutSelector));
            logoutButton.Click();
        }
    }
}
