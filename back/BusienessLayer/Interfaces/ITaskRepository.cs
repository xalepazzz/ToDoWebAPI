using BusienessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace BusienessLayer.Interfaces
{
    public interface ITaskRepository
    {
        public Task<List<ToDo>> GetAllTasksAsync(Guid UserId);
        public Task<ToDo> GetTaskByIdAsync (Guid id, Guid UserId);
        public Task<bool> PostTaskAsync(ToDo task );
        public Task<bool> UpdateTaskAsync(ToDo newTask);
        public Task<bool> ChangeStatusAsync(Guid id, Guid userId, bool status);
        public Task<bool> DeleteTaskAsync(Guid id, Guid userId);

    }
}
