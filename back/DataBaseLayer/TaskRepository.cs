using Dapper;
using DataBaseLayer.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace DataBaseLayer
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connstring;
        public TaskRepository(IConfiguration conf)
        {
            _configuration = conf;
            connstring = conf.GetConnectionString("MSSQL");
        }

        public async Task<bool> ChangeStatusAsync(Guid id, bool status)
        {
            using (IDbConnection db = new SqlConnection(connstring))
            {
                int response = await db.ExecuteAsync("UPDATE Task SET Status = @stat WHERE ID = @id", new { @id = id, @stat = status});
                return response > 0;
            }
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            using (IDbConnection db = new SqlConnection(connstring))
            {
                int response = await db.ExecuteAsync("DELETE FROM Task WHERE ID = @id", new { @id = id});
                return response > 0;
            }
        }

        public async Task<List<ToDo>> GetAllTasksAsync()
        {
            using (IDbConnection db = new SqlConnection(connstring))
            {
                 var response = await db.QueryAsync<ToDo>("SELECT * FROM Task");
                return response.ToList(); 
             }
        }

        public async Task<ToDo> GetTaskByIdAsync(Guid id) //7E84325F-E597-4CE7-8087-5CB3BD04BBC3
        {
            using (IDbConnection db = new SqlConnection(connstring))
            {
                var response = await db.QueryAsync<ToDo>("SELECT * FROM Task WHERE ID = @id", new { @id = id });
                return response.FirstOrDefault();
            }
        }

        public async Task<bool> PostTaskAsync(ToDo task)
        {
            int rows;

            using (IDbConnection db = new SqlConnection(connstring))
            {
                 rows = await db.ExecuteAsync(
    "INSERT INTO Task (ID, Title, Description, StartDate, CreateDate, Status, EndDate) " +
    "VALUES (@id, @title, @desc, @start, @create, @stat, @end)",
    new
    {
        @id = task.Id,
        @title = task.Title,
        @desc = task.Description,
        @start = task.StartTime,
        @create = task.CreateTime,
        @stat = task.Status,
        @end = task.EndTime
    });
            }
            return rows > 0;
        }

        public async Task<bool> UpdateTaskAsync(ToDo newTask)
        {
            using (IDbConnection db = new SqlConnection(connstring))
            {
                ToDo oldTask = await GetTaskByIdAsync(newTask.Id);
                int response = await db.ExecuteAsync("UPDATE Task SET Title = @title, Description = @desc, StartDate = @start, EndDate = @end WHERE ID = @id",
                    new
                    {
                        @id = newTask.Id,
                        @title = newTask.Title == null ? oldTask.Title : newTask.Title,
                        @desc = newTask.Description == null ? oldTask.Description : newTask.Description,
                        @start = newTask.StartTime == null ? oldTask.StartTime : newTask.StartTime,
                        @end = newTask.EndTime == null ? oldTask.EndTime : newTask.EndTime
                    });
                return response > 0;
            }
        }
    }
}
