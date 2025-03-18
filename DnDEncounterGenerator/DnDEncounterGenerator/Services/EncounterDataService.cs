using DnDEncounterGenerator.Shared;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;

namespace DnDEncounterGenerator.Services
{
    public class EncounterDataService : IEncounterDataService
    {
        private readonly HttpClient _httpClient;

        public EncounterDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Encounter>> GetAllEncounters()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Encounter>>
                (await _httpClient.GetStreamAsync($"api/encounter"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Encounter> GetEncounterById(Encounter encounter)
        {
            return await JsonSerializer.DeserializeAsync<Encounter>
                (await _httpClient.GetStreamAsync($"api/encounter/{encounter.EncounterId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Encounter> AddEncounter(Encounter encounter)
        {
            var encounterJson =
                new StringContent(JsonSerializer.Serialize(encounter), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/encounter", encounterJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Encounter>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateEncounter(Encounter encounter)
        {
            var encounterJson =
                new StringContent(JsonSerializer.Serialize(encounter), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/encounter", encounterJson);
        }

        public async Task AddMonsterToEncounter(Encounter encounter, Monster monster)
        {
            var encounterJson =
               new StringContent(JsonSerializer.Serialize(encounter), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"api/encounter/add/{monster.MonsterId}", encounterJson);
        }

        public async Task DeleteEncounter(Encounter encounter)
        {
            await _httpClient.DeleteAsync($"api/encounter/{encounter.EncounterId}");
        }
    }
}
