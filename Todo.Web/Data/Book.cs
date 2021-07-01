using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Todo.Web.Data
{
    public class Book
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public virtual List<TodoItem> TodoItems { get; set; } = new();
    }
}
