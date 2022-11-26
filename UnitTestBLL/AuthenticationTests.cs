using Moq;
using NUnit.Framework;
using System;
using BLL.Concrete;
using DAL.Interfaces;
using DTO;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace UnitTestBLL
{
    [TestFixture]
    public class AuthenticationTests
    {
        private Mock<IUserDAL> userDAL;
        private Authentication auth;
        private List<UserDTO> users = new List<UserDTO>();
        private UserDTO user = new UserDTO
        {
            Login = "login",
            Passsword = Convert.FromBase64String("1111"),
            FirstName = "first_name",
            LastName = "last_name",
            Keyword = "keyword",
            Email = "email",
            PhoneNumber = "ph_num",

        };

        [Test]
    public void GetUserByLoginTest()
    {
        string login = "";
        userDAL.Setup(d => d.GetUserByLogin(login)).Returns(user);
        var res = auth.GetUserByLogin(login);
        Assert.IsTrue(user.UserID.GetType() == res.GetType());
    }

    [Test]
    public void GetAllUsersTest()
    {
        users.Add(user);
        userDAL.Setup(d => d.GetAllUsers()).Returns(users);
        var res = auth.GetUsers();
        Assert.IsTrue(users.Contains(user) == res.Contains(user));
    }

    [Test]
    public void GetUserByIdTest()
    {
        int id = 1;
        userDAL.Setup(d => d.GetUserByID(id)).Returns(user);
        var res = auth.GetUserByID(id);
        Assert.IsTrue(user.GetType() == res.GetType());
    }

   

 

        [SetUp]
        public void Setup()
        {
            userDAL = new Mock<IUserDAL>(MockBehavior.Strict);
            auth = new Authentication(userDAL.Object);
        }

        [Test]
        public void LoginTest()
        {
            string login = "al.stasiuk";
            string password = "2003";
            userDAL.Setup(d => d.Login(login, password)).Returns(true);
            var res = auth.Login(login, password);
            Assert.IsTrue(res);
        }
        [Test]
        public void RegisterTest()
        {
            string login = "login1";
            string password = "1111";
            string firstName = "first_name1";
            string lastName = "last_name1";
            string keyword = "keyword1";
            string email = "email1";
            string phoneNumber = "ph_num1";
            userDAL.Setup(d => d.CreateUser(first_name, last_name, login, password, keyword, email, phoneNumber)).Returns(user);
            var res = auth.Register(first_name, last_name, login, password, keyword, email, phoneNumber);
            Assert.IsTrue(res);
        }
        

        
    }
}
