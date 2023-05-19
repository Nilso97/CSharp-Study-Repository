using Books.Models;

namespace Books.Repositories
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> Get();
        public Task<Book> GetById(Guid id);
        public Task<Book> Create(Book book);
        public Task Update(Book book);
        public Task Delete(Guid id);        
    }
}