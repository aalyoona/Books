using AutoMapper;
using Books.API.Models;
using Books.BLL;
using Books.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBooksService _service;
        private readonly IMapper _mapper;

        public BooksController(IBooksService booksService, IMapper mapper)
        {
            _service = booksService;
            _mapper = mapper;
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation("Buy book")]
        public ActionResult<int> BuyBook(int id)
        {
            _service.BuyBook(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation("Get books")]
        public ActionResult<List<BookOutputModel>> GetPapers([FromQuery] GettingBooksInputModel gettingBooks)
        {
            List<BookOutputModel>? papers = _mapper.Map<List<BookOutputModel>>(_service.GetBooks(_mapper.Map<GettingBooksModel>(gettingBooks)));
            return Ok(papers);
        }
    }
}
