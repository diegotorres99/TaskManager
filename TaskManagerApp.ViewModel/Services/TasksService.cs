using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using TaskManager.Model.DTOs;


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
                BaseAddress = new Uri("https://your-api-endpoint.com/")
            };
        }

        public async Task<List<TaskDto>> GetOrderItemsAsync(int skip, int take, string sortField, bool sortAscending)
        {
            var requestUri = $"api/orderitems?skip={skip}&take={take}&sortField={sortField}&sortAscending={sortAscending}";

            try
            {
                var response = await _httpClient.GetAsync(requestUri);

                if (!response.IsSuccessStatusCode)
                {
                    // Log the error or handle it as per your application's requirements
                    throw new HttpRequestException($"Error fetching order items: {response.ReasonPhrase}");
                }

                var orderItems = await response.Content.ReadFromJsonAsync<List<TaskDto>>();
                return orderItems ?? new List<TaskDto>();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Exception in GetOrderItemsAsync: {ex.Message}");
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
