using System;
using OpenQA.Selenium;

namespace SampleApp2
{
    internal class ContactUsPage : BaseApplicationPage
    {
        

        public ContactUsPage(IWebDriver driver) :base(driver) { }

        //public bool IsLoaded => Driver.FindElement(By.Id("center_column")).Displayed;

        public bool IsLoaded
        {
            get
            {
                try
                {
                    return Driver.FindElement(By.Id("center_column")).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                
            }
        }


        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");
        }
    }
}