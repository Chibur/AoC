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

            foreach (var guard in guards)
            {
            }

            return 0;
        }

        //private IEnumerator<int> GetSleepIntervals(List<Action> actions)
        //{
        //    var isAsleep = false;
        //    foreach (var action in actions)
        //    {
        //        action.Timestamp.
        //    }
        //}
    }
}