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
    }
}
