using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.POM
{
    class MyWishlistPage : BasePage
    {

        const string myAccountSelector = "ctl00_LoginViewMasterPage1_LoginView1_HyperLinkMyaccount";//id
        const string numberOfProductInWishlistSelector = "ctl00_LabelWishListCount";//id
        const string allProductsInWishlistSelector = "WishListItem";//class
        const string deleteProductButtonSelector = "DeleteBotton";//class
        const string goToMyWhislistButtonSelector = "ctl00_HyperLinkWishList";//id





        public MyWishlistPage(IWebDriver driver) : base(driver)
        {
        }
        public bool HasDeletewhislistError()
        {
            int numberOfProductsExistingInWishlist = int.Parse(driver.FindElement(By.Id(numberOfProductInWishlistSelector)).Text);
            if (numberOfProductsExistingInWishlist > 0)
            {
                var firstProductInWishlist = driver.FindElements(By.ClassName(allProductsInWishlistSelector))[0];
                var deleteProductButton = firstProductInWishlist.FindElement(By.ClassName(deleteProductButtonSelector));
                deleteProductButton.Click();
                IAlert deleteAlert = driver.SwitchTo().Alert();
                deleteAlert.Accept();
                MyUtils.WaitForElementClick(driver, 10, By.Id(goToMyWhislistButtonSelector)).Click();
                return numberOfProductsExistingInWishlist == int.Parse(driver.FindElement(By.Id(numberOfProductInWishlistSelector)).Text);

            }
            else
            {
                Console.WriteLine("The basket is empty");
                return false;
            }
        }
    }
}
