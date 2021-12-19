using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;

namespace ToDoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private readonly ILogger<ToDoController> _logger;
        public ToDoController(IToDoService toDoService, ILogger<ToDoController> logger)
        {
            _toDoService = toDoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> Get()
        {
            _logger.LogInformation($"[API-REQUEST][api/todo] => GET REQUEST by : {HttpContext.Connection.RemoteIpAddress.ToString()}");
            List<ToDoItem> items = await _toDoService.GetAllToDoItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetById(int id)
        {
            _logger.LogInformation($"[{DateTime.Now.ToString("HH:mm:ss")}][api/todo/{id}] => GET REQUEST by : {HttpContext.Connection.RemoteIpAddress.ToString()}");
            ToDoItem item = await _toDoService.GetToDoItemByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public void Create(ToDoItem toDoItem)
        {
            _logger.LogInformation($"[{DateTime.Now.ToString("HH:mm:ss")}][api/todo] => POST REQUEST by : {HttpContext.Connection.RemoteIpAddress.ToString()}");

            _toDoService.CreateToDoItem(toDoItem);
        }
    }
}
