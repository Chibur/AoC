using AdventOfCode.AdventClient;
using AdventOfCode.AdventInput;
using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveDay1();
            SolveDay2();
            SolveDay3();
            SolveDay4();
            // SolveDay5();
        }

        static void SolveDay1()
        {
            // TODO: dependancy injection
            var adventClient = new AdventHttpClient();
            var adventInput = new AdventInputProvider(adventClient);
            var day1 = new Day1(adventInput);

            var frequency = day1.CalculateFrequency().Result;
            Console.WriteLine($"Day 1 frequency: {frequency}");

            var duplicateFrequency = day1.GetFirstFrequencyDuplication().Result;
            Console.WriteLine($"Day 1 frequency duplication: {duplicateFrequency}");
        }

        static void SolveDay2()
        {
            var adventClient = new AdventHttpClient();
            var adventInput = new AdventInputProvider(adventClient);
            var day2 = new Day2(adventInput);

            var checksum = day2.CalculateChecksum().Result;
            Console.WriteLine($"Day 2 checksum: {checksum}");

            var boxId = day2.GetStringOfCommonLettersFromMostSimilarBoxIds().Result;
            Console.WriteLine($"Day 2 BoxId : {boxId}");
        }

        static void SolveDay3()
        {
            var adventClient = new AdventHttpClient();
            var adventInput = new AdventInputProvider(adventClient);
            var day3 = new Day3(adventInput);

            var overlappingInches = day3.CountFabricInchesOverlaping().Result;
            Console.WriteLine($"Day 3 Overlapping Inches: {overlappingInches}");

            var nonOverlappingClaimId = day3.GetNonOverlapingClaimId().Result;
            Console.WriteLine($"Day 3 Non Overlapping Claim Id: {nonOverlappingClaimId}");
        }

        static void SolveDay4()
        {
            var adventClient = new AdventHttpClient();
            var adventInput = new AdventInputProvider(adventClient);
            var day4 = new Day4(adventInput);

            var longestSleepingResult = day4.FindLongestSleepingGuardAndMinuteToSneak().Result;
            Console.WriteLine($"Day 4 Best Minute to go and longest sleeping guard id and minute multiplication result: {longestSleepingResult}");

            var mostFrequentlySleepingResult = day4.FindGuardMostFrequentlyAsleepAndMinuteToSneak().Result;
            Console.WriteLine($"Day 4 Best Minute to go and most frequently sleeping guard id and minute multiplication result: {mostFrequentlySleepingResult}");
        }

        static void SolveDay5()
        {
            var adventClient = new AdventHttpClient();
            var adventInput = new AdventInputProvider(adventClient);
            var day5 = new Day5(adventInput);

            var reducedPolymer = day5.GetReducedPolymer().Result;
            Console.WriteLine($"Day 5 Count of units in reduced polymer of fabric: {reducedPolymer.Length}");

            var mostReducedPolymer = day5.GetShortestPossiblePolymer().Result;
            Console.WriteLine($"Day 5 Count of units in most reduced polymer of fabric: {mostReducedPolymer.Length}");
        }

    }
}
