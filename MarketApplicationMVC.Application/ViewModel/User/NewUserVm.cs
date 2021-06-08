using AutoMapper;
using FluentValidation;
using MarketApplicationMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.User
{
    public class NewUserVm : IMapFrom<MarketApplicationMVC.Domain.Model.User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<string, int?>()
                .ConvertUsing(new StringToInt());

            profile.CreateMap<int?, string>()
                .ConvertUsing(new IntToString());

            profile.CreateMap<NewUserVm, MarketApplicationMVC.Domain.Model.User>()
                .ForMember(p => p.TypeId, opt => opt.MapFrom(b => b.TypeId));

            profile.CreateMap<MarketApplicationMVC.Domain.Model.User, NewUserVm>()
                .ForMember(p => p.TypeId, opt => opt.MapFrom(b => b.TypeId));
                
        }
    }

    public class NewUserValidator : AbstractValidator<NewUserVm>
    {
        public NewUserValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Za długi ciąg znaków.");
            RuleFor(x => x.TypeId).NotNull().WithMessage("Należy wybrać opcję.");
        }
    }

    public class StringToInt : ITypeConverter<string, int?>
    {
        public int? Convert(string source, int? destination, ResolutionContext context)
        {
            if(source is null)
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
}
