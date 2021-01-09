using System;
using System.IO;
using System.Reflection;
using CreatingReports.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CreatingReports.Tests
{
    [TestClass]
    [TestCategory("Contact Us Page"), TestCategory("Sample app 2")]
    public class SearchFunctionality : BaseTest
    {
      

        [Description("Checks to make sure that if we search for browser, that browser comes back.")]
        [TestProperty("Author", "PeterPorte")]
        [TestMethod]
        public void TCID1()
        {
            var itemToSearchFor = "Blouse";

            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            Wait.Until(ExpectedConditions.ElementExists(By.Id("search_query_top")));
            SearchPage searchPage = homePage.Search(itemToSearchFor);
            Assert.IsTrue(searchPage.Contains(Item.Blouse),
                $"When searching for the string=>{itemToSearchFor}, " +
                $"we did not find it in the search results.");

        }


   
    }
}
