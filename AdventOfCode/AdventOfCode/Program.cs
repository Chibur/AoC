using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveDay1();
        }

        static void SolveDay1()
        {
            var adventClient = new AdventClient();
            var day1 = new Day1(adventClient);

            var frequency = day1.CalculateFrequency().Result;
            Console.WriteLine($"Day 1 frequency: {frequency}");

            var duplicateFrequency = day1.GetFirstFrequencyDuplication().Result;
            Console.WriteLine($"Day 1 frequency duplication: {duplicateFrequency}");
        }
    }
}
