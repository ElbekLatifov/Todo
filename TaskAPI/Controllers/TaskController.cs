using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Entities;
using TaskAPI.Models;
using TaskAPI.Services;
using TaskAPI.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private ILogger<TaskController> _logger;
        private IValidator<TaskModel> validator;

        public TaskController(ITaskService taskService, IValidator<TaskModel> rules, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            validator = rules;
            _logger = logger;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public async Task<List<Entities.Task>> Get()
        {
            return await _taskService.GetTasksAsync();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<Entities.Task> GetById(Guid id)
        {
            return await _taskService.GetTaskByIdAsync(id);
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskModel value)
        {
            var result = validator.Validate(value);
            if(result.IsValid)
            {
                var taskid = await _taskService.AddTaskAsync(value);
                return Created("", new { id = taskid });
            }
            _logger.LogError("Error with create task", result.Errors);
            return BadRequest(result);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task Put(Guid id, [FromBody] TaskModel value)
        {
            var result = validator.Validate(value);
            if(result.IsValid)
            {
                await _taskService.UpdateTaskAsync(id, value);
            }
            
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task Delete(Guid id)
        {
            await _taskService.DeleteTaskAsync(id);
            _logger.LogWarning($"Task deleted with id : {id}");
        }
    }
}
