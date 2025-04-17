using BookLibrary.Data.Models;
using MediatR;

namespace BookLibrary.Core.Queries.Books
{
    public class SearchBooksQuery : IRequest<IEnumerable<Book>>
    {
        public string Type { get; }
        public string Value { get; }

        public SearchBooksQuery(string type, string value)
        {
            Type = type.ToLower();
            Value = value;
        }
    }
}
