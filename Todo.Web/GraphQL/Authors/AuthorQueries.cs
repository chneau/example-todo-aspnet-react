using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using Todo.Web.Data;
using Todo.Web.GraphQL.GraphQL.Extensions;

namespace Todo.Web.GraphQL.Authors
{
    [ExtendObjectType("Query")]
    public class AuthorQueries
    {
        [UseApplicationDbContext]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthors([ScopedService] ApplicationDbContext context) =>
            context.Authors;

        public Task<Author> GetAuthorAsync([ID(nameof(Author))] Guid id, AuthorByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
