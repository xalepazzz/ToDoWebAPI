using BuisenessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisenessLogic
{
    public static class Extensions
    {
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserService,UserService>();
        }
    }
}
