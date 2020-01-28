using System;

namespace Workshop
{
    public class NumberGenerator
    {
        public const int DefaultValue = 0;
        public const int DefaultStep = 10;

        public int Number { get; private set; }

        private readonly INextNumber nextNumberService;

        public NumberGenerator(INextNumber nextNumber)
        {
            this.nextNumberService = nextNumber;

            Number = DefaultValue;
            Step = DefaultStep;
        }
        
        public int Step;

        public int GenerateNextNumber()
        {
            int newNumber = nextNumberService.GetNextNumber(PreviousNumber);
            PreviousNumber = Number;
            Number = newNumber;

            return Number;
        }

        public int PreviousNumber { get; private set; } = DefaultValue;
    }
}
