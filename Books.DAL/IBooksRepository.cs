using Books.DAL.Entities;

namespace Books.DAL
{
    public interface IBooksRepository
    {
        void BuyBook(int id);
        List<BookEntity> GetAllBooks();
        BookEntity? GetBookById(int id);
    }
}