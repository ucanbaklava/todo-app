using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Services;
using ToDoApp.Data.UOW;
using ToDoApp.Domain.Entities;
using Xunit;

namespace ToDoApp.Tests
{
    public class ToDoServiceTests
    {
        private readonly ToDoService _sut;
        private readonly Mock<IToDoService> _toDoServiceMock = new Mock<IToDoService>();
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        List<ToDoItem> todoItems;

        public ToDoServiceTests()
        {
            _sut = new ToDoService(_unitOfWork.Object);
            todoItems = new List<ToDoItem>()
            {
                new ToDoItem() {Id = 1, TaskContent = "Do the dishes", CreatedAt = DateTime.UtcNow, IsCompleted = false },
                new ToDoItem() {Id = 2, TaskContent = "Tidy up your room", CreatedAt = DateTime.UtcNow, IsCompleted = true },
                new ToDoItem() {Id = 3, TaskContent = "Finish your assignment", CreatedAt = DateTime.UtcNow, IsCompleted = false },
                new ToDoItem() {Id = 4, TaskContent = "Excercise", CreatedAt = DateTime.UtcNow, IsCompleted = false },
            };
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnToDoItem_When_Exists()
        {
            var toDoItemId = 5;
            var taskContent = "Do your assignment";

            var toDoItemDto = new ToDoItem
            {
                Id = toDoItemId,
                TaskContent = taskContent,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Setup(x => x.ToDos.GetByIdAsync(toDoItemId))
                .ReturnsAsync(toDoItemDto);

            var toDoItem = await _sut.GetToDoItemByIdAsync(toDoItemId);

            Assert.Equal(toDoItemId, toDoItem.Id);
            Assert.Equal(taskContent, toDoItem.TaskContent);
        }


        [Fact]
        public async Task GetAllToDoItemsAsync_ShouldReturnAllToDoItems()
        {
            _unitOfWork.Setup(x => x.ToDos.GetAllAsync())
                .ReturnsAsync(todoItems);

            var items = await _sut.GetAllToDoItemsAsync();

            Assert.Equal(todoItems.Count, items.Count);
            Assert.Equal(todoItems[1].Id, items[1].Id);
        }

    }
}
