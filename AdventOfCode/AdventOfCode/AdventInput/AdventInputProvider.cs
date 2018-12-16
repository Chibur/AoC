using AdventOfCode.AdventClient;
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
                var claim = new ElfsFabricClaim(claimString);
                elfsClaims.Add(claim);
            }
            return elfsClaims;
        }

      
    }
}
