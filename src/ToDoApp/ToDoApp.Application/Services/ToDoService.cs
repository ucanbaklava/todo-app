using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Data.UOW;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToDoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateToDoItem(ToDoItem toDoItem)
        {
            if (toDoItem == null)
            {
                throw new ArgumentNullException(nameof(toDoItem));
            }
            _unitOfWork.ToDos.Create(toDoItem);
            _unitOfWork.Complete();
        }

        public async Task<List<ToDoItem>> GetAllToDoItemsAsync()
        {
            return await _unitOfWork.ToDos.GetAllAsync();
        }

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            ToDoItem toDoItem = await _unitOfWork.ToDos.GetByIdAsync(id);

            if (toDoItem == null)
            {
                throw new ArgumentNullException(nameof(toDoItem), "No task found with the given id.");
            }

            return toDoItem;
        }
    }
}
