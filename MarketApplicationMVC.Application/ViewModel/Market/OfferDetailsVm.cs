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
        public string SellerName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Offer, OfferDetailsVm>()
                .ForMember(d => d.OfferCategory, opt => opt.MapFrom(s => s.OfferCategory.Name));
                
        }
    }



}
