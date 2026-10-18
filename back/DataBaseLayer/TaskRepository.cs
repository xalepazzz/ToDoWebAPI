using Dapper;
using DataBaseLayer.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

        public Task<bool> DeleteTaskAsync(string id)
        {
            throw  new NotImplementedException();
        }

        public async Task<ToDo> GetTaskByIdAsync(string id) //7E84325F-E597-4CE7-8087-5CB3BD04BBC3
        {
            using (IDbConnection db = new SqlConnection(connstring))
            {
                var response = await db.QueryAsync<ToDo>("SELECT * FROM Task WHERE ID = @id", new { @id = id });
                return response.FirstOrDefault();
            }
        }

        public async Task<bool> PutTaskAsync(ToDo task)
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

        public Task<bool> UpdateTaskAsync()
        {
            throw new NotImplementedException();
        }
    }
}
