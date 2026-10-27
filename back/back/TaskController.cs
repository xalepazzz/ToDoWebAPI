using BusienessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace back
{
    [Controller]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _serv;
        public TaskController(ITaskService serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTasks()
        {
            try
            {
                return Ok(await _serv.GetAllTasksAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetTaskById(Guid id)
        {
            try
            {
                var task = await _serv.GetTaskByIdAsync(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostTaskById(string title, string? description, string startTime)
        {
            try
            {
                var task = await _serv.PostTaskAsync(new DataBaseLayer.Entities.ToDo { Title = title, Description = description, StartTime = DateTime.Parse(startTime), EndTime = null });
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutTaskAync(Guid id, string? title, string? description, DateTime? startDate, DateTime? endDate)
        {
            
            try
            {
                if (title == null && description == null && startDate == null && endDate == null)
                {
                    
                }
                var newToDo = await _serv.UpdateTaskAsync(new DataBaseLayer.Entities.ToDo { Id = id, Title = title, Description = description, EndTime = endDate });
                return Ok(newToDo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateTaskStatusAsync(Guid id, bool stat)
        {
            try
            {
                var response = await _serv.ChangeStatusAsync(id, stat);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

            [HttpDelete]
            public async Task<ActionResult> DeleteTaskById(Guid id)
            {
                try
                {
                throw new Exception();
                    var response = await _serv.DeleteTaskAsync(id);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                throw new Exception("TestException");
                    return BadRequest(ex.Message);
                }


            }
        }
    }

