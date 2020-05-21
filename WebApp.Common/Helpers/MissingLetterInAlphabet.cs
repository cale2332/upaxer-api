using System.Linq;

namespace WebApp.Common.Helpers
{
    public static class MissingLetterInAlphabet
    {
        public static string solution(string[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            string[] alpha = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            foreach (var item in alpha)
            {
                if (!A.Contains(item))
                    return item;
            }
            return "A";
        }
    }
}
