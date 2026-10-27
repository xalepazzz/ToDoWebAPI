using BusienessLayer.Entities;
using BusienessLayer.Interfaces;

namespace BusienessLayer
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repos;

        public TaskService(ITaskRepository repos )
        {
            _repos = repos;
        }

        public async Task<bool> ChangeStatusAsync(Guid id, Guid userId, bool status)
        {
            var response = await _repos.ChangeStatusAsync(id, userId, status);
            return response;
        }

        public async Task<bool> DeleteTaskAsync(Guid id, Guid userId)
        {
            var response = await _repos.DeleteTaskAsync(id, userId);
            return response;
        }

        public async Task<List<ToDo>> GetAllTasksAsync(Guid userId)
        {

            var response = await _repos.GetAllTasksAsync(userId);
                return response;
            
        }

        public async Task<ToDo> GetTaskByIdAsync(Guid id, Guid userId)
        {
            var response = await _repos.GetTaskByIdAsync(id, userId);
            return response;
        }

        public async Task<bool> PostTaskAsync(Guid userId, string title, string? description, DateTime startDate, DateTime? endTime)
        {
            ToDo task = 
                new ToDo { UserId = userId,
                    Title = title,
                    Description = description,
                    StartTime = startDate,
                    EndTime = endTime
                };

            var response = await  _repos.PostTaskAsync(task);
            return response;
        }

        public async Task<bool> UpdateTaskAsync(Guid id, Guid userId, string? title, string? description, DateTime? startDate, DateTime? endDate)
        {
            ToDo newtask =
               new ToDo
               {
                   Id = id,
                   UserId = userId,
                   Title = title,
                   Description = description,
                   StartTime = startDate,
                   EndTime = endDate
               };

            var response = await _repos.UpdateTaskAsync(newtask);
            return response; 
        }
    }
}
