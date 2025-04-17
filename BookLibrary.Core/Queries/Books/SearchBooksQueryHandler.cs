using BookLibrary.Core.Repositories;
using BookLibrary.Data.Models;
using MediatR;

namespace BookLibrary.Core.Queries.Books
{
    public class SearchBooksQueryHandler
        : IRequestHandler<SearchBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository _repo;
        public SearchBooksQueryHandler(IBookRepository repo) => _repo = repo;

        public async Task<IEnumerable<Book>> Handle(
            SearchBooksQuery req,
            CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(req.Value))
            {
                var result = await _repo.GetAllAsync();
                return result;
            }

            return req.Type switch
            {
                "title" => await _repo.SearchByTitleAsync(req.Value),
                "isbn" => await _repo.SearchByIsbnAsync(req.Value),
                _ => new List<Book>()
            };
        }
    }
}
