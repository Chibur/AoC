using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using AdventOfCode.AdventInput;

namespace AdventOfCode
{
    public class Day2
    {
        private readonly IAdventInputProvider _adventInput;

        public Day2(IAdventInputProvider adventInput)
        {
            _adventInput = adventInput;
        }

        public async Task<int> CalculateChecksum()
        {
            var boxIds = await _adventInput.GetBoxIds();
            var countOfPair = 0;
            var countOfTriplet = 0;
            var foundPair = false;
            var foundTriplet = false;

            foreach (var id in boxIds)
            {
                for (var i = 'a'; i <= 'z'; i++)
                {
                    var count = id.Count(c => c == i);
                    if(count == 2 && !foundPair)
                    {
                        foundPair = true;
                        countOfPair++;
                    }
                    else if (count == 3 && !foundTriplet)
                    {
                        foundTriplet = true;
                        countOfTriplet++;
                    }

                    if (foundPair && foundTriplet)
                    {
                        break;
                    }
                }
                foundPair = false;
                foundTriplet = false;
            }

            var checksum = countOfPair * countOfTriplet;
            return checksum;
        }

        public async Task<string> GetStringOfCommonLettersFromMostSimilarBoxIds()
        {
            var boxIds = await _adventInput.GetBoxIds();
            var (firstId, secondId) = FindMostSimilarBoxIds(boxIds.ToList());
            var commonLetterString = RemoveLetterThatDiffer(firstId, secondId);
    
            return commonLetterString;
        }

        private (string, string) FindMostSimilarBoxIds(List<string> boxIds)
        {
            var firstSimilarId = string.Empty;
            var secondSimilarId = string.Empty;

            boxIds.Sort();
            for (var i = 0; i < boxIds.Count() - 1; i++)
            {
                var IdsToCompare = boxIds.Skip(i).Take(2).ToList();

                var countOfDifferectLetters = GetNumberOfDifferetLetters(IdsToCompare[0], IdsToCompare[1]);

                if (countOfDifferectLetters == 1)
                {
                    firstSimilarId = IdsToCompare[0];
                    secondSimilarId = IdsToCompare[1];
                    break;
                }
            }

            return (firstSimilarId, secondSimilarId);
        }

        private int GetNumberOfDifferetLetters(string firstId, string secondId)
        {
            var countOfDifferectLetters = 0;
            for (int i = 0; i < firstId.Length; i++)
            {
                if (Math.Abs(firstId[i] - secondId[i]) > 0)
                {
                    countOfDifferectLetters++;
                }
            }
            return countOfDifferectLetters;
        }

        private string RemoveLetterThatDiffer(string firstId, string secondId)
        {
            string newString = string.Empty;
            for(int i = 0; i < firstId.Length; i++)
            {
                if (Math.Abs(firstId[i] - secondId[i]) > 0)
                {
                    newString = firstId.Remove(i, 1);
                }
            }
            return newString;
        }
    }
}
