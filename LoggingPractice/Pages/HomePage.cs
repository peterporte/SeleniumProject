using System;
using NLog;
using OpenQA.Selenium;

namespace SampleApp2
{
    public class HomePage : BaseApplicationPage
    {

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        public Slider Slider { get; internal set; }


        public IWebElement searchBox => Driver.FindElement(By.Id("search_query_top"));

        public IWebElement submitButton => Driver.FindElement(By.Name("submit_search"));

        

        internal void GoTo()
        {
            var url = "http://automationpractice.com/index.php";
            Driver.Navigate().GoToUrl(url);
            _logger.Info($"Open url=>{url}");
        }

        //internal void Search(string item)
        //{
        //    //Driver.FindElement(By.Id("search_query_top")).SendKeys(item);
        //    searchBox.SendKeys(item);
        //    //Driver.FindElement(By.Name("submit_search")).Click();
        //    submitButton.Click();
        //}

        internal SearchPage Search(string itemToSearchFor)
        {
            _logger.Trace("Attempting to perform a Search.");
            searchBox.SendKeys(itemToSearchFor);
            submitButton.Click();
            _logger.Info($"Search for an item in the search bar=>{itemToSearchFor}");
            return new SearchPage(Driver);
        }
    }
}