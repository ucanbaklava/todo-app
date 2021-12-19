using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Services;

namespace ToDoApp.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection SetupApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IToDoService, ToDoService>();
            return serviceCollection;
        }
    }
}
