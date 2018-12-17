using AdventOfCode.AdventInput.Guards;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode.AdventInput
{
    public interface IAdventInputProvider
    {
        Task<IEnumerable<string>> GetFrequencies();
        Task<IEnumerable<string>> GetBoxIds();
        Task<IEnumerable<ElfsFabricClaim>> GetElfsFabricClaims();
        Task<IEnumerable<Guard>> GetGuards();
    }
}
