using AutoMapper;
using FluentAssertions;
using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.Mapping;
using MarketApplicationMVC.Application.ViewModel.Market;
using MarketApplicationMVC.Domain.Interface;
using MarketApplicationMVC.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MarketApplicationMVC.Tests.Services.MarketService
{

    public class MappingFixture : IDisposable
    {
        public IMapper _mapper;
        public MappingFixture()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();

        }

        public void Dispose()
        {

        }
    }

    public class MarketServiceTests : MappingFixture
    {

        [Fact]
        public void CanViewAllActiveOffersForList()
        {
            var _marketRepositoryMock = new Mock<IMarketRepository>();        
            _marketRepositoryMock.Setup(r => r.GetAllOffers()).Returns(
                new List<Offer>() 
                { 
                    new Offer() {Id = 1, Name = "Name", IsActive = true},
                    new Offer() {Id = 2, Name = "qwerty", IsActive = true},
                    new Offer() {Id = 3, Name = "Nameqwe", IsActive = true},
                    new Offer() {Id = 4, Name = "Name1", IsActive = true},
                    new Offer() {Id = 5, Name = "Namqwee2", IsActive = false},
                    new Offer() {Id = 6, Name = "Name3", IsActive = true},
                    new Offer() {Id = 7, Name = "Name4qwe", IsActive = true},
                    new Offer() {Id = 8, Name = "Name5", IsActive = true},
                    new Offer() {Id = 9, Name = "qwert", IsActive = true},
                    new Offer() {Id = 10, Name = "Name7", IsActive = true}

                }.AsQueryable());
            var _marketService = new MarketApplicationMVC.Application.Services.MarketService(marketRepository: _marketRepositoryMock.Object, mapper: _mapper, userManager: null);

            var offersList = _marketService.ViewAllActiveOffersForList("qwe", 1, 2);

            offersList.Offers.FirstOrDefault().Id.Should().Be(2);
            offersList.Offers.FirstOrDefault().Name.Should().Be("qwerty");
            offersList.Count.Should().Be(4);
        }

    }
}
