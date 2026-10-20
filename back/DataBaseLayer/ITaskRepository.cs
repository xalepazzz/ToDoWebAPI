using DataBaseLayer.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DataBaseLayer
{
    public interface ITaskRepository
    {
        public Task<List<ToDo>> GetAllTasksAsync();
        public Task<ToDo> GetTaskByIdAsync (Guid id);
        public Task<bool> PostTaskAsync(ToDo task );
        public Task<bool> UpdateTaskAsync(ToDo newTask);
        public Task<bool> ChangeStatusAsync(Guid id, bool status);
        public Task<bool> DeleteTaskAsync(Guid id);

    }
}
