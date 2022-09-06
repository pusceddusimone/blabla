using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public enum UserRole { Admin, User };
        public UserRole Role { get; set; }
        public User(int userId, string username, string password, UserRole role)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Role = role;
        }

        public User()
        {

        }
    }
}
