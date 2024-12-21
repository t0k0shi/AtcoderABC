using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Rectangle
    {
        public int X1, Y1, X2, Y2;
        public bool IsAdd;
        public Rectangle(int x, int y, int size, bool isAdd)
        {
            X1 = x;
            Y1 = y;
            X2 = x + size;
            Y2 = y + size;
            IsAdd = isAdd;
        }
    }

    static int CalculateTotalArea(List<Rectangle> rectangles)
    {
        var xCoords = rectangles.SelectMany(r => new[] { r.X1, r.X2 }).Distinct().OrderBy(x => x).ToList();
        var yCoords = rectangles.SelectMany(r => new[] { r.Y1, r.Y2 }).Distinct().OrderBy(y => y).ToList();

        var xMap = xCoords.Select((x, i) => (x, i)).ToDictionary(x => x.x, x => x.i);
        var yMap = yCoords.Select((y, i) => (y, i)).ToDictionary(y => y.y, y => y.i);

        bool[,] grid = new bool[xCoords.Count, yCoords.Count];
        foreach (var rect in rectangles)
        {
            int x1 = xMap[rect.X1], x2 = xMap[rect.X2];
            int y1 = yMap[rect.Y1], y2 = yMap[rect.Y2];

            for (int x = x1; x < x2; x++)
                for (int y = y1; y < y2; y++)
                    grid[x, y] = !grid[x, y];
        }

        int totalArea = 0;
        for (int x = 0; x < xCoords.Count - 1; x++)
            for (int y = 0; y < yCoords.Count - 1; y++)
                if (grid[x, y])
                    totalArea += (xCoords[x + 1] - xCoords[x]) * (yCoords[y + 1] - yCoords[y]);

        return totalArea;
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            char operation = input[0][0];
            int x = int.Parse(input[1]);
            int y = int.Parse(input[2]);
            int a = int.Parse(input[3]);

            rectangles.Add(new Rectangle(x, y, a, operation == '+'));
        }

        int result = CalculateTotalArea(rectangles);
        Console.WriteLine(result);
    }
}