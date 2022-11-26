using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        List<UserDTO> GetAllUsers();
        UserDTO CreateUser(string first_name, string last_name, string login, string password, string keyword, string email, string phonenumber);
        UserDTO RemoveUserByID(int id);
        UserDTO UpdateUserByID(UserDTO user, int id);
        bool Login(string username, string password);
        UserDTO GetUserByID(int id);
        UserDTO GetUserByLogin(string username);
        byte[] hash(string password, string salt);
        
    }
}
