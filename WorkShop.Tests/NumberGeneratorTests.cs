using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Workshop;

namespace WorkShop.Tests
{
    [TestClass]
    public class NumberGeneratorTests
    {
        INextNumber nextNumberService;

        [TestInitialize]
        public void TestInitialize()
        {
            nextNumberService = new NextNumberByStep();
        }

        [TestMethod]
        public void ShouldHaveDefaultValue0()
        {
            NumberGenerator generator = new NumberGenerator(nextNumberService);

            int expectedDefaultValue = NumberGenerator.DefaultValue;
            Assert.AreEqual(expectedDefaultValue, generator.Number);
        }

        [TestMethod]
        public void ShouldGetPreviousNumber()
        {
            //given
            NumberGenerator generator = new NumberGenerator(nextNumberService);
            int expectedPreviousValue = generator.Number;

            //when
            generator.GenerateNextNumber();
            int previousValue = generator.PreviousNumber;

            //then
            Assert.AreEqual(expectedPreviousValue, previousValue);
        }

        [TestMethod]
        public void ShouldNumberEqualToGenerated()
        {
            //given
            NumberGenerator generator = new NumberGenerator(nextNumberService);
            int generatedValue = generator.GenerateNextNumber();

            //when
            int nextValue = generator.Number;

            //then
            Assert.AreEqual(generatedValue, nextValue);
        }


        [TestMethod]
        public void ShouldGetDefaultValueAsPreviousIfNothingGenerated()
        {
            //given
            NumberGenerator generator = new NumberGenerator(nextNumberService);

            //when
            int previousValue = generator.PreviousNumber;

            //then
            Assert.AreEqual(NumberGenerator.DefaultValue, previousValue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionWhenGetPreviousAndNothingGenerated()
        {
            Assert.Fail();
        }
    }
}

