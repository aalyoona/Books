namespace Books.BLL.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is BookModel model &&
                   Id == model.Id &&
                   Author == model.Author &&
                   Title == model.Title &&
                   Year == model.Year;
        }

        public override string ToString()
        {
            return $"{Id} {Author} {Title} {Year} ";
        }
    }
}
