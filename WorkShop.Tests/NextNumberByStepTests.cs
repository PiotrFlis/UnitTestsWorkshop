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
        public void ShouldUseDefaultStep()
        {
            //given
            NextNumberByStep next = new NextNumberByStep();
            int previousNumber = 0;

            //when
            int nextNumber = next.GetNextNumber(previousNumber);

            //then
            int expectedNextValue = previousNumber + NextNumberByStep.DefaultStep;
            Assert.AreEqual(expectedNextValue, nextNumber);
        }

        [TestMethod]
        public void ShouldGenerateCorrectNumber()
        {
            //given
            NextNumberByStep next = new NextNumberByStep();
            int previousNumber = 0;
            next.Step = 23;

            //when
            int nextNumber = next.GetNextNumber(previousNumber);

            //then
            Assert.AreEqual(previousNumber + next.Step, nextNumber);
        }

        [TestMethod]
        [DataRow(1, 2, 3, DisplayName = "add")]
        [DataRow(0, -3, -3, DisplayName = "subtract")]
        public void ShouldAddNumbers(int step, int previous, int expected)
        {
            NextNumberByStep next = new NextNumberByStep();
            next.Step = step;

            int newNumber = next.GetNextNumber(previous);

            Assert.AreEqual(expected, step + previous);
        }
    }
}
