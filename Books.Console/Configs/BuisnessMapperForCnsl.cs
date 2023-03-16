using AutoMapper;
using Books.BLL.Models;
using Books.Cnsl.Models;

namespace Books.Cnsl.Configs
{
    public class BuisnessMapperForCnsl : Profile
    {
        public BuisnessMapperForCnsl()
        {
            CreateMap<BookModel, BookOutputModel>();
            CreateMap<GettingBooksInputModel, GettingBooksModel>();
        }
    }
}
