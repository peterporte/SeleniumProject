using System;
using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class HomePage : BaseApplicationPage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    

        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
            Header = new HeaderSection(driver);
            
            
        }

        public Slider Slider { get; internal set; }
        public HeaderSection Header { get; set; }
        //public HeaderSection Header => new HeaderSection(Driver);



        public IWebElement searchBox => Driver.FindElement(By.Id("search_query_top"));

        public IWebElement submitButton => Driver.FindElement(By.Name("submit_search"));

        public bool IsLoaded
        {

            get
            {
                var isLoaded = Driver.Url.Contains("http://automationpractice.com/index.php");
                Reporter.LogTestStepForBugLogger(Status.Info, "Validate whether the Home Page loaded successfully.");
                _logger.Trace($"Home page is loaded=>{isLoaded}");
                return isLoaded;
            }
        }



        internal void GoTo()
        {
            var url = "http://automationpractice.com/index.php";
            Driver.Navigate().GoToUrl(url);
            _logger.Info($"Open url=>{url}");
            Reporter.LogPassingTestStepToBugLogger($"In a browser, go to url=>{url}");
        }

       
        internal SearchPage Search(string itemToSearchFor)  
        {
            _logger.Trace("Attempting to perform a Search.");
            searchBox.SendKeys(itemToSearchFor);
            submitButton.Click();
            Reporter.LogTestStepForBugLogger(Status.Info,
                $"Search for=>{itemToSearchFor} in the search bar on the page.");
            //_logger.Info($"Search for an item in the search bar=>{itemToSearchFor}");
            return new SearchPage(Driver);
        }
    }
}