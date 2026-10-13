using DataBaseLayer;
using Microsoft.AspNetCore.Mvc;

namespace back
{
    [Controller]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _rep;
        TaskController(ITaskRepository rep)
        {
            _rep = rep;
        }
        [HttpGet]
        public async Task<ActionResult> GetTaskById(string Id)
        {
            var task = await _rep.GetTaskByIdAsync(Id);
            return Ok(task);

        }
    }
}
