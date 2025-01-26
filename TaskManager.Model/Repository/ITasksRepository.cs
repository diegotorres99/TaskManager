namespace TaskManager.Model.Repository
{
    public interface ITasksRepository
    {
        Task<(IEnumerable<object> Items, int TotalCount)> GetOrderTasksAsync(int skip, int take, string sortField, bool sortAscending);
    }
}
