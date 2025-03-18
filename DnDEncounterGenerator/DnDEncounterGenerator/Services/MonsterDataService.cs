using DnDEncounterGenerator.Shared;
using System.Net.Http;
using System.Text;
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

        public async Task<Monster> GetMonsterById(Monster monster)
        //public async Task<Monster> GetMonsterById(int monster)
        {
            return await JsonSerializer.DeserializeAsync<Monster>
                (await _httpClient.GetStreamAsync($"api/monster/{monster.MonsterId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                //(await _httpClient.GetStreamAsync($"api/monster/{monster}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Monster> AddMonster(Monster monster)
        {
            var monsterJson =
                new StringContent(JsonSerializer.Serialize(monster), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/monster", monsterJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Monster>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateMonster(Monster monster)
        {
            var monsterJson =
                new StringContent(JsonSerializer.Serialize(monster), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/monster", monsterJson);
        }

        public async Task DeleteMonster(Monster monster)
        {
            await _httpClient.DeleteAsync($"api/monster/{monster.MonsterId}");
        }
    }
}
