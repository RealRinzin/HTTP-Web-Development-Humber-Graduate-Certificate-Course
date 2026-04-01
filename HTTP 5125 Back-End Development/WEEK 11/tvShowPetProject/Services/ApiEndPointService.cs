using tvShowPetProject.Models;
using System.Text.Json;
namespace tvShowPetProject.Services
{

    public class ApiEndPointService
    {
        public HttpClient client { get; set; }
        public ApiEndPointService(HttpClient client_)
        {
            client = client_;
        }

        public async Task<List<Shows>> getData()
        {

            // console.WriteLine("This is the API endpoint for the TV show pet project.");
            var req = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.tvmaze.com/shows?page=2"),
            };

            // var req = new HttpRequestMessage(HttpMethod.Get,
            //     "https://api.tvmaze.com/search/shows?q=girls");

            // ✅ Correct way to add header
            // req.Headers.Add("Accept", "application/json");
            using (var res = await client.SendAsync(req))
            {
                res.EnsureSuccessStatusCode();

                var body = await res.Content.ReadAsStringAsync();
                var parameters = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<List<Shows>>(body, parameters);
                // Console.WriteLine(result);
                return result;
            }
        }

    }
}