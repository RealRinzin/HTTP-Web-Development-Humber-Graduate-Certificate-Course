using tvShowPetProject.Models;
using System.Text.Json;

namespace tvShowPetProject.Services
{
    public class ActorEndPointService
    {
        private readonly HttpClient _httpClient;
        public ActorEndPointService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Actors>> getData()
        {
            var req = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.tvmaze.com/people"),
            };
            using (var res = await _httpClient.SendAsync(req))
            {
                res.EnsureSuccessStatusCode();
                var body = await res.Content.ReadAsStringAsync();
                var parameters = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<List<Actors>>(body, parameters);
                return result;
            }
        }

        // Details

        public async Task<Actors> GetShowById(int id)
        {
            var data = await getData(); // your existing method
            return data.FirstOrDefault(x => x.Id == id);
        }
    }
}