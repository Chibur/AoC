using AdventOfCode.AdventInput;
using System;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day5
    {
        private readonly IAdventInputProvider _adventInput;

        public Day5(IAdventInputProvider adventInput)
        {
            _adventInput = adventInput;
        }

        public async Task<string> GetReducedPolymer()
        {
            var polymer = await _adventInput.GetPolymer();
            return String.Empty;
        }
    }
}
