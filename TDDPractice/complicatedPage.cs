using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TDDPractice
{
    class complicatedPage
    {
        public IWebDriver Driver;
        private WebDriverWait wait;

        public complicatedPage(IWebDriver driver)
        {
            Driver = driver;
        }

        internal void Open()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/complicated-page/");
        }

        internal void Search(string searchTerm)
        { 
            Driver.FindElement(By.Id("s")).SendKeys(searchTerm);
            Driver.FindElement(By.Id("searchsubmit")).Click();
        }


        internal AmazonSearchPage SearchUsingAmazon(string searchTerm)
        {
            var searchBar = Driver.FindElement(By.ClassName("amzn-native-search"));
            searchBar.SendKeys(searchTerm);
            Driver.FindElement(By.ClassName("amzn-native-search-go")).Click();

            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            return new AmazonSearchPage(Driver);
        }

        internal void SearchArticles(string searchTerm)
        {
            Driver.Manage().Window.Maximize();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var searchBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#s")));
            searchBox.Click();
            searchBox.SendKeys(searchTerm);
        }



        internal bool AreResultsReturned()
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var searchResults = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[starts-with(text(), 'Found')]")));
            return searchResults.Displayed;
        }
    }
}
