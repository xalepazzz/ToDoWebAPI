using BusienessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusienessLayer
{
    public static class Extensions
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
