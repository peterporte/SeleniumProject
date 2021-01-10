using System;
using System.IO;
using System.Reflection;
using CreatingReports.Pages;
using CreatingReports.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CreatingReports.Tests
{
    [TestClass]
    [TestCategory("Contact Us Page"), TestCategory("Sample app 2")]
    public class ContactUsFeature : BaseTest
    {
        

        [TestMethod]
        [TestProperty("Author", "PeterPorte")]
        [Description("Validate that Contact Us page opens successfully")]
        public void TCID2()
        {
            ContactUsPage contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();
            Assert.IsTrue(contactUsPage.IsLoaded, "Contact Us page did not load successfully");
        }



        [TestMethod]
        [TestProperty("Author", "PeterPorte")]
        [Description("Validate that the contact us page opens when clicking the Contact Us link.")]
        public void TCID4()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            var contactUsPage = homePage.Header.ClickContactUsLink();
            Assert.IsTrue(contactUsPage.IsLoaded, "The contact us page did not open successfully.");
        }

        public void TCID5()
        {
           
        }

        
        public void TCID7()
        {
           
        }




    }
}
