using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Model.DTOs;
using TaskManagerApp.ViewModel.Services;

public class TasksViewModel
{
    private readonly TasksService _dataServiceClient;

    public TasksViewModel(TasksService dataServiceClient)
    {
        _dataServiceClient = dataServiceClient;
    }

    public async Task<List<TaskDto>> GetOrderItems(int skip, int take, string sortField, bool sortAscending)
    {
        var orderItems = await _dataServiceClient.GetOrderItemsAsync(skip, take, sortField, sortAscending);
        return orderItems;
    }
}
