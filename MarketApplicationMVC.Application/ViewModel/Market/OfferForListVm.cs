using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Market
{
    public class OfferForListVm : IMapFrom<Offer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } //rozwiązać problem z przecinkiem
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Offer, OfferForListVm>();

        }
    }
}
