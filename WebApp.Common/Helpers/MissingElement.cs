using System;
using System.Linq;

namespace WebApp.Common.Helpers
{
    public static class MissingElement
    {
        public static int solution(int[] X)
        {
            var A = X.Where(x => x > 0).ToArray();
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length != 0 && A.Length == 1)
                return A[0] == 1 ? 2 : 1;
            else if (A.Length != 0 && A.Length > 1)
            {
                Array.Sort(A);

                if (A[0] != 1)
                    return 1;
                else
                {
                    for (int i = 0; i < A.Length - 1; i++)
                    {
                        if (A[i + 1] - A[i] > 1)
                            return A[i] + 1;
                    }
                }
                return A.Length + 1;
            }
            return 1;
        }
    }
}
