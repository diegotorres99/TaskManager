using TaskManager.Model.DTOs;

namespace TaskManager.Model.Repository
{
    public interface IPrioritiesRepository
    {
        Task<IEnumerable<PriorityDto>> GetAll();
    }
}
