using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.POM
{
    class ProductsPage : BasePage
    {

        const string myAccountLinkSelector = "ctl00_LoginViewMasterPage1_LoginView1_HyperLinkMyaccount1";//id
        const string usernameInputSelector = "ctl00_LoginFormMasterPage1_Login1_UserName";//id
        const string passwordInputSelector = "ctl00_LoginFormMasterPage1_Login1_Password";//id
        const string loginSubmitButtonSelector = "ctl00_LoginFormMasterPage1_Login1_LoginButton";//id
        const string numberOfProductsInBasketSelector = "ctl00_LabelShoppingCartBoxCount";//id
        const string numberOfProductInWishlistSelector = "ctl00_LabelWishListCount";//id
        const string allProductsSelector = "prodListItem";//class
        const string addToCartButtonSelector = "ProdAddCartSmall";//class
        const string addToWishListButtonSelector = "ButtonWishlist";//class
        const string productButtonsContainerSelector = "ProdFooter";//class
        const string productOutOfStockSelector = "NoStockLabel";//class
        const string goToMyBasketButtonSelector = "ctl00_HyperLinkShoppingCartBox";//id
        const string goToMyWhislistButtonSelector = "ctl00_HyperLinkWishList";//id

        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }
       
        public void ProductsPageUserLogin(string user, string pass)
        {
            MyUtils.WaitForElementClick(driver, 5, (By.Id(myAccountLinkSelector))).Click();
            var loginButton = driver.FindElement(By.Id(loginSubmitButtonSelector));
            var usernameInputElement = MyUtils.WaitForElementClick(driver, 5, By.Id(usernameInputSelector));
            var passwordInputElement = MyUtils.WaitForElementClick(driver, 5, By.Id(passwordInputSelector));
            usernameInputElement.Clear();
            usernameInputElement.SendKeys(user);
            passwordInputElement.Clear();
            passwordInputElement.SendKeys(pass);
            loginButton.Submit();

        }

        public int AddToBasket(int numberOfProductsToBuy)
        {
            var productCards = driver.FindElements(By.ClassName(allProductsSelector));
            var outOfstockNumber = 0;
            int addToBasketNumber = 0;
            var numberOfProductsExistingInBasket = int.Parse(MyUtils.WaitForElementClick(driver,10,By.Id(numberOfProductsInBasketSelector)).Text);
           

            if (numberOfProductsToBuy < productCards.Count)
            {
                 addToBasketNumber = numberOfProductsToBuy;
            }
            else
            {
                 addToBasketNumber = productCards.Count - 1;
            }

            for (var i = 0; i < addToBasketNumber; i++)
            {
                var productCard = driver.FindElements(By.ClassName(allProductsSelector))[i];
                var buttonsContainer = productCard.FindElement(By.ClassName(productButtonsContainerSelector));
                try
                {
                    buttonsContainer.FindElement(By.ClassName(productOutOfStockSelector));
                    var linkToProducDetails = productCard.FindElement(By.TagName("a"));
                    Console.WriteLine("The product {0} is out of stock", linkToProducDetails.GetAttribute("href"));
                     outOfstockNumber =outOfstockNumber++;
                }
                catch (NoSuchElementException)
                {
                    var addToCartBtn = buttonsContainer.FindElement(By.ClassName(addToCartButtonSelector));
                    addToCartBtn.Submit();
                }
            }
            var numberOfProductsInBasket = MyUtils.WaitForElementClick(driver, 10, By.Id(numberOfProductsInBasketSelector)).Text;
            Console.WriteLine("Au fost {0} produse in cos, a trebuit sa cumpar {1}, dintre acestea {2} nu erau in stoc, acum am {3} produse in cos",numberOfProductsExistingInBasket,numberOfProductsToBuy,outOfstockNumber,numberOfProductsInBasket);
             return int.Parse(numberOfProductsInBasket)+outOfstockNumber-numberOfProductsExistingInBasket;
        }

        public int AddToWishlist(int numberOfWishedProducts)
        {
            var productCards = driver.FindElements(By.ClassName(allProductsSelector));
            int addToWishlisttNumber = 0;
            int numberOfProductsExistingInWishlist = int.Parse(driver.FindElement(By.Id(numberOfProductInWishlistSelector)).Text);
            if (numberOfWishedProducts < productCards.Count)
            {
                addToWishlisttNumber = numberOfWishedProducts;
            }
            else
            {
                addToWishlisttNumber = productCards.Count - 1;
            }
            for (var i = 0; i < addToWishlisttNumber; i++)
            {
                var productCard = driver.FindElements(By.ClassName(allProductsSelector))[i];
                var buttonsContainer = productCard.FindElement(By.ClassName(productButtonsContainerSelector));
                var addToWishlistBtn = buttonsContainer.FindElement(By.ClassName(addToWishListButtonSelector));
                addToWishlistBtn.Submit();
            }
            
            return int.Parse(MyUtils.WaitForElementClick(driver,5,By.Id(numberOfProductInWishlistSelector)).Text)-numberOfProductsExistingInWishlist;

        }

        public void GoToMyBasket()
        {
            driver.FindElement(By.Id(goToMyBasketButtonSelector)).Click();
        }

        public void GoToMyWishList()
        {
            driver.FindElement(By.Id(goToMyWhislistButtonSelector)).Click();
        }
    }

}
