using OpenQA.Selenium;
using System;

namespace FelicityStore_IrinaOrban.POM
{
    class MyBasketPage : BasePage
    {
        const string accountNameSelector = "ctl00_LoginViewMasterPage1_LoginView1_LoginName1";//id
        const string goToMyBasketButtonSelector = "ctl00_HyperLinkShoppingCartBox";//id
        const string allProductsInBasketSelector = "ShoppingCartTable";//class
        const string productQuantityControlsSelector = "QuantityShop";//class
        const string productQuantityButtonsSelector = "ButtonAddProd";//class
        const string quantityOfProductSelector = "TextBox";//class
        const string deleteProductButtonSelector = "DeleteBotton";//class
        const string confirmDeleteButtonSelector = "ctl00_DeleteShoppingCartItemPopUp1_btnDeleteOk";//id
        const string cancelDeleteButtonSelector = "ctl00_DeleteShoppingCartItemPopUp1_btnDeleteCancel";//id
        const string numberOfProductsInBasketSelector = "ctl00_LabelShoppingCartBoxCount";//id
        const string continueOrderButtonSelector= "nextbutton";//id
        const string sendOrderButtonSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ShoppingCartPage1_ButtonSendOrder";//id
        const string chooseYourPaymentMethodErrorSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ShoppingCartPage1_RequiredFieldValidator17";//id

        public MyBasketPage(IWebDriver driver) : base(driver)
        {
        }
        public int NumberOfProductsInBasket()
        {
            return int.Parse(MyUtils.WaitForElementClick(driver, 10, By.Id(numberOfProductsInBasketSelector)).Text);
        }
        public int IncreaseProductsToBasket()
        {
            var firstProductInBasket = driver.FindElements(By.ClassName(allProductsInBasketSelector))[0];
            var productQuantityControls = firstProductInBasket.FindElement(By.ClassName(productQuantityControlsSelector));
            var increaseProductsButton = productQuantityControls.FindElement(By.ClassName(productQuantityButtonsSelector));
            increaseProductsButton.Submit();
            driver.FindElement(By.Id(goToMyBasketButtonSelector)).Click();
            return NumberOfProductsInBasket();
        }
        public bool HasDeleteProductsErrors()
        {
            if (NumberOfProductsInBasket() > 0)
            {
                var firstProductInBasket = driver.FindElements(By.ClassName(allProductsInBasketSelector))[0];
                var productQuantityControls = firstProductInBasket.FindElement(By.ClassName(productQuantityControlsSelector));
                var quantityOfProduct = firstProductInBasket.FindElement(By.ClassName(quantityOfProductSelector)).GetAttribute("value");
                var numberofExistingProductsInBasket = NumberOfProductsInBasket();
                var deleteProductButton = firstProductInBasket.FindElement(By.ClassName(deleteProductButtonSelector));
                deleteProductButton.Click();
                var confirmDeleteButton = MyUtils.WaitForElementClick(driver, 5, By.Id(confirmDeleteButtonSelector));
                confirmDeleteButton.Submit();
                MyUtils.WaitForElementClick(driver, 10, By.Id(goToMyBasketButtonSelector)).Click();
                return numberofExistingProductsInBasket - int.Parse(quantityOfProduct) == NumberOfProductsInBasket();

            }
            else
            {
                Console.WriteLine("The basket is empty");
                return false;
            }
        }
         public string CheckOutNegative()
        {
            var continueOrderButton = MyUtils.WaitForElementClick(driver, 10, By.Id(continueOrderButtonSelector));
            continueOrderButton.Click();
            var sendOrderButton = MyUtils.WaitForElementClick(driver, 10, By.Id(sendOrderButtonSelector));
            sendOrderButton.Click();
            return MyUtils.WaitForElementClick(driver, 10, By.Id(chooseYourPaymentMethodErrorSelector)).Text;
        }
    }

}
