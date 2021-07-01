using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Todo.Web.Data;
using Todo.Web.GraphQL.GraphQL.Extensions;

namespace Todo.Web.GraphQL.Authors
{
    public record AddAuthorInput(string Name);

    [ExtendObjectType("Mutation")]
    public class AuthorMutations
    {
        [UseApplicationDbContext]
        public async Task<AddAuthorPayload> AddAuthorAsync(AddAuthorInput input, [ScopedService] ApplicationDbContext context)
        {
            var author = new Author
            {
                Name = input.Name,
            };

            context.Authors.Add(author);
            await context.SaveChangesAsync();

            return new AddAuthorPayload(author);
        }
    }
}
