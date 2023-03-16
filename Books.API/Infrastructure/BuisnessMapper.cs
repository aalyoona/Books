using AutoMapper;
using Books.API.Models;
using Books.BLL.Models;

namespace Books.API.Configs
{
    public class BuisnessMapper : Profile
    {
        public BuisnessMapper()
        {
            CreateMap<BookModel, BookOutputModel>();
            CreateMap<GettingBooksInputModel, GettingBooksModel>();
        }
    }
}