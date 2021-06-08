using AutoMapper;
using MarketApplicationMVC.Application.Interfaces;
using MarketApplicationMVC.Application.ViewModel.Market;
using MarketApplicationMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace MarketApplicationMVC.Application.Services
{
    class MarketService : IMarketService
    {
        private readonly IMarketRepository _marketRepository;
        private readonly IMapper _mapper;

        public MarketService(IMarketRepository marketRepository, IMapper mapper)
        {
            _marketRepository = marketRepository;
            _mapper = mapper;
        }
        public int AddOffer(NewOfferVm newOffer)
        {
            throw new NotImplementedException();
        }

        public ListOfferForListVm ViewAllActiveOffers()
        {
            var offers = _marketRepository.GetAllOffers().Where(p => p.IsActive == true).ProjectTo<OfferForListVm>(_mapper.ConfigurationProvider).ToList();
            var offersList = new ListOfferForListVm
            {
                Offers = offers,
                Count = offers.Count
            };
            return offersList;
        }

        public OfferDetailsVm ViewOfferDetails(int offerId)
        {
            var offer = _marketRepository.GetOfferById(offerId);
            var offerVm = _mapper.Map<OfferDetailsVm>(offer);
            return offerVm;
        }
    }
}
