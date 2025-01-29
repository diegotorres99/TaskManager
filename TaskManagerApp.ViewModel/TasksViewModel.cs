using TaskManager.Model.DTOs;
using TaskManager.Model.Entities;
using TaskManager.ViewModels.Models;
using TaskManagerApp.ViewModel.Services;

public class TasksViewModel
{
    private readonly TasksService _dataServiceClient;

    public TasksViewModel(TasksService dataServiceClient)
    {
        _dataServiceClient = dataServiceClient;
    }

    public async Task<List<Tasks>> GetOrderItems(TaskFilterDto taskFilterDto)
    {
        var orderItems = await _dataServiceClient.GetFilteredTasksAsync(taskFilterDto);
        return orderItems;
    }
}
