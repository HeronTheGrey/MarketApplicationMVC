using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.User
{
    public class UserTypeVm : IMapFrom<MarketApplicationMVC.Domain.Model.Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MarketApplicationMVC.Domain.Model.Type, UserTypeVm>();
        }
    }

    
}
