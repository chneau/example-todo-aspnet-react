using HotChocolate.Resolvers;
using HotChocolate.Types;
using Todo.Web.Data;

namespace Todo.Web.GraphQL.Authors
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<AuthorByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }
    }
}
