using Todo.Web.Data;

namespace Todo.Web.GraphQL
{
    public class AddTodoItemPayload
    {
        public AddTodoItemPayload(TodoItem todoItem)
        {
            TodoItem = todoItem;
        }

        public TodoItem TodoItem { get; }
    }
}
