using AventStack.ExtentReports;
using Microsoft.VisualBasic.FileIO;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace FelicityStore_IrinaOrban
{
    public class MyUtils
    {

        public static IWebElement WaitForElementClick(IWebDriver driver, int seconds, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public static IWebElement WaitForElementVisible(IWebDriver driver, int seconds, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public static bool IsElementPresent(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static bool TryClick(IWebElement element)
        {
            try
            {
                element.Click();

                return true;
            }
            catch (ElementNotInteractableException)
            {
                return false;
            }
        }
        public static IWebElement WaitForFluentElement(IWebDriver driver, int seconds, By locator)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(seconds),
                PollingInterval = TimeSpan.FromMilliseconds(100),
                Message = "Sorry !! The element in the page cannot be found!"
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait.Until(x => x.FindElement(locator));
        }
        public static void PrintCookies(ICookieJar cookies)
        {
            foreach (Cookie c in cookies.AllCookies)
            {
                Console.WriteLine("Cookie name {0} - cookie value {1}", c.Name, c.Value);
            }
        }
        public static void TakeScreenshotWithDate(IWebDriver driver, string path, string fileName, ScreenshotImageFormat format)
        {
            DirectoryInfo validation = new DirectoryInfo(path);
            if (!validation.Exists)
            {
                validation.Create();
            }
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd-T-HH_mm_ss");
            string finalFilePath = String.Format("{0}\\{1}_{2}.{3}", path, fileName, currentDate, format);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(finalFilePath, format);
        }
        public static MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, string name)
        {
            var screenShot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, name).Build();
        }
        public static void ExecuteJSScript(IWebDriver driver, string script)
        {
            var jsExecutor = (IJavaScriptExecutor)driver;
            var result = jsExecutor.ExecuteScript(script);
            if (result != null)
            {
                Console.WriteLine(result.ToString());
            }
        }
        public static Dictionary<string,string> ReadConfig(string confiFilePath)
        {
            var configData = new Dictionary<string, string>();
            foreach(var line in File.ReadAllLines(confiFilePath))
            {
                string[] values = line.Split('=');
                configData.Add(values[0].Trim(), values[1].Trim());
                //sau mai simplu: configData.Add(line.Split('=')[0].Trim(),line.Split('=')[1].Trim());

            }
            return configData;
        }
        public static string[][] GetGenericData(string path)
        {
            var lines = File.ReadAllLines(path).Select(a => a.Split(',')).Skip(1);
            return lines.ToArray();
           
        }
        public static DataTable GetDataTableFromCsv(string csv)
        {
            DataTable dataTable = new DataTable();

            try 
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colunNames = csvReader.ReadFields();
                    foreach (string colum in colunNames)
                        {
                        DataColumn dataColum = new DataColumn();
                            dataColum.AllowDBNull = true;
                            dataTable.Columns.Add(dataColum);
                    }
                    while(!csvReader.EndOfData)
                    {
                        string[] rowValues = csvReader.ReadFields();
                        dataTable.Rows.Add(rowValues);
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Could not read from csv file {0}", csv));
            }
            return dataTable;
        }
        public static DataTable GetDataTableFromExcel(string excelPath )

        {
            DataTable dataTable = new DataTable();
            XSSFWorkbook wb;
            XSSFSheet sh;
            string sheetName;
            using(var fs =new FileStream(excelPath,FileMode.Open, FileAccess.Read))
            {
                wb = new XSSFWorkbook(fs);
                sheetName = wb.GetSheetAt(0).SheetName;
            }

            dataTable.Columns.Clear();
            dataTable.Rows.Clear();

            sh =(XSSFSheet) wb.GetSheet(sheetName);

            int i = 0;

            while (sh.GetRow(i) != null)
            {
                if (dataTable.Columns.Count < sh.GetRow(i).Cells.Count)
                {
                    for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
                    {
                        dataTable.Columns.Add("", typeof(string));
                    }
                }
                dataTable.Rows.Add();
                for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
                {
                    var cell = sh.GetRow(i).GetCell(j);
                    if (cell != null)
                    {
                        switch (cell.CellType)
                        {
                            case NPOI.SS.UserModel.CellType.Numeric:
                                {
                                    dataTable.Rows[i][j] = sh.GetRow(i).GetCell(j).NumericCellValue;
                                    break;
                                }
                            case NPOI.SS.UserModel.CellType.String:
                                {
                                    dataTable.Rows[i][j] = sh.GetRow(i).GetCell(j).StringCellValue;
                                    break;
                                }
                            default:
                                {
                                    dataTable.Rows[i][j] = "";
                                    break;
                                }

                        }

                    }

                }

                i++;

            }

                return dataTable;

        }
        public static T JsonRead<T>(string jsonFile)
        {
            string text = File.ReadAllText(jsonFile);
            return JsonSerializer.Deserialize<T>(text);
        }
        public static List<string> GetAllFilesInFolderExt(string path, string extension)
        {
            List<string> files = new List<string>();
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo fi in di.GetFiles(extension, System.IO.SearchOption.TopDirectoryOnly))
            {
                files.Add(fi.FullName);
            }
            return files;
        }
        public static string Encrypt(string source, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Encoding.UTF8.GetBytes(source);
                    return Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }
        public static string Decrypt(string encrypt, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Convert.FromBase64String(encrypt);
                    return Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }
        public static bool CheckLinkNavigation(IWebElement element, IWebDriver driver, string elementHref)
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool hasError = false;
            var elementTarget = element.GetAttribute("target");
            element.Click();

            if (elementTarget == null || elementTarget == "_self")
            {
                if (elementHref != driver.Url)
                {
                    Console.WriteLine("Href link was {0} and target link was {1}", elementHref, driver.Url);
                    hasError = true;
                }
            }
            else
            {
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                if (elementHref != driver.Url)
                {
                    Console.WriteLine("Href link was {0} and target link was {1}", elementHref, driver.Url);
                    hasError = true;
                }

            }
            return hasError;
        }
        public static string ConvertDictionaryToQuery(Dictionary<string, string> queryParams)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in queryParams.Keys)
            {
                sb.Append(String.Format("&{0}={1}", key, queryParams[key]));
            }
            return sb.ToString();
        }
        public static List<Dictionary<string, string>> ConvertCsvToDictionary(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Select(a => a.Split(','));
            List<Dictionary<string, string>> dictionaryList = new List<Dictionary<string, string>>();
            string[] header = lines.ElementAt(0).ToArray();
            for (int i = 1; i < lines.Count(); i++)
            {
                var currentValues = lines.ElementAt(i).ToArray();
                Dictionary<string, string> queryParams = new Dictionary<string, string>();
                for (int j = 0; j < currentValues.Count(); j++)
                {
                    queryParams.Add(header[j], currentValues[j]);
                }
                dictionaryList.Add(queryParams);
            }
            return dictionaryList;
        }
        public static string GenerateRandomStringCount(int count)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[count];
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            
            return finalString;

        }
        public static string GenerateRandomStringOfNumbersCount(int count)
        {
            var chars = "0123456789";
            var stringChars = new char[count];
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;

        }

    }
}
