using Books.BLL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Models
{
    public class GettingBooksInputModel
    {
        //For fields "Author" and "Title" value is set through equality in case it is not entered, since in Swashbuckle.AspNetCore all query parameters are required by default 

        public string Author { get; set; } = "";

        public string Title { get; set; } = "";

        [DefaultValue(0)]
        [Range(1445, 2022)]
        public int Year { get; set; }

        [DefaultValue(SortType.None)]
        [EnumDataType(typeof(SortType))]
        public SortType SortType { get; set; }
    }
}