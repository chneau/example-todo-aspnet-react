using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Todo.Web.Data;

namespace Todo.Web.GraphQL.GraphQL.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
