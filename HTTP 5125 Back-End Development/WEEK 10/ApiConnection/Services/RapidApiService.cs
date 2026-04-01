using ApiConnection.Models;
using System.Text.Json;
namespace ApiConnection.Services
{
    public class RapidApiService
    {
        public HttpClient client { get; set; }
        public RapidApiService(HttpClient client_)
        {
            client = client_;
        }

        public async Task<List<Job>> getData()
        {
            // var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://linkedin-job-search-api.p.rapidapi.com/active-jb-24h?limit=10&offset=0&title_filter=%22Data%20Engineer%22&location_filter=%22United%20States%22%20OR%20%22United%20Kingdom%22&description_type=text"),
                // RequestUri = new Uri("https://rapidapi.com/letscrape-6bRBa3QguO5/api/jsearch"),

                Headers =
            {
                { "x-rapidapi-key", "d7fc58f757mshdbf7ab4dc33ff66p1ac4bfjsna090cbb26f08" },
                { "x-rapidapi-host", "linkedin-job-search-api.p.rapidapi.com" },
            },
            };
            // Async function for the client request
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();


                // Wait the response from the api
                var body = await response.Content.ReadAsStringAsync();
                // Console.WriteLine(body);
                // Declare the new object for caseinsenstive
                var parameters = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                // Create an empty object to store the response objects
                var result = JsonSerializer.Deserialize<List<Job>>(body, parameters);
                // return the converted json response
                return result;
            }
        }


    }
}
