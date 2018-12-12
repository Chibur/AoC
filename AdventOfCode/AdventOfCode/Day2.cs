using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day2
    {
        private readonly IAdventClient _adventClient;

        public Day2(IAdventClient adventClient)
        {
            _adventClient = adventClient;
        }

        public async Task<int> CalculateChecksum()
        {
            var boxIds = await _adventClient.GetGetBoxIds();
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
            var boxIds = await _adventClient.GetGetBoxIds();
            var (firstId, secondId) = FindMostSimilarBoxIds(boxIds.ToList());
            var commonLetterString = RemoveLetterThatDiffer(firstId, secondId);
            return commonLetterString;
        }

        private (string, string) FindMostSimilarBoxIds(List<string> boxIds)
        {
            var firstSimilarId = string.Empty;
            var secondSimilarId = string.Empty;

            for(var i = 0; i < boxIds.Count(); i++)
            {
                var firstId = boxIds[i];

                for(var j = i + 1; j < boxIds.Count() - 1; j++)
                {
                    var secondId = boxIds[j];
                    var countOfDifferectLetters = GetNumberOfDifferetLetters(firstId, secondId);

                    if (countOfDifferectLetters == 1)
                    {
                        firstSimilarId = firstId;
                        secondSimilarId = secondId;
                        break;
                    }
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
