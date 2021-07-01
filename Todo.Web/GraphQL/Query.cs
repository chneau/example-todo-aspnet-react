using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Todo.Web.Data;
using Todo.Web.GraphQL.GraphQL.Extensions;

namespace Todo.Web.GraphQL
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<TodoItem>> GetTodoItems([ScopedService] ApplicationDbContext context) =>
            context.TodoItems.ToListAsync();
    }
}
