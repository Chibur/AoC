using AdventOfCode.AdventInput;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode
{
    
    public class Day1
    {
        private readonly IAdventInputProvider _adventInput;

        public Day1(IAdventInputProvider adventInput)
        {
            _adventInput = adventInput;
        }

        public async Task<int> CalculateFrequency()
        {
            var frequencies = await _adventInput.GetFrequencies();
            int summedFrequency = 0;

            foreach (var frequency in frequencies)
            {
                summedFrequency += int.Parse(frequency);
            }

            return summedFrequency;
        }

        public async Task<int> GetFirstFrequencyDuplication()
        {
            var frequencies = await _adventInput.GetFrequencies();

            var uniqInputList = new HashSet<int>();
            var sumedFrequency = 0;
            var duplicateFound = false;

            while(!duplicateFound)
            {
                foreach(var frequency in frequencies)
                {
                    var currentFrequency = int.Parse(frequency);
                    sumedFrequency += currentFrequency;
                    duplicateFound = !uniqInputList.Add(sumedFrequency);
                    if (duplicateFound)
                    {
                        break;
                    }
                }
            }
            return sumedFrequency;
        }
    }
}
