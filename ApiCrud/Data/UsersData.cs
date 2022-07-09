using ApiCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Data
{
    public class UsersData : IUsersData
    {
        private List<User> users = new List<User>()
        {
          new User()
          {
              Id = Guid.NewGuid(),
              Name = "Ifedi",
              Email = "ifedi@gmail.com",
              Role = "Software Engineer"
          },

           new User()
          {
              Id = Guid.NewGuid(),
              Name = "Bethel",
              Email = "bethel@gmail.com",
              Role = "Senior Engineer"
          },
            new User()
          {
              Id = Guid.NewGuid(),
              Name = "Iqma",
              Email = "igma@gmail.com",
              Role = "Intern Software Engineer"
          }
        };
        public User AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            users.Add(user);
            return user;
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }

        public User EditUser(User user)
        {
            var existingUser = GetUser(user.Id);
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Role = user.Role;
            return existingUser;
        }

        public User GetUser(Guid id)
        {
            return users.SingleOrDefault(x => x.Id == id);
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
