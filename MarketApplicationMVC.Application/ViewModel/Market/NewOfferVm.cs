using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Market
{
    public class NewOfferVm : IMapFrom<Offer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string OfferCategory { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Offer, OfferDetailsVm>()
                .ForMember(s => s.OfferCategory, opt => opt.MapFrom(d => d.OfferCategory.Name));
        }
    }
}
