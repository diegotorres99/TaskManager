using TaskManager.Model.DTOs;

namespace TaskManager.Model.Repository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserDto>> GetAll();
    }
}
