using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Complete
{
    public class UserDAL : IUserDAL
    {
        private readonly IMapper _mapper;
        public UserDAL(IMapper mapper)
        {
            _mapper = mapper;
        }
        public UserDTO CreateUser(string first_name, string last_name, string login, string password, string keyword, string email, string phonenumber)
        {
            using (var entities = new TradingEntities())
            {
                if (entities.Users.Any(u => u.Login == login))
                {
                    throw new Exception("This user already exists!");
                }
                Guid salt = Guid.NewGuid();
                var user = new User
                {
                    FirstName = first_name,
                    LastName = last_name,
                    Login = login,
                    Salt = salt,
                    Keyword = keyword,
                    Email = email,
                    PhoneNumber = phonenumber,
                    Passsword = hash(password, salt.ToString()),
                    RowInsertTime = System.DateTime.Now,
                    RowUpdateTime = System.DateTime.Now
                };
                entities.Users.Add(user);
                entities.SaveChanges();
                return _mapper.Map<UserDTO>(user);
            }
        }

        public UserDTO UpdateUserByID(UserDTO user, int id)
        {
            using (var entites = new TradingEntities())
            {
                var userInDB = _mapper.Map<User>(user);
                userInDB = entites.Users.SingleOrDefault(x => x.UserID == id);
                if (userInDB != null)
                {
                    userInDB.RowUpdateTime = DateTime.Now;
                    userInDB.FirstName = user.FirstName;
                    userInDB.LastName = user.LastName;
                    userInDB.Login = user.Login;
                    userInDB.Passsword = user.Passsword;
                    userInDB.Keyword = user.Keyword;
                    userInDB.Email = user.Email;
                    userInDB.PhoneNumber = user.PhoneNumber;
                    
                    entites.SaveChanges();
                }
                return _mapper.Map<UserDTO>(userInDB);
            }
        }

        public UserDTO RemoveUserByID(int id)
        {
            using (var entites = new TradingEntities())
            {
                var usersInDB = entites.Users.SingleOrDefault(x => x.UserID == id);
                if (usersInDB != null)
                {
                    entites.Users.Remove(usersInDB);
                    entites.SaveChanges();
                }
                return _mapper.Map<UserDTO>(usersInDB);
            }
        }
        public List<UserDTO> GetAllUsers()
        {
            using (var entities = new TradingEntities())
            {
                var users = entities.Users.ToList();
                return _mapper.Map<List<UserDTO>>(users);
            }
        }
       
        public UserDTO GetUserByID(int id)
        {
            using (var entities = new TradingEntities())
            {
                var userID = entities.Users.Select(x => x.UserID).ToList();
                var user = entities.Users.Where(x => userID.Contains(id)).ToList();
                return _mapper.Map<UserDTO>(user[id - 1]);
            }
        }

        public bool Login(string username, string password)
        {
            using (var ent = new TradingEntities())
            {
                UserDTO user = _mapper.Map<UserDTO>(ent.Users.FirstOrDefault(u => u.Login == username));
                return user != null && user.Passsword.SequenceEqual(hash(password, user.Salt.ToString()));
            }
        }

        public byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
        public UserDTO GetUserByLogin(string login)
        {
            using (var entities = new TradingEntities())
            {
                var found = entities.Users.SingleOrDefault(d => d.Login == login);
                return _mapper.Map<UserDTO>(found);
            }
        }
        
    }
}
