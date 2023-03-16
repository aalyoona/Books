using Books.BLL.Models;
using Books.DAL.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Books.BLL.Tests
{
    public class GetBooksTestCaseSource_NegativeTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<BookEntity> books = new List<BookEntity>()
            {
                new BookEntity()
                {
                    Id = 1,
                    Title = "AAA",
                    Author = "AAA",
                    Year = 2001,
                    IsBuy = false
                },
                new BookEntity()
                {
                    Id = 2,
                    Title = "CCC",
                    Author = "CCC",
                    Year = 2000,
                    IsBuy = false
                },
                new BookEntity()
                {
                    Id = 3,
                    Title = "QQQ",
                    Author = "QQQ",
                    Year = 2005,
                    IsBuy = false
                },
                new BookEntity()
                {
                    Id = 4,
                    Title = "AAAQQ",
                    Author = "AAAQQ",
                    Year = 2001,
                    IsBuy = false
                },
                new BookEntity()
                {
                    Id = 5,
                    Title = "BAAAQQ",
                    Author = "BAAAQQ",
                    Year = 2010,
                    IsBuy = false
                },
                new BookEntity()
                {
                    Id = 6,
                    Title = "BAA",
                    Author = "BAA",
                    Year = 1999,
                    IsBuy = false
                }
            };

            GettingBooksModel gettingBooks1 = new GettingBooksModel()
            {
                Title = "qwerty"
            };

            string expected1 = $"Books with the given title ({gettingBooks1.Title}) weren't found";

            GettingBooksModel gettingBooks2 = new GettingBooksModel()
            {
                Author = "QQQ123"
            };

            string expected2 = $"Books with the given author ({gettingBooks2.Author}) weren't found";

            GettingBooksModel gettingBooks3 = new GettingBooksModel()
            {
                Year = 1234
            };

            string expected3 = $"Books with the given year ({gettingBooks3.Year}) weren't found";

            yield return new object[] { books, expected1, gettingBooks1 };
            yield return new object[] { books, expected2, gettingBooks2 };
            yield return new object[] { books, expected3, gettingBooks3 };
        }
    }
}