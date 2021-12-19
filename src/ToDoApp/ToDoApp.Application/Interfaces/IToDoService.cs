using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoService
    {
        /// <summary>
        /// Returns all To-Do items asynchronously.
        /// <seealso cref="ToDoItem"/>
        /// </summary>
        /// <returns></returns>
        Task<List<ToDoItem>> GetAllToDoItemsAsync();

        /// <summary>
        /// Returns a single To-Do item asynchronously by Id.
        /// <seealso cref="ToDoItem"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ToDoItem> GetToDoItemByIdAsync(int id);

        /// <summary>
        /// This method takes a ToDoItem as parameter and creates a ToDoItem. Returns void.
        /// <seealso cref="ToDoItem"/>
        /// </summary>
        /// <param name="toDoItem"></param>
        void CreateToDoItem(ToDoItem toDoItem);
    }
}
