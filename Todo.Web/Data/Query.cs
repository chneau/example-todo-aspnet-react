namespace Todo.Web.Data
{
    public class Query
    {
        public TodoItem GetTodo() =>
            new()
            {
                Description = "C# in depth.",
                Author = new Author { Name = "Jon Skeet" }
            };
    }
}
