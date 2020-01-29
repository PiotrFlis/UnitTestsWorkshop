using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Workshop;

namespace WorkShop.Tests
{
    [TestClass]
    public class NextNumberByStepTests
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        [DeploymentItem("ShouldAddNumbers.xml"),
        DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "ShouldAddNumbers.xml", "Test", DataAccessMethod.Sequential)]
        [DataRow(1, 2, 3, DisplayName = "add")]
        [DataRow(0, -3, -3, DisplayName = "subtract")]
        public void ShouldAddNumbers()
        {
            int step = Convert.ToInt32(TestContext.DataRow["step"]);
            int previous = Convert.ToInt32(TestContext.DataRow["previous"]);
            int expected = Convert.ToInt32(TestContext.DataRow["expected"]);

            NextNumberByStep next = new NextNumberByStep();
            next.Step = step;

            int newNumber = next.GetNextNumber(previous);

            Assert.AreEqual(expected, step + previous, Convert.ToString(TestContext.DataRow["case"]));
        }
    }
}
