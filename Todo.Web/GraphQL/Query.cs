using System.Linq;
using HotChocolate;
using Todo.Web.Data;

namespace Todo.Web.GraphQL
{
    public class Query
    {
        public IQueryable<TodoItem> GetTodoItems([Service] ApplicationDbContext context) => context.TodoItems;
    }
}
