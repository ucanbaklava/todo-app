using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Contexts;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Data.Extensions
{
    public static class DataExtensions
    {
        private static List<ToDoItem> ToDoItems = new List<ToDoItem>()
        {
            new ToDoItem() { Id = 1, CreatedAt = DateTime.UtcNow, IsCompleted = false, TaskContent = "Do the dishes"},
            new ToDoItem() { Id = 2, CreatedAt = DateTime.UtcNow, IsCompleted = false, TaskContent = "Tidy up your room"},
            new ToDoItem() { Id = 3, CreatedAt = DateTime.UtcNow, IsCompleted = false, TaskContent = "Finish your assignment"},
            new ToDoItem() { Id = 4, CreatedAt = DateTime.UtcNow, IsCompleted = false, TaskContent = "Do dishes"}
        };

        public static EntityTypeBuilder<ToDoItem> SeedData(this EntityTypeBuilder<ToDoItem> todos)
        {
            todos.HasData(ToDoItems);
            return todos;
        }

        public static IServiceCollection SetupData(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ToDoAppContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            return serviceCollection;
        }

    }

}
