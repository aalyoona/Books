using AutoMapper;
using Books.BLL.Models;
using Books.DAL;
using System.Reflection;

namespace Books.BLL
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public void BuyBook(int id)
        {
            if (_booksRepository.GetBookById(id) is null)
            {
                throw new Exception($"Book with id={id} not found");
            }

            _booksRepository.BuyBook(id);
        }

        public List<BookModel> GetBooks(GettingBooksModel gettingBooks)
        {
            List<BookModel>? books = _mapper.Map<List<BookModel>>(_booksRepository.GetAllBooks());

            if (!string.IsNullOrEmpty(gettingBooks.Title))
            {
                books = GetBooksByTitle(books, gettingBooks.Title);
                if (books.Count == 0)
                {
                    throw new Exception($"Books with the given title ({gettingBooks.Title}) weren't found");
                }
            }

            if (!string.IsNullOrEmpty(gettingBooks.Author))
            {
                books = GetBooksByAuthor(books, gettingBooks.Author);
                if (books.Count == 0)
                {
                    throw new Exception($"Books with the given author ({gettingBooks.Author}) weren't found");
                }
            }

            if (gettingBooks.Year is not 0)
            {
                books = GetBooksByYear(books, gettingBooks.Year);
                if (books.Count == 0)
                {
                    throw new Exception($"Books with the given year ({gettingBooks.Year}) weren't found");
                }
            }

            if (gettingBooks.SortType != SortType.None)
            {
                MethodInfo? m = GetType().GetMethod(gettingBooks.SortType.ToString());
                books = m.Invoke(this, new object[] { books }) as List<BookModel>;
            }

            return books;
        }

        private List<BookModel> GetBooksByAuthor(List<BookModel> books, string Author) => books.Where(x => x.Author == Author).ToList();
        private List<BookModel> GetBooksByTitle(List<BookModel> books, string title) => books.Where(x => x.Title.ToUpper().Contains(title.ToUpper())).ToList();
        private List<BookModel> GetBooksByYear(List<BookModel> books, int year) => books.Where(x => x.Year == year).ToList();

        public List<BookModel> SortByTitle(List<BookModel> books) => books.OrderBy(x => x.Title).ToList();
        public List<BookModel> SortByAuthor(List<BookModel> books) => books.OrderBy(x => x.Author).ToList();
        public List<BookModel> SortByYear(List<BookModel> books) => books.OrderBy(x => x.Year).ToList();
    }
}