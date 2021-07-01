using HotChocolate.Resolvers;
using HotChocolate.Types;
using Todo.Web.Data;

namespace Todo.Web.GraphQL.Books
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<BookByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }
    }
}
