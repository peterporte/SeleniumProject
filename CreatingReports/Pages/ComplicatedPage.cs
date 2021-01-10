using System;
using AventStack.ExtentReports;
using MongoDB.Driver;
using NLog;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class ComplicatedPage : BaseApplicationPage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ComplicatedPage(IWebDriver driver) : base(driver)
        {

        }

        public RandomStuffSection RandomStuffSection => new RandomStuffSection(Driver);

        public bool IsLoaded
        {
            get
            {

                var isLoaded = Driver.Url.Contains("complicated-page");
                Reporter.LogTestStepForBugLogger(Status.Info, "Check if the Complicated page loaded successfully.");
                _logger.Trace($"Did complicatted page open successfully=>{isLoaded}");

                return isLoaded;

            }
        }

        

        

        internal void Goto()
        {
            string url = "https://ultimateqa.com/complicated-page";
            Driver.Navigate().GoToUrl(url);
            _logger.Info($"Open Complicated Page=>{url}");
            Reporter.LogPassingTestStepToBugLogger($"In a browser, open Complicated Page page =>{url}");

        }
    }
}