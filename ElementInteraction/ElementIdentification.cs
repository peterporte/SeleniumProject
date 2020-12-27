using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ElementInteraction
{
    [TestClass]
    public class ElementIdentification
    {

        public IWebDriver driver;
        [TestInitialize]
        public void SetupBeforeBeforeEveryMethod()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(outputDirectory);
        }

        [TestCleanup]
        public void CleanUpEveryAfterTestMethod()
        {
            driver.Quit();
        }


        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            driver.Navigate().Forward();
            driver.Navigate().Back();
            driver.Navigate().Refresh();
        }



        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigationTest()
        {
            //Go here and assert for title - "https://www.ultimateqa.com"
            driver.Navigate().GoToUrl("https://ultimateqa.com");
            Assert.AreEqual("Home - Ultimate QA",driver.Title);

            //Go here and assert for title - "https://www.ultimateqa.com/automation"
            driver.Navigate().GoToUrl("https://ultimateqa.com/Automation");
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);

            //Click link with href - /complicated-page
            driver.FindElement(By.XPath("//*[@href='../complicated-page']")).Click();
            //assert page title 'Complicated Page - Ultimate QA'
            Assert.AreEqual("Complicated Page - Ultimate QA", driver.Title);

            //Go back
            driver.Navigate().Back();
            //assert page title equals - 'Automation Practice - Ultimate QA
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);


        }


        [TestMethod]
        [TestCategory("Manipulation")]
        public void Manipulation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
            //find the name field

            var nameField = driver.FindElement(By.Id("et_pb_contact_name_1"));
            nameField.Clear();
            nameField.SendKeys("test");
            //clear the field
            //type into the field

            //find the text field
            var textBox = driver.FindElement(By.Id("et_pb_contact_message_1"));
            //clear the field
            textBox.Clear();
            //type into the field
            textBox.SendKeys("testing");
            //submit
            var submitButton = driver.FindElements(By.ClassName("et_contact_bottom_container"));
            submitButton[0].Submit();
        }


        [TestMethod]
        [TestCategory("Manipulation")]
        public void ManipulationTest()
        {
            driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms/");

            var nameField2 = driver.FindElement(By.Id("et_pb_contact_name_1"));
            nameField2.Clear();
            nameField2.SendKeys("Test Name 2");

            var textBox2 = driver.FindElement(By.Id("et_pb_contact_message_1"));
            textBox2.Clear();
            textBox2.SendKeys("Test Message 2");

            var num1 = int.Parse(driver.FindElement(By.XPath("//*[@data-first_digit]")).GetAttribute("data-first_digit"));
            var num2 = int.Parse(driver.FindElement(By.XPath("//*[@data-first_digit]")).GetAttribute("data-second_digit"));
            int answer = num1 + num2;
            var captchaBox = driver.FindElement(By.XPath("//*[@class='input et_pb_contact_captcha']"));
            captchaBox.Clear();
            captchaBox.SendKeys(answer.ToString());

            /*
            //alternative to captcha  
            var captcha = _driver.FindElement(By.ClassName("et_pb_contact_captcha_question"));
            var table = new DataTable();
            var captchaAnswer = (int)table.Compute(captcha.Text,"");

            var captchaTextBox = _driver.FindElement(By.XPath("//*[@class='input et_pb_contact_captcha']"));
            captchaTextBox.SendKeys(captchaAnswer.ToString());
             */

            var submitButton = driver.FindElements(By.ClassName("et_contact_bottom_container"));
            submitButton[1].Submit();


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(c => c.FindElement(By.XPath("//*[@class='et-pb-contact-message']/p")));
            var successMsg = driver.FindElement(By.XPath("//*[@class='et-pb-contact-message']/p"));
            Assert.IsTrue(successMsg.Text.Equals("Success"));
        }


        [TestMethod]
        [TestCategory("Driver Interrogation")]
        public void DriverLevelInterrogation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            var x = driver.CurrentWindowHandle;
            var y =driver.WindowHandles;
            x = driver.PageSource;
            x = driver.Title;
            x = driver.Url;
        }


        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void ElementInterrogation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation/");
            var myElement = driver.FindElement(By.XPath("//*[@href='http://courses.ultimateqa.com/users/sign_in']"));
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void ElementInterrogationTest()
        {
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");
            driver.Manage().Window.Maximize();
            var clickMeButton = driver.FindElement(By.Id("button1"));

            var type = clickMeButton.GetAttribute("type");
            Assert.AreEqual("submit", type);

            var cssValue = clickMeButton.GetCssValue("letter-spacing");
            Assert.AreEqual("normal", cssValue);

            Assert.IsTrue(clickMeButton.Displayed);
            Assert.IsTrue(clickMeButton.Enabled);
            Assert.IsFalse(clickMeButton.Selected);
            Assert.AreEqual("Click Me!", clickMeButton.Text);
            Assert.AreEqual("button", clickMeButton.TagName);
            Assert.AreEqual(21, clickMeButton.Size.Height);
            Assert.AreEqual(341, clickMeButton.Location.X);

        }

    }
}
