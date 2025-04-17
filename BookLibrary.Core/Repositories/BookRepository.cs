using BookLibrary.Data.Contexts;
using BookLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Core.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _ctx;
        public BookRepository(LibraryContext ctx) => _ctx = ctx;
        
        public async Task<IEnumerable<Book>> GetAllAsync() =>
        await _ctx.Books.ToListAsync();

        public async Task<IEnumerable<Book>> SearchByTitleAsync(string title) =>
            await _ctx.Books
                      .Where(b => b.Title.Contains(title) || string.IsNullOrEmpty(title))
                      .ToListAsync();

        public async Task<IEnumerable<Book>> SearchByIsbnAsync(string isbn) =>
            await _ctx.Books
                      .Where(b => b.ISBN == isbn)
                      .ToListAsync();
    }
}
