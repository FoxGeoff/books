using Books.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksRepository _repo;

        public BooksController(IBooksRepository repo)
        {
            _repo = repo ??
                throw new ArgumentNullException(nameof(BooksRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var bookEntities = await _repo.GetBooksAsync();
            return Ok(bookEntities);
        }
    }
}
