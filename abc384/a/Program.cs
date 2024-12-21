using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        char c1 = char.Parse(input[1]);
        char c2 = char.Parse(input[2]);
        string S = Console.ReadLine();

        char[] result = new char[N];

        for (int i = 0; i < N; i++)
        {
            if (S[i] == c1)
            {
                result[i] = c1;
            }
            else
            {
                result[i] = c2;
            }
        }
        Console.WriteLine(new string(result));
    }
}
