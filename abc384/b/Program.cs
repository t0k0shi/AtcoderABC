using System;

class Program
{
    static void Main()
    {

        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int R = int.Parse(input[1]);

        for (int i = 0; i < N; i++)
        {
            string[] contest = Console.ReadLine().Split();
            int Di = int.Parse(contest[0]);
            int Ai = int.Parse(contest[1]);

            if (ShouldUpdateRating(Di, R))
            {
                R += Ai;
            }
        }
        Console.WriteLine(R);
    }

    static bool ShouldUpdateRating(int division, int rating)
    {
        if (division == 1)
        {
            return rating >= 1600 && rating <= 2799;
        }
        else if (division == 2)
        {
            return rating >= 1200 && rating <= 2399;
        }

        return false;
    }
}
