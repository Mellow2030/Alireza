using Data.Context;
using DomainClasses;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Services
{
            
    public class UsersRepository : IUsersRepository
    {
        private MyDbContext _context;

        public UsersRepository(MyDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Users> GetAllUsers()
        {
            return _context.Userses.ToList();
        }

        public Users GetUserById(int userId)
        {
            return _context.Userses.Find(userId);
        }

        public void AddUser(Users users)
        {
            _context.Userses.Add(users);
        }


        public void UpdateUser(Users users)
        {
            _context.Entry(users).State = EntityState.Modified;
        }


        public void DeleteUser(Users users)
        {
            _context.Entry(users).State = EntityState.Deleted;
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            DeleteUser(user);
        }

        public void UserExists(int userId)
        {
            _context.Userses.Any(u => u.UserID == userId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
