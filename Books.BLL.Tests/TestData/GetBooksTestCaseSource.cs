using Books.BLL.Models;
using Books.DAL.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Books.BLL.Tests
{
    public class GetBooksTestCaseSource : IEnumerable
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
                Title = "AA",
                SortType = SortType.SortByTitle
            };

            List<BookModel> expected1 = new List<BookModel>()
            {
                new BookModel()
                {
                    Id = 1,
                    Title = "AAA",
                    Author = "AAA",
                    Year = 2001
                },
                new BookModel()
                {
                    Id = 4,
                    Title = "AAAQQ",
                    Author = "AAAQQ",
                    Year = 2001
                },
                new BookModel()
                {
                    Id = 6,
                    Title = "BAA",
                    Author = "BAA",
                    Year = 1999
                },
                new BookModel()
                {
                    Id = 5,
                    Title = "BAAAQQ",
                    Author = "BAAAQQ",
                    Year = 2010
                }
            };

            GettingBooksModel gettingBooks2 = new GettingBooksModel() { };

            List<BookModel> expected2 = new List<BookModel>()
            {
                new BookModel()
                {
                    Id = 1,
                    Title = "AAA",
                    Author = "AAA",
                    Year = 2001
                },
                new BookModel()
                {
                    Id = 2,
                    Title = "CCC",
                    Author = "CCC",
                    Year = 2000
                },
                new BookModel()
                {
                    Id = 3,
                    Title = "QQQ",
                    Author = "QQQ",
                    Year = 2005
                },
                new BookModel()
                {
                    Id = 4,
                    Title = "AAAQQ",
                    Author = "AAAQQ",
                    Year = 2001
                },
                new BookModel()
                {
                    Id = 5,
                    Title = "BAAAQQ",
                    Author = "BAAAQQ",
                    Year = 2010
                },
                new BookModel()
                {
                    Id = 6,
                    Title = "BAA",
                    Author = "BAA",
                    Year = 1999
                }
            };

            GettingBooksModel gettingBooks3 = new GettingBooksModel()
            {
                Title = "QQQ"
            };

            List<BookModel> expected3 = new List<BookModel>()
            {
                new BookModel()
                {
                    Id = 3,
                    Title = "QQQ",
                    Author = "QQQ",
                    Year = 2005
                }
            };

            GettingBooksModel gettingBooks4 = new GettingBooksModel()
            {
                SortType = SortType.SortByYear
            };

            List<BookModel> expected4 = new List<BookModel>()
            {
                new BookModel()
                {
                    Id = 6,
                    Title = "BAA",
                    Author = "BAA",
                    Year = 1999
                },
                new BookModel()
                {
                    Id = 2,
                    Title = "CCC",
                    Author = "CCC",
                    Year = 2000
                },
                new BookModel()
                {
                    Id = 1,
                    Title = "AAA",
                    Author = "AAA",
                    Year = 2001
                },
                new BookModel()
                {
                    Id = 4,
                    Title = "AAAQQ",
                    Author = "AAAQQ",
                    Year = 2001
                },
                new BookModel()
                {
                    Id = 3,
                    Title = "QQQ",
                    Author = "QQQ",
                    Year = 2005
                },
                new BookModel()
                {
                    Id = 5,
                    Title = "BAAAQQ",
                    Author = "BAAAQQ",
                    Year = 2010
                }
            };

            yield return new object[] { books, expected1, gettingBooks1 };
            yield return new object[] { books, expected2, gettingBooks2 };
            yield return new object[] { books, expected3, gettingBooks3 };
            yield return new object[] { books, expected4, gettingBooks4 };
        }
    }
}
