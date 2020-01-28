using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop;

namespace WorkShop.Tests
{
    [TestClass]
    public class NumberGeneratorTests
    {
        [TestMethod]
        public void ShouldHaveDefaultValue0()
        {
            NumberGenerator generator = new NumberGenerator();

            int expectedDefaultValue = NumberGenerator.DefaultValue;
            Assert.AreEqual(expectedDefaultValue, generator.Number);
        }

        [TestMethod]
        public void ShouldGetLastNumber()
        {
            //given
            NumberGenerator generator = new NumberGenerator();
            int expectedNextValue = generator.GenerateNextNumber();

            //when
            int lastValue = generator.Number;

            //then
            Assert.AreEqual(expectedNextValue, lastValue);
        }

        [TestMethod]
        public void ShouldGetPreviousNumber()
        {
            //given
            NumberGenerator generator = new NumberGenerator();
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
            NumberGenerator generator = new NumberGenerator();
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
            NumberGenerator generator = new NumberGenerator();
            int expectedPreviousValue = generator.Number;

            //when
            int previousValue = generator.PreviousNumber;

            //then
            Assert.AreEqual(expectedPreviousValue, previousValue);
        }
    }
}

