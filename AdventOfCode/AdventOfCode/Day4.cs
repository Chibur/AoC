﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.AdventInput;
using AdventOfCode.AdventInput.Guards;

namespace AdventOfCode
{
    // TODO: refactor to use use strategy pattern
    public class Day4
    {
        private readonly IAdventInputProvider _adventInput;

        public Day4(IAdventInputProvider adventInput)
        {
            _adventInput = adventInput;
        }

        public async Task<int> FindLongestSleepingGuardAndMinuteToSneak()
        {
            var guards = await _adventInput.GetGuards();

            var sleepiestGuard = guards.Select(guard =>
            {
                var totalSleepTime = GetSleepingIntervals(guard.Actions).Sum(g => g.WakesUpAt - g.FellAsleepAt);
                return (Guard: guard, totalSleepTime);
            })
            .OrderByDescending(g => g.totalSleepTime)
            .First()
            .Guard;

            var bestMinuteToSneak = FingBestMinuteToSneak(sleepiestGuard);

            return bestMinuteToSneak * sleepiestGuard.Id;
        }

        public async Task<int> FindGuardMostFrequentlyAsleepAndMinuteToSneak()
        {
            var guards = await _adventInput.GetGuards();

            var mostFrequentlyAsleepGuard = guards.Select(guard =>
            {
                var bestMinuteToSneak = FingBestMinuteToSneak(guard);
                return (Guard: guard, BestMinuteToSneak :bestMinuteToSneak);
            })
           .OrderByDescending(g => g.BestMinuteToSneak)
           .FirstOrDefault();

            return mostFrequentlyAsleepGuard.BestMinuteToSneak * mostFrequentlyAsleepGuard.Guard.Id;
        }

        private int FingBestMinuteToSneak(Guard sleepiestGuard)
        {
            var sleepHistogram = new Dictionary<int, int>();

            foreach (var sleepInterval in GetSleepingIntervals(sleepiestGuard.Actions))
            {
                for (int i = sleepInterval.FellAsleepAt; i < sleepInterval.WakesUpAt; i++)
                {
                    if (!sleepHistogram.TryAdd(i, 1))
                    {
                        sleepHistogram[i]++;
                    }
                }
            }

            if (sleepHistogram.Count == 0)
            {
                return 0;
            }
            
            return sleepHistogram.OrderByDescending(h => h.Value).FirstOrDefault().Key;
        }

        private IEnumerable<(int FellAsleepAt, int WakesUpAt)> GetSleepingIntervals(IEnumerable<AdventInput.Guards.Action> actions)
        {
            var fellAsleepAt = 0;
            var sleepingIntervals = new List<(int, int)>();
            foreach (var action in actions)
            {
                switch (action.Type)
                {
                    case ActionType.FallsAsleep:
                        fellAsleepAt = action.Timestamp.Minute;
                        break;
                    case ActionType.WakesUp:
                        var wakesUpAt = action.Timestamp.Minute;
                        sleepingIntervals.Add((fellAsleepAt, wakesUpAt));
                        break;
                    default:
                        break;
                }
            }
            return sleepingIntervals;
        }
    }
}