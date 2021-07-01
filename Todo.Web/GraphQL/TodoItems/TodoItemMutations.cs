using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Todo.Web.Data;
using Todo.Web.GraphQL.GraphQL.Extensions;

namespace Todo.Web.GraphQL.TodoItems
{
    public record AddTodoItemInput(string Description, Author? Author, List<Book>? Books);

    [ExtendObjectType("Mutation")]
    public class TodoItemMutations
    {
        [UseApplicationDbContext]
        public async Task<AddTodoItemPayload> AddTodoItemAsync(AddTodoItemInput input, [ScopedService] ApplicationDbContext context)
        {
            var speaker = new TodoItem
            {
                Description = input.Description,
                Author = input.Author,
                Books = input.Books ?? new(),
            };

            context.TodoItems.Add(speaker);
            await context.SaveChangesAsync();

            return new AddTodoItemPayload(speaker);
        }
    }
}
