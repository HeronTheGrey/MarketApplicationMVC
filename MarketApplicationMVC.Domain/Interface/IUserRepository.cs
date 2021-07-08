
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketApplicationMVC.Domain.Interface
{
    public interface IUserRepository
    {
        IQueryable<Microsoft.AspNetCore.Identity.IdentityUser> GetAllUsers();
    }
}
