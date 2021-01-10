using System;
using CreatingReports.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreatingReports.Tests
{
    [TestClass]
    public class ComplicatedPageFeature : BaseTest
    {
        [TestMethod]
        public void TCID6()
        {
            ComplicatedPage complicatedPage = new ComplicatedPage(Driver);
            complicatedPage.Goto();
            Assert.IsTrue(complicatedPage.IsLoaded, "Complicated page did not load successfully");

            complicatedPage.RandomStuffSection.FillOutFormAndSubmit("pedro", "pedro@porte.com", "Hello");
            Assert.IsTrue(complicatedPage.RandomStuffSection.IsFormSubmitted, "The form was not submitted successfully");




        }
    }
}
