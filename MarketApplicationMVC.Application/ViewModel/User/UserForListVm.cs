using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.User
{
    public class UserForListVm : IMapFrom<MarketApplicationMVC.Domain.Model.User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MarketApplicationMVC.Domain.Model.User, UserForListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.UserType, opt => opt.MapFrom(s => s.Type.Name));
                ;
        }

        
    }
}
