using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Market
{
    public class OfferDetailsVm : IMapFrom<Offer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } // rozwiązać problem z przecinkiem
        public string OfferCategory { get; set; }
        public int SellerName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Offer, OfferDetailsVm>()
                .ForMember(s => s.OfferCategory, opt => opt.MapFrom(d => d.OfferCategory.Name))
                .ForMember(s => s.SellerName, opt => opt.MapFrom(d => d.User.Name));
        }
    }
}
