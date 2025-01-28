using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TaskManager.Model.DTOs;
using TaskManager.ViewModels.Models;


namespace TaskManagerApp.ViewModel.Services
{
    public class TasksService
    {
        private readonly HttpClient _httpClient;

        public TasksService()
        {
            // Assuming the base address of your API is already set
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7177/")
            };
        }

        public async Task<List<TaskDto>> GetFilteredTasksAsync(TaskFilterDto filters)
        {
            // Construct query parameters dynamically from the TaskFilterDto object
            var queryParams = new List<string>();

            if (filters.UserId.HasValue)
                queryParams.Add($"UserId={filters.UserId}");
            if (filters.StateId.HasValue)
                queryParams.Add($"StateId={filters.StateId}");
            if (!string.IsNullOrEmpty(filters.PriorityId.ToString()))
                queryParams.Add($"Priority={filters.PriorityId}");
            if (filters.DueDateStart.HasValue)
                queryParams.Add($"DueDateStart={filters.DueDateStart.Value:yyyy-MM-dd}");
            if (filters.DueDateEnd.HasValue)
                queryParams.Add($"DueDateEnd={filters.DueDateEnd.Value:yyyy-MM-dd}");

            queryParams.Add($"Skip={filters.Skip}");
            queryParams.Add($"Take={filters.Take}");
            queryParams.Add($"SortField={filters.SortField}");
            queryParams.Add($"SortAscending={filters.SortAscending.ToString().ToLower()}");

            // Combine the base URI with query parameters
            var requestUri = $"api/tasks?{string.Join("&", queryParams)}";

            try
            {
                // Send the POST request to the endpoint with filters in the body
                var response = await _httpClient.PostAsJsonAsync("api/tasks", filters);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle the error if the response is not successful
                    throw new HttpRequestException($"Error fetching tasks: {response.ReasonPhrase}");
                }

                // Deserialize the response into a list of TaskDto
                var taskResponse = await response.Content.ReadFromJsonAsync<TaskResponseDto>();
                return taskResponse?.Items ?? new List<TaskDto>();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Exception in GetFilteredTasksAsync: {ex.Message}");
                return new List<TaskDto>();
            }
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
                // Log or handle the exception
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
                // Log or handle the exception
                Console.WriteLine($"Exception in DeleteOrderItemAsync: {ex.Message}");
                throw;
            }
        }
    }
}
