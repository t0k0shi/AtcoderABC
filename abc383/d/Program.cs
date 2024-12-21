using System;

class Program
{
    static void Main()
    {
        long N = long.Parse(Console.ReadLine());

        int count = 0;

        for (long p = 2; p * p * p * p * p * p * p * p <= N; p++)
        {
            if (IsPrime(p))
            {
                long power8 = p * p * p * p * p * p * p * p;
                if (power8 <= N) count++;
            }
        }

        for (long p = 2; p * p <= N; p++)
        {
            if (IsPrime(p))
            {
                for (long q = p + 1; q * q <= N / (p * p); q++)
                {
                    if (IsPrime(q))
                    {
                        long num = p * p * q * q;
                        if (num <= N) count++;
                    }
                }
            }
        }

        Console.WriteLine(count);
    }

    static bool IsPrime(long num)
    {
        if (num < 2) return false;
        for (long i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}
