using System;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    public class HeaderSection : BaseApplicationPage
    {
        

        public HeaderSection(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ContactUsLink =>
            Driver.FindElement(By.XPath("//div[@id='contact-link']/a[@title='Contact Us']"));

        public IWebElement SignInLink => Driver.FindElement(By.ClassName("login"));

        internal ContactUsPage ClickContactUsLink()
        {
            ContactUsLink.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the Contact Us link on the header");
            return new ContactUsPage(Driver);
        }

        internal SignInPage ClickSignInLink()
        {
            SignInLink.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the Sign In link on the header");
            return new SignInPage(Driver);
        }
    }
}