using Books.DAL.Entities;
using System.Collections;

namespace Books.BLL.Tests
{
    public class BuyBookTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            BookEntity book = new BookEntity()
            {
                Id = 1,
                Title = "AAA",
                Author = "AAA",
                Year = 2001,
                IsBuy = false
            };

            int id = 1;

            yield return new object[] { book, id };
        }
    }
}