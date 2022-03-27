using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.POM
{
    class SearchResultPage : BasePage
    {
        const string searchPageTextSelector = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductDescription";//id
        const string acceptcookiesSelector = "//*[@id='ctl00_divBody']/div[1]/div/a[1]";//xpath
        const string searchButtonSelector = "ctl00_ButtonSearch";//id
        const string searchTextInputSelector = "ctl00_txtSearchText";//id

        public SearchResultPage(IWebDriver driver) : base(driver)
        {
        }
        public void AcceptCookies()
        {
            var acceptButton = MyUtils.WaitForElementClick(driver, 30, By.XPath(acceptcookiesSelector));
            acceptButton.SendKeys(Keys.Return);

        }
        public string CheckSearchPage()
        {
            var authPageEl = driver.FindElement(By.Id(searchPageTextSelector));
            return authPageEl.Text;
        }
        public void SubmitSearchText(string searchedText)
        {
            var searchButton = driver.FindElement(By.Id(searchButtonSelector));
            searchButton.Click();
            var searchTextInput = MyUtils.WaitForElementClick(driver, 5, By.Id(searchTextInputSelector));
            searchTextInput.Clear();
            searchTextInput.SendKeys(searchedText);
            Actions actions = new Actions(driver);
            actions.MoveToElement(searchButton).Click().Build().Perform();
        }

        public bool HasSearchErrors()
        {
            var hasSearchErrros = false;
            var jsExecutor = (IJavaScriptExecutor)driver;
            bool hasFoundProducts = (Boolean)jsExecutor.ExecuteScript("return !!document.getElementsByClassName('prodListItem').length");
            bool hasFoundArticles = (Boolean)jsExecutor.ExecuteScript("return !!document.getElementsByClassName('ArticleBlogTabs').length");
           
            if(hasFoundProducts || hasFoundArticles)
            {
                hasSearchErrros = false;
            }
            else
            {
                hasSearchErrros = true;
            }


            return hasSearchErrros;

        }
    }
}
