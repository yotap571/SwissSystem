using System;
using System.Collections.Generic;

public static class TeamShuffle
{
    public static List<(int round, string team1, string team2)> Shuffle(List<string> arr)
    {
        var pool = new List<int>();
        for (int i = 0; i < arr.Count; i++)
        {
            pool.Add(i);
        }

        var returnArray = new List<(int round, string team1, string team2)>();
        int round = 0;

        try
        {
            while (pool.Count > 0)
            {
                round++;
                int index1 = new Random().Next(pool.Count);
                int r1 = pool[index1];
                pool.RemoveAt(index1);

                if (pool.Count == 0)
                {
                    Console.WriteLine($"Round {round}: {arr[r1]} ");
                    returnArray.Add((round, arr[r1], "x"));
                }
                else
                {
                    int index2 = new Random().Next(pool.Count);
                    int r2 = pool[index2];
                    pool.RemoveAt(index2);
                    Console.WriteLine($"Round {round}: {arr[r1]} vs {arr[r2]}");
                    returnArray.Add((round, arr[r1], arr[r2]));
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        return returnArray;
    }

    public static List<(int round, string team1, string team2)> GroupShuffle(List<string> arr, int totalGroup)
    {
        var pool = new List<int>();
        for (int i = 0; i < arr.Count; i++)
        {
            pool.Add(i);
        }

        var returnArray = new List<(int round, string team1, string team2)>();
        int round = 0;

        try
        {
            while (pool.Count > 0)
            {
                round++;
                int index1 = new Random().Next(pool.Count);
                int r1 = pool[index1];
                pool.RemoveAt(index1);

                if (pool.Count == 0)
                {
                    Console.WriteLine($"Round {round}: {arr[r1]} ");
                }
                else
                {
                    int index2 = new Random().Next(pool.Count);
                    int r2 = pool[index2];
                    pool.RemoveAt(index2);
                    Console.WriteLine($"Round {round}: {arr[r1]} vs {arr[r2]}");
                    returnArray.Add((round, arr[r1], arr[r2]));
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        return returnArray;
    }
}