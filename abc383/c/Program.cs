using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] hwd = Console.ReadLine().Split();
        int H = int.Parse(hwd[0]);
        int W = int.Parse(hwd[1]);
        int D = int.Parse(hwd[2]);

        char[,] grid = new char[H, W];
        for (int i = 0; i < H; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < W; j++)
            {
                grid[i, j] = row[j];
            }
        }

        Queue<(int x, int y, int dist)> queue = new Queue<(int x, int y, int dist)>();
        bool[,] visited = new bool[H, W];

        int humidifiedCount = 0;

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                if (grid[i, j] == 'H')
                {
                    queue.Enqueue((i, j, 0));
                    visited[i, j] = true;
                    humidifiedCount++;
                }
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        while (queue.Count > 0)
        {
            var (x, y, dist) = queue.Dequeue();
            if (dist >= D) continue;

            for (int dir = 0; dir < 4; dir++)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];

                if (nx >= 0 && nx < H && ny >= 0 && ny < W && !visited[nx, ny] && grid[nx, ny] != '#')
                {
                    visited[nx, ny] = true;
                    if (grid[nx, ny] == '.')
                        humidifiedCount++;
                    queue.Enqueue((nx, ny, dist + 1));
                }
            }
        }

        Console.WriteLine(humidifiedCount);
    }
}
