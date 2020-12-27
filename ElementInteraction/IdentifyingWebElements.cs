using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ElementInteraction
{
    [TestClass]
    public class IdentifyingWebElements
    {

        public IWebDriver Driver { get; private set; }
        [TestInitialize]
        public void SetupBeforeEveryTestMethod()
        {
            
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }
        [TestCleanup]
        public void CleanupAfterEveryTestMethod()
        {
            //If driver is not null, then Quit()
            //always check for null driver in the TestCleanup first
            //Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }

        //[TestMethod]
        //public void TestMethod1()
        //{

        //    Driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");
            

            //Driver.FindElements(By.ClassName("et_pb_blurb_description"))[4].Click();

            //var text = Driver.FindElement(By.ClassName("entry-title"));
            //Assert.AreEqual(text.Text, "Link Success");

        //}




        private void HighlightElementUsingJavaScript(By locationStrategy, int duration = 2)
        {
            var element = Driver.FindElement(locationStrategy);
            var originalStyle = element.GetAttribute("style");
            IJavaScriptExecutor JavaScriptExecutor = Driver as IJavaScriptExecutor;
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                "border: 7px solid yellow; border-style: dashed;");

            if (duration <= 0) return;
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                originalStyle);
        }


        [TestMethod]
        public void DifferentTypesOfSeleniumLocationStrategies()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            HighlightElementUsingJavaScript(By.ClassName("buttonClass"));
            HighlightElementUsingJavaScript(By.Id("idExample"));
            HighlightElementUsingJavaScript(By.LinkText("Click me using this link text!"));
            HighlightElementUsingJavaScript(By.Name("button1"));
            HighlightElementUsingJavaScript(By.PartialLinkText("link text!"));
            HighlightElementUsingJavaScript(By.TagName("div"));
            HighlightElementUsingJavaScript(By.CssSelector("#idExample"));
            HighlightElementUsingJavaScript(By.CssSelector(".buttonClass"));
            HighlightElementUsingJavaScript(By.XPath("//*[@id='idExample']"));
            HighlightElementUsingJavaScript(By.XPath("//*[@class='buttonClass']"));
        }

        [TestMethod]
        public void SeleniumLocationStrategiesQuiz()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            var link = Driver.FindElements(By.ClassName("et_pb_blurb_description"))[4];
            HighlightElementUsingJavaScript(By.Id("simpleElementsLink"));
            HighlightElementUsingJavaScript(By.LinkText("Click this link"));
            HighlightElementUsingJavaScript(By.Name("clickableLink"));
            HighlightElementUsingJavaScript(By.PartialLinkText("Click this l"));
            HighlightElementUsingJavaScript(By.TagName("a"));
            HighlightElementUsingJavaScript(By.CssSelector("#simpleElementsLink"));
            HighlightElementUsingJavaScript(By.XPath("//*[@id='simpleElementsLink']"));

                
        }


        [TestMethod]
        public void SeleniumElementLocationExam()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");
            Driver.FindElement(By.XPath("//*[@value='male']")).Click();

            Driver.FindElement(By.XPath("//*[@type='checkbox'][@value='Bike']")).Click();

            Driver.FindElement(By.TagName("select")).Click();
            Driver.FindElement(By.XPath("//select/option[@value='audi']")).Click();

            Driver.FindElement(By.XPath("//*[contains(text(), 'Tab 2')]")).Click();
            var tab2 = Driver
                .FindElement(By.XPath("//*[@class='et_pb_tab_content'][contains(text(), 'Tab 2 content')]")).Text;
            Assert.AreEqual(tab2, "Tab 2 content");

            HighlightElementUsingJavaScript(By.XPath("//*[@id='htmlTableId']//td[contains(text(), '$150,000+')]"));

            HighlightElementUsingJavaScript(By.XPath("//*[@class='et_pb_column et_pb_column_1_3 et_pb_column_10  et_pb_css_mix_blend_mode_passthrough']"));



        }
    }
}
