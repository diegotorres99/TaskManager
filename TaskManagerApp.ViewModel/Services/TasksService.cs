using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TaskManager.Model.DTOs;
using TaskManager.Model.Entities;
using TaskManager.ViewModels.Models;


namespace TaskManagerApp.ViewModel.Services
{
    public class TasksService
    {
        private readonly HttpClient _httpClient;

        public TasksService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7177/")
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

        public async Task UpdateOrderItemAsync(TaskDto item)
        {
            var requestUri = $"api/orderitems/{item.Id}";

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
                // Log or handle the exception
                Console.WriteLine($"Exception in UpdateOrderItemAsync: {ex.Message}");
                throw;
            }
        }

        public async Task CreateOrderItemAsync(TaskDto item)
        {
            var requestUri = $"api/orderitems";

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

        public async Task DeleteOrderItemAsync(int id)
        {
            var requestUri = $"api/orderitems/{id}";

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

        // Get users asynchronously from the API
        public async Task<List<UserDto>> GetUsersAsync()
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
                Console.WriteLine($"Exception in GetUsersAsync: {ex.Message}");
                return new List<UserDto>();
            }
        }

        public async Task<List<StateDto>> GetStatesAsync()
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
                Console.WriteLine($"Exception in GetStatesAsync: {ex.Message}");
                return new List<StateDto>();
            }
        }

        public async Task<List<PriorityDto>> GetPrioritiesAsync()
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
                Console.WriteLine($"Exception in GetPrioritiesAsync: {ex.Message}");
                return new List<PriorityDto>();
            }
        }
    }
}

