using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
using FelicityStore_IrinaOrban.Utilities;

namespace FelicityStore_IrinaOrban.Test
{
    public class BaseTest
    {
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public IWebDriver _driver;
        public static ExtentReports _extent;
        public ExtentTest _test;
        public string testName;

        [OneTimeSetUp]
        protected void ExtentStart()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;//path to the location of the test that are running
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));//get bin folder
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");//creates folder
            DateTime time = DateTime.Now;
            var reportPath = projectPath + "Reports\\report_" + time.ToString("h_mn_ss") + ".html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "Localhost");
            _extent.AddSystemInfo("Username", "Irina_Orban");
            htmlReporter.LoadConfig(projectPath + "report-config.xml");
        }

        [SetUp]
        public void Setup()
        {
         driver.Value = Browser.GetDriver();
         _driver = driver.Value;
        }

        [TearDown]
        public void Teardown()
        {
            var currentStatus = TestContext.CurrentContext.Result.Outcome.Status;//current test status(PASS/FAIL/Inclocusive/skipped)
            var currentStackTrace = TestContext.CurrentContext.Result.StackTrace;
            var stackTrace = string.IsNullOrEmpty(currentStackTrace) ? "" : currentStackTrace;
            Status logstatus = Status.Pass;
            String filename;
            DateTime time = DateTime.Now;
            filename = "SShot_" + time.ToString("HH_mm_ss") + testName + ".png";
            switch (currentStatus)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    {
                        logstatus = Status.Fail;
                        var screenshotEntity = MyUtils.CaptureScreenShot(_driver, filename);
                        _test.Log(logstatus,"Fail");
                        _test.Fail("Test failed:", screenshotEntity);
                        break;
                    }
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    {
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Pass");
                        _test.Pass("Test passed:", MyUtils.CaptureScreenShot(_driver, filename));
                        break;
                    }
                case NUnit.Framework.Interfaces.TestStatus.Inconclusive:
                    {
                        logstatus = Status.Warning;
                        _test.Log(logstatus, "Test is inconclusive");
                        break;
                    }
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    {
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test is skipped");
                        break;
                    }
                default:
                    {
                        logstatus = Status.Error;
                        _test.Log(Status.Error, "The test had errors whie running");
                        break;
                    }
            }
            _test.Log(logstatus, "Test" + testName + "was" + logstatus + "\n" + stackTrace);
            _driver.Quit();
        }

        [OneTimeTearDown]
        public void AllTerdown()
        {
            _extent.Flush();
        }
    }
}
