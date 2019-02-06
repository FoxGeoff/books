using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.api.Context;
using Books.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.api.Services
{
    public class BooksRepository : IBooksRepository
    {
        private BooksContext _context;

        public BooksRepository(BooksContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<Book> GetBooksAsync(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
