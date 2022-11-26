using DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IRegistered
    {
        List<BookDTO> GetAllBooks();
        bool CreateBook(BookDTO book);
       

    }
}
