using back.Mapping;
using BusienessLayer.DTO;
using BusienessLayer.Entities;
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
        public async Task<ActionResult> GetAllTasks(Guid userId)
        {
            try
            {
                var response = await _serv.GetAllTasksAsync(userId);
                return Ok(response.ToDtoList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetTaskById(Guid id, Guid userId)
        {
            try
            {
                var task = await _serv.GetTaskByIdAsync(id, userId);
                
                return Ok(task.ToDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostTaskById(Guid userId, string title, string? description, string startDate, string endDate)
        {
            try
            {
                var task = await _serv.PostTaskAsync(userId, title, description, DateTime.Parse(startDate), DateTime.Parse(endDate));
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutTaskAync(Guid id, Guid userId, string? title, string? description, DateTime? startDate, DateTime? endDate)
        {
            
            try
            {
                if (title == null && description == null && startDate == null && endDate == null)
                {
                    
                }
                var newToDo = await _serv.UpdateTaskAsync(id, userId, title, description, startDate, endDate);
                return Ok(newToDo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateTaskStatusAsync(Guid id, Guid userId, bool stat)
        {
            try
            {
                var response = await _serv.ChangeStatusAsync(id, userId, stat);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

            [HttpDelete]
            public async Task<ActionResult> DeleteTaskById(Guid id, Guid userId)
            {
                try
                { 
                    var response = await _serv.DeleteTaskAsync(id, userId);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


            }
        }
    }

