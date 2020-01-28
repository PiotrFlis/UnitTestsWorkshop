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
        public void ShouldUseDefaultStep()
        {
            //given
            NumberGenerator generator = new NumberGenerator();

            //when
            int nextNumber = generator.GenerateNextNumber();

            //then
            int expectedNextValue = NumberGenerator.DefaultValue + NumberGenerator.DefaultStep;
            Assert.AreEqual(expectedNextValue, nextNumber);
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
    }
}

