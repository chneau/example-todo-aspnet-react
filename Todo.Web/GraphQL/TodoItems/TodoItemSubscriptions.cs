using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Todo.Web.Data;

namespace Todo.Web.GraphQL.TodoItems
{
    [ExtendObjectType("Subscription")]
    public class TodoItemSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<TodoItem> OnTodoItemScheduledAsync(
            [EventMessage] Guid id,
            TodoItemByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            sessionById.LoadAsync(id, cancellationToken);
    }
}
