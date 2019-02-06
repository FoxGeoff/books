using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.api.Services
{
    public interface IBooksRepository
    {
        //IEnumerable<Entities.Book> GetBooks();

        //IEnumerable<Entities.Author> GetAuthors();

        Task<IEnumerable<Entities.Book>> GetBooksAsync();

        Task<Entities.Book> GetBooksAsync(Guid id);
    }
}
