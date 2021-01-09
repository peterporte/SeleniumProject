using System;
using CreatingReports.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreatingReports.Tests
{
    [TestClass]
    public class SliderFeature : BaseTest
    {
        [TestMethod]
        [Description("Validate that slider changes images")]
        [TestProperty("Author", "PeterPorte")]
        public void TCID3()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            var currentImage = homePage.Slider.CurrentImage;
            homePage.Slider.ClickNextButton();
            var newImage = homePage.Slider.CurrentImage;
            //Assert.AreNotEqual(currentImage, newImage); 
            homePage.Slider.AssertThatImageChanged(currentImage, newImage);



        }
    }
}
