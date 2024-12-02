using AoC_2024.Helpers;

namespace AoC_2024.Logic
{
    public class Day02 : PuzzleLogicTemplate
    {
        public Day02() : base(2)
        {
            
        }

        protected override string LogicPart1(string data)
        {
            var inputsAsList = StringHelper.ExplodeStringToLines(data);

            var totalSafe = 0;

            foreach (var inputElm in inputsAsList)
            {
                if (IsSafe(inputElm.Split(' ').ToList(), false))
                {
                    totalSafe++;
                }
            }

            return totalSafe.ToString();
        }

        protected override string LogicPart2(string data)
        {
            var inputsAsList = StringHelper.ExplodeStringToLines(data);

            var totalSafe = 0;

            foreach (var inputElm in inputsAsList)
            {
                if (IsSafe(inputElm.Split(' ').ToList(), true))
                {
                    totalSafe++;
                }
            }

            return totalSafe.ToString();
        }

        private bool IsSafe(List<string> lineList, bool withToleration)
        {
            var isSafe = true;
            var increasing = Int32.Parse(lineList[0]) < Int32.Parse(lineList[1]) ? true : false;

            for(int i = 0; i < lineList.Count - 1; i++)
            {
                var elm1 = Int32.Parse(lineList[i]);
                var elm2 = Int32.Parse(lineList[i + 1]);

                var diff = elm1 - elm2;

                if ((increasing && diff >= 0) || (!increasing && diff <= 0))
                {
                    isSafe = false;
                }

                if (diff > 3 || diff < -3)
                {
                    isSafe = false;
                }

                if (!isSafe)
                {
                    if (withToleration)
                    {
                        var childList1 = new List<string>(lineList); // child list without last element
                        var childList2 = new List<string>(lineList); // child list without current element
                        var childList3 = new List<string>(lineList); // child list without next element

                        if (i >= 1)
                        {
                            childList1.RemoveAt(i-1);
                        }

                        childList2.RemoveAt(i);

                        childList3.RemoveAt(i+1);


                        if (IsSafe(childList2, false) || IsSafe(childList3, false) || IsSafe(childList1, false))
                        {
                            isSafe = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return isSafe;
        }
    }
}
