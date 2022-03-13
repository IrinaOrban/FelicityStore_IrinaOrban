using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicityStore_IrinaOrban.Utilities
{
    public class Browser
    {
        // Return a driver, based on the enum WebBrowsers and set up the options baed on the cfg file
        public static IWebDriver GetDriver(WebBrowsers browserType)
        {
            switch (browserType)
            {
                // Instantiate a chrome driver
                case WebBrowsers.Chrome:
                    {
                        var options = new ChromeOptions();
                        // Options for the driver based on flags from FrameworkConstants
                        if (FrameworkConstants.startMaximized)
                        {
                            options.AddArgument("--start-maximized");
                        }
                        if (FrameworkConstants.startHeadless)
                        {
                            options.AddArgument("headless");
                        }
                        if (FrameworkConstants.ignoreCertErr)
                        {
                            options.AddArgument("ignore-certificate-errors");
                        }
                        // Proxy definition
                        var proxy = new Proxy
                        {
                            HttpProxy = FrameworkConstants.browserProxy,
                            IsAutoDetect = false
                        };
                        if (FrameworkConstants.useProxy)
                        {
                            options.Proxy = proxy;
                        }
                        // Intiatiate chrome driver with options
                        return new ChromeDriver(options);
                    }
                case WebBrowsers.Firefox:
                    {
                        // Defining the firefox options based on the flags in the Framework constants
                        var firefoxOptions = new FirefoxOptions();
                        List<string> optionList = new List<string>();
                        if (FrameworkConstants.startHeadless)
                        {
                            optionList.Add("--headless");
                        }
                        if (FrameworkConstants.ignoreCertErr)
                        {
                            optionList.Add("--ignore-certificate-errors");
                        }
                        firefoxOptions.AddArguments(optionList);
                        FirefoxProfile fProfile = new FirefoxProfile();

                        // Adding extension if the option is enabled in FrameworkCOnstants
                        if (FrameworkConstants.startWithExtension)
                        {
                            fProfile.AddExtension(FrameworkConstants.GetExtensionName(browserType));
                        }
                        firefoxOptions.Profile = fProfile;
                        // Instantiate Frefix driver with options
                        return new FirefoxDriver(firefoxOptions);
                    }
                case WebBrowsers.Edge:
                    {
                        // Adding edge options based on the flags in the FrameWorkConstants
                        var edgeOptions = new EdgeOptions();
                        if (FrameworkConstants.startMaximized)
                        {
                            edgeOptions.AddArgument("--start-maximized");
                        }
                        if (FrameworkConstants.startHeadless)
                        {
                            edgeOptions.AddArgument("headless");
                        }
                        if (FrameworkConstants.startWithExtension)
                        {
                            edgeOptions.AddExtension(FrameworkConstants.GetExtensionName(browserType));
                        }
                        // Instatiate Edge driver with options defined
                        return new EdgeDriver(edgeOptions);
                    }
                default:
                    {
                        // If the driver specified is not implemented
                        throw new BrowserTypeException(browserType.ToString());
                    }

            }
        }


        // This method will provide a driver, based on the config file browser attribute
        public static IWebDriver GetDriver()
        {
            WebBrowsers cfgBrowser;
            switch (FrameworkConstants.configBrowser.ToUpper())
            {
                case "FIREFOX":
                    {
                        cfgBrowser = WebBrowsers.Firefox;
                        break;
                    }
                case "CHROME":
                    {
                        cfgBrowser = WebBrowsers.Chrome;
                        break;
                    }
                case "EDGE":
                    {
                        cfgBrowser = WebBrowsers.Edge;
                        break;
                    }
                default:
                    {
                        throw new BrowserTypeException(String.Format("Browser {0} not supported", FrameworkConstants.configBrowser));
                    }
            }

            return GetDriver(cfgBrowser);
        }
    }

    // Browser Enum with the suported browser types
    public enum WebBrowsers
    {
        Chrome,
        Firefox,
        Edge
    }
}