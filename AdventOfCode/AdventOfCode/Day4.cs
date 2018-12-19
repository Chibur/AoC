using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.AdventInput;
using AdventOfCode.AdventInput.Guards;

namespace AdventOfCode
{
    public class Day4
    {
        private readonly IAdventInputProvider _adventInput;

        public Day4(IAdventInputProvider adventInput)
        {
            _adventInput = adventInput;
        }

        public async Task<int> FindGuardIdAndMinute()
        {
            var guards = await _adventInput.GetGuards();

            var sleepiestGuard = guards.Select(guard =>
            {
                var totalSleepTime = GetSleepingIntervals(guard.Actions).Sum(g => g.Ticks);
                return ( Guard: guard, totalSleepTime);
            })
            .OrderByDescending(g => g.totalSleepTime)
            .First()
            .Guard;

            var bestMinuteToSneak = FingBestMinuteToSneak(sleepiestGuard);

            return 0;
        }

        private int FingBestMinuteToSneak(Guard sleepiestGuard)
        {
            var startOfRange = 0;
            var endOfRange = 59;
            var sleepIntervals = GetSleepingIntervals(sleepiestGuard.Actions);

            return 0;

        }

        private IEnumerable<TimeSpan> GetSleepingIntervals(IEnumerable<AdventInput.Guards.Action> actions)
        {
            var fellAsleepAt = DateTime.MinValue;
            List<TimeSpan> sleepingIntervals = new List<TimeSpan>();
            foreach (var action in actions)
            {
                switch (action.Type)
                {
                    case ActionType.FallsAsleep:
                        fellAsleepAt = action.Timestamp;
                        break;
                    case ActionType.WakesUp:
                        var amountSlept = action.Timestamp - fellAsleepAt;
                        sleepingIntervals.Add(amountSlept);
                        break;
                    default:
                        break;
                }
            }
            return sleepingIntervals;
        }
    }
}