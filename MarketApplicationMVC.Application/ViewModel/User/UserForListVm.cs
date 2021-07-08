using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.User
{
    public class UserForListVm : IMapFrom<IdentityUser>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityUser, UserForListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.UserType, opt => opt.Ignore());

        }


    }
}
