namespace Todo.Web.GraphQL
{
    public class Query
    {
        public Todo GetTodo() =>
            new()
            {
                Description = "C# in depth.",
                Author = new Author
                {
                    Name = "Jon Skeet"
                }
            };
    }
}
