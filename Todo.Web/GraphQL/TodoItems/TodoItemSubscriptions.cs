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
        public Task<TodoItem> OnTodoItemAsync(
            [EventMessage] Guid id,
            TodoItemByIdDataLoader todoItemById,
            CancellationToken cancellationToken) =>
            todoItemById.LoadAsync(id, cancellationToken);
    }
}
