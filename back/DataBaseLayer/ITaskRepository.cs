using DataBaseLayer.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DataBaseLayer
{
    public interface ITaskRepository
    {
        public Task<ToDo> GetTaskByIdAsync (string id);
        public Task<bool> PutTaskAsync(Task task);
        public Task<bool> UpdateTaskAsync();
        public Task<bool> DeleteTaskAsync(string id);

    }
}
