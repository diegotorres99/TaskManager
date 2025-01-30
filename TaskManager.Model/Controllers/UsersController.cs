using Microsoft.AspNetCore.Mvc;
using TaskManager.Model.Repository;

namespace TaskManager.Model.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var resp = await _usersRepository.GetAll();
            return Ok(resp);
        }

    }
}
