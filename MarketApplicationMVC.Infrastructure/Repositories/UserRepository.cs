using MarketApplicationMVC.Domain.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketApplicationMVC.Infrastructure.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }


        IQueryable<Microsoft.AspNetCore.Identity.IdentityUser> IUserRepository.GetAllUsers()
        {
            var users = _context.Users;
            return users;
        }
    }
}
