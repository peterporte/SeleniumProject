using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UserInteraction
{
    [TestFixture]
    public class InteractionsDemo
    {
        private ChromeDriver _driver;
        private Actions _action;
        private WebDriverWait _wait;
        [Test]
        public void DragAndDrop1()
        {
 

            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            _action.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);

            

        }
        [Test]
        public void DragAndDrop2()
        {


            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));

            var drag = _action.ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Release(targetElement)
                .Build();

            drag.Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);

        }


        [Test]
        public void DragAndDropQuiz()
        {


            _driver.Navigate().GoToUrl("http://www.pureexample.com/jquery-ui/basic-droppable.html");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ExampleFrame-94")));

            IWebElement sourceElement = _driver.FindElement(By.XPath("//*[@class='square ui-draggable']"));
            IWebElement targetElement = _driver.FindElement(By.XPath("//*[@class='squaredotted ui-droppable']"));
            IWebElement status = _driver.FindElementById("info");

            _action.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("dropped!", status.Text);

        }

        [Test]
        public void ResizingExample()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement resizeHandle =
                _driver.FindElement(By.XPath(
                    "//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"));

            _action.ClickAndHold(resizeHandle).MoveByOffset(100, 100).Perform();

            Assert.IsTrue(_driver.FindElementByXPath("//*[@id='resizable'][@style]").Displayed);

        }

        [Test]
        public void OpenNetworkTabInFirefoxExample()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _action.KeyDown(Keys.Control).KeyDown(Keys.Shift).SendKeys("q").Perform();

            _action.KeyUp(Keys.Control).KeyUp(Keys.Shift).Perform();

            _driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");

        }


        [Test]
        public void DragAndDropHtml5_Quiz()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("column-a")));

            IWebElement boxA = _driver.FindElement(By.Id("column-a"));
            IWebElement boxB = _driver.FindElement(By.Id("column-b"));

            var jsFile = File.ReadAllText(@"C:\Users\pporte\source\repos\SeleniumProject\UserInteraction\drag_and_drop_helper.js");
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            js.ExecuteScript(jsFile + "$('#column-a').simulateDragDrop({ dropTarget: '#column-b'});");


            var newColumn2 = _driver.FindElement(By.XPath("//*[@id='column-b']/header")).Text;
            Assert.AreEqual("A", newColumn2);


        }

        [SetUp]
        public void Setup()
        {
            
            _driver = new ChromeDriver();
            _action = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(6));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();

        }
    }
}
