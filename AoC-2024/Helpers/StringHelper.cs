
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

        public static string[,] ExplodeStringToMatrixByLine(string data, string elmSeparator)
        {
            var lines = data.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);


            var lineLength = elmSeparator != "" ? lines[0].Split(elmSeparator).Length : lines[0].ToList().Count;

            var matrix = new string[lines.Length, lineLength];

            for (int i = 0; i < lines.Length; i++)
            {
                if(elmSeparator == "")
                {
                    var lineElm = lines[i].ToList();

                    for (int j = 0; j < lineElm.Count; j++)
                    {
                        matrix[i, j] = lineElm[j].ToString();
                    }
                }
                else
                {
                    var lineElm = lines[i].Split(elmSeparator);

                    for (int j = 0; j < lineElm.Length; j++)
                    {
                        matrix[i, j] = lineElm[j];
                    }
                }
            }

            return matrix;
        }
    }
}
