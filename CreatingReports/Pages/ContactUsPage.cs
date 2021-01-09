using System;
using NLog;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;

namespace CreatingReports.Pages
{
    internal class ContactUsPage : BaseApplicationPage
    {

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public ContactUsPage(IWebDriver driver) :base(driver) { }

        //public bool IsLoaded => Driver.FindElement(By.Id("center_column")).Displayed;

        public bool IsLoaded
        {
            get
            {
                try
                {

                    Reporter.LogTestStepForBugLogger(Status.Info,
                        "Validate that Contact Us page loaded successfully.");
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                    return Driver.FindElement(By.Id("center_column")).Displayed;
                    
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                
            }
        }


        internal void GoTo()
        {
            string url = "http://automationpractice.com/index.php?controller=contact";
            Driver.Navigate().GoToUrl(url);
            _logger.Info($"Open Contact Us=>{url}");
            Reporter.LogPassingTestStepToBugLogger($"In a browser, open contact us page =>{url}");
        }
    }
}