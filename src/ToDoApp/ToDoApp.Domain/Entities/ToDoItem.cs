using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string TaskContent { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
