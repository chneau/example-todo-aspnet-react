using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using Todo.Web.Data;
using Todo.Web.GraphQL.GraphQL.Extensions;
using HotChocolate.Data;

namespace Todo.Web.GraphQL.TodoItems
{
    [ExtendObjectType("Query")]
    public class TodoItemQueries
    {
        [UseApplicationDbContext]
        [UsePaging(typeof(NonNullType<TodoItemType>))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<TodoItem> GetTodoItems([ScopedService] ApplicationDbContext context) =>
            context.TodoItems;

        public Task<TodoItem> GetTodoItemAsync([ID(nameof(TodoItem))] Guid id, TodoItemByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
