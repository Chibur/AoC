using AdventOfCode.AdventInput;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AdventOfCode
{
    public class Day3
    {
        private readonly IAdventInputProvider _adventInput;

        public Day3 (IAdventInputProvider adventInput)
        {
            _adventInput = adventInput;
        }
        
        public async Task<int> CountFabricInchesOverlaping()
        {
            var claims = await _adventInput.GetElfsFabricClaims();
            var claimMap = CountClaimsOnEveryInchOfFabric(claims);
            var overlapingInches = claimMap.Count(m => m.Value > 1);
            return overlapingInches;
        }

        public async Task<int> GetNonOverlapingClaimId()
        {
            var claims = await _adventInput.GetElfsFabricClaims();
            var claimMap = CountClaimsOnEveryInchOfFabric(claims);
            var nonOverlapingClaim = FindNonOverlapingCliam(claimMap, claims);
            return nonOverlapingClaim.Id;
        }

        private Dictionary<(int, int), int> CountClaimsOnEveryInchOfFabric(IEnumerable<ElfsFabricClaim> claims)
        {
            var claimMap = new Dictionary<(int, int), int>();

            foreach(var claim in claims)
            {
                var firstX = claim.OffsetLeft + 1;
                var lastX = claim.OffsetLeft + claim.Width;

                var firstY = claim.OffsetTop + 1;
                var lastY = claim.OffsetTop + claim.Height;

                for (int i = firstX; i <= lastX; i++)
                {
                    for (int j = firstY; j <= lastY; j++)
                    {

                        if (!claimMap.ContainsKey((i, j)))
                        {
                            claimMap.Add((i, j), 1);
                        }
                        else
                        {
                            claimMap[(i, j)] += 1;
                        }
                    }
                }
            }

            return claimMap;
        }

        private ElfsFabricClaim FindNonOverlapingCliam(Dictionary<(int, int), int> claimMap, IEnumerable<ElfsFabricClaim> claims)
        {
            var nonOverlapingClaim = new ElfsFabricClaim();

            foreach (var claim in claims)
            {
                var firstX = claim.OffsetLeft + 1;
                var lastX = claim.OffsetLeft + claim.Width;

                var firstY = claim.OffsetTop + 1;
                var lastY = claim.OffsetTop + claim.Height;
                var foundOverlap = false;

                for (int i = firstX; i <= lastX; i++)
                {

                    for (int j = firstY; j <= lastY; j++)
                    {
                        if (claimMap[(i, j)] > 1)
                        {
                            foundOverlap = true;
                            break;
                        } 
                    }

                    if(foundOverlap)
                    {
                        break;
                    }
                }

                if(!foundOverlap)
                {
                    nonOverlapingClaim = claim;
                }
            }
            return nonOverlapingClaim;
        }
    }
}
