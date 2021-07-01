using System.Collections.Generic;
using Todo.Web.Data;
using Todo.Web.GraphQL.Common;

namespace Todo.Web.GraphQL.Books
{
    public class AddBookPayload : BookPayloadBase
    {
        public AddBookPayload(Book book) : base(book) { }

        public AddBookPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}
