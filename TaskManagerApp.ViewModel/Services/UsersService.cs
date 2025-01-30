using System.Text.Json;
using TaskManager.Model.DTOs;
using TaskManager.ViewModel.Helpers;

namespace TaskManager.ViewModel.Services
{
    public class UsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService()
        {
            var configuration = Settings.LoadConfiguration();
            string baseUrl = configuration["ApiSettings:BaseUrl"]
                             ?? throw new Exception("BaseUrl not found in appsettings.json");

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/users");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error fetching users: {response.ReasonPhrase}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var users = JsonSerializer.Deserialize<List<UserDto>>(jsonString, options);
                return users ?? new List<UserDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetAllAsync: {ex.Message}");
                return new List<UserDto>();
            }
        }
    }
}
