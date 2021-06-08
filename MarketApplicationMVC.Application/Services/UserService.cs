using AutoMapper;
using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.ViewModel.User;
using MarketApplicationMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper.QueryableExtensions;
using MarketApplicationMVC.Domain.Model;

namespace MarketApplicationMVC.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userService, IMapper mapper)
        {
            _userRepository = userService;
            _mapper = mapper;
        }
        public int AddContactInformation(ContactInformationVm model)
        {
            throw new NotImplementedException();
        }

        public int AddUser(NewUserVm model)
        {
            var user = _mapper.Map<User>(model);
            var id = _userRepository.AddUser(user);
            return id;
        }

        public NewUserVm GetUserForEdit(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var userVm = _mapper.Map<NewUserVm>(user);
            return userVm;
        }

        public ListUserForListVm GetAllActiveUsersForList(int pageSize, int currentPage, string searchPhrase)
        {
            var users = _userRepository.GetAllUsers()
                .Where(p => p.IsActive == true)
                .Where(p => p.Name.Contains(searchPhrase))
                .ProjectTo<UserForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var usersToShow = users.Skip((pageSize * (currentPage - 1))).Take(pageSize).ToList();
            var usersList = new ListUserForListVm
            {
                PageSize = pageSize,
                CurrentPage = currentPage,
                SearchPhrase = searchPhrase,
                Users = usersToShow,
                Count = users.Count
            };
            return usersList;
        }

        public UserDetailsVm ViewUserDetails(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var userVm = _mapper.Map<UserDetailsVm>(user);
            if(!(user.ContactInformations is null))
            { 
                foreach(var contact in user.ContactInformations)
                {
                    if(contact.ContactType.Id == 1)
                    {
                        userVm.Emails.Add(_mapper.Map<ContactInformationForListVm>(contact.ContactInformationDetail));
                    }
                    else if(contact.ContactType.Id == 2)
                    {
                        userVm.PhoneNumbers.Add(_mapper.Map<ContactInformationForListVm>(contact.ContactInformationDetail));
                    }
                }
            }
            return userVm;
        }

        public void UpdateUser(NewUserVm model)
        {
            var user = _mapper.Map<User>(model);
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<UserTypeVm> GetAllUserTypes()
        {
            var types = _userRepository.GetAllTypes().ProjectTo<UserTypeVm>(_mapper.ConfigurationProvider).ToList();
            return types;

        }

        public AddressEditVm GetUserAddress(int id)
        {
            var address = _userRepository.GetAddress(id);
            if (address is null)
            {
                return new AddressEditVm();
            }
            else
            {
                var addressVm = _mapper.Map<AddressEditVm>(address);
                return addressVm;
            }
        }

        public void UpdateUserAddress(AddressEditVm model)
        {
            var address = _mapper.Map<Address>(model);
            _userRepository.AddOrUpdateAddress(address);
        }
    }
}
