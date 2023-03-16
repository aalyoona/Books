using AutoMapper;
using Books.BLL;
using Books.BLL.Models;
using Books.Cnsl.Models;

namespace Books.Cnsl.Services
{
    public class ConsoleExecutor : IConsoleExecutor
    {
        private readonly IBooksService _service;
        private readonly IMapper _mapper;
        private bool _exit;

        public ConsoleExecutor(IBooksService booksService, IMapper mapper)
        {
            _service = booksService;
            _mapper = mapper;
            _exit = false;
        }

        public void Run()
        {
            SendHelloMessage();

            while (!_exit)
            {
                string words = Console.ReadLine();
                string[] split = words.Split(new char[] { '-', '=', '"' }).Where(s => !string.IsNullOrEmpty(s)).ToArray();

                switch (split[0])
                {
                    case "Exit" or "exit":
                        _exit = true;
                        break;

                    case "Get" or "get":
                        GettingBooksInputModel model = new GettingBooksInputModel();
                        model = CheckSort(split, model);
                        model = CheckGettingParams(split, model);

                        try
                        {
                            List<BookOutputModel> books = _mapper.Map<List<BookOutputModel>>(_service.GetBooks(_mapper.Map<GettingBooksModel>(model)));
                            WriteLineBooks(books);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case "Buy" or "buy":
                        _service.BuyBook(Convert.ToInt32(split[1]));
                        break;

                    default:
                        Console.WriteLine("Unknown team");
                        break;
                }
            }
        }

        private void SendHelloMessage()
        {
            Console.WriteLine("Hello! This is a bookstore managed through the console. " +
                "\nYou can use commands: " +
                "\n --Get " +
                "\n --Buy " +
                "\n --order-by " +
                "\nPossible filters for searching and sorting: " +
                "\nAuthor (Sort alphabetically by author name when sorted), " +
                "\nTitle (Sort alphabetically by title when sorted), " +
                "\nYear (Sort by book release year from smallest to largest when sorted)" +
                "\nRequest example: Buy=id " +
                "\nRequest example: Get " +
                "\nRequest example: Get--Author--\"Author name\" " +
                "\nRequest example: Get--Title--\"Name\"--order--by=Year" +
                "\n" +
                "\nTo complete the work, enter Exit");
        }

        private void WriteLineBooks(List<BookOutputModel> books)
        {
            foreach (BookOutputModel book in books)
            {
                Console.WriteLine($"{book.Title} | {book.Author} | {book.Year}");
            }
        }

        private GettingBooksInputModel CheckSort(string[] split, GettingBooksInputModel model)
        {
            if (split.Length > 2 && split[split.Length - 3] == "order")
            {
                switch (split[split.Length - 1])
                {
                    case "Title" or "title":
                        model.SortType = SortType.SortByTitle;
                        break;
                    case "Author" or "author":
                        model.SortType = SortType.SortByAuthor;
                        break;
                    case "Year" or "year":
                        model.SortType = SortType.SortByYear;
                        break;
                    default:
                        model.SortType = SortType.None;
                        break;
                }
            }
            return model;
        }

        private GettingBooksInputModel CheckGettingParams(string[] split, GettingBooksInputModel model)
        {
            try
            {
                switch (split[1])
                {
                    case "Title" or "title":
                        model.Title = split[2];
                        break;
                    case "Author" or "author":
                        model.Author = split[2];
                        break;
                    case "Year" or "year":
                        if (2022 < Convert.ToInt32(split[2]) || Convert.ToInt32(split[2]) < 1455)
                        {
                            throw new Exception("Invalid year entered");
                        }
                        model.Year = Convert.ToInt32(split[2]);

                        break;
                }
            }
            catch (IndexOutOfRangeException) { }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return model;
        }
    }
}
