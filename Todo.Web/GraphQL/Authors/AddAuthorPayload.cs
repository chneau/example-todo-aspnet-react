using System.Collections.Generic;
using Todo.Web.Data;
using Todo.Web.GraphQL.Common;

namespace Todo.Web.GraphQL.Authors
{
    public class AddAuthorPayload : AuthorPayloadBase
    {
        public AddAuthorPayload(Author author) : base(author) { }

        public AddAuthorPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}
