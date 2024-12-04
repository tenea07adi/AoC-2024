using AoC_2024.Helpers;

namespace AoC_2024.Logic
{
    public class Day04 : PuzzleLogicTemplate
    {
        Dictionary<string, string> nextCharacterXmasMap = new Dictionary<string, string>() 
        {
            {"X", "M" },
            {"M", "A" },
            {"A", "S" },
            {"S", null }
        };

        Dictionary<string, string> nextCharacterCrossMasMap = new Dictionary<string, string>()
        {
            {"M", "A" },
            {"A", "S" },
            {"S", null }
        };

        public Day04() : base(4)
        {
            
        }

        protected override string LogicPart1(string data)
        {
            var matrix = StringHelper.ExplodeStringToMatrixByLine(data, "");

            var total = 0;

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == "X")
                    {
                        total += KeyowordsForStartingPointXmas(matrix, i, j);
                    }
                }
            }

            return total.ToString();
        }

        protected override string LogicPart2(string data)
        {
            var matrix = StringHelper.ExplodeStringToMatrixByLine(data, "");

            var aPos = new Dictionary<string, int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "M")
                    {
                        aPos = KeyowordsForStartingPointCrossMas(aPos, matrix, i, j);
                    }
                }
            }

            var total = aPos.Where(c => c.Value >= 2).Count();

            return total.ToString();
        }

        private int KeyowordsForStartingPointXmas(string[,] matrix, int x, int y)
        {
            var total = 0;

            total += IsKeyword(nextCharacterXmasMap, matrix, x, y, 0, 1) ? 1 : 0;
            total += IsKeyword(nextCharacterXmasMap, matrix, x, y, 0, -1) ? 1 : 0;
            total += IsKeyword(nextCharacterXmasMap, matrix, x, y, 1, 0) ? 1 : 0;
            total += IsKeyword(nextCharacterXmasMap, matrix, x, y, -1, 0) ? 1 : 0;
            total += IsKeyword(nextCharacterXmasMap, matrix, x, y, 1, 1) ? 1 : 0;
            total += IsKeyword(nextCharacterXmasMap, matrix, x, y, 1, -1) ? 1 : 0;
            total += IsKeyword(nextCharacterXmasMap, matrix, x, y, -1, 1) ? 1 : 0;
            total += IsKeyword(nextCharacterXmasMap, matrix, x, y, -1, -1) ? 1 : 0;

            return total;
        }

        private Dictionary<string, int> KeyowordsForStartingPointCrossMas(Dictionary<string, int> aPos, string[,] matrix, int x, int y)
        {

            if (IsKeyword(nextCharacterCrossMasMap, matrix, x, y, 1, 1))
            {
                AddFoundPositionToDictionary(aPos, x + 1, y + 1);
            }

            if (IsKeyword(nextCharacterCrossMasMap, matrix, x, y, 1, -1))
            {
                AddFoundPositionToDictionary(aPos, x + 1, y - 1);
            }

            if (IsKeyword(nextCharacterCrossMasMap, matrix, x, y, -1, 1))
            {
                AddFoundPositionToDictionary(aPos, x - 1, y + 1);
            }

            if (IsKeyword(nextCharacterCrossMasMap, matrix, x, y, -1, -1))
            {
                AddFoundPositionToDictionary(aPos, x - 1, y - 1);
            }

            return aPos;
        }

        private bool IsKeyword(Dictionary<string, string> nextCharacterMap, string[,] matrix, int x, int y, int xDir, int yDir)
        {
            int i = x;
            int j = y;

            string lastLetter = matrix[i,j];

            while (true)
            {
                if(nextCharacterMap[lastLetter] == null)
                {
                    return true;
                }

                i += xDir;
                j += yDir;

                if(i <= -1 || i >= matrix.GetLength(0) || j <= -1 || j >= matrix.GetLength(1))
                {
                    return false;
                }

                if (nextCharacterMap[lastLetter] == matrix[i, j])
                {
                    lastLetter = matrix[i, j];
                }
                else
                {
                    return false;
                }
            }
        }
        
        private void AddFoundPositionToDictionary(Dictionary<string, int> dictionary, int x, int y)
        {
            var key = $"{x}-{y}";

            var currentValue = 0;

            if(dictionary.TryGetValue(key, out currentValue))
            {
                dictionary[key] = currentValue + 1;
            }
            else
            {
                dictionary.Add(key, 1);
            }
        }
    }
}
