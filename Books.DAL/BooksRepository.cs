using Books.DAL.Entities;

namespace Books.DAL
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksContext _context;

        public BooksRepository(BooksContext context)
        {
            _context = context;
        }

        public BookEntity? GetBookById(int id) => _context.Books.Where(x => x.IsBuy == false).FirstOrDefault(x => x.Id == id);

        public List<BookEntity> GetAllBooks() => _context.Books.Where(x => x.IsBuy == false).ToList();

        public void BuyBook(int id)
        {
            BookEntity book = _context.Books.FirstOrDefault(_x => _x.Id == id);
            book.IsBuy = true;
            _context.SaveChanges();
        }
    }
}
