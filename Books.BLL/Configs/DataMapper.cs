using AutoMapper;
using Books.BLL.Models;
using Books.DAL.Entities;

namespace Books.BLL.Configs
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<BookEntity, BookModel>().ReverseMap();
        }
    }
}
