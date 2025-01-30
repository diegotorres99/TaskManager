using Microsoft.AspNetCore.Mvc;
using TaskManager.Model.Repository;

namespace TaskManager.Model.Controllers
{
    public class StatesController : BaseApiController
    {
        private readonly IStatesRepository _statesRepository;
        
        public StatesController(IStatesRepository statesRepository)
        {
            _statesRepository = statesRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var resp = await _statesRepository.GetAll();
            return Ok(resp);
        }
    }
}
