using Microsoft.AspNetCore.Mvc;
using TaskManager.Model.Entities;
using TaskManager.Model.Repository;

namespace TaskManager.Model.Controllers
{
    public class TasksController : BaseApiController
    {
        private readonly IGenericRepository<Tasks> _tasksRepository; 

        public TasksController(IGenericRepository<Tasks> tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        // GET: /tasks
        [HttpGet]
        public async Task<ActionResult> GetTasks(int skip = 0, int take = 20, string sortField = "Id", bool sortAscending = true)
        {
            try
            {
                var (items, totalCount) = await _tasksRepository.GetOrderTasksAsync(skip, take, sortField, sortAscending);

                return Ok(new
                {
                    Items = items,
                    TotalCount = totalCount
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while fetching tasks: {ex.Message}" });
            }
        }

        // GET: /tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTask(int id)
        {
            var task = await _tasksRepository.GetById(id);

            if (task == null)
                return NotFound(new { Message = $"Task with ID {id} not found." });

            return Ok(task);
        }

        // POST: /tasks
        [HttpPost]
        public async Task<ActionResult> CreateTask([FromBody] Tasks task)
        {
            if (task == null)
                return BadRequest(new { Message = "Task data is required." });

            try
            {
                await _tasksRepository.Insert(task);
                return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while creating the task: {ex.Message}" });
            }
        }

        // PUT: /tasks/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, [FromBody] Tasks task)
        {
            if (task == null || task.Id != id)
                return BadRequest(new { Message = "Task ID mismatch." });

            try
            {
                var existingTask = await _tasksRepository.GetById(id);

                if (existingTask == null)
                    return NotFound(new { Message = $"Task with ID {id} not found." });

                await _tasksRepository.Update(task);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while updating the task: {ex.Message}" });
            }
        }

        // DELETE: /tasks/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                var existingTask = await _tasksRepository.GetById(id);

                if (existingTask == null)
                    return NotFound(new { Message = $"Task with ID {id} not found." });

                await _tasksRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while deleting the task: {ex.Message}" });
            }
        }
    }
}
