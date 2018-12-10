using System;
using System.Collections.Generic;
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
            var inputList = await _adventClient.GetInputListForADayAsync("2018/day/1/input");
            int frequency = 0;
            inputList.ForEach(i => frequency += int.Parse(i));
            return frequency;
        }

        public async Task<int> GetFirstFrequencyDuplication()
        {
            var inputList = await _adventClient.GetInputListForADayAsync("2018/day/1/input");

            var uniqInputList = new HashSet<int>();
            var result = 0;
            var frequency = 0;
            foreach(var inputString in inputList)
            {
                var inputInt = int.Parse(inputString);
                frequency += inputInt;

                if (!uniqInputList.Add(frequency))
                {
                    result = frequency;
                    break;
                }

            }
            return result;

        }
    }
}
