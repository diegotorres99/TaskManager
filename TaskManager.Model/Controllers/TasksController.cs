using Microsoft.AspNetCore.Mvc;
using TaskManager.Model.DTOs;
using TaskManager.Model.Entities;
using TaskManager.Model.Repository;

namespace TaskManager.Model.Controllers
{
    public class TasksController : BaseApiController
    {
        private readonly ITasksRepository _tasksRepository; 

        public TasksController(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        [HttpPost]
        public async Task<ActionResult> GetTasks([FromBody] TaskFilter filters)
        {
             var resp = await _tasksRepository.GetAll(filters);

             return Ok(resp);
        }

        [HttpGet("test")]
        public async Task<ActionResult> GetTasksTest()
        {
            var resp = await _tasksRepository.GetAll();
            return Ok(new
            {
                Items = resp,
                TotalCount = resp.Count()
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTask(int id)
        {
            var task = await _tasksRepository.GetById(id);

            if (task == null)
                return NotFound(new { Message = $"Task with ID {id} not found." });

            return Ok(task);
        }

        [HttpPost("create-task")]
        public async Task<ActionResult> CreateTask([FromBody] Tasks task)
        {
            if (task == null)
                return BadRequest(new { Message = "Task data is required." });

                await _tasksRepository.Insert(task);
                return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, [FromBody] Tasks task)
        {
            if (task == null || task.Id != id)
                return BadRequest(new { Message = "Task ID mismatch." });

                var existingTask = await _tasksRepository.GetById(id);

                if (existingTask == null)
                    return NotFound(new { Message = $"Task with ID {id} not found." });

                await _tasksRepository.Update(task);
                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
             var existingTask = await _tasksRepository.GetById(id);
             if (existingTask == null)
                  return NotFound(new { Message = $"Task with ID {id} not found." });

             await _tasksRepository.Delete(id);
             return NoContent();
        }
    }
}
