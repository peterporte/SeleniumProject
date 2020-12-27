using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverTimeoutsTutorial
{
    [TestClass]
    [TestCategory("Implicit Waits")]
    public class ImplicitWaits
    {
        private IWebDriver _driver;
        [TestInitialize]
        public void SetupBeforeBeforeEveryMethod()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory);
        }

        [TestCleanup]
        public void CleanUpEveryAfterTestMethod()
        {
            _driver.Quit();
        }

        [TestMethod]
        [ExpectedException(typeof(ElementNotVisibleException))]
        public void Test1()
        {
            _driver.Navigate().GoToUrl(URL.SlowAnimationUrl);
            FillOutCreditCardInfo();
            _driver.FindElement(By.Id("go")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }

        private void FillOutCreditCardInfo()
        {
            _driver.FindElement(By.Id("name")).SendKeys("test name");
            _driver.FindElement(By.Id("cc")).SendKeys("1234123412341234");
            _driver.FindElement(By.Id("month")).SendKeys("01");
            _driver.FindElement(By.Id("year")).SendKeys("2020");
        }

        [TestMethod]
        [ExpectedException(typeof(ElementNotVisibleException))]
        public void Test1_FixedImplicitly()
        {
            _driver.Navigate().GoToUrl(URL.SlowAnimationUrl);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FillOutCreditCardInfo();
            _driver.FindElement(By.Id("go")).Click();
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void Test2_ImplicitWaitExample()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.IsTrue(_driver.FindElement(By.Id("success")).Displayed);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementNotInteractableException))]
        public void Test3_ImplicitWait_HiddenElement()
        {
            _driver.Navigate().GoToUrl(URL.HiddenElementUrl);
            SetImplicitWaitAndClick();
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void Test4_ImplicitWait_RenderedAfter()
        {
            _driver.Navigate().GoToUrl(URL.ElementRenderedAfterUrl);
            SetImplicitWaitAndClick();
        }


        private void SetImplicitWaitAndClick()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(By.Id("finish")).Click();
        }

    }
}
