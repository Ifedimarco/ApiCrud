using ApiCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Data
{
   public interface IUsersData
    {
        List<User> GetUsers();
        User GetUser(Guid id);
        User AddUser(User user);
        void DeleteUser(User user);
        User EditUser(User user);
    }
}
