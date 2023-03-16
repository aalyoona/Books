using Books.BLL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books.Cnsl.Models
{
    public class GettingBooksInputModel
    {
        public string Author { get; set; }

        public string Title { get; set; }

        [DefaultValue(0)]
        [Range(1445, 2022, ErrorMessage = "Invalid year entered")]
        public int Year { get; set; }

        [DefaultValue(SortType.None)]
        [EnumDataType(typeof(SortType))]
        public SortType SortType { get; set; }
    }
}
