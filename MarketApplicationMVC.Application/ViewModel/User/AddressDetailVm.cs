using AutoMapper;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Application.ViewModel.User
{
    public class AddressDetailVm : IMapFrom<Address>
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressDetailVm>();
        }
    }
}
