using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode.AdventClient
{
    public interface IAdventHttpClient
    {
        Task<string> GetInputStringAsync(string uri);
        Task<IEnumerable<string>> GetInputStringListAsync(string uri);
    }
}
