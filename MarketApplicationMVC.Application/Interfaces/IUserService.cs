using MarketApplicationMVC.Application.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.Interfaces
{
    public interface IUserService
    {
        int AddUser(NewUserVm model);
        ListUserForListVm GetAllActiveUsersForList(int pageSize, int currentPage, string searchPhrase);
        int AddContactInformation(ContactInformationVm model);
        UserDetailsVm ViewUserDetails(int userId);
        NewUserVm GetUserForEdit(int id);
        void UpdateUser(NewUserVm model);
        void DeleteUser(int id);
        List<UserTypeVm> GetAllUserTypes();
        AddressEditVm GetUserAddress(int id);
        void UpdateUserAddress(AddressEditVm model);
    }
}
