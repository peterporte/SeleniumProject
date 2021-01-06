using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SampleApp2
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

        
        

    }
}
