using Books.BLL.Models;

namespace Books.BLL
{
    public interface IBooksService
    {
        void BuyBook(int id);
        List<BookModel> GetBooks(GettingBooksModel gettingBooks);
    }
}