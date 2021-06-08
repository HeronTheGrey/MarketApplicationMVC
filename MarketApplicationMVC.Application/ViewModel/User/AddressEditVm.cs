using AutoMapper;
using FluentValidation;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.User
{
    public class AddressEditVm : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
        public int UserRef { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressEditVm>();

            profile.CreateMap<AddressEditVm, Address>();
        }
        
    }

    public class NewAddressValidator : AbstractValidator<AddressEditVm>
    {
        public NewAddressValidator()
        {
            RuleFor(x => x.Country).MaximumLength(40);
            RuleFor(x => x.City).MaximumLength(40);
            RuleFor(x => x.Street).MaximumLength(40);
        }
    }
}
