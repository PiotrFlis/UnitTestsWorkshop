using System;

namespace Workshop
{
    public class NumberGenerator
    {
        public const int DefaultValue = 0;
        public const int DefaultStep = 10;

        public int Number { get; private set; }
        
        public NumberGenerator()
        {
            Number = DefaultValue;
            Step = DefaultStep;
        }
        
        public int Step;

        public int GenerateNextNumber()
        {
            PreviousNumber = Number;
            Number += Step;
            return Number;
        }

        public int PreviousNumber { get; private set; } = DefaultValue;
    }
}
