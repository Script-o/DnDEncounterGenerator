using DnDEncounterGenerator.Shared;
using System.Net.Http;
using System.Text.Json;

namespace DnDEncounterGenerator.Services
{
    public class MonsterDataService : IMonsterDataService
    {
        private readonly HttpClient _httpClient;

        public MonsterDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Monster>> GetAllMonsters()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Monster>>
                (await _httpClient.GetStreamAsync($"api/monster"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
