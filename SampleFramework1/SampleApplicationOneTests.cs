using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("SampleApplicationOne")]
    public class SampleApplicationOneTests
    {
        private IWebDriver Driver { get; set; }
        internal SampleApplicationPage SampleAppPage { get; private set; }        
        internal TestUser TheTestUser { get;  private set; }
        internal TestUser EmergencyContactUser { get; private set; }

        [TestMethod]
        [Description("Validate that user is able to fill out the form successfully using valid data.")]
        public void Test1()
        {
            SetGenderTypes(Gender.Female, Gender.Female);

            //var sampleApplicationPage = new SampleApplicationPage(Driver);
            //sampleApplicationPage.GoTo();
            SampleAppPage.GoTo();
            SampleAppPage.FilloutEmergencyContact(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible");
        }

       

        [TestMethod]
        [Description("Fake 2nd test.")]
        public void Test2()
        {
            SampleAppPage.GoTo();
            //Assert.IsTrue(SampleAppPage.IsVisible, "Sample application page was not visible");
            SampleAppPage.FilloutEmergencyContact(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }       

        [TestMethod]
        [Description("Validate that when selecting the Other gender type, the form is submitted successfully.")]
        public void Test3()
        {
            SetGenderTypes(Gender.Other, Gender.Other);
            SampleAppPage.GoTo();
            SampleAppPage.FilloutEmergencyContact(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            SampleAppPage = new SampleApplicationPage(Driver);
            Driver = GetChromeDriver();
            TheTestUser = new TestUser();
            TheTestUser.FirstName = "Pedro";
            TheTestUser.LastName = "Porte";

            EmergencyContactUser = new TestUser();
            EmergencyContactUser.FirstName = "Angela";
            EmergencyContactUser.LastName = "Fin";


        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }

        private static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible");
        }

        private static void AssertPageVisibleVariation2(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible");
        }

        private void SetGenderTypes(Gender primaryContact, Gender emergencyContact)
        {
            TheTestUser.GenderType = primaryContact;
            EmergencyContactUser.GenderType = emergencyContact;
        }

       
    }
}
