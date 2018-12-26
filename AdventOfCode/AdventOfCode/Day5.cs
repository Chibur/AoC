using System;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.AdventInput;

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
            var reducedPolymer = RuducePolymer(polymer);
            return reducedPolymer;
        }

        private string RuducePolymer(string polymer)
        {
            var isReduced = false;
            do
            {
                isReduced = false;
                for (var i = 'a'; i <= 'z'; i++)
                {
                    var pair1 = $"{i}{char.ToUpper(i)}";
                    var pair2 = $"{char.ToUpper(i)}{i}";
                    polymer.Substring()

                    if (shouldReduce)
                    {
                        polymer = polymer.Remove(i, 2);
                        isReduced = true;
                        Console.WriteLine(polymer);
                        break;
                    }
                }
            } while (isReduced);
           
            return polymer;
        }
    }
}