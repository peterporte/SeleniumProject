using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace PageObject
{
    public class ShoppingCartPage
    {
        private IWebDriver _driver;
        public ShoppingCartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public  ShoppingCartPage Open()
        {
            _driver.Navigate().GoToUrl("https://react-shopping-cart-67954.firebaseapp.com/");
            return this;
        }

        public ShoppingCartComponent AddItemToCart()
        {
            _driver.FindElement(By.ClassName("shelf-item__buy-btn")).Click();
            return new ShoppingCartComponent(_driver);
        }
          
    }
}
