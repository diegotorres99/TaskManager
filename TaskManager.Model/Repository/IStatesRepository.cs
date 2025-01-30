using TaskManager.Model.DTOs;

namespace TaskManager.Model.Repository
{
    public interface IStatesRepository
    {
        Task<IEnumerable<StateDto>> GetAll();
    }
}
