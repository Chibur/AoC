using AdventOfCode.AdventClient;
using AdventOfCode.AdventInput.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.AdventInput
{
    public class AdventInputProvider : IAdventInputProvider
    {
        private readonly IAdventHttpClient _adventClient;

        public AdventInputProvider(IAdventHttpClient adventClient)
        {
            _adventClient = adventClient;
        }

        public async Task<IEnumerable<string>> GetFrequencies()
        {
            var frequencies = await _adventClient.GetInputStringListAsync("2018/day/1/input");
            return frequencies;
        }

        public async Task<IEnumerable<string>> GetBoxIds()
        {
            var boxIds = await _adventClient.GetInputStringListAsync("2018/day/2/input");
            return boxIds;
        }

        public async Task<IEnumerable<ElfsFabricClaim>> GetElfsFabricClaims()
        {
            var elfsClaimsStrings = await _adventClient.GetInputStringListAsync("2018/day/3/input");
            var elfsClaims = new List<ElfsFabricClaim>();

            foreach (var claimString in elfsClaimsStrings)
            {
                var claim = ElfsFabricClaim.Parse(claimString);
                elfsClaims.Add(claim);
            }
            return elfsClaims;
        }

        public async Task<IEnumerable<Guard>> GetGuardActions()
        {
            var guardActionStrings = await _adventClient.GetInputStringListAsync("2018/day/4/input");
            var a = guardActionStrings.ToList();
            a.Sort(new ActionTimestampComparer());

            return new List<Guard>();
        }
    }
}
