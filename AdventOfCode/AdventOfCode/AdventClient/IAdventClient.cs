using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public interface IAdventClient
    {
        Task<IEnumerable<string>> GetFrequencies();
        Task<IEnumerable<string>> GetGetBoxIds();
    }
}
