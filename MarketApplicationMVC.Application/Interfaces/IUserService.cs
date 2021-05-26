using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.Interfaces
{
    public interface IUserService
    {
        List<int> GetAllUsers();
    }
}
