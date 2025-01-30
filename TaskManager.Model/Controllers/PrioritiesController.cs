using Microsoft.AspNetCore.Mvc;
using TaskManager.Model.Repository;

namespace TaskManager.Model.Controllers
{
    public class PrioritiesController : BaseApiController
    {
        private readonly IPrioritiesRepository _prioritiesRepository;
        public PrioritiesController(IPrioritiesRepository prioritiesRepository)
        {
            _prioritiesRepository = prioritiesRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPriorities()
        {
            var resp = await _prioritiesRepository.GetAll();
            return Ok(resp);
        }
    }
}
