using DataBaseLayer;
using Microsoft.AspNetCore.Mvc;

namespace back
{
    [Controller]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _rep;
        public TaskController(ITaskRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<ActionResult> GetTaskById(string id)
        {
            var task = await _rep.GetTaskByIdAsync(id);
            return Ok(task);

        }

        [HttpPut]
        public async Task<ActionResult> PutTaskById(string title, string? description, string startTime)
        {
            var task = await _rep.PutTaskAsync(new DataBaseLayer.Entities.ToDo {Title = title, Description = description, StartTime = DateTime.Parse(startTime), EndTime = null});
            return Ok(task);

        }
    }
}
