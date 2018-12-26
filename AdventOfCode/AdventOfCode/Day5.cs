using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


        public async Task<string> GetShortestPossiblePolymer()
        {
            var originalPolymer = await _adventInput.GetPolymer();
            var polymerPrototypes = new List<string>();
            for (var i = 'a'; i <= 'z'; i++)
            {
                var polymer = originalPolymer;
                polymer = polymer.Replace(i.ToString(), string.Empty);
                polymer = polymer.Replace(char.ToUpper(i).ToString(), string.Empty);
                polymer = RuducePolymer(polymer);
                polymerPrototypes.Add(polymer);
            }
            var shortestPossiblePolymer = polymerPrototypes.OrderByDescending(p => p.Length).Last();
            return shortestPossiblePolymer;
        }
        private string RuducePolymer(string polymer)
        {
            var isReduced = false;
            var pairExp = BuildRegEx();
            do
            {
                isReduced = false;
                if (pairExp.IsMatch(polymer)) {
                    polymer = pairExp.Replace(polymer, string.Empty);
                    isReduced = true;
                }
            } while (isReduced);
           
            return polymer;
        }

        private Regex BuildRegEx()
        {
            var expBuilder = new StringBuilder();
            for (var i = 'a'; i <= 'z'; i++)
            {
                var exp = $"{i}{char.ToUpper(i)}|{char.ToUpper(i)}{i}";
                expBuilder.Append(exp);
                if (i != 'z')
                {
                    expBuilder.Append("|");
                }
            }
            return new Regex(expBuilder.ToString(), RegexOptions.Compiled);
        }
    }
}