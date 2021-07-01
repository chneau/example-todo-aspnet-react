using System.Collections.Generic;
using Todo.Web.Data;
using Todo.Web.GraphQL.Common;

namespace Todo.Web.GraphQL.TodoItems
{
    public class TodoItemPayloadBase : Payload
    {
        protected TodoItemPayloadBase(TodoItem todoItem)
        {
            TodoItem = todoItem;
        }

        protected TodoItemPayloadBase(IReadOnlyList<UserError> errors) : base(errors) { }

        public TodoItem? TodoItem { get; }
    }
}
