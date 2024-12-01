using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{
using System;
using System.Collections.Generic;

    class Program
{
    static string S;
    static int SLength;

    static void Main()
    {
        S = Console.ReadLine();
        SLength = S.Length;
        int Q = int.Parse(Console.ReadLine());
        string[] tokens = Console.ReadLine().Split();
        long[] K = new long[Q];
        for (int i = 0; i < Q; i++)
        {
            K[i] = long.Parse(tokens[i]);
        }

        char[] result = new char[Q];
        for (int i = 0; i < Q; i++)
        {
            result[i] = GetChar(K[i]);
        }
        Console.WriteLine(string.Join(" ", result));
    }

    static char GetChar(long K)
    {
        bool swap = false;
        long lenTotal = SLength;
        while (lenTotal < K)
        {
            lenTotal *= 2;
        }

        while (lenTotal > SLength)
        {
            lenTotal /= 2;
            if (K > lenTotal)
            {
                K -= lenTotal;
                swap = !swap;
            }
        }

        char c = S[(int)(K - 1)];
        return swap ? SwapCase(c) : c;
    }

    static char SwapCase(char c)
    {
        if (char.IsUpper(c))
            return char.ToLower(c);
        else
            return char.ToUpper(c);
    }
}

}