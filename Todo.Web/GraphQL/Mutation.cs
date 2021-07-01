using System.Threading.Tasks;
using HotChocolate;
using Todo.Web.Data;
using Todo.Web.GraphQL.GraphQL.Extensions;

namespace Todo.Web.GraphQL
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddTodoItemPayload> AddTodoItemAsync(AddTodoItemInput input, [ScopedService] ApplicationDbContext context)
        {
            var speaker = new TodoItem
            {
                Description = input.Description,
                Author = input.Author,
                Books = input.Books,
            };

            context.TodoItems.Add(speaker);
            await context.SaveChangesAsync();

            return new AddTodoItemPayload(speaker);
        }
    }
}
