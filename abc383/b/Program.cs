using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 入力の読み取り
        string[] hwd = Console.ReadLine().Split();
        int H = int.Parse(hwd[0]);
        int W = int.Parse(hwd[1]);
        int D = int.Parse(hwd[2]);

        char[,] grid = new char[H, W];
        List<(int, int)> floors = new List<(int, int)>();

        for (int i = 0; i < H; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < W; j++)
            {
                grid[i, j] = row[j];
                if (grid[i, j] == '.')
                {
                    floors.Add((i, j));
                }
            }
        }

        int maxHumidified = 0;

        // 2つの加湿器を配置するすべての組み合わせを試す
        for (int i = 0; i < floors.Count; i++)
        {
            for (int j = i + 1; j < floors.Count; j++)
            {
                var humidified = new HashSet<(int, int)>();

                // 加湿器1の加湿範囲を計算
                AddHumidifiedArea(floors[i].Item1, floors[i].Item2, D, H, W, grid, humidified);

                // 加湿器2の加湿範囲を計算
                AddHumidifiedArea(floors[j].Item1, floors[j].Item2, D, H, W, grid, humidified);

                // 加湿範囲のサイズを確認
                maxHumidified = Math.Max(maxHumidified, humidified.Count);
            }
        }

        // 結果を出力
        Console.WriteLine(maxHumidified);
    }

    static void AddHumidifiedArea(int x, int y, int D, int H, int W, char[,] grid, HashSet<(int, int)> humidified)
    {
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                if (grid[i, j] == '.' && Math.Abs(i - x) + Math.Abs(j - y) <= D)
                {
                    humidified.Add((i, j));
                }
            }
        }
    }
}
