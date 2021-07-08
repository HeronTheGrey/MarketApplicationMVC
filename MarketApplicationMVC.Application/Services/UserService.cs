using AutoMapper;
using AutoMapper.QueryableExtensions;
using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.ViewModel.User;
using MarketApplicationMVC.Domain.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Application.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ListUserForListVm> GetListOfAllUsers(string searchPhrase, int currentPage, int pageSize)
        {
            var users = _userRepository.GetAllUsers()
                .Where(p => p.UserName.Contains(searchPhrase))
                .ProjectTo<UserForListVm>(_mapper.ConfigurationProvider)
                .ToList();

            foreach(var user in users)
            {
                var _user = await _userManager.FindByIdAsync(user.Id);
                var rolesList = await _userManager.GetRolesAsync(_user);
                user.UserType = String.Join(", ", rolesList);
            }

            var usersToShow = users.Skip((pageSize * (currentPage - 1))).Take(pageSize).ToList();
            var usersList = new ListUserForListVm()
            {
                PageSize = pageSize,
                CurrentPage = currentPage,
                SearchPhrase = searchPhrase,
                Users = usersToShow,
                Count = users.Count
            };
            return usersList;
        }
    }
}
