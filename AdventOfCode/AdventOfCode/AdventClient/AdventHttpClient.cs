using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace AdventOfCode.AdventClient
{
    public class AdventHttpClient: IAdventHttpClient
    {
        private Uri _baseUrl => new Uri("https://adventofcode.com");

        public async Task<string> GetInputStringAsync(string uri)
        {
            string result;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseUrl;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("cookie", "_ga=GA1.2.2010882644.1544457104; _gid=GA1.2.785056167.1544457104; session=53616c7465645f5fe57a5508b8cecfe077d33dab2b326652a244344e6509766a0eceb5a21e915feccb9bbb04ae295b9c");

                result = await httpClient.GetStringAsync(uri);
            }
            return result;
        }

        public async Task<IEnumerable<string>> GetInputStringListAsync(string uri)
        {
            var rawInput = await GetInputStringAsync(uri);
            var splitInput = rawInput.Split('\n');
            return splitInput.SkipLast(1);
        }
    }
}
