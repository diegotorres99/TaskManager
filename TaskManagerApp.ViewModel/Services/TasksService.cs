using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TaskManager.Model.DTOs;
using TaskManager.Model.Entities;
using TaskManager.ViewModel.Helpers;
using TaskManager.ViewModels.Models;

namespace TaskManagerApp.ViewModel.Services
{
    public class TasksService
    {
        private readonly HttpClient _httpClient;

        public TasksService()
        {
            var configuration = Settings.LoadConfiguration();
            string baseUrl = configuration["ApiSettings:BaseUrl"] 
                ?? throw new Exception("BaseUrl not found in appsettings.json");

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<List<Tasks>> GetFilteredTasksAsync(TaskFilterDto filters)
        {
            var requestUri = $"api/tasks?{BuildQueryParams(filters)}";

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/tasks", filters);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error fetching tasks: {response.ReasonPhrase}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var taskResponse = JsonSerializer.Deserialize<List<Tasks>>(jsonString, options);
                return taskResponse ?? [];

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetFilteredTasksAsync: {ex.Message}");
                return new List<Tasks>();
            }
        }

        public async Task UpdateTaskAsync(TaskDto item)
        {
            var requestUri = $"api/tasks/{item.Id}";

            try
            {
                var jsonContent = JsonSerializer.Serialize(item);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(requestUri, httpContent);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error updating order item: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UpdateOrderItemAsync: {ex.Message}");
                throw;
            }
        }

        public async Task CreateTaskAsync(TaskDto item)
        {
            var requestUri = $"api/tasks/create-task";

            try
            {
                var jsonContent = JsonSerializer.Serialize(item);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(requestUri, httpContent);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error creating order item: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in CreateOrderItemAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            var requestUri = $"api/tasks/{id}";

            try
            {
                var response = await _httpClient.DeleteAsync(requestUri);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error deleting order item: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in DeleteOrderItemAsync: {ex.Message}");
                throw;
            }
        }

        private string BuildQueryParams(TaskFilterDto filters)
        {
            var queryParams = new List<string>();

            if (filters.UserId.HasValue)
                queryParams.Add($"UserId={filters.UserId}");
            if (filters.StateId.HasValue)
                queryParams.Add($"StateId={filters.StateId}");
            if (!string.IsNullOrEmpty(filters.PriorityId.ToString()))
                queryParams.Add($"PriorityId={filters.PriorityId}");
            if (filters.DueDateStart.HasValue)
                queryParams.Add($"DueDateStart={filters.DueDateStart.Value:yyyy-MM-dd}");
            if (filters.DueDateEnd.HasValue)
                queryParams.Add($"DueDateEnd={filters.DueDateEnd.Value:yyyy-MM-dd}");

            queryParams.Add($"Skip={filters.Skip}");
            queryParams.Add($"Take={filters.Take}");
            queryParams.Add($"SortField={filters.SortField}");
            queryParams.Add($"SortAscending={filters.SortAscending.ToString().ToLower()}");

            return string.Join("&", queryParams);
        }
    }
}

