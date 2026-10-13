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

        public async Task<ToDo> GetTaskByIdAsync(string id)
        {
            using (IDbConnection db = new SqlConnection(connstring))
            {
                var response = await db.QueryAsync<ToDo>("SELECT * FROM Task WHERE ID = @id", new { id });
                return response.FirstOrDefault();
            }
        }

        public Task<bool> PutTaskAsync(Task task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTaskAsync()
        {
            throw new NotImplementedException();
        }
    }
}
