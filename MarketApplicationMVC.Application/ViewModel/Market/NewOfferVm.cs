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
    public class NewOfferVm : IMapFrom<Offer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } //rozwiązać problem z przecinkiem
        public string OfferCategoryId { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<string, int?>()
                .ConvertUsing(new StringToInt());

            profile.CreateMap<int?, string>()
                .ConvertUsing(new IntToString());

            profile.CreateMap<Offer, NewOfferVm>()
                .ForMember(d => d.OfferCategoryId, opt => opt.MapFrom(s => s.OfferCategoryId))
                .ForMember(d => d.Picture, opt => opt.Ignore());

            profile.CreateMap<NewOfferVm, Offer>()
                .ForMember(d => d.OfferCategoryId, opt => opt.MapFrom(s => s.OfferCategoryId))
                .ForMember(d => d.Picture, opt => opt.Ignore());
        }
    }

    public class StringToInt : ITypeConverter<string, int?>
    {
        public int? Convert(string source, int? destination, ResolutionContext context)
        {
            if (source is null)
            {
                return null;
            }
            int intValue;
            int.TryParse(source, out intValue);
            return intValue;
        }
    }

    public class IntToString : ITypeConverter<int?, string>
    {
        public string Convert(int? source, string destination, ResolutionContext context)
        {
            if (source is null)
            {
                return null;
            }

            return source.ToString();
        }
    }

    public class NewOfferValidator : AbstractValidator<NewOfferVm>
    {
        public NewOfferValidator()
        {
            RuleFor(x => x.OfferCategoryId).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.Picture).NotNull();
            RuleFor(x => x.Picture).SetValidator(new FileValidator());

        }
    }

    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(1)
                .WithMessage("File size is larger than allowed");
            RuleFor(x => x.Length).NotNull().GreaterThan(1)
                .WithMessage("File size is larger than allowed");

            RuleFor(x => x.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("File type is larger than allowed");

        }
    }

}
