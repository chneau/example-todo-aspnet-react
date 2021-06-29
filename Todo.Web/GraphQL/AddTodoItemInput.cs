using Todo.Web.Data;

namespace Todo.Web.GraphQL
{
    public record AddTodoItemInput(string Description, Author Author);
}
