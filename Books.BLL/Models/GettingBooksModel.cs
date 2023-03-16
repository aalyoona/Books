using System.ComponentModel;

namespace Books.BLL.Models
{
    public class GettingBooksModel
    {
        [DefaultValue("")]
        public string Author { get; set; }

        [DefaultValue("")]
        public string Title { get; set; }

        [DefaultValue(0)]
        public int Year { get; set; }

        [DefaultValue(SortType.None)]
        public SortType SortType { get; set; }
    }
}
