using Books.Models;
using Books.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository; 

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _bookRepository.GetById(id);

            if (book != null) return Ok(book);

            return NotFound( new { message = "Este livro não existe no registro!" });
        }

        [HttpPost]
        public async Task<ActionResult<Book>> SaveBook([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);

            return CreatedAtAction(nameof(GetBook), new { id = newBook.BookId }, newBook);            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(Guid id, [FromBody] Book book)
        {
            if (id == book.BookId) 
            {
                await _bookRepository.Update(book);

                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveBook(Guid id)
        {
            var book = await _bookRepository.GetById(id);

            if (book != null)
            {
                await _bookRepository.Delete(book.BookId);

                return NoContent();
            }

            return NotFound( new { message = "Este livro não existe no registro!" });
        }
    }
}