using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Contexts;
using ToDoApp.Data.Repository;

namespace ToDoApp.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoAppContext _toDoAppContext;
        public IToDoRepository ToDos { get; }

        public UnitOfWork(IToDoRepository toDoRepository, ToDoAppContext toDoAppContext)
        {
            ToDos = toDoRepository;
            _toDoAppContext = toDoAppContext;
        }

        public int Complete()
        {
            return _toDoAppContext.SaveChanges();
        }
        public void Dispose()
        {
            _toDoAppContext.Dispose();
        }
    }
}
