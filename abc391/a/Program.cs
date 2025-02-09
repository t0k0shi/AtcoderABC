using System;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            string D = Console.ReadLine();
            string oppositeDirection = GetOppositeDirection(D);
            Console.WriteLine(oppositeDirection);
        }

        static string GetOppositeDirection(string direction)
        {
            switch (direction)
            {
                case "N":
                    return "S";
                case "E":
                    return "W";
                case "W":
                    return "E";
                case "S":
                    return "N";
                case "NE":
                    return "SW";
                case "NW":
                    return "SE";
                case "SE":
                    return "NW";
                case "SW":
                    return "NE";
                default:
                    return "";
            }
        }
    }
}
