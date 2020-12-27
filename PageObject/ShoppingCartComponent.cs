using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject
{
    public class ShoppingCartComponent
    {
        private readonly IWebDriver _driver;

        public ShoppingCartComponent(IWebDriver driver)
        {
            _driver = driver;
        }

        public int CartQuantity()
        {
            return int.Parse(_driver.FindElement(By.ClassName("bag__quantity")).Text);
        }
    }
}
