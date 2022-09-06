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
    public class UserGetterByUsername : IUserGetterByUsername
    {
        Repository _repository;
        public UserGetterByUsername(Repository repository)
        {
            _repository = repository;
        }

        public User GetUserByUserName(string userName) => _repository.GetAllUsers()
                                                            .Where(u => u.Username == userName)
                                                            .SingleOrDefault();
    }
}
