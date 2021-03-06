using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Market
{
    public class OfferCategoryVm : IMapFrom<OfferCategory>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OfferCategory, OfferCategoryVm>();
            profile.CreateMap<OfferCategoryVm, OfferCategory>();
        }
    }
}
