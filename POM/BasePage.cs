using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.POM
{
   public class BasePage
    {
      public  IWebDriver driver;
       const string acceptcookiesSelector = "//*[@id='ctl00_divBody']/div[1]/div/a[1]";//xpath
        public void AcceptCookies()
        {
            var acceptButton = MyUtils.WaitForElementClick(driver, 10, By.XPath(acceptcookiesSelector));
            acceptButton.SendKeys(Keys.Return);
        }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
