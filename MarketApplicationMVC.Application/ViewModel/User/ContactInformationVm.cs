using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.User
{
    public class ContactInformationVm : IMapFrom<ContactInformation>
    {
        public int Id { get; set; }
        public string ContactInformationDetail { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContactInformation, ContactInformationVm>();
        }
        
    }
}
