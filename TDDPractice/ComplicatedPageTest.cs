using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace TDDPractice
{
    [TestClass]
    [TestCategory("TDDPractice")]
    public class ComplicatedPageTest
    {

        [TestMethod]
        public void Test1()
        {
            var driver = new ChromeDriver();
            var complicatedPage = new complicatedPage(driver);
            complicatedPage.Open();
            complicatedPage.Search("automation testing");
            Assert.IsTrue(complicatedPage.AreResultsReturned());

            driver.Quit();

        }

    }

        
}
