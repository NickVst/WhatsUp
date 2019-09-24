using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;
using WhatsUp.Repositories;

namespace WhatsUp.Services
{
    public class AuthService
    {
        private IRepository<Account> _repository;
        public AuthService(IRepository<Account> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Account> GetAll()
        {
            return _repository.GetAll();
        }

        public Account Login(string username, string password)
        {
            return _repository.QueryOne(new Account
            {
                Username = username,
                Password = password
            });

        }

        public void Register(Account accountInfo)
        {

        }
    }


    public class UsernameExistsException : Exception
    {

    }

    public class InvalidCredentialsException : Exception
    {

    }
}