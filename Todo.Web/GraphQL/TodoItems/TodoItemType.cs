using HotChocolate.Resolvers;
using HotChocolate.Types;
using Todo.Web.Data;

namespace Todo.Web.GraphQL.TodoItems
{
    public class TodoItemType : ObjectType<TodoItem>
    {
        protected override void Configure(IObjectTypeDescriptor<TodoItem> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<TodoItemByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }
    }
}
