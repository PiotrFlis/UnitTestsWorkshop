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
            previousNumber = Number;
            Number = nextNumberService.GetNextNumber(Number);

            return Number;
        }

        private int? previousNumber = null;

        public int PreviousNumber
        {
            get
            {
                if (previousNumber == null)
                {
                    throw new InvalidOperationException("No number generated yet");
                }

                return (int)previousNumber;
            }

            private set { previousNumber = value; }
        }
    }
}
