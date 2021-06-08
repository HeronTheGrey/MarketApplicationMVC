using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.User
{
    public class UserDetailsVm : IMapFrom<MarketApplicationMVC.Domain.Model.User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDetailVm Address { get; set; }
        public string Type { get; set; }
        public int CountOfThreads { get; set; }
        public int CountOfPosts { get; set; }
        public int CountOfOffers { get; set; }
        public List<ContactInformationForListVm> Emails { get; set; }
        public List<ContactInformationForListVm> PhoneNumbers { get; set; }

        public void Mapping(Profile profile)
        {


            profile.CreateMap<MarketApplicationMVC.Domain.Model.User, UserDetailsVm>()
                .ForMember(s => s.Type, opt => opt.MapFrom(d => d.Type.Name))
                .ForMember(s => s.Address, opt => opt.MapFrom(d => d.Address))
                .ForMember(s => s.Emails, opt => opt.Ignore())
                .ForMember(s => s.CountOfOffers, opt => opt.MapFrom(d => d.Offers.Count))
                .ForMember(s => s.CountOfPosts, opt => opt.MapFrom(d => d.ForumPosts.Count))
                .ForMember(s => s.CountOfThreads, opt => opt.MapFrom(d => d.ForumThreads.Count))
                .ForMember(s => s.PhoneNumbers, opt => opt.Ignore());
        }

    }

}
