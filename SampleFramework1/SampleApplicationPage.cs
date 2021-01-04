using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SampleFramework1
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {
       

        public SampleApplicationPage(IWebDriver driver) : base(driver){}



        public bool IsVisible
        {
            get { return Driver.Title.Contains(PageTitle); }

            set { }
        }

        public string PageTitle => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));

        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));

        public IWebElement MaleRadioButton => Driver.FindElement(By.XPath("//*[@value='male']"));

        public IWebElement FemaleRadioButton => Driver.FindElement(By.XPath("//*[@value='female']"));

        public IWebElement OtherRadioButton => Driver.FindElement(By.XPath("//*[@value='other']"));

        public IWebElement MaleEmergencyRadioButton => Driver.FindElement(By.Id("radio2-m"));

        public IWebElement FemaleEmergencyRadioButton => Driver.FindElement(By.Id("radio2-f"));

        public IWebElement OtherEmergencyRadioButton => Driver.FindElement(By.Id("radio2-o"));

        public IWebElement FirstNameEmergencyField => Driver.FindElement(By.Id("f2"));

        public IWebElement LastNameEmergencyField => Driver.FindElement(By.Id("l2"));

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-4/");
            Assert.IsTrue(IsVisible,
                $"Sample application page was not visible. Expected=>{PageTitle}." +
                $"Actual=>{Driver.Title}");
        }

        internal UltimateQAHomePage FillOutPrimaryContactFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Click();
            return new UltimateQAHomePage(Driver);
        }

        internal void FilloutEmergencyContact(TestUser emergencyContact)
        {
            SetEmergencyGender(emergencyContact);
            FirstNameEmergencyField.SendKeys(emergencyContact.FirstName);
            LastNameEmergencyField.SendKeys(emergencyContact.LastName);
            
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    MaleRadioButton.Click();
                    break;
                case Gender.Female:
                    FemaleRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherRadioButton.Click();
                    break;
                default:
                    break;
            }
        }

        private void SetEmergencyGender(TestUser emergencyContact)
        {
            switch (emergencyContact.GenderType)
            {
                case Gender.Male:
                    MaleEmergencyRadioButton.Click();
                    break;
                case Gender.Female:
                    FemaleEmergencyRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherEmergencyRadioButton.Click();
                    break;
                default:
                    break;
            }
        }

       
    }
}