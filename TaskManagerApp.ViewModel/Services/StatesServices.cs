using System.Text.Json;
using TaskManager.Model.DTOs;
using TaskManager.ViewModel.Helpers;

namespace TaskManager.ViewModel.Services
{
    public class StatesServices
    {
        private readonly HttpClient _httpClient;

        public StatesServices()
        {
            var configuration = Settings.LoadConfiguration();
            string baseUrl = configuration["ApiSettings:BaseUrl"]
                             ?? throw new Exception("BaseUrl not found in appsettings.json");

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<List<StateDto>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/states");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error fetching states: {response.ReasonPhrase}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var states = JsonSerializer.Deserialize<List<StateDto>>(jsonString, options);
                return states ?? new List<StateDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetAllAsync: {ex.Message}");
                return new List<StateDto>();
            }
        }
    }
}
