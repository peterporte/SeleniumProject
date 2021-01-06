using System;
using OpenQA.Selenium;

namespace SampleApp2
{
    public class HomePage : BaseApplicationPage
    {
        
        

        public HomePage(IWebDriver driver) : base(driver) { }


        public IWebElement searchBox => Driver.FindElement(By.Id("search_query_top"));

        public IWebElement submitButton => Driver.FindElement(By.Name("submit_search"));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
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
            searchBox.SendKeys(itemToSearchFor);
            submitButton.Click();
            return new SearchPage(Driver);
        }
    }
}