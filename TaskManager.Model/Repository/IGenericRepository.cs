namespace TaskManager.Model.Repository
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<(IEnumerable<object> Items, int TotalCount)> GetOrderTasksAsync(int skip, int take, string sortField, bool sortAscending);
        Task<bool> Insert(TEntityModel entity);
        Task<bool> Update(TEntityModel entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<TEntityModel>> GetAll();
        Task<TEntityModel> GetById(int id);
    }
}
