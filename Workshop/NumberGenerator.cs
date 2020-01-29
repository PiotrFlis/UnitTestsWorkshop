using System;

namespace Workshop
{
    public class NumberGenerator
    {
        public const int DefaultValue = 0;

        public int Number { get; private set; }

        private readonly INextNumber nextNumberService;

        public NumberGenerator(INextNumber nextNumber)
        {
            this.nextNumberService = nextNumber;

            Number = DefaultValue;
        }

        public int GenerateNextNumber()
        {
            PreviousNumber = Number;
            Number = nextNumberService.GetNextNumber(Number);

            return Number;

        }

        public int PreviousNumber { get; private set; } = DefaultValue;
    }
}
