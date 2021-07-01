using System.Collections.Generic;
using Todo.Web.Data;
using Todo.Web.GraphQL.Common;

namespace Todo.Web.GraphQL.TodoItems
{
    public class AddTodoItemPayload : TodoItemPayloadBase
    {
        public AddTodoItemPayload(TodoItem todoItem) : base(todoItem) { }

        public AddTodoItemPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}
