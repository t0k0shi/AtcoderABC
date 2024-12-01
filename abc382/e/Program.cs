using System;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int X = int.Parse(input[1]);
        var P_input = Console.ReadLine().Split();
        double[] p = new double[N];
        for (int i = 0; i < N; i++)
        {
            p[i] = int.Parse(P_input[i]) / 100.0;
        }

        int maxS = Math.Min(X - 1, N);
        double[] dp = new double[X];
        dp[0] = 1.0;

        for (int i = 0; i < N; i++)
        {
            double pi = p[i];
            for (int s = maxS; s >= 1; s--)
            {
                dp[s] = dp[s] * (1 - pi) + dp[s - 1] * pi;
            }
            dp[0] *= (1 - pi);
        }

        double[] E = new double[X + 1];
        for (int k = X - 1; k >= 0; k--)
        {
            double sum = 0.0;
            for (int s = 1; s <= Math.Min(N, X - k - 1); s++)
            {
                if (k + s >= X) continue;
                sum += dp[s] * E[k + s];
            }

            double denom = 1.0 - dp[0];
            if (denom == 0.0)
            {
                // 特殊なケース: P(S_i = 0) = 1 の場合
                E[k] = double.PositiveInfinity;
            }
            else
            {
                E[k] = (1.0 + sum) / denom;
            }
        }

        Console.WriteLine($"{E[0]:0.###############}");
    }
}
