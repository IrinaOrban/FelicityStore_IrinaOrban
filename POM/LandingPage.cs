using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FelicityStore_IrinaOrban.POM
{
    public class LandingPage : BasePage
    {
        const string acasaLinkSelector = "#ctl00_MenuTop > ul > li:nth-child(1) > a";//csc
        const string bijuteriiLinkSelector = "#ctl00_MenuTop > ul > li:nth-child(2) > a";//css
        const string contactLinkSelector = "#ctl00_MenuTop > ul > li:nth-child(3) > a";//css
        const string myAccountLinkSelector = "ctl00_LoginViewMasterPage1_LoginView1_HyperLinkMyaccount1";//id
        const string usernameInputSelector = "ctl00_LoginFormMasterPage1_Login1_UserName";//id
        const string passwordInputSelector = "ctl00_LoginFormMasterPage1_Login1_Password";//id
        const string loginSubmitButtonSelector = "ctl00_LoginFormMasterPage1_Login1_LoginButton";//id
        const string forgotPasswordButtonSelector = "ctl00_LoginFormMasterPage1_Login1_HyperLinkRecoverPassword";//id
        const string createAccountButtonSelector = "ctl00_LoginFormMasterPage1_HyperLink1";//id
        const string loginErrorSelector = "//*[@id='ctl00_LoginFormMasterPage1_Login1']/tbody/tr/td/table/tbody/tr[7]/td/div";//xpath
        const string whishlistLinkSelector = "#ctl00_HyperLinkWishList";//css
        const string cosulMeuLinkSelector = "#ctl00_HyperLinkShoppingCartBox";//css;
        const string searchButtonSelector = "ctl00_ButtonSearch";//id
        const string searchTextInputSelector = "ctl00_txtSearchText";//id
        const string pandantiveLinkSelector = "#HomeBanners > div:nth-child(1) > a";//css- I used css to be able to get href attribute.
        const string cerceiLinkSelector = "#HomeBanners > div:nth-child(2) > a";//css
        const string bratariLinkSelector = "#HomeBanners > div:nth-child(3) > a";//css
        const string butoniLinkSelector = "#HomeBanners > div:nth-child(4) > a";//css
        const string ineleSiBroseLinkSelector = "#HomeBanners > div:nth-child(5) > a";//css
        const string bijuteriiArgintLinkSelector = "#HomeBanners > div:nth-child(6) > a";//css
        const string giftCardLinkSelector = "#HomeBanners > div.HomeBannersTab2 > a:nth-child(1)";//css
        const string povesteaNoastraLinkSelector = "#ctl00_ZonaGeneral1_PanelArroundControl > div.LabelZone > p > a.PovLink";//css
        const string articoleBlogLinkSelector = "#articleListHome > span > a"; //css
        const string despreNoiLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(1) > a";//css
        const string blogLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(2) > a";//css
        const string marektingLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(3) > a";//css
        const string intrebariFrecventeLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(4) > a";//css
        const string returnareProduseLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(5) > a";//css
        const string guestbookLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(6) > a";//css
        const string cariereLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(7) > a";//css
        const string politicaDeCookiesLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(9) > a";//css
        const string politicaDeConfidentialitateLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(10) > a";//css
        const string termeniSiConditiiLinkSelector = "#ctl00_FooterData1_PanelArroundControl > div:nth-child(3) > ul > li:nth-child(11) > a";//css
        const string caruselButtonPreviousSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductsPanelForHome1_ProductsListRecommendedForHome1_PanelArroundControll > div > button.slick-prev";//css
        const string caruselButtonNextSelector = "#ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductsPanelForHome1_ProductsListRecommendedForHome1_PanelArroundControll > div > button.slick-next";//css
        const string bijuteriiRecomandateCaruselSelector = "prodListItem";//class
        const string bijuteriiRecomandateLinkSelector1 = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductsPanelForHome1_ProductsListRecommendedForHome1_DataListProducts_ctrl0_ProductItemsAllVertical1_HyperLink2";//id
        const string bijuteriiRecomandateLinkSelector2 = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductsPanelForHome1_ProductsListRecommendedForHome1_DataListProducts_ctrl1_ProductItemsAllVertical1_HyperLink2";//id
        const string bijuteriiRecomandateLinkSelector3 = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductsPanelForHome1_ProductsListRecommendedForHome1_DataListProducts_ctrl2_ProductItemsAllVertical1_HyperLink2";//id
        const string bijuteriiRecomandateLinkSelector4 = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductsPanelForHome1_ProductsListRecommendedForHome1_DataListProducts_ctrl3_ProductItemsAllVertical1_HyperLink2";//id
        const string bijuteriiRecomandateLinkSelector5 = "ctl00_ContentPlaceHolderBody_DepartmentDetailsPageContent1_ProductsPanelForHome1_ProductsListRecommendedForHome1_DataListProducts_ctrl4_ProductItemsAllVertical1_HyperLink2";//id

        public LandingPage(IWebDriver driver) : base(driver)
        {
        }
        
        private string[] getHeaderLinksSelectors()
        {

            string[] headderElements = { acasaLinkSelector, bijuteriiLinkSelector, contactLinkSelector,whishlistLinkSelector,cosulMeuLinkSelector};
           
            return headderElements;
        }
        private string [] getFooterLinksSelectors()
        {

            string[] footerElements = { despreNoiLinkSelector,marektingLinkSelector,intrebariFrecventeLinkSelector,returnareProduseLinkSelector,guestbookLinkSelector,cariereLinkSelector,politicaDeCookiesLinkSelector, politicaDeConfidentialitateLinkSelector,termeniSiConditiiLinkSelector,blogLinkSelector };

            return footerElements;
        }
        public string CheckAccount()
        {
            return driver.FindElement(By.Id(myAccountLinkSelector)).Text;
        }
        public bool CheckHeaderLinks()
        {
            var linkNavigationFailed = false;
            var headerLinkElements = getHeaderLinksSelectors();
    
            foreach (string link in headerLinkElements)
            {
                var linkElement = MyUtils.WaitForElementClick(driver,5,By.CssSelector(link));
                var href = linkElement.GetAttribute("href");
                if (MyUtils.CheckLinkNavigation(linkElement, driver,href) == true) 
                {
                    linkNavigationFailed = true;
                }
            }
            return linkNavigationFailed;
        }
        public bool CheckFooterLinks()
        {
            var linkNavigationFailed = false;
            var footerLinks = getFooterLinksSelectors();

            foreach (string link in footerLinks)
            {
                var linkElement = MyUtils.WaitForElementClick(driver,5,By.CssSelector(link));
                var href = linkElement.GetAttribute("href");
                if (MyUtils.CheckLinkNavigation(linkElement, driver, href) == true)
                {
                    linkNavigationFailed = true;
                }
            }
            return linkNavigationFailed;
        }
        public bool CheckDynamicLinks(string linkName)
        {
            bool linkNavigationFailed;
            switch (linkName)
            {
                case "pandantive":
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver,5,By.CssSelector(pandantiveLinkSelector));
                        var linkHref = linkElement.GetAttribute("href");
                        Console.WriteLine("href",linkHref);
                        linkNavigationFailed=MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;
                    }
                case "cercei":
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(cerceiLinkSelector));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;
                    }
                case "bratari":
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(bratariLinkSelector));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;
                    }
                case "butoni":
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(butoniLinkSelector));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;
                    }
                case "inele":
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(ineleSiBroseLinkSelector));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;
                    }
                case "bijuterii":
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(bijuteriiArgintLinkSelector));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;
                    }
                case "giftCard":
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(giftCardLinkSelector));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;
                    }
                case "povestea":
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(povesteaNoastraLinkSelector));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;
                    }
                case "blog":
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(articoleBlogLinkSelector));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;
                    }
                default:
                    {
                        linkNavigationFailed = false;
                        break;
                    }
            }
            return linkNavigationFailed;

        }
        public bool CheckCaruselBijuteriiRecomandate()
        {
            bool caruselHasError = false;
            var caruselButtonNext = driver.FindElement(By.CssSelector(caruselButtonNextSelector));
            var caruselButtonPrevious = driver.FindElement(By.CssSelector(caruselButtonPreviousSelector));
            var bijuteriiRecomandateCaruselElements = driver.FindElements(By.ClassName(bijuteriiRecomandateCaruselSelector));
            var numberOfElementsInCarusel = bijuteriiRecomandateCaruselElements.Count;
            int numberOfVisibleItems = 0;
            
            for (int i=0; i<numberOfElementsInCarusel; i++)
            {

                string newItemCssSelector = $".{bijuteriiRecomandateCaruselSelector}:nth-child({i + 1})";
                var currentElement = MyUtils.WaitForElementClick(driver, 10, By.CssSelector(newItemCssSelector));

                if (currentElement.GetAttribute("aria-hidden") == "true")
                {
                    caruselButtonNext.Click();

                    if (currentElement.GetAttribute("aria-hidden") == "true")
                    {
                        caruselHasError = true;
                    }
                    if (numberOfVisibleItems==0)
                    {
                        numberOfVisibleItems = i;
                    }
                }
                newItemCssSelector = $".{bijuteriiRecomandateCaruselSelector}:nth-child({numberOfElementsInCarusel - i})";
                currentElement = MyUtils.WaitForElementClick(driver, 10, By.CssSelector(newItemCssSelector));

                if (i >= numberOfVisibleItems && numberOfVisibleItems > 0 && currentElement.GetAttribute("aria-hidden") == "true")
                {
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(caruselButtonPrevious).Click().Build().Perform();
                    Console.WriteLine(newItemCssSelector); Console.WriteLine(i);

                    if (currentElement.GetAttribute("aria-hidden") == "true")
                    {
                        caruselHasError = true;
                    }
                }

            }
            return caruselHasError;
        }
        public bool CheckCaruselProductLinks(int caruselProductNumber)
        {
            bool linkNavigationFailed;
            switch (caruselProductNumber)
            {
                case 1:
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.Id(bijuteriiRecomandateLinkSelector1));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;

                    }
                case 2:
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.Id(bijuteriiRecomandateLinkSelector2));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;

                    }
                case 3:
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.Id(bijuteriiRecomandateLinkSelector3));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;

                    }
                case 4:
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.Id(bijuteriiRecomandateLinkSelector4));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;

                    }
                case 5:
                    {
                        var linkElement = MyUtils.WaitForElementClick(driver, 5, By.CssSelector(bijuteriiRecomandateLinkSelector5));
                        var linkHref = linkElement.GetAttribute("href");
                        linkNavigationFailed = MyUtils.CheckLinkNavigation(linkElement, driver, linkHref);
                        break;

                    }
               
                default:
                    {
                        linkNavigationFailed = false;
                        break;
                    }

            }
            return linkNavigationFailed;
        }
        public void MoveToContactPage()
        {
            driver.FindElement(By.Id(myAccountLinkSelector)).Click();
            MyUtils.WaitForElementClick(driver, 5,(By.Id(createAccountButtonSelector))).Click();
        }
        public void LandingPageUserLogin(string user, string pass)
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
        public string LandingPageLogin(string user, string pass)
        {
            MyUtils.WaitForElementClick(driver, 5, (By.Id(myAccountLinkSelector))).Click();
            var usernameInputElement = MyUtils.WaitForElementClick(driver, 5, By.Id(usernameInputSelector));
            var passwordInputElement = MyUtils.WaitForElementClick(driver, 5, By.Id(passwordInputSelector));
            var loginButton = driver.FindElement(By.Id(loginSubmitButtonSelector));
            usernameInputElement.Clear();
            usernameInputElement.SendKeys(user);
            passwordInputElement.Clear();
            passwordInputElement.SendKeys(pass);
            loginButton.Submit();
            var loginErrorMessage = MyUtils.WaitForElementClick(driver, 10, By.XPath(loginErrorSelector));
            return loginErrorMessage.Text;
        }
        public void MoveToForgotPassword()
        {
            MyUtils.WaitForElementClick(driver, 5,(By.Id(myAccountLinkSelector))).Click();
            MyUtils.WaitForElementClick(driver, 5,(By.Id(forgotPasswordButtonSelector))).Click();

        }
        public void SubmitSearchText(string searchedText)
        {
            var searchButton = driver.FindElement(By.Id(searchButtonSelector));
            searchButton.Click();
            var searchTextInput = MyUtils.WaitForElementClick(driver, 5,By.Id(searchTextInputSelector));
            searchTextInput.Clear();
            searchTextInput.SendKeys(searchedText);
            Actions actions = new Actions(driver);
            actions.MoveToElement(searchButton).Click().Build().Perform();
        }

    }
}