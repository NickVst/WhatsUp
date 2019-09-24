using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace WhatsUp.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }

    public class UserRepository : IUserRepository
    {
        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Query(User entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}