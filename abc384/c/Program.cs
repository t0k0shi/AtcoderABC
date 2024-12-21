using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Participant
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Participant(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int[] points = Array.ConvertAll(input, int.Parse);
        char[] problems = { 'A', 'B', 'C', 'D', 'E' };

        List<Participant> participants = new List<Participant>();
        GenerateParticipants(participants, points, problems, "", 0);

        var sortedParticipants = participants.OrderByDescending(p => p.Score).ThenBy(p => p.Name);

        foreach (var participant in sortedParticipants)
        {
            Console.WriteLine(participant.Name);
        }
    }

    static void GenerateParticipants(List<Participant> participants, int[] points, char[] problems, string current, int index)
    {
        if (!string.IsNullOrEmpty(current))
        {
            int score = CalculateScore(current, points, problems);
            participants.Add(new Participant(current, score));
        }

        for (int i = index; i < problems.Length; i++)
        {
            GenerateParticipants(participants, points, problems, current + problems[i], i + 1);
        }
    }

    static int CalculateScore(string name, int[] points, char[] problems)
    {
        int score = 0;
        foreach (char c in name)
        {
            score += points[Array.IndexOf(problems, c)];
        }
        return score;
    }
}
