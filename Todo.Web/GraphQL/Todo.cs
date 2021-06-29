using System;

namespace Todo.Web.GraphQL
{
    public class Todo
    {
        public string Description { get; set; }
        public DateTime? Done { get; set; }
        public Author Author { get; set; }
    }
}
