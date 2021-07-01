using System.Collections.Generic;
using Todo.Web.Data;
using Todo.Web.GraphQL.Common;

namespace Todo.Web.GraphQL.Books
{
    public class BookPayloadBase : Payload
    {
        protected BookPayloadBase(Book book)
        {
            Book = book;
        }

        protected BookPayloadBase(IReadOnlyList<UserError> errors) : base(errors) { }

        public Book? Book { get; }
    }
}
