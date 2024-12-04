using AoC_2024.Logic;

namespace AoC_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, too warmed world! I'm Adrian and this is my AoC 2023 solution.");
            Console.WriteLine("AoC-2024 URL: " + @"https://adventofcode.com/2024/");
            Console.WriteLine("---------------------------------------------------------------------");

            List<PuzzleLogicTemplate> puzzles = new List<PuzzleLogicTemplate>();

            LoadPuzzles(puzzles);
            RunPuzzles(puzzles);
        }

        static void LoadPuzzles(List<PuzzleLogicTemplate> puzzles)
        {
            puzzles.Add(new Day01());
            puzzles.Add(new Day02());
            puzzles.Add(new Day03());
            puzzles.Add(new Day04());
        }

        static void RunPuzzles(List<PuzzleLogicTemplate> puzzles)
        {
            foreach (var puzzle in puzzles)
            {
                puzzle.Run();
                Console.WriteLine("---------------------------------------------------------------------");
            }
        }
    }
}
