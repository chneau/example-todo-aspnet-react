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

namespace Todo.Web.GraphQL.Books
{
    [ExtendObjectType("Query")]
    public class BookQueries
    {
        [UseApplicationDbContext]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] ApplicationDbContext context) =>
            context.Books;

        public Task<Book> GetBookAsync([ID(nameof(Book))] Guid id, BookByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
