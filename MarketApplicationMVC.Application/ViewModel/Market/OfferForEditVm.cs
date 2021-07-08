using AutoMapper;
using FluentValidation;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.Market
{
    public class OfferForEditVm : IMapFrom<Offer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } // rozwiązać problem z przecinkiem
        public int OfferCategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Offer, OfferForEditVm>()
                .ForMember(s => s.Picture, opt => opt.Ignore());

            profile.CreateMap<OfferForEditVm, Offer>()
                .ForMember(s => s.Picture, opt => opt.Ignore());
        }
    }

    public class OfferForEditValidator : AbstractValidator<OfferForEditVm>
    {
        public OfferForEditValidator()
        {
            RuleFor(x => x.OfferCategoryId).NotNull();
            RuleFor(x => x.Name).NotNull().MaximumLength(50);
            RuleFor(x => x.Description).NotNull().MaximumLength(1000);
            RuleFor(x => x.Price).NotNull();

        }
    }

}
