using OpenQA.Selenium;

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

        public MyBasketPage(IWebDriver driver) : base(driver)
        {
        }
        public string IncreaseProductsToBasket()
        {
            var firstProductInBasket = driver.FindElements(By.ClassName(allProductsInBasketSelector))[0];
            var productQuantityControls = firstProductInBasket.FindElement(By.ClassName(productQuantityControlsSelector));
            var increaseProductsButton = productQuantityControls.FindElement(By.ClassName(productQuantityButtonsSelector));
            increaseProductsButton.Submit();
            driver.FindElement(By.Id(goToMyBasketButtonSelector)).Click();
            return MyUtils.WaitForElementClick(driver,5,By.Id(numberOfProductsInBasketSelector)).Text;
        }
        public bool HasDeleteProductsErrors()
        {

            var firstProductInBasket = driver.FindElements(By.ClassName(allProductsInBasketSelector))[0];
            var productQuantityControls = firstProductInBasket.FindElement(By.ClassName(productQuantityControlsSelector));
            var quantityOfProduct = firstProductInBasket.FindElement(By.ClassName(quantityOfProductSelector)).GetAttribute("value");
            var numberofProductsInBasket = driver.FindElement(By.Id(numberOfProductsInBasketSelector)).Text;
            var deleteProductButton = firstProductInBasket.FindElement(By.ClassName(deleteProductButtonSelector));
            deleteProductButton.Click();
            var confirmDeleteButton = MyUtils.WaitForElementClick(driver, 5, By.Id(confirmDeleteButtonSelector));
            confirmDeleteButton.Submit();
            MyUtils.WaitForElementClick(driver,10,By.Id(goToMyBasketButtonSelector)).Click();
            return int.Parse(numberofProductsInBasket)-int.Parse(quantityOfProduct)==int.Parse(driver.FindElement(By.Id(numberOfProductsInBasketSelector)).Text);
        }


    }

}
