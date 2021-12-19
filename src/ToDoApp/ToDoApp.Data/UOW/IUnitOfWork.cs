using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Repository;

namespace ToDoApp.Data.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IToDoRepository ToDos { get; }
        int Complete();
    }
}
