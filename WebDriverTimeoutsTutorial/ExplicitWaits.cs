using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WebDriverTimeoutsTutorial
{
    [TestClass]
    [TestCategory("Explicit Waits")]
    public class ExplicitWaits
    {
        private IWebDriver _driver;
        By ElementToWaitFor = By.Id("finish");

        [TestInitialize]
        public void SetupBeforeBeforeEveryMethod()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory);
        }

        [TestCleanup]
        public void CleanUpEveryAfterTestMethod()
        {
            //_driver.Quit();
        }

        [TestMethod]
        public void ExplicitWait1()
        {
            Thread.Sleep(1000);
        }
        [TestMethod]
        public void ExplicitWait2()
        {
            _driver.Navigate().GoToUrl(URL.HiddenElementUrl);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement element = wait.Until((d) =>
            {
                return d.FindElement(By.Id("finish"));
            });
        }
        [TestMethod]
        public void Test1_FixedExplicitly()
        {
            _driver.Navigate().GoToUrl(URL.SlowAnimationUrl);
            FillOutCreditCardInfo();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("go"))).Click();
            Assert.IsTrue(wait.Until(ExpectedConditions.ElementIsVisible(By.Id("success"))).Displayed);
        }

        [TestMethod]
        public void Test3_ExplicitWait_HiddenElement()
        {
            _driver.Navigate().GoToUrl(URL.HiddenElementUrl);
            _driver.FindElement(By.XPath("//button[contains(text(),'Start')]")).Click();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(ElementToWaitFor)).Click();
        }
        [TestMethod]
        public void Test4_ExplicitWait_RenderedAfter()
        {
            _driver.Navigate().GoToUrl(URL.ElementRenderedAfterUrl);
            _driver.FindElement(By.XPath("//button[contains(text(),'Start')]")).Click();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(ElementToWaitFor)).Click();
        }

        [TestMethod]
        public void HowToCorrectlySynchronize()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            _driver.Manage().Window.Maximize();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var firstSyncElement = By.XPath("//*[@class='wp-image-10670 jetpack-lazy-image lazyloaded jetpack-lazy-image--handled']");
            wait.Until(ExpectedConditions.ElementIsVisible(firstSyncElement));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Automation Exercises"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='Automation Practice']")));
            _driver.FindElement(By.LinkText("Big page with many elements")).Click();

            var finalElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=' ls-is-cached lazyloaded']")));
            Assert.IsTrue(finalElement.Displayed);

        }


        private void FillOutCreditCardInfo()
        {
            _driver.FindElement(By.Id("name")).SendKeys("test name");
            _driver.FindElement(By.Id("cc")).SendKeys("1234123412341234");
            _driver.FindElement(By.Id("month")).SendKeys("01");
            _driver.FindElement(By.Id("year")).SendKeys("2020");
        }

        
    }
}
