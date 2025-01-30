using System.Text.Json;
using TaskManager.Model.DTOs;
using TaskManager.ViewModel.Helpers;

namespace TaskManager.ViewModel.Services
{
    public class PrioritiesService
    {
        private readonly HttpClient _httpClient;

        public PrioritiesService()
        {
            var configuration = Settings.LoadConfiguration();
            string baseUrl = configuration["ApiSettings:BaseUrl"]
                             ?? throw new Exception("BaseUrl not found in appsettings.json");

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<List<PriorityDto>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/priorities");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error fetching priorities: {response.ReasonPhrase}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var priorities = JsonSerializer.Deserialize<List<PriorityDto>>(jsonString, options);
                return priorities ?? new List<PriorityDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetAllAsync: {ex.Message}");
                return new List<PriorityDto>();
            }
        }
    }
}
