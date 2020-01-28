using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Workshop;

namespace WorkShop.Tests
{
    [TestClass]
    public class NumberGeneratorTests
    {
        INextNumber nextNumberService;
        Mock<INextNumber> StepOperationMock { get; set; }



        [TestInitialize]
        public void TestInitialize()
        {
            StepOperationMock = new Mock<INextNumber>();
            nextNumberService = StepOperationMock.Object;
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
        [Ignore("This test is no longer valid for the class")]
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
            //given
            NumberGenerator generator = new NumberGenerator(nextNumberService);

            //when
            int previousValue = generator.PreviousNumber;

            Assert.Fail("No exception thrown");
        }

        [TestMethod]
        public void ShouldUseServiceToGenerateNumber()
        {
            NumberGenerator generator = new NumberGenerator(nextNumberService);

            generator.GenerateNextNumber();

            StepOperationMock.Verify(op => op.GetNextNumber(NumberGenerator.DefaultValue), Times.Once);
        }

        [TestMethod]
        public void ShouldGenerateNumber()
        {
            NumberGenerator generator = new NumberGenerator(nextNumberService);
            int expectedNumber = 432;
            StepOperationMock.Setup(op => op.GetNextNumber(It.IsAny<int>())).Returns(expectedNumber);

            int generatedNumber = generator.GenerateNextNumber();

            Assert.AreEqual(expectedNumber, generatedNumber);
        }

        [TestMethod]
        public void ShouldGenerateNumberUsingPrevious()
        {
            NumberGenerator generator = new NumberGenerator(nextNumberService);
            int firstNumber = 432;
            int secondNumber = 345;

            StepOperationMock.Setup(op => op.GetNextNumber(NumberGenerator.DefaultValue)).Returns(firstNumber);
            StepOperationMock.Setup(op => op.GetNextNumber(firstNumber)).Returns(secondNumber);

            generator.GenerateNextNumber();
            int generatedNumber = generator.GenerateNextNumber();

            StepOperationMock.Verify(op => op.GetNextNumber(NumberGenerator.DefaultValue), Times.Once);
            StepOperationMock.Verify(op => op.GetNextNumber(firstNumber), Times.Once);
            Assert.AreEqual(secondNumber, generatedNumber);
        }

        [TestMethod]
        public void ShouldGenerateNumberUsingDefault()
        {
            NumberGenerator generator = new NumberGenerator(nextNumberService);
            StepOperationMock.Setup(op => op.GetNextNumber(NumberGenerator.DefaultValue));

            generator.GenerateNextNumber();

            StepOperationMock.Verify(op => op.GetNextNumber(NumberGenerator.DefaultValue), Times.Once);
        }

        [TestMethod]
        public void ShouldGenerateNumberProperNUmberOfTimes()
        {
            NumberGenerator generator = new NumberGenerator(nextNumberService);
            int numberCount = 0;
            int generatorCalls = 234;
            StepOperationMock.Setup(op => op.GetNextNumber(It.IsAny<int>()))
                .Callback(() => numberCount++ );

            for (int i = 0; i < generatorCalls; i++)
            {
                generator.GenerateNextNumber();
            }

            Assert.AreEqual(generatorCalls, numberCount);

            StepOperationMock.Verify(op => op.GetNextNumber(NumberGenerator.DefaultValue), Times.Exactly(numberCount));
        }
    }
}

