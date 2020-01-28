using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop
{
    public class NextNumberByStep : INextNumber
    {
        public const int DefaultStep = 10;

        public int Step;

        public NextNumberByStep()
        {
            Step = DefaultStep;
        }

        public int GetNextNumber(int previousNumber)
        {
            return previousNumber + Step;
        }
    }
}
