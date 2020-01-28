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

        [TestMethod]
        public void ShouldGenerateCorrectNumber()
        {
            //given
            NumberGenerator generator = new NumberGenerator();
            generator.Step = 23;

            //when
            int nextValue = generator.GenerateNextNumber();
            
            //then
            Assert.AreEqual(NumberGenerator.DefaultValue + generator.Step, nextValue);
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

            //when
            int previousValue = generator.PreviousNumber;

            //then
            Assert.AreEqual(NumberGenerator.DefaultValue, previousValue);
        }
    }
}

