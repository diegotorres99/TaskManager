using TaskManager.Model.DTOs;
using TaskManager.Model.Entities;

namespace TaskManager.Model.Repository
{
    public interface ITasksRepository
    {
        Task<bool> Insert(Tasks tasks);
        Task<bool> Update(Tasks tasks);
        Task<bool> Delete(int id);
        Task<IEnumerable<Tasks>> GetAll(TaskFilter filters);
        Task<IEnumerable<Tasks>> GetAll();
        Task<Tasks> GetById(int id);
    }
}
