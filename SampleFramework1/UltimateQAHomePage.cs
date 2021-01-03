using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SampleFramework1
{
    internal class UltimateQAHomePage : BaseSampleApplicationPage
    {
        public UltimateQAHomePage(IWebDriver driver) : base(driver) { }

        //public bool IsVisible => HomePageHeader.Displayed;

        //public IWebElement HomePageHeader =>
        //    Driver.FindElement(By.XPath("//*[contains(text(),'Master test Automation, Faster.')]"));



        public bool IsVisible
        {
            get
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                    IWebElement HomePageHeader = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Master test Automation, Faster.')]")));
                    return HomePageHeader.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
    }
}