using BookLibrary.Data.Models;

namespace BookLibrary.Core.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> SearchByTitleAsync(string title);
        Task<IEnumerable<Book>> SearchByIsbnAsync(string isbn);
    }
}
