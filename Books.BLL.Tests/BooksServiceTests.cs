using AutoMapper;
using Books.BLL.Configs;
using Books.BLL.Models;
using Books.DAL;
using Books.DAL.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Books.BLL.Tests
{
    public class BooksServiceTests
    {
        private Mock<IBooksRepository> _booksRepositoryMock;
        private IMapper _mapper;
        private BooksService _bookService;

        [SetUp]
        public void Setup()
        {
            _booksRepositoryMock = new Mock<IBooksRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _bookService = new BooksService(_booksRepositoryMock.Object, _mapper);
        }

        [TestCaseSource(typeof(GetBooksTestCaseSource))]
        public void GetBooksTest(List<BookEntity> books, List<BookModel> expected, GettingBooksModel gettingBooks)
        {
            //given
            _booksRepositoryMock.Setup(x => x.GetAllBooks()).Returns(books).Verifiable();

            //when
            var actual = _bookService.GetBooks(gettingBooks);

            //then
            Assert.AreEqual(expected, actual);
            _booksRepositoryMock.Verify(x => x.GetAllBooks(), Times.Once);
        }

        [TestCaseSource(typeof(GetBooksTestCaseSource_NegativeTest))]
        public void GetBooksTest_WhenBooksMatchingSpecifiedCriteriaNotFound_ShouldThrowException(List<BookEntity> books, string expected, GettingBooksModel gettingBooks)
        {
            //given
            _booksRepositoryMock.Setup(x => x.GetAllBooks()).Returns(books).Verifiable();

            //when

            //then
            Exception? ex = Assert.Throws<Exception>(() => _bookService.GetBooks(gettingBooks));
            Assert.AreEqual(expected, ex.Message);
            _booksRepositoryMock.Verify(x => x.GetAllBooks(), Times.Once);
        }

        [TestCaseSource(typeof(BuyBookTestCaseSource))]
        public void BuyBookTest(BookEntity book, int id)
        {
            //given
            _booksRepositoryMock.Setup(x => x.GetBookById(id)).Returns(book).Verifiable();
            _booksRepositoryMock.Setup(x => x.BuyBook(id)).Verifiable();

            //when
            _bookService.BuyBook(id);

            //then
            _booksRepositoryMock.Verify(x => x.BuyBook(id), Times.Once);
            _booksRepositoryMock.Verify(x => x.GetBookById(id), Times.Once);
        }

        [Test]
        public void BuyBookTest_WhenBookNotFound_ShouldThroeException()
        {
            //given
            _booksRepositoryMock.Setup(x => x.GetBookById(It.IsAny<int>())).Verifiable();
            _booksRepositoryMock.Setup(x => x.BuyBook(It.IsAny<int>())).Verifiable();

            //when

            //then
            Assert.Throws<Exception>(() => _bookService.BuyBook(It.IsAny<int>()));
            _booksRepositoryMock.Verify(x => x.BuyBook(It.IsAny<int>()), Times.Never);
            _booksRepositoryMock.Verify(x => x.GetBookById(It.IsAny<int>()), Times.Once);
        }

    }
}