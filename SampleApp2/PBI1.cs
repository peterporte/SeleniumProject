﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleApp2
{
    [TestClass]
    [TestCategory("HomePage")]
    public class PBI1
    {
        [Description("This is the description of the test case")]
        [TestProperty("Author", "PeterPorte")]
        [TestMethod]

        public void TCID1()
        {
        }

        [Description("Another test description")]
        [TestProperty("Author", "PeterPorte")]
        [TestMethod]
        public void TCID2()
        {
        }
    }
}
