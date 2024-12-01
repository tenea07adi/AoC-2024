using AoC_2024.Helpers;

namespace AoC_2024.Logic
{
    public class Day01 : PuzzleLogicTemplate
    {
        public Day01() : base(1)
        {
        }

        protected override string LogicPart1(string data)
        {
            var inputsAsList = StringHelper.ExplodeStringToSingleElements(data);

            inputsAsList = inputsAsList.Where(c => c != "").ToList();

            var leftColumn = new List<int>();
            var rightColumn = new List<int>();

            for (int i = 0; i < inputsAsList.Count(); i++)
            {
                var currentNumber = Int32.Parse(inputsAsList[i]);

                if (i % 2 == 0)
                {
                    leftColumn.Add(currentNumber);
                }
                else
                {
                    rightColumn.Add(currentNumber);
                }
            }

            var result = 0;

            var numberOfElements = inputsAsList.Count() / 2;

            for(var j = 0; j < numberOfElements; j++)
            {
                var minLeftNumberPos = 0;
                var minRightNumberPos = 0;

                for (int i = 0; i < numberOfElements; i++)
                {

                    if (leftColumn[i] != -1 && ( leftColumn[minLeftNumberPos] > leftColumn[i] || leftColumn[minLeftNumberPos] == -1))
                    {
                        minLeftNumberPos = i;
                    }

                    if (rightColumn[i] != -1 && ( rightColumn[minRightNumberPos] > rightColumn[i] || rightColumn[minRightNumberPos] == -1))
                    {
                        minRightNumberPos = i;
                    }

                }

                result += leftColumn[minLeftNumberPos] > rightColumn[minRightNumberPos] ? leftColumn[minLeftNumberPos] - rightColumn[minRightNumberPos] : rightColumn[minRightNumberPos] - leftColumn[minLeftNumberPos];

                leftColumn[minLeftNumberPos] = -1;
                rightColumn[minRightNumberPos] = -1;
            }

            return result.ToString();
        }

        protected override string LogicPart2(string data)
        {
            var inputsAsList = StringHelper.ExplodeStringToSingleElements(data);

            inputsAsList = inputsAsList.Where(c => c != "").ToList();

            var leftColumn = new List<int>();
            var rightColumn = new List<int>();

            for (int i = 0; i < inputsAsList.Count(); i++)
            {
                var currentNumber = Int32.Parse(inputsAsList[i]);

                if (i % 2 == 0)
                {
                    leftColumn.Add(currentNumber);
                }
                else
                {
                    rightColumn.Add(currentNumber);
                }
            }

            var result = 0;

            var numberOfElements = inputsAsList.Count() / 2;

            for (int i = 0; i < numberOfElements; i++)
            {
                var elementCountInRightCol = 0;

                for (var j = 0; j < numberOfElements; j++)
                {
                    if (leftColumn[i] == rightColumn[j])
                    {
                        elementCountInRightCol++;
                    }
                }

                result += leftColumn[i] * elementCountInRightCol;
            }

            return result.ToString();
        }
    }
}
