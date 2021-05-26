using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarketApplicationMVC.Domain.Interface;
using MarketApplicationMVC.Domain.Model;

namespace MarketApplicationMVC.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public IQueryable<User> GetUsersByTypeId(int typeId)
        {
            var users = _context.Users.Where(i => i.TypeId == typeId);
            return users;
        }

        public User GetUserById(int userId)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == userId);
            return user;
        }
    }
}
