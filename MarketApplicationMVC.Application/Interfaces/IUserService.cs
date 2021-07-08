using MarketApplicationMVC.Application.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Application.Interfaces
{
    public interface IUserService
    {
        public Task<ListUserForListVm> GetListOfAllUsers(string searchPhrase, int currentPage, int pageSize);
        

        
    }
}
