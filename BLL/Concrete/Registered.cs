using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class Registered : IRegistered
    {
       
        private readonly IBookDAL _bookDAL;
        public Registered(IBookDAL bookDAL)
        {

            _bookDAL = bookDAL;
        }
        public bool CreateBook(BookDTO bookDTO)
        {
            var res = _bookDAL.CreateBook(bookDTO);
            return res.BookID != 0;
        }
        public List<BookDTO> GetAllBooks()
        {
            return _bookDAL.GetAllBooks();
        }
    }
}