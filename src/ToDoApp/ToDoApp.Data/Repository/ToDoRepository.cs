using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Contexts;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Data.Repository
{
    public class ToDoRepository : GenericRepository<ToDoItem>, IToDoRepository
    {
        public ToDoRepository(ToDoAppContext context) : base(context) { }
    }
}
