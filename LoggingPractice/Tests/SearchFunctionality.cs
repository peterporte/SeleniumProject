using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleApp2
{
    [TestClass]
    [TestCategory("Contact Us Page"), TestCategory("Sample app 2")]
    public class SearchFunctionality
    {
        public IWebDriver Driver { get; private set; }
        

        private WebDriverWait wait;


        [Description("Checks to make sure that if we search for browser, that browser comes back.")]
        [TestProperty("Author", "PeterPorte")]
        [TestMethod]
        public void TCID1()
        {
            //Sample without using BaseTest inheritanc
            var itemToSearchFor = "Blouse";

            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            //wait.Until(ExpectedConditions.ElementExists(By.Id("search_query_top")));
            SearchPage searchPage = homePage.Search(itemToSearchFor);
            Assert.IsTrue(searchPage.Contains(Item.Blouse),
                $"When searching for the string=>{itemToSearchFor}, " +
                $"we did not find it in the search results.");

        }


        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            
            Driver = GetChromeDriver();
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }
    }
}
