using System.Collections.Generic;
using Todo.Web.Data;
using Todo.Web.GraphQL.Common;

namespace Todo.Web.GraphQL.Authors
{
    public class AuthorPayloadBase : Payload
    {
        protected AuthorPayloadBase(Author author)
        {
            Author = author;
        }

        protected AuthorPayloadBase(IReadOnlyList<UserError> errors) : base(errors) { }

        public Author? Author { get; }
    }
}
