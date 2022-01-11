using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Data;
using Authentication.Models;
using Authentication.Services;

namespace Authentication.Services
{
    public class AccountService : IAccount
    {
        private readonly DataContext db;

        public AccountService(DataContext db)
        {
            this.db = db;
        }

        public User getUserById(string userId)
        {
            return db.Users.Where(x => x.userId == Convert.ToInt32(userId)).FirstOrDefault();
        }

        public User login(User u)
        {
            return db.Users.Where(x => x.email.Equals(u.email) && x.password.Equals(u.password)).FirstOrDefault();
        }

        public User checkRegistered(User u)
        {
            try
            {
                return db.Users.Where(x => x.email.Equals(u.email)).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool register(User u)
        {
            try
            {
                db.Users.Add(u);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
