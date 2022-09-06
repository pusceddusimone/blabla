using BusinessLogic.Library.Interfaces;
using DataAccessLayer.Library;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.Classes
{
    public class Logger : ILogger
    {
        Repository _repository;
        public Logger(Repository repository)
        {
            _repository = repository;
        }

        public User Login(string username = null, string password = null)
        {
            if (username == null || password == null)
                return null;
            User user = _repository.GetAllUsers()
                .Where(p => (p.Username == username || username == null)
                && (p.Password == password || password == null))
                .FirstOrDefault();
            if (user == null)
                return null;
            return user;
        }
    }
}
