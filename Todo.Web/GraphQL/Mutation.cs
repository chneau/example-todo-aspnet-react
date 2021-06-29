using System.Threading.Tasks;
using HotChocolate;
using Todo.Web.Data;

namespace Todo.Web.GraphQL
{
    public class Mutation
    {
        public async Task<AddTodoItemPayload> AddTodoItemAsync(AddTodoItemInput input, [Service] ApplicationDbContext context)
        {
            var speaker = new TodoItem
            {
                Description = input.Description,
                Author = input.Author,
            };

            context.TodoItems.Add(speaker);
            await context.SaveChangesAsync();

            return new AddTodoItemPayload(speaker);
        }
    }
}
