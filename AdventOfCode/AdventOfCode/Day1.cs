using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    
    public class Day1
    {
        private readonly IAdventClient _adventClient;
    
        public Day1(IAdventClient adventClient)
        {
            _adventClient = adventClient;
        }

        public async Task<int> CalculateFrequency()
        {
            var frequencies = await _adventClient.GetFrequencies();
            int summedFrequency = 0;

            foreach (var frequency in frequencies)
            {
                summedFrequency += int.Parse(frequency);
            }

            return summedFrequency;
        }

        public async Task<int> GetFirstFrequencyDuplication()
        {
            var frequencies = await _adventClient.GetFrequencies();

            var uniqInputList = new HashSet<int>();
            var result = 0;
            var sumedFrequency = 0;

            using (var frequencyEnumerator = frequencies.GetEnumerator())
            {
                do
                {
                    var currentFrequency = int.Parse(frequencyEnumerator.Current);
                    sumedFrequency += currentFrequency;

                    if (!frequencyEnumerator.MoveNext())
                    {
                        frequencyEnumerator.Reset();
                    }

                } while (!uniqInputList.Add(sumedFrequency));
            }
              

            return result;

        }
    }
}
