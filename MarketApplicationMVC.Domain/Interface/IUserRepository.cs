using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketApplicationMVC.Domain.Interface
{
    public interface IUserRepository
    {
        void DeleteUser(int userId);
        int AddUser(User user);
        IQueryable<User> GetUsersByTypeId(int typeId);
        User GetUserById(int userId);
        IQueryable<User> GetAllUsers();
        IQueryable<Model.Type> GetAllTypes();
        void UpdateUser(User user);
        Address GetAddress(int id);
        void AddOrUpdateAddress(Address address);
    }
}
