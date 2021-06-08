using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarketApplicationMVC.Domain.Interface;
using MarketApplicationMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

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
            user.IsActive = false;
            _context.Attach(user);
            _context.Entry(user).Property("IsActive").IsModified = true;
            _context.SaveChanges();

            /*var user = _context.Users.Include(e => e.ForumThreads).Where(i => i.Id == userId).First();
            if (user != null)
            {
                foreach(var thread in user.ForumThreads)
                {
                    thread.UserId = null;
                }
                _context.Users.Remove(user);

                _context.SaveChanges();
            }*/
        }

        public int AddUser(User user)
        {
            user.IsActive = true;
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
            var user = _context.Users.Include(e => e.Address)
                .Include(e => e.ContactInformations)
                .Include(e => e.ForumPosts)
                .Include(e => e.ForumThreads)
                .Include(e => e.Offers)
                .Include(e => e.Type)
                .FirstOrDefault(i => i.Id == userId)
                ;
            return user;
        }

        public IQueryable<User> GetAllUsers()
        {
            var users = _context.Users;
            return users;
        }


        public IQueryable<Domain.Model.Type> GetAllTypes()
        {
            var types = _context.Types;
            return types;
        }

        public void UpdateUser(User user)
        {
            _context.Attach(user);
            _context.Entry(user).Property("Name").IsModified = true;
            _context.SaveChanges();
        }

        public Address GetAddress(int id)
        {
            var address = _context.Addresses.Where(s => s.UserRef == id).FirstOrDefault();
            return address;
        }

        public void AddOrUpdateAddress(Address address)
        {
            var addressVar = _context.Addresses.Where(s => s.Id == address.Id).FirstOrDefault();
            if(addressVar is null)
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
            }
            else
            {
                addressVar.Country = address.Country;
                addressVar.City = address.City;
                addressVar.Street = address.Street;
                addressVar.ZipCode = address.ZipCode;
                addressVar.BuildingNumber = address.BuildingNumber;
                addressVar.FlatNumber = address.FlatNumber;
                _context.SaveChanges();
            }
        }
    }
}
