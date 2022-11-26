using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class Authentication : IAuthentication
    {
        private readonly IUserDAL userDAL;
        public Authentication(IUserDAL userDal)
        {
            this.userDAL = userDAL;
        }
        public int GetUserByLogin(string username)
        {
            return userDAL.GetUserByLogin(username).UserID;
        }
        public UserDTO GetUserByID(int id)
        {
            return userDAL.GetUserByID(id);
        }
        public List<UserDTO> GetUsers()
        {
            return userDAL.GetAllUsers();
        }


        public bool Login(string username, string password)
        {
            return userDAL.Login(username, password);
        }


   
    }
}