
using AoC_2024.Helpers;

namespace AoC_2024.Logic
{
    public abstract class PuzzleLogicTemplate
    {
        private int CalendarDay = 0;
        private string PuzzleUrlBase = @"https://adventofcode.com/2024/day/";

        public PuzzleLogicTemplate(int calendarDay)
        {
            CalendarDay = calendarDay;
        }

        public void Run()
        {
            string calendarDayAsString = CalendarDay.ToString();
            calendarDayAsString = calendarDayAsString.Length == 1 ? "0" + calendarDayAsString : calendarDayAsString;

            string data = DataProviderHelper.GetText($"\\Day{calendarDayAsString}\\data.txt");

            string resultP1 = this.LogicPart1(data);
            string resultP2 = this.LogicPart2(data);

            LogResult($"Part 1: {resultP1} \n Part 2: {resultP2}");
        }

        private void LogResult(string result)
        {
            Console.WriteLine($"Day_{CalendarDay}: \n {PuzzleUrlBase}{CalendarDay} \n {result} \n");
        }

        protected abstract string LogicPart1(string data);
        protected abstract string LogicPart2(string data);

    }
}
