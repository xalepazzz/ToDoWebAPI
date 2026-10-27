using BusienessLayer.DTO;
using BusienessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BusienessLayer.Interfaces
{
    public interface ITaskService
    {
        public Task<List<ToDo>> GetAllTasksAsync(Guid userId);
        public Task<ToDo> GetTaskByIdAsync(Guid id, Guid userId);
        public Task<bool> PostTaskAsync(Guid userId, string title, string? description, DateTime startDate, DateTime? endDate);
        public Task<bool> UpdateTaskAsync(Guid id, Guid userId, string? title, string? description, DateTime? startDate, DateTime? endDate);
        public Task<bool> ChangeStatusAsync(Guid id, Guid userId, bool status);
        public Task<bool> DeleteTaskAsync(Guid id, Guid userId);
    }
}
