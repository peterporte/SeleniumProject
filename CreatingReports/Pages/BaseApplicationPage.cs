using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingReports.Pages
{
    public class BaseApplicationPage
    {


        protected IWebDriver Driver { get; set; }


        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}


