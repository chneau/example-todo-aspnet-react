using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using Todo.Web.Data;
using Todo.Web.GraphQL.DataLoaders;
using Todo.Web.GraphQL.GraphQL.Extensions;

namespace Todo.Web.GraphQL
{
    [ExtendObjectType("Query")]
    public class SpeakerQueries
    {
        [UseApplicationDbContext]
        public Task<List<TodoItem>> GetTodoItems([ScopedService] ApplicationDbContext context) =>
            context.TodoItems.ToListAsync();

        public Task<TodoItem> GetTodoItemAsync([ID(nameof(TodoItem))] Guid id, TodoItemByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
