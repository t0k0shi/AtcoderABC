using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{

    class Program
{
    static void Main()
    {
        string s = Console.ReadLine().Trim();
        
        string[] parts = s.Split('|', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < parts.Length; i++)
        {
            Console.Write(parts[i].Length);
            if (i < parts.Length - 1)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}

}