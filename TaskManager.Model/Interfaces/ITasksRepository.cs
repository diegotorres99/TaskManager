using TaskManager.Model.Entities;

namespace TaskManager.Model.Interfaces
{
    public interface ITasksRepository2
    {
        Task<(IEnumerable<object> Items, int TotalCount)> GetOrderItemsAsync(int skip, int take, string sortField, bool sortAscending);
        Task<Tasks> GetTaskIdAsync(int id); 
        Task<Tasks> AddTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
