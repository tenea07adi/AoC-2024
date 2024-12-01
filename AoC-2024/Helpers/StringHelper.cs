
namespace AoC_2024.Helpers
{
    public class StringHelper
    {
        public static List<string> ExplodeStringToLines(string data)
        {
            return data.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            ).ToList();
        }

        public static List<string> ExplodeStringByDoubleNewLine(string data)
        {
            return data.Split(
                new string[] { "\r\n\r\n", "\r\r", "\n\n" },
                StringSplitOptions.None
            ).ToList();
        }

        public static List<string> ExplodeStringToSingleElements(string data)
        {
            return data.Split(
                new string[] { "\r\n", "\r", "\n", " " },
                StringSplitOptions.None
            ).ToList();
        }
    }
}
