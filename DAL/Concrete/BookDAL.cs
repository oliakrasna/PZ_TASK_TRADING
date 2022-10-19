using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class BookDAL : IBookDAL
    {
        private readonly IMapper _mapper;

        public BookDAL(IMapper mapper)
        {
            _mapper = mapper;

        }
        public BookDTO CreateBook(BookDTO book)
        {
            using (var entities = new TradingEntities())
            {
                var bookInDB = _mapper.Map<Book>(book);
                bookInDB.RowInsertTime = System.DateTime.Now;
                bookInDB.RowUpdateTime = System.DateTime.Now;
                entities.Books.Add(bookInDB);
                entities.SaveChanges();
                return _mapper.Map<BookDTO>(bookInDB);
            }
        }

        public List<BookDTO> GetAllBooks()
        {
            using (var entities = new TradingEntities())
            {
                var books = entities.Books.ToList();
                return _mapper.Map<List<BookDTO>>(books);
            }

        }



        public BookDTO RemoveBookByID(int id)
        {
            using (var entites = new TradingEntities())
            {
                var bookInDB = entites.Books.SingleOrDefault(x => x.BookID == id);
                if (bookInDB != null)
                {
                    entites.Books.Remove(bookInDB);
                    entites.SaveChanges();
                }
                return _mapper.Map<BookDTO>(bookInDB);
            }

        }


        public BookDTO UpdateBookByID(BookDTO book, int id)
        {
            using (var entites = new TradingEntities())
            {
                var bookInDB = _mapper.Map<Book>(book);
                bookInDB = entites.Books.SingleOrDefault(x => x.BookID == id);
                if (bookInDB != null)
                {
                    bookInDB.RowUpdateTime = DateTime.Now;
                    bookInDB.BookID = book.BookID;
                    bookInDB.BookName = book.BookName;
                    bookInDB.BookAuthor = book.BookAuthor;
                    bookInDB.GenreID = book.GenreID;
                    bookInDB.PublishingHouseID = book.PublishingHouseID;
                    bookInDB.Quantity = book.Quantity;

                    entites.SaveChanges();
                }
                return _mapper.Map<BookDTO>(bookInDB);
            }
        }

        
    }
}
