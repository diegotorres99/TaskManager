using TaskManager.Model.DTOs;
using TaskManager.Model.Entities;

namespace TaskManager.Model.Repository
{
    public interface ITasksRepository
    {
        Task<bool> Insert(Tasks tasks);
        Task<bool> Update(Tasks tasks);
        Task<bool> Delete(int id);
        Task<IEnumerable<TaskDto>> GetAll(TaskFilter filters);
        Task<IEnumerable<TaskDto>> GetAll();
        Task<TaskDto> GetById(int id);
    }
}
