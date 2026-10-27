using BusienessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataBaseLayer
{
    public static class Extensions
    {

        public static void AddTaskRepository(this IServiceCollection _service)
        {
            _service.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}
