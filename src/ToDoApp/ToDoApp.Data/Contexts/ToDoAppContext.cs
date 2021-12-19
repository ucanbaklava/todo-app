using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Data.Contexts
{
    public class ToDoAppContext : DbContext
    {
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
