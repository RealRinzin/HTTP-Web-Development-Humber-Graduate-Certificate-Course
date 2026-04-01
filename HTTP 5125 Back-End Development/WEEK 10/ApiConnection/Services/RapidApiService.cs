using ApiConnection.Models;
using System.Text.Json;
namespace ApiConnection.Services
{
    /** This class is responsible for connecting to the Rapid API and retrieving data from it.
     * It uses the HttpClient class to send a GET request to the API and retrieve the response. 
     * The response is then deserialized into a list of Job objects and returned to the caller.
     */
    public class RapidApiService
    {

        // Declare the HttpClient object to be used for sending requests to the API
        public HttpClient client { get; set; }
        // Constructor for the RapidApiService class that takes an HttpClient object as a parameter and assigns it to the client property
        public RapidApiService(HttpClient client_)
        {
            client = client_;
        }
        // Asynchronous method that retrieves data from the Rapid API and returns a list of Job objects
        //  Task<List<Job>> is used to indicate that the method is asynchronous and will return a result in the future, while List<Job> indicates that the result will be a list of Job objects
        public async Task<List<Job>> getData()
        {
            // Create a new HttpRequestMessage object to send a GET request to the API with the specified URL and headers
            var request = new HttpRequestMessage
            {
                // Set the HTTP method to GET and specify the URL for the API endpoint, including query parameters for filtering job listings by title and location
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://linkedin-job-search-api.p.rapidapi.com/active-jb-24h?limit=10&offset=0&title_filter=%22Data%20Engineer%22&location_filter=%22United%20States%22%20OR%20%22United%20Kingdom%22&description_type=text"),
                Headers =
                {
                    { "x-rapidapi-key", "d7fc58f757mshdbf7ab4dc33ff66p1ac4bfjsna090cbb26f08" },
                    { "x-rapidapi-host", "linkedin-job-search-api.p.rapidapi.com" },
                },
            };

            // Send the request to the API and wait for the response. If the response is successful, read the response body as a string and deserialize it into a list of Job objects using the JsonSerializer class. 
            // The deserialization process is case-insensitive to ensure that the property names in the JSON response match the property names in the Job class.
            // Finally, return the list of Job objects to the caller.
            using (var response = await client.SendAsync(request))
            {
                // Ensure that the response is successful (status code 200-299) and throw an exception if it is not
                response.EnsureSuccessStatusCode();

                // Read the response body as a string and store it in the body variable
                var body = await response.Content.ReadAsStringAsync();
                // Create a new JsonSerializerOptions object with the PropertyNameCaseInsensitive property set to true to allow for case-insensitive deserialization of the JSON response
                var parameters = new JsonSerializerOptions()
                {
                    // Set the PropertyNameCaseInsensitive property to true to allow for case-insensitive deserialization of the JSON response
                    PropertyNameCaseInsensitive = true
                };
                // Deserialize the JSON response body into a list of Job objects using the JsonSerializer.Deserialize method and the specified options, and store the result in the result variable
                var result = JsonSerializer.Deserialize<List<Job>>(body, parameters);
                // Return the list of Job objects to the caller
                return result;
            }
        }


    }
}
