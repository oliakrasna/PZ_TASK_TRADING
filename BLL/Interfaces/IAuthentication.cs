using DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAuthentication
    {
        bool Login(string username, string password);
        int GetUserByLogin(string username);
        UserDTO GetUserByID(int id);
        List<UserDTO> GetUsers();
       
        
        
    }
}
