using System;
using System.Collections.Generic;
using System.Text;

namespace Molmed.LargeFileTool.Data
{
    public class ReadCriteria
    {
        private int MyFirstOccurenceValue;
        private int MySecondOccurenceValue;

        public ReadCriteria()
        {
            MyFirstOccurenceValue = -1;
            MySecondOccurenceValue = -1;
        }

        public ReadCriteria(int firstCriteria, int secondCriteria)
        {
            MyFirstOccurenceValue = firstCriteria;
            MySecondOccurenceValue = secondCriteria;
        }

        public bool ContainSegment(int number)
        {
            return (number >= MyFirstOccurenceValue && number < MySecondOccurenceValue);
        }

        public bool IsInBetween(int number)
        {
            return (number > MyFirstOccurenceValue && number < MySecondOccurenceValue);
        }

        public bool IsNested(int first, int second)
        {
            return (IsInBetween(first) || IsInBetween(second) || IsOverlapping(first, second));
        }

        public bool IsOverlapping(int first, int second)
        {
            return (first <= MyFirstOccurenceValue && second >= MySecondOccurenceValue);
        }

        public int GetFirstOccurence()
        {
            return MyFirstOccurenceValue;
        }

        public int GetSecondOccurence()
        {
            return MySecondOccurenceValue;
        }
    }
}
