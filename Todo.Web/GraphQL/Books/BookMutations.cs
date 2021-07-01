using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Todo.Web.Data;
using Todo.Web.GraphQL.GraphQL.Extensions;

namespace Todo.Web.GraphQL.Books
{
    public record AddBookInput(string Name);

    [ExtendObjectType("Mutation")]
    public class BookMutations
    {
        [UseApplicationDbContext]
        public async Task<AddBookPayload> AddBookAsync(AddBookInput input, [ScopedService] ApplicationDbContext context)
        {
            var speaker = new Book
            {
                Name = input.Name,
            };

            context.Books.Add(speaker);
            await context.SaveChangesAsync();

            return new AddBookPayload(speaker);
        }
    }
}
