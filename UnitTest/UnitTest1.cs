using AutoMapper;
using DAL.Concrete;
using DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        
        private IMapper _mapper;
        [OneTimeSetUp]
        public void SetupOnce()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(BookDAL).Assembly)
                );
            _mapper = config.CreateMapper();
        }

        [Test]
        public void CreateBookTest()
        {
            BookDAL dal = new BookDAL(_mapper);
            var result = dal.CreateBook(new BookDTO
            {
                BookID = 21,
                BookName = "test_book_name",
                BookAuthor = "test_author",
                GenreID = 4,
                PublishingHouseID = 5,
                Quantity = 23
                
            });
            Assert.IsTrue(result.BookID != 0);
        }


        [Test]
        public void GetAllBooksTest()
        {
            BookDAL dal = new BookDAL(_mapper);
            
            var books = dal.GetAllBooks();
            Assert.IsTrue(books.Count > 0 );
        }

        [Test]
        public void UpdateBookByIDTest()
        {
            BookDTO newBook = new BookDTO
            {
                BookAuthor = "Marry Robinson"
            };
            string _testBook = " ";

            var dal = new BookDAL(_mapper);

            var booksList = dal.GetAllBooks();
            int id = booksList.SingleOrDefault(x => x.BookAuthor == _testBook).BookID;

            Assert.IsTrue(dal.UpdateBookByID(newBook, id).BookAuthor == newBook.BookAuthor);
        }


        [Test]
        public void RemoveBookTest()
        {
            BookDAL dal = new BookDAL(_mapper);
            var book = dal.CreateBook(new BookDTO
            {
                BookID = 22,
                BookName = "test_book_name_4",
                BookAuthor = "test_author_4",
                GenreID = 4,
                PublishingHouseID = 5,
                Quantity = 23
            });
            dal.RemoveBookByID(book.BookID);
            var deleted = dal.GetAllBooks().Find(x => x.BookName == book.BookName);

            Assert.IsNull(deleted);
        }

    }
}

