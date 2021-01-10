using System;
using CreatingReports.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreatingReports.Tests
{
    [TestClass]
    public class SignInFunctionality : BaseTest
    {
        [TestMethod]
        [TestProperty("Author", "PeterPorte")]
        public void TCID5()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.IsTrue(homePage.IsLoaded, "Home page did not open successfully");

            var signInPage = homePage.Header.ClickSignInLink();
            Assert.IsTrue(signInPage.IsLoaded, "Sign in page did not open sucessfully.");

        }
    }
}
