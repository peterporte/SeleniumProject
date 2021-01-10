using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CreatingReports.Pages
{
    public class SignInPage : BaseApplicationPage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public SignInPage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsLoaded
        {
            get
            {
                
                    var isLoaded = Driver.Url.Contains("controller=authentication");
                    Reporter.LogTestStepForBugLogger(Status.Info, "Check if the Sign In page loaded successfully.");
                    _logger.Trace($"Did sign in page open successfully=>{isLoaded}");
                    
                    return isLoaded;
   
            }
        }



    }
}