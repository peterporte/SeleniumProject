using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PageObject
{
    [TestClass]
    public class Autotest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [TestInitialize]
        public void SetupBeforeBeforeEveryMethod()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        [TestCleanup]
        public void CleanUpEveryAfterTestMethod()
        {
            _driver.Quit();
        }


        private static void GoToUrl(IWebDriver _driver)
        {
            _driver.Navigate().GoToUrl("https://react-shopping-cart-67954.firebaseapp.com/");
        }

        private static void ClickButton(IWebDriver _driver, By className)
        {
                _driver.FindElement(className).Click();
        }

        private static string getText(IWebDriver _driver, By className)
        {

           return _driver.FindElement(className).Text;
        }


        [TestMethod]
        public void Test1()
        {
            GoToUrl(_driver);
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("shelf-item__buy-btn")));
            ClickButton(_driver, By.ClassName("shelf-item__buy-btn"));
            _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("bag__quantity")));
            var bagQuantity = getText(_driver, By.ClassName("bag__quantity"));
            Assert.AreEqual(1, int.Parse(bagQuantity));
        }


        [TestMethod]
        public void Test2()
        {
            var theShoppingCart = new ShoppingCartPage(_driver).Open().AddItemToCart();
            Assert.AreEqual(1, theShoppingCart.CartQuantity());
        }

    }
}
