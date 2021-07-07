using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Market
{
    public class OfferForApiVm : IMapFrom<Offer>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } // rozwiązać problem z przecinkiem
        public string OfferCategoryId { get; set; }
        public string UserId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<string, int?>()
                .ConvertUsing(new StringToInt());

            profile.CreateMap<int?, string>()
                .ConvertUsing(new IntToString());

            profile.CreateMap<Offer, OfferForApiVm>()
                .ForMember(d => d.OfferCategoryId, opt => opt.MapFrom(s => s.OfferCategoryId));


            profile.CreateMap<OfferForApiVm, Offer>()
                .ForMember(d => d.OfferCategoryId, opt => opt.MapFrom(s => s.OfferCategoryId));

        }

    }

}
